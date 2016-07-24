using Newtonsoft.Json;

namespace TossSharp {
    /// <summary>
    /// 결제 생성 요청
    /// </summary>
    public class PaymentCreationRequest {
        /// <summary>
        /// 가맹점 Key를 가져오거나 설정합니다. 필수 매개 변수입니다.
        /// </summary>
        /// <value>
        /// 가맹점 Key입니다.
        /// </value>
        [JsonProperty("apiKey", Required = Required.Always)]
        public string ApiKey { get; set; }
        /// <summary>
        /// 가맹점의 상품 주문번호를 가져오거나 설정합니다. 필수 매개 변수입니다.
        /// </summary>
        /// <value>
        /// 가맹점의 상품 주문번호입니다.
        /// </value>
        [JsonProperty("orderNo", Required = Required.Always)]
        public string OrderNo { get; set; }
        /// <summary>
        /// 원단위 결제 금액을 가져오거나 설정합니다. 필수 매개 변수입니다.
        /// </summary>
        /// <value>
        /// 원단위 결제 금액입니다.
        /// </value>
        [JsonProperty("amount", Required = Required.Always)]
        public int Amount { get; set; }
        /// <summary>
        /// 상품 설명을 가져오거나 설정합니다. 필수 매개 변수입니다.
        /// </summary>
        /// <value>
        /// 상품 설명입니다.
        /// </value>
        [JsonProperty("productDesc", Required = Required.Always)]
        public string ProductDescription { get; set; }
        /// <summary>
        /// 원단위 결제 금액 중 과세금액 (복합과세)을 가져오거나 설정합니다.
        /// </summary>
        /// <value>
        /// 원단위 결제 금액 중 과세금액 (복합과세)입니다.
        /// </value>
        [JsonProperty("amountTaxable", NullValueHandling = NullValueHandling.Ignore)]
        public int? AmountTaxable { get; set; }
        /// <summary>
        /// 원단위 결제 금액 중 비과세금액 (복합과세)을 가져오거나 설정합니다.
        /// </summary>
        /// <value>
        /// 원단위 결제 금액 중 비과세금액 (복합과세)입니다.
        /// </value>
        [JsonProperty("amountTaxFree", NullValueHandling = NullValueHandling.Ignore)]
        public int? AmountTaxFree { get; set; }
        /// <summary>
        /// 원단위 결제 금액 중 부가세 (복합과세)를 가져오거나 설정합니다.
        /// </summary>
        /// <value>
        /// 원단위 결제 금액 중 부가세 (복합과세)입니다.
        /// </value>
        [JsonProperty("amountVat", NullValueHandling = NullValueHandling.Ignore)]
        public int? AmountVat { get; set; }
        /// <summary>
        /// 원단위 결제 금액 중 봉사료 (복합 과세)를 가져오거나 설정합니다.
        /// </summary>
        /// <value>
        /// 원단위 결제 금액 중 봉사료 (복합 과세)입니다.
        /// </value>
        [JsonProperty("amountServiceFee", NullValueHandling = NullValueHandling.Ignore)]
        public int? AmountServiceFee { get; set; }
        /// <summary>
        /// 결제 완료 후 연결할 웹 페이지의 URL을 가져오거나 설정합니다.
        /// </summary>
        /// <remarks>
        /// 미 지정시 Toss 웹 페이지의 URL이 대신 선택됩니다.
        /// </remarks>
        /// <value>
        /// 결제 완료 후 연결할 웹 페이지의 URL입니다.
        /// </value>
        [JsonProperty("retUrl", NullValueHandling = NullValueHandling.Ignore)]
        public string ReturnUrl { get; set; }
        /// <summary>
        /// 결제 만료 기한을 가져오거나 설정합니다.
        /// </summary>
        /// <remarks>
        /// yyyy-MM-dd HH:mm:ss (24시간제)의 형태로 지정합니다. 기본값은 1시간이고, 최소 10분에서 최대 24시간까지 설정 가능합니다.
        /// </remarks>
        /// <value>
        /// 결제 만료 기한입니다.
        /// </value>
        [JsonProperty("expiredTime", NullValueHandling = NullValueHandling.Ignore)]
        public string ExpiredTime { get; set; }

