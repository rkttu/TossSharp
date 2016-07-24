using Newtonsoft.Json;

namespace TossSharp {
    /// <summary>
    /// 결제 승인 응답
    /// </summary>
    public class PaymentExecutionResponse {
        /// <summary>
        /// 결제 승인 응답 코드를 가져옵니다.
        /// </summary>
        /// <value>
        /// 결제 승인 응답 코드입니다.
        /// </value>
        [JsonProperty("code")]
        public TossResultCode Code { get; internal set; }
    }
}
