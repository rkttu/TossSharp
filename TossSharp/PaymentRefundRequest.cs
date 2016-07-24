using Newtonsoft.Json;

namespace TossSharp {
    /// <summary>
    /// 결제 환불 요청
    /// </summary>
    public class PaymentRefundRequest {
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
        /// 환불 번호를 가져오거나 설정합니다.
        /// </summary>
        /// <remarks>
        /// 환불 상태 확인 시 필요합니다. 미입력 시 자동 생성되며 환불 완료 응답에서 확인 가능합니다.
        /// </remarks>
        /// <value>
        /// 환불 번호입니다.
        /// </value>
        [JsonProperty("refundNo", NullValueHandling = NullValueHandling.Ignore)]
        public string RefundNo { get; set; }

        /// <summary>
        /// 환불 사유를 가져오거나 설정합니다.
        /// </summary>
        /// <remarks>
        /// 유니코드 문자열 기준 최대 50자까지 지정 가능합니다.
        /// </remarks>
        /// <value>
        /// 환불 사유입니다.
        /// </value>
        [JsonProperty("reason", NullValueHandling = NullValueHandling.Ignore)]
        public string Reason { get; set; }

        /// <summary>
        /// 원단위 환불할 금액을 가져오거나 설정합니다.
        /// </summary>
        /// <remarks>
        /// 금액을 지정하지 않으면 전액 환불 처리합니다.
        /// </remarks>
        /// <value>
        /// 원단위 환불할 금액입니다.
        /// </value>
        [JsonProperty("amount", NullValueHandling = NullValueHandling.Ignore)]
        public int? Amount { get; set; }

        /// <summary>
        /// 원단위 환불할 금액 중 과세금액 (복합과세)을 가져오거나 설정합니다.
        /// </summary>
        /// <value>
        /// 원단위 환불할 금액 중 과세금액 (복합과세)입니다.
        /// </value>
        [JsonProperty("amountTaxable", NullValueHandling = NullValueHandling.Ignore)]
        public int? AmountTaxable { get; set; }

        /// <summary>
        /// 원단위 환불할 금액 중 비과세금액 (복합과세)을 가져오거나 설정합니다.
        /// </summary>
        /// <value>
        /// 원단위 환불할 금액 중 비과세금액 (복합과세)입니다.
        /// </value>
        [JsonProperty("amountTaxFree", NullValueHandling = NullValueHandling.Ignore)]
        public int? AmountTaxFree { get; set; }

        /// <summary>
        /// 원단위 환불할 금액 중 부가세 (복합과세)를 가져오거나 설정합니다.
        /// </summary>
        /// <value>
        /// 원단위 환불할 금액 중 부가세 (복합과세)입니다.
        /// </value>
        [JsonProperty("amountVat", NullValueHandling = NullValueHandling.Ignore)]
        public int? AmountVat { get; set; }

        /// <summary>
        /// 원단위 환불할 금액 중 봉사료 (복합 과세)를 가져오거나 설정합니다.
        /// </summary>
        /// <value>
        /// 원단위 환불할 금액 중 봉사료 (복합 과세)입니다.
        /// </value>
        [JsonProperty("amountServiceFee", NullValueHandling = NullValueHandling.Ignore)]
        public int? AmountServiceFee { get; set; }
    }
}
