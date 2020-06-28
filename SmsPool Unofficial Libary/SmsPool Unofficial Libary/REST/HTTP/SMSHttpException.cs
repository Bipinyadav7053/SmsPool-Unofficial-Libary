using System;
namespace SmsPool_Unofficial_Libary
{
    public class SMSHttpException : SMSException
    {
        public SMSError Code { get; private set; }
        public string ErrorMessage { get; private set; }

        internal SMSHttpException(SMSClient client, SMSHttpError error) : base(client, $"{(int)error.Code} {error.Message}")
        {
            Code = error.Code;
            ErrorMessage = error.Message;
        }
    }
}
