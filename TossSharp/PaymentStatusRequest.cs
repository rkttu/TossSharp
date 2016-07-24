using Newtonsoft.Json;

namespace TossSharp {
    /// <summary>
    /// 결제 상태 조회 요청
    /// </summary>
    public class PaymentStatusRequest {
        /// <summary>
        /// 가맹점 Key를 가져오거나 설정합니다. 필수 매개 변수입니다.
        /// </summary>
        /// <value>
        /// 가맹점 Key입니다.
        /// </value>
        [JsonProperty("apiKey", Required = Required.Always)]
        public string ApiKey { get; set; }

        /// <summary>
        /// Toss 결제 토큰을 가져오거나 설정합니다. OrderNo 매개 변수를 지정하지 않았을 경우 필수 매개 변수입니다.
        /// </summary>
        /// <value>
        /// 승인할 결제 건의 Toss 결제 토큰입니다.
        /// </value>
        [JsonProperty("payToken", NullValueHandling = NullValueHandling.Ignore)]
        public string PayToken { get; set; }

        /// <summary>
        /// 가맹점의 상품 주문번호를 가져오거나 설정합니다. PayToken 매개 변수를 지정하지 않았을 경우 필수 매개 변수입니다.
        /// </summary>
        /// <value>
        /// 가맹점의 상품 주문번호입니다.
        /// </value>
        [JsonProperty("orderNo", NullValueHandling = NullValueHandling.Ignore)]
        public string OrderNo { get; set; }
    }
}
