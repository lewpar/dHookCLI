using System.Text;

using dHookCLI.Models;

namespace dHookCLI.Utils
{
    public class Webhook
    {
        private static HttpClient _httpClient;

        public static HttpResponseMessage Send(WebhookArguments wArgs)
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

            return _httpClient.Send(message);
        }
    }
}
