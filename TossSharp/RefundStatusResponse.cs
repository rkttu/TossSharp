using Newtonsoft.Json;

namespace TossSharp {
    /// <summary>
    /// 환불 상태 조회 응답
    /// </summary>
    public class RefundStatusResponse {
        /// <summary>
        /// 상태 코드를 가져옵니다.
        /// </summary>
        /// <value>
        /// 상태 코드입니다.
        /// </value>
        [JsonProperty("code")]
        public TossResultCode Code { get; internal set; }

        /// <summary>
        /// 상세 환불 정보를 가져옵니다.
        /// </summary>
        /// <value>
        /// 상세 환불 정보입니다.
        /// </value>
        [JsonProperty("refund")]
        public RefundDetailResponse Refund { get; internal set; }
    }
}
