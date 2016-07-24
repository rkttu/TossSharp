using Newtonsoft.Json;

namespace TossSharp {
    /// <summary>
    /// 에스크로 결제 요청
    /// </summary>
    public class EscrowPaymentRequest {
        /// <summary>
        /// 가맹점 Key를 가져오거나 설정합니다. 필수 매개 변수입니다.
        /// </summary>
        /// <value>
        /// 가맹점 Key입니다.
        /// </value>
        [JsonProperty("apiKey", Required = Required.Always)]
        public string ApiKey { get; set; }

        /// <summary>
        /// Toss 결제 토큰을 가져오거나 설정합니다. 필수 매개 변수입니다.
        /// </summary>
        /// <value>
        /// Toss 결제 토큰입니다.
        /// </value>
        [JsonProperty("payToken", Required = Required.Always)]
        public string PayToken { get; set; }
    }
}
