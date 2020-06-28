using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmsPool_Unofficial_Libary
{
    public class RateLimitException : SMSException
    {
        public int RetryAfter { get; private set; }

        internal RateLimitException(SMSClient client, int retryAfter) : base(client, $"Ratelimited for {retryAfter} milliseconds")
        {
            RetryAfter = retryAfter;
        }


        public override string ToString()
        {
            return RetryAfter.ToString();
        }
    }
}
