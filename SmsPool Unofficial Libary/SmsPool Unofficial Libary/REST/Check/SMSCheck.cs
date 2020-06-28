using Newtonsoft.Json;
using SmsPool_Unofficial_Libary.REST.Cancel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace SmsPool_Unofficial_Libary.REST.Check
{
    public static class SMSCheck
    {
        public static async Task<string> Check(this SMSClient client, string order_id)
        {
            HttpResponseMessage post = await client.HttpClient.Send("check.php?api_key=" + client.Api_key + "&orderid=" + order_id + "&method=CHECK");
            string results = await post.Content.ReadAsStringAsync();
            if (results.Contains("Please fill in your API key.")) { return "Please fill in your API key."; }
            SMSCheckExtension result = JsonConvert.DeserializeObject<SMSCheckExtension>(results);
            Console.WriteLine(result.successcode);
            if (result.successcode == 1)
            {
                return result.Message;
            }
            if (result.successcode == 2)
            {
                return "Waiting";
            }
            if (result.successcode == 3)
            {
                await client.Cancel(order_id);
            }
            return "Failed to check order.";
        }
    }
}
