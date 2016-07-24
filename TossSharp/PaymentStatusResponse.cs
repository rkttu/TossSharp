using Newtonsoft.Json;
using System.Collections.Generic;

namespace TossSharp {
    /// <summary>
    /// 결제 상태 조회 응답
    /// </summary>
    public class PaymentStatusResponse {
        /// <summary>
        /// 상태 코드를 가져옵니다.
        /// </summary>
        /// <value>
        /// 상태 코드입니다.
        /// </value>
        [JsonProperty("code")]
        public TossResultCode Code { get; internal set; }

        /// <summary>
        /// Toss 결제 토큰을 가져옵니다.
        /// </summary>
        /// <value>
        /// Toss 결제 토큰입니다.
        /// </value>
        [JsonProperty("payToken")]
        public string PayToken { get; internal set; }

        /// <summary>
        /// 결제 상태입니다.
        /// </summary>
        /// <value>
        /// 결제 상태입니다.
        /// </value>
        [JsonProperty("payStatus")]
        public string PayStatus { get; internal set; }

        /// <summary>
        /// Toss 결제와 이어진 주문번호를 가져옵니다.
        /// </summary>
        /// <value>
        /// Toss 결제와 이어진 주문번호입니다.
        /// </value>
        [JsonProperty("orderNo")]
        public string OrderNo { get; internal set; }

        /// <summary>
        /// 구매자의 결제 정보 입력 여부를 가져옵니다.
        /// </summary>
        /// <value>
        /// <c>true</c>인 경우 결제 정보가 입력된 상태이며, 그렇지 않은 경우 <c>false</c>입니다.
        /// </value>
        [JsonProperty("hasOwner")]
        public bool HasOwner { get; internal set; }

        /// <summary>
        /// 가능한 액션 목록을 가져옵니다.
        /// </summary>
        /// <remarks>
        /// 이 컬렉션에 포함될 수 있는 값은 CANCEL, REFUND, ESCROW입니다.
        /// </remarks>
        /// <value>
        /// 가능한 액션 목록입니다.
        /// </value>
        [JsonProperty("availableActions")]
        public IEnumerable<string> AvailableActions { get; internal set; }

        /// <summary>
        /// 조회한 결제에 대한 환불 요청 및 결과를 가져옵니다.
        /// </summary>
        /// <value>
        /// 조회한 결제에 대한 환불 요청 및 결과입니다.
        /// </value>
        [JsonProperty("refunds")]
        public IEnumerable<RefundDetailResponse> Refunds { get; internal set; }
    }
}
