using Newtonsoft.Json.Schema;
using Newtonsoft.Json.Schema.Generation;
using Newtonsoft.Json.Linq;
using System.Threading;
using Newtonsoft.Json;
using System.Collections.Generic;
using System;
using System.Threading.Tasks;
using System.Net.Http;
using System.Net;

namespace SmsPool_Unofficial_Libary
{
    public class SMSHttpClient
    {
        private readonly SMSClient _smsClient;

#pragma warning disable IDE0044
        private static JSchema _errorSchema = new JSchemaGenerator().Generate(typeof(SMSHttpError));
#pragma warning restore IDE0044

        public Dictionary<string, string> Param { get; set; } = new Dictionary<string, string>();

        public string Api { get; set; } = "https://smspool.net/api/";

        public bool RetryOnRatelimit { get; private set; } = true;

        public SMSHttpClient(SMSClient smsClient)
        {
            _smsClient = smsClient;
        }



        /// <summary>
        /// Sends an HTTP request and checks for errors
        /// </summary>
        /// <param name="method">HTTP method to use</param>
        /// <param name="endpoint">API endpoint (fx. /users/@me)</param>
        /// <param name="json">JSON content</param>
        public async Task<HttpResponseMessage> Send(string endpoint)
        {
            var webClient = new HttpClient(new HttpClientHandler
            {
                    AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate,
            });

            while (true)
            {
                try
                {
                    webClient.DefaultRequestHeaders.TryAddWithoutValidation("Accept", "application/x-www-form-urlencoded");
                    HttpResponseMessage response =
                    await webClient.GetAsync(Api + endpoint);
                    return response;
                }
                catch (RateLimitException ex)
                {
                    if (RetryOnRatelimit)
                        Thread.Sleep(ex.RetryAfter);
                    else
                        throw;
                }
            }
        }
    }
}
