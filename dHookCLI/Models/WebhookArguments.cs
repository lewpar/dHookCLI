using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dHookCLI.Models
{
    public class WebhookArguments
    {
        public string Header { get; set; }
        public string Body { get; set; }

        public override string ToString()
        {
            return $"{Header}:{Body}";
        }
    }
}
