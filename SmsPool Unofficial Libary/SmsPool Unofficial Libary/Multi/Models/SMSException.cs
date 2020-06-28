using System;

namespace SmsPool_Unofficial_Libary
{
    public class SMSException : Exception
    {
        public SMSClient Client { get; private set; }

        internal SMSException(SMSClient client, string message = null) : base(message)
        {
            Client = client;
        }
    }
}