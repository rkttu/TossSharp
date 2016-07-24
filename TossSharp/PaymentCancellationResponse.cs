using System;
using Newtonsoft.Json;

namespace TossSharp {
    /// <summary>
    /// 결제 취소 응답
    /// </summary>
    public class PaymentCancellationResponse {
        /// <summary>
        /// 결제 취소 응답 코드를 가져옵니다.
        /// </summary>
        /// <value>
        /// 결제 취소 응답 코드입니다.
        /// </value>
        [JsonProperty("code")]
        public TossResultCode Code { get; internal set; }

        public static implicit operator PaymentCancellationResponse(PaymentCancellationRequest v) {
            throw new NotImplementedException();
        }
    }
}
