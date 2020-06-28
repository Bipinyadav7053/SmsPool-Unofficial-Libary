﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace SmsPool_Unofficial_Libary
{
    public class SMSClient
    {
        public string Api_key { get; set; }

        public string Order_ID { get; set; }

        public SMSHttpClient HttpClient { get; private set; }

        public SMSClient(string api_key)
        {
            HttpClient = new SMSHttpClient(this);
            Api_key = api_key;
        }

    }
}

