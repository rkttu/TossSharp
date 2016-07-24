
namespace TossSharp {
    /// <summary>
    /// API 오류 코드
    /// </summary>
    public enum TossResultCode : int {
        /// <summary>
        /// 성공
        /// </summary>
        Success = 0,
        /// <summary>
        /// 오류
        /// </summary>
        Error = 1,

        /// <summary>
        /// 결제 오류
        /// </summary>
        PaymentError = 10,
        /// <summary>
        /// 중복 주문
        /// </summary>
        DuplicatedRequest = 11,
        /// <summary>
        /// 1회 결제 한도 초과 금액
        /// </summary>
        ExceedLimit = 12,

        /// <summary>
        /// 결제 취소 오류
        /// </summary>
        CancellationError = 30,
        /// <summary>
        /// 존재하지 않는 결제
        /// </summary>
        NonExistingCancellablePayment = 31,
        /// <summary>
        /// 취소 불가 상태
        /// </summary>
        CancellationNotAvailable = 32,
        /// <summary>
        /// 기 취소된 결제
        /// </summary>
        AlreadyCancelled = 33,

        /// <summary>
        /// 결제 환불 오류
        /// </summary>
        RefundError = 50,
        /// <summary>
        /// 존재하지 않는 결제
        /// </summary>
        NonExistingRefundablePayment = 51,
        /// <summary>
        /// 환불 불가 상태
        /// </summary>
        RefundNotAvailable = 52,
        /// <summary>
        /// 기 환불된 결제
        /// </summary>
        AlreadyRefunded = 53,
        /// <summary>
        /// 대기중인 환불이 있음
        /// </summary>
        PendingRefund = 54,
        /// <summary>
        /// 결제 미결
        /// </summary>
        PaymentIncompleted = 55,
        /// <summary>
        /// 환불 가능 금액 초과
        /// </summary>
        ExceedRefundAmount = 56,

        /// <summary>
        /// 결제 상태 오류
        /// </summary>
        PaymentStatusError = 70,
        /// <summary>
        /// 존재하지 않는 결제
        /// </summary>
        NonExistingPayment = 71,

        /// <summary>
        /// 에스크로 오류
        /// </summary>
        EscrowError = 90,
        /// <summary>
        /// 존재하지 않는 에스크로 결제
        /// </summary>
        NonExistingEscrowPayment = 91,
        /// <summary>
        /// 에스크로 불가 상태
        /// </summary>
        EscrowNotAvailable = 92,
        /// <summary>
        /// 에스크로 환불 시 전체 환불만 가능
        /// </summary>
        CanNotDoPartialEscrowRefund = 93
    }
}