        /// <summary>
        /// 결제 결과 Callback URL을 가져오거나 설정합니다.
        /// </summary>
        /// <value>
        /// 결제 결과 Callback URL입니다.
        /// </value>
        [JsonProperty("resultCallback", NullValueHandling = NullValueHandling.Ignore)]
        public string ResultCallback { get; set; }

        /// <summary>
        /// 에스크로 결제 여부를 가져오거나 설정합니다.
        /// </summary>
        /// <remarks>
        /// 기본값은 <c>false</c> 입니다.
        /// </remarks>
        /// <value>
        /// 에스크로 결제 여부입니다.
        /// </value>
        [JsonProperty("escrow", NullValueHandling = NullValueHandling.Ignore)]
        public bool? Escrow { get; set; }

        /// <summary>
        /// 현금영수증 발급 가능 여부를 가져오거나 설정합니다.
        /// </summary>
        /// <remarks>
        /// 기본값은 <c>true</c> 입니다.
        /// </remarks>
        /// <value>
        /// 현금영수증 발급 가능 여부입니다.
        /// </value>
        [JsonProperty("cashReceipt", NullValueHandling = NullValueHandling.Ignore)]
        public bool? CashReceipt { get; set; }

        /// <summary>
        /// 자동 승인 여부를 가져오거나 설정합니다.
        /// </summary>
        /// <remarks>
        /// 기본값은 <c>true</c> 입니다.
        /// </remarks>
        /// <value>
        /// <c>true</c>로 설정하면 구매자 인증 완료 시 바로 결제 완료 처리합니다.
        /// <c>false</c>로 설정하면 구매자 인증 완료 후 가맹점의 최종 승인 시 결제 완료 처리합니다.
        /// </value>
        [JsonProperty("autoExecute", NullValueHandling = NullValueHandling.Ignore)]
        public bool? AutoExecute { get; set; }

        /// <summary>
        /// 인증된 기기에서 다시 결제할 때 ARS 인증 생략 여부를 설정합니다.
        /// </summary>
        /// <remarks>
        /// 기본값은 <c>'Y'</c>이며, 환금성이 높은 상품권이나 포인트 등의 결제건은 <c>'N'</c>으로 설정하는 것을 권장합니다.
        /// 이 설정을 이용하려면 별도의 가맹점 계약이 필요합니다.
        /// </remarks>
        /// <value>
        /// <c>'Y'</c>로 설정하면 인증된 기기에서는 ARS 인증을 생략할 수 있습니다.
        /// <c>'N'</c>으로 설정하면 인증 여부와 관계없이 ARS 인증을 사용합니다.
        /// </value>
        [JsonProperty("arsAuthSkippable", NullValueHandling = NullValueHandling.Ignore)]
        public bool? ArsAuthSkippable { get; set; }

        /// <summary>
        /// 구매자가 결제 시 이용할 휴대전화번호를 가져오거나 설정합니다.
        /// </summary>
        /// <remarks>
        /// 지정 시 구매자가 번호를 변경할 수 없으므로 전화번호가 정확할 때에만 값을 설정해야 합니다.
        /// </remarks>
        /// <value>
        /// 구매자가 결제 시 이용할 휴대전화번호입니다.
        /// </value>
        [JsonProperty("userPhone", NullValueHandling = NullValueHandling.Ignore)]
        public string UserPhone { get; set; }

        /// <summary>
        /// 결제와 연관된 추가 데이터를 가져오거나 설정합니다.
        /// </summary>
        /// <value>
        /// 결제와 연관된 추가 데이터입니다.
        /// </value>
        [JsonProperty("metadata", NullValueHandling = NullValueHandling.Ignore)]
        public string Metadata { get; set; }
    }
}
