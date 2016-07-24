using Moq;
using Moq.Protected;
using System;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace TossSharp.UnitTest {
    public sealed class RequestSerializationTest {
        private TossClient BuildMockupClient(
            Action<HttpRequestMessage, CancellationToken> callback) {
            Mock<HttpMessageHandler> handler = new Mock<HttpMessageHandler>();
            handler
                .Protected()
                .Setup<Task<HttpResponseMessage>>("SendAsync", ItExpr.IsAny<HttpRequestMessage>(), ItExpr.IsAny<CancellationToken>())
                .Returns(Task<HttpResponseMessage>.Factory.StartNew(() => {
                    return new HttpResponseMessage(HttpStatusCode.OK) {
                        Content = new StringContent(String.Empty, Encoding.UTF8, "application/json")
                    };
                }))
                .Callback(callback);

            Lazy<HttpClient> customFactory = new Lazy<HttpClient>(
                () => new HttpClient(handler.Object) { BaseAddress = new Uri("http://localhost/") },
                true);

            TossClient client = new TossClient(customFactory);
            return client;
        }

        [Fact]
        public async Task CreatePaymentRequest_Serialization_Test() {
            // arrange
            TaskCompletionSource<string> rawMessageTask = new TaskCompletionSource<string>();
            TossClient client = this.BuildMockupClient(async (req, cancelToken) => {
                rawMessageTask.SetResult(await req.Content.ReadAsStringAsync().ConfigureAwait(false));
            });

            // act
            await client.CreatePaymentAsync(new PaymentCreationRequest() {
                ApiKey = "1234",
                OrderNo = "90AB",
                Amount = 15000,
                ProductDescription = "5678"
            }).ConfigureAwait(false);
            string rawContent = await rawMessageTask.Task.ConfigureAwait(false);

            // assert
            Assert.NotNull(rawContent);
            Assert.NotEmpty(rawContent);

            Assert.Contains("\"apiKey\":", rawContent, StringComparison.Ordinal);
            Assert.Contains("\"1234\"", rawContent, StringComparison.Ordinal);
            Assert.Contains("\"orderNo\":", rawContent, StringComparison.Ordinal);
            Assert.Contains("\"90AB\"", rawContent, StringComparison.Ordinal);
            Assert.Contains("\"amount\":", rawContent, StringComparison.Ordinal);
            Assert.Contains("15000", rawContent, StringComparison.Ordinal);
            Assert.Contains("\"productDesc\":", rawContent, StringComparison.Ordinal);

            Assert.DoesNotContain("\"amountTaxable\":", rawContent, StringComparison.Ordinal);
            Assert.DoesNotContain("\"amountTaxFree\":", rawContent, StringComparison.Ordinal);
            Assert.DoesNotContain("\"amountVat\":", rawContent, StringComparison.Ordinal);
            Assert.DoesNotContain("\"amountServiceFee\":", rawContent, StringComparison.Ordinal);
            Assert.DoesNotContain("\"retUrl\":", rawContent, StringComparison.Ordinal);
            Assert.DoesNotContain("\"expiredTime\":", rawContent, StringComparison.Ordinal);
            Assert.DoesNotContain("\"resultCallback\":", rawContent, StringComparison.Ordinal);
            Assert.DoesNotContain("\"escrow\":", rawContent, StringComparison.Ordinal);
            Assert.DoesNotContain("\"cashReceipt\":", rawContent, StringComparison.Ordinal);
            Assert.DoesNotContain("\"autoExecute\":", rawContent, StringComparison.Ordinal);
            Assert.DoesNotContain("\"arsAuthSkippable\":", rawContent, StringComparison.Ordinal);
            Assert.DoesNotContain("\"userPhone\":", rawContent, StringComparison.Ordinal);
            Assert.DoesNotContain("\"metadata\":", rawContent, StringComparison.Ordinal);
        }

        [Fact]
        public async Task ExecutePaymentRequest_Serialization_Test() {
            // arrange
            TaskCompletionSource<string> rawMessageTask = new TaskCompletionSource<string>();
            TossClient client = this.BuildMockupClient(async (req, cancelToken) => {
                rawMessageTask.SetResult(await req.Content.ReadAsStringAsync().ConfigureAwait(false));
            });

            // act
            await client.ExecutePaymentAsync(new PaymentExecutionRequest() {
                ApiKey = "1234",
                PayToken = "5678"
            }).ConfigureAwait(false);
            string rawContent = await rawMessageTask.Task.ConfigureAwait(false);

            // assert
            Assert.NotNull(rawContent);
            Assert.NotEmpty(rawContent);

            Assert.Contains("\"apiKey\":", rawContent, StringComparison.Ordinal);
            Assert.Contains("\"1234\"", rawContent, StringComparison.Ordinal);
            Assert.Contains("\"payToken\":", rawContent, StringComparison.Ordinal);
            Assert.Contains("\"5678\"", rawContent, StringComparison.Ordinal);
        }

        [Fact]
        public async Task CancelPaymentRequest_Serialization_Test() {
            // arrange
            TaskCompletionSource<string> rawMessageTask = new TaskCompletionSource<string>();
            TossClient client = this.BuildMockupClient(async (req, cancelToken) => {
                rawMessageTask.SetResult(await req.Content.ReadAsStringAsync().ConfigureAwait(false));
            });

            // act
            await client.CancelPaymentAsync(new PaymentCancellationRequest() {
                ApiKey = "1234",
                PayToken = "5678",
                Reason = "90AB"
            }).ConfigureAwait(false);
            string rawContent = await rawMessageTask.Task.ConfigureAwait(false);

            // assert
            Assert.NotNull(rawContent);
            Assert.NotEmpty(rawContent);

            Assert.Contains("\"apiKey\":", rawContent, StringComparison.Ordinal);
            Assert.Contains("\"1234\"", rawContent, StringComparison.Ordinal);
            Assert.Contains("\"payToken\":", rawContent, StringComparison.Ordinal);
            Assert.Contains("\"5678\"", rawContent, StringComparison.Ordinal);
            Assert.Contains("\"reason\":", rawContent, StringComparison.Ordinal);
            Assert.Contains("\"90AB\"", rawContent, StringComparison.Ordinal);
        }

        [Fact]
        public async Task RefundPaymentRequest_Serialization_Test() {
            // arrange
            TaskCompletionSource<string> rawMessageTask = new TaskCompletionSource<string>();
            TossClient client = this.BuildMockupClient(async (req, cancelToken) => {
                rawMessageTask.SetResult(await req.Content.ReadAsStringAsync().ConfigureAwait(false));
            });

            // act
            await client.RefundPaymentAsync(new PaymentRefundRequest() {
                ApiKey = "1234",
                PayToken = "5678"
            }).ConfigureAwait(false);
            string rawContent = await rawMessageTask.Task.ConfigureAwait(false);

            // assert
            Assert.NotNull(rawContent);
            Assert.NotEmpty(rawContent);

            Assert.Contains("\"apiKey\":", rawContent, StringComparison.Ordinal);
            Assert.Contains("\"1234\"", rawContent, StringComparison.Ordinal);
            Assert.Contains("\"payToken\":", rawContent, StringComparison.Ordinal);
            Assert.Contains("\"5678\"", rawContent, StringComparison.Ordinal);

            Assert.DoesNotContain("\"refundNo\":", rawContent, StringComparison.Ordinal);
            Assert.DoesNotContain("\"reason\":", rawContent, StringComparison.Ordinal);
            Assert.DoesNotContain("\"amount\":", rawContent, StringComparison.Ordinal);
            Assert.DoesNotContain("\"amountTaxable\":", rawContent, StringComparison.Ordinal);
            Assert.DoesNotContain("\"amountTaxFree\":", rawContent, StringComparison.Ordinal);
            Assert.DoesNotContain("\"amountVat\":", rawContent, StringComparison.Ordinal);
            Assert.DoesNotContain("\"amountServiceFee\":", rawContent, StringComparison.Ordinal);
        }

        [Fact]
        public async Task PaymentStatusRequest_WithPayToken_Serialization_Test() {
            // arrange
            TaskCompletionSource<string> rawMessageTask = new TaskCompletionSource<string>();
            TossClient client = this.BuildMockupClient(async (req, cancelToken) => {
                rawMessageTask.SetResult(await req.Content.ReadAsStringAsync());
            });

            // act
            await client.RequestPaymentStatusAsync(new PaymentStatusRequest() {
                ApiKey = "1234",
                PayToken = "5678"
            }).ConfigureAwait(false);
            string rawContent = await rawMessageTask.Task.ConfigureAwait(false);

            // assert
            Assert.NotNull(rawContent);
            Assert.NotEmpty(rawContent);

            Assert.Contains("\"apiKey\":", rawContent, StringComparison.Ordinal);
            Assert.Contains("\"1234\"", rawContent, StringComparison.Ordinal);
            Assert.Contains("\"payToken\":", rawContent, StringComparison.Ordinal);
            Assert.Contains("\"5678\"", rawContent, StringComparison.Ordinal);

            Assert.DoesNotContain("\"orderNo\":", rawContent, StringComparison.Ordinal);
        }

        [Fact]
        public async Task PaymentStatusRequest_WithOrderNo_Serialization_Test() {
            // arrange
            TaskCompletionSource<string> rawMessageTask = new TaskCompletionSource<string>();
            TossClient client = this.BuildMockupClient(async (req, cancelToken) => {
                rawMessageTask.SetResult(await req.Content.ReadAsStringAsync());
            });

            // act
            await client.RequestPaymentStatusAsync(new PaymentStatusRequest() {
                ApiKey = "1234",
                OrderNo = "5678"
            }).ConfigureAwait(false);
            string rawContent = await rawMessageTask.Task.ConfigureAwait(false);

            // assert
            Assert.NotNull(rawContent);
            Assert.NotEmpty(rawContent);

            Assert.Contains("\"apiKey\":", rawContent, StringComparison.Ordinal);
            Assert.Contains("\"1234\"", rawContent, StringComparison.Ordinal);
            Assert.Contains("\"orderNo\":", rawContent, StringComparison.Ordinal);
            Assert.Contains("\"5678\"", rawContent, StringComparison.Ordinal);

            Assert.DoesNotContain("\"payToken\":", rawContent, StringComparison.Ordinal);
        }

        [Fact]
        public async Task RefundStatusRequest_Serialization_Test() {
            // arrange
            TaskCompletionSource<Uri> rawUriTask = new TaskCompletionSource<Uri>();
            TaskCompletionSource<string> rawMessageTask = new TaskCompletionSource<string>();
            TossClient client = this.BuildMockupClient(async (req, cancelToken) => {
                rawUriTask.SetResult(req.RequestUri);
                rawMessageTask.SetResult(await req.Content.ReadAsStringAsync());
            });

            // act
            await client.RequestPaymentRefundStatusAsync("order_no_1234", new RefundStatusRequest() {
                ApiKey = "5678"
            });
            Uri rawRequestUri = await rawUriTask.Task.ConfigureAwait(false);
            string rawContent = await rawMessageTask.Task.ConfigureAwait(false);

            // assert
            Assert.NotNull(rawRequestUri);
            Assert.NotNull(rawContent);
            Assert.NotEmpty(rawContent);

            Assert.Contains("order_no_1234", rawRequestUri.PathAndQuery, StringComparison.Ordinal);
            Assert.Contains("\"apiKey\":", rawContent, StringComparison.Ordinal);
            Assert.Contains("\"5678\"", rawContent, StringComparison.Ordinal);
        }

        [Fact]
        public async Task EscrowPaymentRequest_Serialization_Test() {
            // arrange
            TaskCompletionSource<string> rawMessageTask = new TaskCompletionSource<string>();
            TossClient client = this.BuildMockupClient(async (req, cancelToken) => {
                rawMessageTask.SetResult(await req.Content.ReadAsStringAsync().ConfigureAwait(false));
            });

            // act
            await client.ExecuteEscrowPaymentAsync(new EscrowPaymentRequest() {
                ApiKey = "1234",
                PayToken = "5678"
            }).ConfigureAwait(false);
            string rawContent = await rawMessageTask.Task.ConfigureAwait(false);

            // assert
            Assert.NotNull(rawContent);
            Assert.NotEmpty(rawContent);

            Assert.Contains("\"apiKey\":", rawContent, StringComparison.Ordinal);
            Assert.Contains("\"1234\"", rawContent, StringComparison.Ordinal);
            Assert.Contains("\"payToken\":", rawContent, StringComparison.Ordinal);
            Assert.Contains("\"5678\"", rawContent, StringComparison.Ordinal);
        }
    }
}
