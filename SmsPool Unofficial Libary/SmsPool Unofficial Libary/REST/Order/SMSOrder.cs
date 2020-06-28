using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace SmsPool_Unofficial_Libary
{
    public static class SMSOrder
    {
        public static async Task<string> Order(this SMSClient client, string pool, string service, string country)
        {
            HttpResponseMessage post =  await client.HttpClient.Send("order.php?api_key=" + client.Api_key + "&pool=" + pool + "&service=" + service + "&country=" + country);
            string results = await post.Content.ReadAsStringAsync();
            if (results.Contains("Please fill in your API key.")) { return "Please fill in your API key."; }
            SMSOrderExtension result = JsonConvert.DeserializeObject<SMSOrderExtension>(results);
            if (result.Message != null)
            {
                return result.Message;
            }
            if (result.OrderID != null)
            {
                return result.OrderID;
            }
            return "Success";
        }
    }
}
