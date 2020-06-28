using Newtonsoft.Json;

namespace SmsPool_Unofficial_Libary
{
    internal class SMSHttpError
    {
        [JsonProperty("code")]
        public SMSError Code { get; private set; }


        [JsonProperty("message")]
        public string Message { get; private set; }
    }
}
