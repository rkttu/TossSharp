using Newtonsoft.Json;

namespace TossSharp {
    /// <summary>
    /// 환불 결과 응답
    /// </summary>
    public class PaymentRefundResponse {
        /// <summary>
        /// 환불 상태 코드를 가져옵니다.
        /// </summary>
        /// <value>
        /// 환불 상태 코드입니다.
        /// </value>
        [JsonProperty("code")]
        public TossResultCode Code { get; internal set; }

        /// <summary>
        /// 환불 번호를 가져옵니다.
        /// </summary>
        /// <remarks>
        /// 환불 상태 조회 시 이 번호가 필요합니다.
        /// </remarks>
        /// <value>
        /// 환불 번호입니다.
        /// </value>
        [JsonProperty("refundNo")]
        public string RefundNo { get; internal set; }
    }
}
