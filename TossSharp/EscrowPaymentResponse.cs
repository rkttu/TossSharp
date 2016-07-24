using Newtonsoft.Json;

namespace TossSharp {
    /// <summary>
    /// 에스크로 결제 응답
    /// </summary>
    public class EscrowPaymentResponse {
        /// <summary>
        /// 상태 코드를 가져옵니다.
        /// </summary>
        /// <value>
        /// 상태 코드입니다.
        /// </value>
        [JsonProperty("code")]
        public TossResultCode Code { get; set; }
    }
}
