using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TossSharp
{
    /// <summary>
    /// 토스 결제 API를 호출할 수 있는 클라이언트 클래스입니다.
    /// </summary>
    /// <remarks>
    /// 전체 API 레퍼런스는 http://tossdev.github.io/api.html 문서를 참조하여 주십시오.
    /// </remarks>
    public class TossClient {
        /// <summary>
        /// 토스 결제 API를 호출할 기본 대상 URL입니다.
        /// </summary>
        public static readonly Uri DefaultBaseAddress =
            new Uri("https://toss.im/tosspay/api/v1/", UriKind.Absolute);

        /// <summary>
        /// <see cref="TossClient"/> 클래스의 인스턴스를 새롭게 생성합니다.
        /// </summary>
        /// <param name="httpClientFactory">HTTP 클라이언트 생성을 위한 팩토리 인스턴스입니다. 생략할 경우 기본 팩토리 생성 정책을 대신 사용합니다.</param>
        /// <param name="baseAddress">HTTP 요청 발송 시 사용할 기반 주소입니다. 생략할 경우 기본값을 대신 사용합니다.</param>
        public TossClient(Lazy<HttpClient> httpClientFactory = null, Uri baseAddress = null)
            : base() {
            if (httpClientFactory == null) {
                httpClientFactory = new Lazy<HttpClient>(() => {
                    HttpClient client = new HttpClient() {
                        BaseAddress = baseAddress ?? DefaultBaseAddress
                    };
                    return client;
                }, true);
            }

            this.httpClientFactory = httpClientFactory;
        }

        private Lazy<HttpClient> httpClientFactory;

        /// <summary>
        /// 결제 건을 생성합니다.
        /// </summary>
        /// <param name="request">요청에 필요한 매개 변수들을 담은 개체입니다.</param>
        /// <param name="completionOption">응답 수신 완료의 기준을 정합니다.</param>
        /// <param name="cancellationToken">작업 중 취소 신호를 받을 토큰입니다.</param>
        /// <returns>
        /// 서비스로부터 반환된 응답 내용을 담은 개체가 반환됩니다.
        /// </returns>
        /// <remarks>
        /// 결제 생성 완료 후, 구매자의 승인을 얻어 완료처리하는 방법은 아래 문서를 참고하세요.
        /// http://tossdev.github.io/gettingstarted.html#overview-3
        /// </remarks>
        public async Task<PaymentCreationResponse> CreatePaymentAsync(
            PaymentCreationRequest request,
            HttpCompletionOption completionOption = default(HttpCompletionOption),
            CancellationToken cancellationToken = default(CancellationToken)) {

            HttpClient client = this.httpClientFactory.Value;
            HttpRequestMessage reqMessage = new HttpRequestMessage(HttpMethod.Post, "payments");
            reqMessage.Content = new StringContent(JsonConvert.SerializeObject(request, Formatting.Indented), Encoding.UTF8, "application/json");
            HttpResponseMessage respMessage = await client.SendAsync(
                reqMessage, completionOption, cancellationToken).ConfigureAwait(false);
            respMessage.EnsureSuccessStatusCode();
            string respContent = await respMessage.Content.ReadAsStringAsync().ConfigureAwait(false);
            return JsonConvert.DeserializeObject<PaymentCreationResponse>(respContent);
        }

        /// <summary>
        /// 구매자 인증 완료 상태(PAY_APPROVED)의 결제 건을 최종 승인하여 결제를 완료 처리합니다.
        /// </summary>
        /// <param name="request">요청에 필요한 매개 변수들을 담은 개체입니다.</param>
        /// <param name="completionOption">응답 수신 완료의 기준을 정합니다.</param>
        /// <param name="cancellationToken">작업 중 취소 신호를 받을 토큰입니다.</param>
        /// <returns>
        /// 서비스로부터 반환된 응답 내용을 담은 개체가 반환됩니다.
        /// </returns>
        /// <remarks>
        /// 결제 승인에 관한 자세한 내용은 아래 문서를 참고하세요.
        /// http://tossdev.github.io/gettingstarted.html#execute
        /// </remarks>
        public async Task<PaymentExecutionResponse> ExecutePaymentAsync(
            PaymentExecutionRequest request,
            HttpCompletionOption completionOption = default(HttpCompletionOption),
            CancellationToken cancellationToken = default(CancellationToken)) {

            HttpClient client = this.httpClientFactory.Value;
            HttpRequestMessage reqMessage = new HttpRequestMessage(HttpMethod.Post, "execute");
            reqMessage.Content = new StringContent(JsonConvert.SerializeObject(request, Formatting.Indented), Encoding.UTF8, "application/json");
            HttpResponseMessage respMessage = await client.SendAsync(
                reqMessage, completionOption, cancellationToken).ConfigureAwait(false);
            respMessage.EnsureSuccessStatusCode();
            string respContent = await respMessage.Content.ReadAsStringAsync().ConfigureAwait(false);
            return JsonConvert.DeserializeObject<PaymentExecutionResponse>(respContent);
        }

        /// <summary>
        /// 결제 대기 중인 결제 건을 취소합니다.
        /// </summary>
        /// <param name="request">요청에 필요한 매개 변수들을 담은 개체입니다.</param>
        /// <param name="completionOption">응답 수신 완료의 기준을 정합니다.</param>
        /// <param name="cancellationToken">작업 중 취소 신호를 받을 토큰입니다.</param>
        /// <returns>
        /// 서비스로부터 반환된 응답 내용을 담은 개체가 반환됩니다.
        /// </returns>
        /// <remarks>
        /// 결제가 완료되어 구매자의 계좌에서 출금된 상태에서는 취소할 수 없으며 환불 처리해야 합니다. 다음 문서를 참조하십시오.
        /// http://tossdev.github.io/api.html#refunds
        /// </remarks>
        public async Task<PaymentCancellationResponse> CancelPaymentAsync(
            PaymentCancellationRequest request,
            HttpCompletionOption completionOption = default(HttpCompletionOption),
            CancellationToken cancellationToken = default(CancellationToken)) {

            HttpClient client = this.httpClientFactory.Value;
            HttpRequestMessage reqMessage = new HttpRequestMessage(HttpMethod.Post, "cancel");
            reqMessage.Content = new StringContent(JsonConvert.SerializeObject(request, Formatting.Indented), Encoding.UTF8, "application/json");
            HttpResponseMessage respMessage = await client.SendAsync(
                reqMessage, completionOption, cancellationToken).ConfigureAwait(false);
            respMessage.EnsureSuccessStatusCode();
            string respContent = await respMessage.Content.ReadAsStringAsync().ConfigureAwait(false);
            return JsonConvert.DeserializeObject<PaymentCancellationResponse>(respContent);
        }

        /// <summary>
        /// 결제 완료 건의 결제 금액 중 일부 또는 전부를 구매자에게 돌려줍니다.
        /// </summary>
        /// <param name="request">요청에 필요한 매개 변수들을 담은 개체입니다.</param>
        /// <param name="completionOption">응답 수신 완료의 기준을 정합니다.</param>
        /// <param name="cancellationToken">작업 중 취소 신호를 받을 토큰입니다.</param>
        /// <returns>
        /// 서비스로부터 반환된 응답 내용을 담은 개체가 반환됩니다.
        /// </returns>
        public async Task<PaymentRefundResponse> RefundPaymentAsync(
            PaymentRefundRequest request,
            HttpCompletionOption completionOption = default(HttpCompletionOption),
            CancellationToken cancellationToken = default(CancellationToken)) {

            HttpClient client = this.httpClientFactory.Value;
            HttpRequestMessage reqMessage = new HttpRequestMessage(HttpMethod.Post, "refunds");
            reqMessage.Content = new StringContent(JsonConvert.SerializeObject(request, Formatting.Indented), Encoding.UTF8, "application/json");
            HttpResponseMessage respMessage = await client.SendAsync(
                reqMessage, completionOption, cancellationToken).ConfigureAwait(false);
            respMessage.EnsureSuccessStatusCode();
            string respContent = await respMessage.Content.ReadAsStringAsync().ConfigureAwait(false);
            return JsonConvert.DeserializeObject<PaymentRefundResponse>(respContent);
        }

        /// <summary>
        /// 생성된 결제의 현재 상태를 조회합니다.
        /// </summary>
        /// <param name="request">요청에 필요한 매개 변수들을 담은 개체입니다.</param>
        /// <param name="completionOption">응답 수신 완료의 기준을 정합니다.</param>
        /// <param name="cancellationToken">작업 중 취소 신호를 받을 토큰입니다.</param>
        /// <returns>
        /// 서비스로부터 반환된 응답 내용을 담은 개체가 반환됩니다.
        /// </returns>
        public async Task<PaymentStatusResponse> RequestPaymentStatusAsync(
            PaymentStatusRequest request,
            HttpCompletionOption completionOption = default(HttpCompletionOption),
            CancellationToken cancellationToken = default(CancellationToken)) {

            HttpClient client = this.httpClientFactory.Value;
            HttpRequestMessage reqMessage = new HttpRequestMessage(HttpMethod.Post, "status");
            reqMessage.Content = new StringContent(JsonConvert.SerializeObject(request, Formatting.Indented), Encoding.UTF8, "application/json");
            HttpResponseMessage respMessage = await client.SendAsync(
                reqMessage, completionOption, cancellationToken).ConfigureAwait(false);
            respMessage.EnsureSuccessStatusCode();
            string respContent = await respMessage.Content.ReadAsStringAsync().ConfigureAwait(false);
            return JsonConvert.DeserializeObject<PaymentStatusResponse>(respContent);
        }

        /// <summary>
        /// 요청하신 환불 건의 현재 상태를 조회합니다. (요청 건별 조회)
        /// </summary>
        /// <param name="refundNo">환불 번호입니다.</param>
        /// <param name="request">요청에 필요한 매개 변수들을 담은 개체입니다.</param>
        /// <param name="completionOption">응답 수신 완료의 기준을 정합니다.</param>
        /// <param name="cancellationToken">작업 중 취소 신호를 받을 토큰입니다.</param>
        /// <returns>
        /// 서비스로부터 반환된 응답 내용을 담은 개체가 반환됩니다.
        /// </returns>
        public async Task<RefundStatusResponse> RequestPaymentRefundStatusAsync(
            string refundNo, RefundStatusRequest request,
            HttpCompletionOption completionOption = default(HttpCompletionOption),
            CancellationToken cancellationToken = default(CancellationToken)) {

            HttpClient client = this.httpClientFactory.Value;
            HttpRequestMessage reqMessage = new HttpRequestMessage(HttpMethod.Post, $"refunds/{refundNo}");
            reqMessage.Content = new StringContent(JsonConvert.SerializeObject(request, Formatting.Indented), Encoding.UTF8, "application/json");
            HttpResponseMessage respMessage = await client.SendAsync(
                reqMessage, completionOption, cancellationToken).ConfigureAwait(false);
            respMessage.EnsureSuccessStatusCode();
            string respContent = await respMessage.Content.ReadAsStringAsync().ConfigureAwait(false);
            return JsonConvert.DeserializeObject<RefundStatusResponse>(respContent);
        }

        /// <summary>
        /// 에스크로 결제를 진행합니다.
        /// </summary>
        /// <param name="request">요청에 필요한 매개 변수들을 담은 개체입니다.</param>
        /// <param name="completionOption">응답 수신 완료의 기준을 정합니다.</param>
        /// <param name="cancellationToken">작업 중 취소 신호를 받을 토큰입니다.</param>
        /// <returns>
        /// 서비스로부터 반환된 응답 내용을 담은 개체가 반환됩니다.
        /// </returns>
        /// <remarks>
        /// 에스크로 결제를 완료하고 대금을 정산받기 위해서는 '배송 등록'이 필요합니다. 또, 구매자가 대금 지급을 거부하여 결제가 '에스크로 거부' 상태가 된 경우, '구매확정 재요청'을 통해 거부 상태를 해제할 수 있습니다.
        /// 본 API를 통해 '배송 등록'과 '구매확정 재요청'을 처리할 수 있습니다.
        /// - 에스크로 요청 상태에서 호출 시 : '배송 등록' 됨
        /// - 에스크로 거부 상태에서 호출 시 : '구매확정 재요청' 됨
        /// 더 자세한 내용은 '토스 결제 시작하기 &gt; 에스크로 결제 진행' 문서를 참고하세요.
        /// http://tossdev.github.io/gettingstarted.html#escrow
        /// </remarks>
        public async Task<EscrowPaymentResponse> ExecuteEscrowPaymentAsync(
            EscrowPaymentRequest request,
            HttpCompletionOption completionOption = default(HttpCompletionOption),
            CancellationToken cancellationToken = default(CancellationToken)) {

            HttpClient client = this.httpClientFactory.Value;
            HttpRequestMessage reqMessage = new HttpRequestMessage(HttpMethod.Post, "escrow");
            reqMessage.Content = new StringContent(JsonConvert.SerializeObject(request, Formatting.Indented), Encoding.UTF8, "application/json");
            HttpResponseMessage respMessage = await client.SendAsync(
                reqMessage, completionOption, cancellationToken).ConfigureAwait(false);
            respMessage.EnsureSuccessStatusCode();
            string respContent = await respMessage.Content.ReadAsStringAsync().ConfigureAwait(false);
            return JsonConvert.DeserializeObject<EscrowPaymentResponse>(respContent);
        }
    }
}
