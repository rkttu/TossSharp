using Newtonsoft.Json;

namespace TossSharp {
    /// <summary>
    /// 환불 상세 내역입니다.
    /// </summary>
    public class RefundDetailResponse {
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

        /// <summary>
        /// 환불 상태를 가져옵니다.
        /// </summary>
        /// <value>
        /// 환불 상태입니다.
        /// </value>
        [JsonProperty("status")]
        public string Status { get; internal set; }

        /// <summary>
        /// 원단위 환불된 금액을 가져옵니다.
        /// </summary>
        /// <value>
        /// 원단위 환불된 금액입니다.
        /// </value>
        [JsonProperty("amount")]
        public int Amount { get; internal set; }

        /// <summary>
        /// 환불 사유를 가져옵니다.
        /// </summary>
        /// <value>
        /// 환불 사유입니다.
        /// </value>
        [JsonProperty("reason")]
        public string Reason { get; internal set; }
    }
}
