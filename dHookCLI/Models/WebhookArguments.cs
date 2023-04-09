using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dHookCLI.Models
{
    public class WebhookArguments
    {
        public string Url { get; set; }
        public string Header { get; set; }
        public string Body { get; set; }
        public string Json { get; set; }
        public bool IsRaw { get; set; }
    }
}
