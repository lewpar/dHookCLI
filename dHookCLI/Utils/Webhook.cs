using dHookCLI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace dHookCLI.Utils
{
    public class Webhook
    {
        private static HttpClient _httpClient;

        public static void Send(WebhookArguments wArgs)
        {
            if(_httpClient == null)
            {
                _httpClient = new HttpClient();
            }

            var message = new HttpRequestMessage(HttpMethod.Post, wArgs.Url);
            
            if(wArgs.IsRaw)
            {
                message.Content = new StringContent(wArgs.Json, Encoding.UTF8, "application/json");
            }
            else
            {
                var sb = new StringBuilder();

                sb.Append("{");

                if (!string.IsNullOrEmpty(wArgs.Name))
                {
                    sb.Append($"\"content\": \"{wArgs.Body}\"");
                }

                sb.Append(",");

                if (!string.IsNullOrEmpty(wArgs.Body))
                {
                    sb.Append($"\"username\": \"{wArgs.Name}\"");
                }

                sb.Append("}");

                message.Content = new StringContent(sb.ToString(), Encoding.UTF8, "application/json");
            }

            _httpClient.Send(message);
        }
    }
}
