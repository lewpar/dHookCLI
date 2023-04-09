using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace dHookCLI.Models
{
    public class WebhookArguments
    {
        public string Url { get; set; }
        public string Name { get; set; }
        public string Body { get; set; }
        public string Json { get; set; }
        public bool IsRaw { get; set; }

        public override string ToString()
        {
            return JsonSerializer.Serialize<WebhookArguments>(this);
        }
    }
}
