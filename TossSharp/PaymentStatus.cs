
namespace TossSharp {
    /// <summary>
    /// 결제 상태 코드들을 모아놓은 클래스입니다.
    /// </summary>
    public static class PaymentStatus {
        /// <summary>
        /// 결제 성공
        /// </summary>
        /// <remarks>
        /// 구매자 및 가맹점의 결제 승인 및 출금이 정상적으로 완료된 상태입니다. 에스크로 결제 건의 경우, 자동으로 '에스크로 요청' 상태로 변경됩니다. 
        /// </remarks>
        public static readonly string PaySuccess = "PAY_SUCCESS";

        /// <summary>
        /// 결제 취소
        /// </summary>
        /// <remarks>
        /// 결제가 완료되기 전에 구매자나 가맹점이 결제를 취소한 상태입니다. (결론적으론 금액의 이동 없이 종료된 건) 
        /// </remarks>
        public static readonly string PayCancel = "PAY_CANCEL";

        /// <summary>
        /// 환불 성공
        /// </summary>
        /// <remarks>
        /// 전액 또는 부분 환불이 완료되어, 환불 처리한 금액이 구매자의 계좌로 입금 완료된 상태입니다. 
        /// </remarks>
        public static readonly string RefundSuccess = "REFUND_SUCCESS";

        /// <summary>
        /// 결제 대기 중
        /// </summary>
        /// <remarks>
        /// 결제 건이 생성되었고, 구매자의 결제 진행을 대기 중인 상태. 이 상태에서 구매자나 가맹점이 결제를 취소할 수 있습니다. 또한 설정한 '만료 기간'이 도래하면 자동으로 취소됩니다. 
        /// </remarks>
        public static readonly string PayStandby = "PAY_STANDBY";

        /// <summary>
        /// 구매자 인증 완료
        /// </summary>
        /// <remarks>
        /// 수동 승인 결제 거래일 때에만 유효합니다. 결제를 위한 구매자 인증 완료되고, 가맹점의 최종 승인을 기다리는 상태. (결제 생성 시 'autoExecute'를 false로 설정한 경우에만 이 단계를 거칩니다) 
        /// </remarks>
        public static readonly string PayApproved = "PAY_APPROVED";

        /// <summary>
        /// 결제 진행 중
        /// </summary>
        /// <remarks>
        /// 구매자가 결제를 승인하여 구매자의 계좌에서 결제 금액을 출금 처리 중인 상태입니다. 
        /// </remarks>
        public static readonly string PayProgress = "PAY_PROGRESS";

        /// <summary>
        /// 결제 완료
        /// </summary>
        /// <remarks>
        /// 구매자 및 가맹점의 결제 승인 및 출금이 정상적으로 완료된 상태입니다. 에스크로 결제 건의 경우, 자동으로 '에스크로 요청' 상태로 변경됩니다. 
        /// </remarks>
        public static readonly string PayComplete = "PAY_COMPLETE";

        /// <summary>
        /// 에스크로 요청
        /// </summary>
        /// <remarks>
        /// 에스크로 거래 전용입니다. 에스크로 결제 건이 결제 완료된 후, 매매보호에 들어간 상태입니다. 판매자가 '배송 등록'을 하면 에스크로 해제 상태로 변경되며, 120일 동안 배송 등록을 하지 않는 경우에도 자동으로 에스크로 해제 상태로 변경됩니다. 
        /// </remarks>
        public static readonly string EscrowRequest = "ESCROW_REQUEST";

        /// <summary>
        /// 에스크로 해제
        /// </summary>
        /// <remarks>
        /// 에스크로 거래 전용입니다. 판매자가 '배송 등록'을 완료하고 구매자의 '구매 확정'을 대기 중인 상태입니다. 구매자가 구매 확정을 하면 판매자 대금 지급 과정을 시작하고, 구매자가 지급을 거부하면 에스크로 거부 상태로 변경됩니다. 
        /// </remarks>
        public static readonly string EscrowRelease = "ESCROW_RELEASE";

        /// <summary>
        /// 에스크로 거절
        /// </summary>
        /// <remarks>
        /// 에스크로 거래 전용입니다. 구매자가 지급을 거절한 상태입니다. 판매자는 이 건을 전액 환불 처리하거나 구매자에게 '구매 확정'을 다시 요청할 수 있습니다. 
        /// </remarks>
        public static readonly string EscrowDeny = "ESCROW_DENY";

        /// <summary>
        /// 환불 진행 중
        /// </summary>
        /// <remarks>
        /// 전액 또는 부분 환불을 진행 중인 상태로, 완료되기 전 까지 다른 환불을 진행할 수 없습니다. 
        /// </remarks>
        public static readonly string RefundProgress = "REFUND_PROGRESS";

        /// <summary>
        /// 정산 완료
        /// </summary>
        /// <remarks>
        /// 결제 완료된 금액에 대해 정산이 완료되어 더 이상 환불이 불가한 상태입니다. (승인일 또는 구매 확정일로부터 180일 경과) 
        /// </remarks>
        public static readonly string SettlementComplete = "SETTLEMENT_COMPLETE";

        /// <summary>
        /// 환불 정산 완료
        /// </summary>
        /// <remarks>
        /// 전액 또는 부분 환불에 대한 정산이 완료되어 더 이상 환불이 불가한 상태입니다. (승인일 또는 구매 확정일로부터 180일 경과했거나 전액 환불에 대한 정산 완료된 경우) 
        /// </remarks>
        public static readonly string SettlementRefundComplete = "SETTLEMENT_REFUND_COMPLETE";
    }
}
