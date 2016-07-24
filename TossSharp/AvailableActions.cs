using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TossSharp {
    /// <summary>
    /// 가능한 액션 목록
    /// </summary>
    public static class AvailableActions {
        /// <summary>
        /// 결제 취소
        /// </summary>
        public static readonly string CancelAvailable = "CANCEL";

        /// <summary>
        /// 결제 환불
        /// </summary>
        public static readonly string RefundAvailable = "REFUND";

        /// <summary>
        /// 에스크로 (배송등록/구매확정재요청)
        /// </summary>
        public static readonly string EscrowAvailable = "ESCROW";
    }
}
