using Newtonsoft.Json;

namespace TossSharp {
    /// <summary>
    /// 결제 취소 요청
    /// </summary>
    public class PaymentCancellationRequest {
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
        /// 승인할 결제 건의 Toss 결제 토큰입니다.
        /// </value>
        [JsonProperty("payToken", Required = Required.Always)]
        public string PayToken { get; set; }

        /// <summary>
        /// 취소 사유를 가져오거나 설정합니다.
        /// </summary>
        /// <remarks>
        /// 유니코드 문자열 기준 최대 50자까지 지정 가능합니다.
        /// </remarks>
        /// <value>
        /// 취소 사유입니다.
        /// </value>
        [JsonProperty("reason", NullValueHandling = NullValueHandling.Ignore)]
        public string Reason { get; set; }
    }
}
