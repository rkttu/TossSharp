
namespace TossSharp {
    /// <summary>
    /// 콜백 URL에 전달되는 데이터에 대한 모델입니다.
    /// </summary>
    public class PaymentCreationCallbackModel {
        /// <summary>
        /// 결제 상태를 가져오거나 설정합니다.
        /// </summary>
        /// <value>
        /// PAY_SUCCESS, PAY_CANCEL, REFUND_SUCCESS 중 하나입니다.
        /// </value>
        public string status { get; set; }

        /// <summary>
        /// Toss 결제 토큰을 가져오거나 설정합니다.
        /// </summary>
        /// <value>
        /// Toss 결제 토큰입니다.
        /// </value>
        public string payToken { get; set; }

        /// <summary>
        /// Toss 결제와 이어진 주문번호를 가져오거나 설정합니다.
        /// </summary>
        /// <value>
        /// Toss 결제와 이어진 주문번호입니다.
        /// </value>
        public string orderNo { get; set; }

        /// <summary>
        /// 결제 생성 시 저장한 연관 정보를 가져오거나 설정합니다.
        /// </summary>
        /// <value>
        /// 결제 생성 시 저장한 연관 정보
        /// </value>
        public string metadata { get; set; }
    }
}
