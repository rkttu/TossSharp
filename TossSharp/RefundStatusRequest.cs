using Newtonsoft.Json;

namespace TossSharp {
    /// <summary>
    /// 환불 상태 조회 요청
    /// </summary>
    public class RefundStatusRequest {
        /// <summary>
        /// 가맹점 Key를 가져오거나 설정합니다. 필수 매개 변수입니다.
        /// </summary>
        /// <value>
        /// 가맹점 Key입니다.
        /// </value>
        [JsonProperty("apiKey", Required = Required.Always)]
        public string ApiKey { get; set; }
    }
}
