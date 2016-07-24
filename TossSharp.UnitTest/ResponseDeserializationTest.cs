using Moq;
using Moq.Protected;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace TossSharp.UnitTest {
    public sealed class ResponseDeserializationTest {
        private TossClient BuildMockupClient(
            HttpResponseMessage message) {
            Mock<HttpMessageHandler> handler = new Mock<HttpMessageHandler>();
            handler
                .Protected()
                .Setup<Task<HttpResponseMessage>>("SendAsync", ItExpr.IsAny<HttpRequestMessage>(), ItExpr.IsAny<CancellationToken>())
                .Returns(Task<HttpResponseMessage>.Factory.StartNew(() => {
                    return message;
                }));

            Lazy<HttpClient> customFactory = new Lazy<HttpClient>(
                () => new HttpClient(handler.Object) { BaseAddress = new Uri("http://localhost/") },
                true);

            TossClient client = new TossClient(customFactory);
            return client;
        }

        [Fact]
        public async Task CreatePaymentResponse_Deserialization_Test() {
            // arrange
            TossClient client = this.BuildMockupClient(new HttpResponseMessage(HttpStatusCode.OK) {
                Content = new StringContent(@"{""code"":0,""checkoutPage"":""https://toss.im/tosspay/order/orderWait?payToken=test_token1234567890a&retUrl=http://YOUR-SITE.COM"",""payToken"":""test_token1234567890a""}", Encoding.UTF8, "application/json")
            });

            // act
            PaymentCreationResponse response = await client.CreatePaymentAsync(new PaymentCreationRequest() {
                ApiKey = "api_key",
                OrderNo = "order_no",
                Amount = 15000,
                ProductDescription = "desc"
            }).ConfigureAwait(false);

            // assert
            Assert.NotNull(response);
            Assert.Equal(TossResultCode.Success, response.Code);
            Assert.Equal("https://toss.im/tosspay/order/orderWait?payToken=test_token1234567890a&retUrl=http://YOUR-SITE.COM", response.CheckoutPage);
            Assert.Equal("test_token1234567890a", response.PayToken);
            Assert.Null(response.Message);
        }

        [Fact]
        public async Task ExecutePaymentResponse_Deserialization_Test() {
            // arrange
            TossClient client = this.BuildMockupClient(new HttpResponseMessage(HttpStatusCode.OK) {
                Content = new StringContent(@"{""code"":0}", Encoding.UTF8, "application/json")
            });

            // act
            PaymentExecutionResponse response = await client.ExecutePaymentAsync(new PaymentExecutionRequest() {
                ApiKey = "api_key",
                PayToken = "pay_token"
            });

            // assert
            Assert.NotNull(response);
            Assert.Equal(TossResultCode.Success, response.Code);
        }

        [Fact]
        public async Task CancelPaymentResponse_Deserialization_Test() {
            // arrange
            TossClient client = this.BuildMockupClient(new HttpResponseMessage(HttpStatusCode.OK) {
                Content = new StringContent(@"{""code"":0}", Encoding.UTF8, "application/json")
            });

            // act
            PaymentCancellationResponse response = await client.CancelPaymentAsync(new PaymentCancellationRequest() {
                ApiKey = "api_key",
                PayToken = "pay_token",
                Reason = "reason"
            }).ConfigureAwait(false);

            // assert
            Assert.NotNull(response);
            Assert.Equal(TossResultCode.Success, response.Code);
        }

        [Fact]
        public async Task RefundPaymentResponse_Deserialization_Test() {
            // arrange
            TossClient client = this.BuildMockupClient(new HttpResponseMessage(HttpStatusCode.OK) {
                Content = new StringContent(@"{""code"":0,""refundNo"":""cc92a9ef-8a81-2938-dda9-ff8a78ae29b8""}", Encoding.UTF8, "application/json")
            });

            // act
            PaymentRefundResponse response = await client.RefundPaymentAsync(new PaymentRefundRequest() {
                ApiKey = "api_key",
                PayToken = "pay_token"
            }).ConfigureAwait(false);

            // assert
            Assert.NotNull(response);
            Assert.Equal(TossResultCode.Success, response.Code);
            Assert.Equal("cc92a9ef-8a81-2938-dda9-ff8a78ae29b8", response.RefundNo);
        }

        [Fact]
        public async Task PaymentStatusResponse_Deserialization_Test() {
            // arrange
            TossClient client = this.BuildMockupClient(new HttpResponseMessage(HttpStatusCode.OK) {
                Content = new StringContent(@"{
    ""payToken"": ""test_token1234567890a"",
    ""payStatus"": ""REFUND_SUCCESS"",
    ""orderNo"": ""2015072012211"",
    ""hasOwner"": true,
    ""availableActions"": [
        ""REFUND""
    ],
    ""refunds"": [
        {
            ""refundNo"": ""7161b8e3-4b79-49d7-ab3c-3ae898aa073b"",
            ""status"": ""SUCCESS"",
            ""amount"": 100,
            ""reason"": ""일부 상품 환불""
        },
        {
            ""refundNo"": ""a636fe94-4e1e-41c8-90d9-b17180bdaf04"",
            ""status"": ""SUCCESS"",
            ""amount"": 200,
            ""reason"": ""일부 상품 환불""
        },
        {
            ""refundNo"": ""cc92a9ef-8a81-2938-dda9-ff8a78ae29b8"",
            ""status"": ""SUCCESS"",
            ""amount"": 500,
            ""reason"": ""일부 상품 환불""
        }
    ],
    ""code"": 0
}", Encoding.UTF8, "application/json")
            });

            // act
            PaymentStatusResponse response = await client.RequestPaymentStatusAsync(new PaymentStatusRequest() {
                ApiKey = "api_key",
                OrderNo = "1234"
            }).ConfigureAwait(false);

            // assert
            Assert.NotNull(response);
            Assert.Equal("test_token1234567890a", response.PayToken);
            Assert.Equal(PaymentStatus.RefundSuccess, response.PayStatus);
            Assert.Equal("2015072012211", response.OrderNo);
            Assert.True(response.HasOwner);

            Assert.NotNull(response.AvailableActions);
            Assert.NotEmpty(response.AvailableActions);
            Assert.True(response.IsRefundAvailable());
            Assert.False(response.IsCancelAvailable());
            Assert.False(response.IsEscrowAvailable());

            Assert.NotNull(response.Refunds);
            Assert.NotEmpty(response.Refunds);
            Assert.Equal(3, response.Refunds.Count());

            RefundDetailResponse firstElement = response.Refunds.ElementAtOrDefault(0);
            Assert.NotNull(firstElement);
            Assert.Equal("7161b8e3-4b79-49d7-ab3c-3ae898aa073b", firstElement.RefundNo);
            Assert.Equal("SUCCESS", firstElement.Status);
            Assert.Equal(100, firstElement.Amount);
            Assert.Equal("일부 상품 환불", firstElement.Reason);

            RefundDetailResponse secondElement = response.Refunds.ElementAtOrDefault(1);
            Assert.NotNull(secondElement);
            Assert.Equal("a636fe94-4e1e-41c8-90d9-b17180bdaf04", secondElement.RefundNo);
            Assert.Equal("SUCCESS", secondElement.Status);
            Assert.Equal(200, secondElement.Amount);
            Assert.Equal("일부 상품 환불", secondElement.Reason);

            RefundDetailResponse thirdElement = response.Refunds.ElementAtOrDefault(2);
            Assert.NotNull(thirdElement);
            Assert.Equal("cc92a9ef-8a81-2938-dda9-ff8a78ae29b8", thirdElement.RefundNo);
            Assert.Equal("SUCCESS", thirdElement.Status);
            Assert.Equal(500, thirdElement.Amount);
            Assert.Equal("일부 상품 환불", thirdElement.Reason);
        }

        [Fact]
        public async Task PaymentStatusDetailResponse_Deserialization_Test() {
            // arrange
            TossClient client = this.BuildMockupClient(new HttpResponseMessage(HttpStatusCode.OK) {
                Content = new StringContent(@"{
    ""code"": 0,
    ""refund"": {
        ""refundNo"": ""7161b8e3-4b79-49d7-ab3c-3ae898aa073b"",
        ""status"": ""SUCCESS"",
        ""amount"": 100,
        ""reason"": ""부분 환불 테스트""
    }
}", Encoding.UTF8, "application/json")
            });

            // act
            RefundStatusResponse response = await client.RequestPaymentRefundStatusAsync("Test", new RefundStatusRequest() {
                ApiKey = "api_key"
            }).ConfigureAwait(false);

            // assert
            Assert.NotNull(response);
            Assert.Equal(TossResultCode.Success, response.Code);

            Assert.NotNull(response.Refund);
            Assert.Equal("7161b8e3-4b79-49d7-ab3c-3ae898aa073b", response.Refund.RefundNo);
            Assert.Equal("SUCCESS", response.Refund.Status);
            Assert.Equal(100, response.Refund.Amount);
            Assert.Equal("부분 환불 테스트", response.Refund.Reason);
        }

        [Fact]
        public async Task EscrowPaymentResponse_Deserialization_Test() {
            // arrange
            TossClient client = this.BuildMockupClient(new HttpResponseMessage(HttpStatusCode.OK) {
                Content = new StringContent(@"{""code"":0}", Encoding.UTF8, "application/json")
            });

            // act
            EscrowPaymentResponse response = await client.ExecuteEscrowPaymentAsync(new EscrowPaymentRequest() {
                ApiKey = "api_key",
                PayToken = "pay_token"
            }).ConfigureAwait(false);

            // assert
            Assert.NotNull(response);
            Assert.Equal(TossResultCode.Success, response.Code);
        }
    }
}
