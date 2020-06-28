using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmsPool_Unofficial_Libary
{
    class SMSCancelExtension
    {
            [JsonProperty("message")]
            public static string _message { get; set; }
            public string Message
            {
                get { return _message; }
            }
    }
}
