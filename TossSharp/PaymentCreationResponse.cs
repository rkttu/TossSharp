using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TossSharp {
    /// <summary>
    /// 결제 생성 요청 결과
    /// </summary>
    public class PaymentCreationResponse {
        /// <summary>
        /// 응답 코드를 가져옵니다.
        /// </summary>
        /// <value>
        /// 응답 코드입니다.
        /// </value>
        [JsonProperty("code")]
        public TossResultCode Code { get; internal set; }

        /// <summary>
        /// 생성된 결제를 진행하는 웹 페이지의 URL을 가져옵니다.
        /// </summary>
        /// <remarks>
        /// 구매자가 이 URL을 방문하도록 유도해야 합니다.
        /// </remarks>
        /// <value>
        /// 생성된 결제를 진행하는 웹 페이지의 URL입니다.
        /// </value>
        [JsonProperty("checkoutPage")]
        public string CheckoutPage { get; internal set; }

        /// <summary>
        /// Toss 결제 토큰을 가져옵니다.
        /// </summary>
        /// <value>
        /// Toss 결제 토큰입니다.
        /// </value>
        [JsonProperty("payToken")]
        public string PayToken { get; internal set; }

        /// <summary>
        /// 응답이 성공이 아닌 경우의 상세 설명을 가져옵니다.
        /// </summary>
        /// <value>
        /// 응답이 성공이 아닌 경우의 상세 설명입니다.
        /// </value>
        [JsonProperty("msg")]
        public string Message { get; internal set; }
    }
}
