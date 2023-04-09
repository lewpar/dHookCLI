using dHookCLI.Models;
using dHookCLI.Utils;

namespace dHookCLI
{
    internal class Program
    {
        static void Main(string[] args)
        {
            if(args.Length == 0)
            {
                Console.WriteLine("Invalid arguments, you must have at least one argument.");
                return;
            }

            WebhookArguments wArgs = ParseArguments(args); 

            if(string.IsNullOrEmpty(wArgs.Url))
            {
                Console.WriteLine("You must supply a webhook url.");
                return;
            }

            if(!Uri.IsWellFormedUriString(wArgs.Url, UriKind.Absolute))
            {
                Console.WriteLine("Invalid url format.");
                return;
            }

            Console.WriteLine($"Sending POST request to '{wArgs.Url}'..");
            Webhook.Send(wArgs);

            Console.ReadLine();
        }

        static WebhookArguments ParseArguments(string[] args)
        {
            var wArgs = new WebhookArguments();

            if (ArgumentParser.TryFind(args, "-Url", out Argument argUrl))
            {
                wArgs.Url = argUrl.Value;
            }

            if (ArgumentParser.TryFind(args, "-Header", out Argument argHeader))
            {
                wArgs.Header = argHeader.Value;
            }

            if (ArgumentParser.TryFind(args, "-Body", out Argument argBody))
            {
                wArgs.Body = argBody.Value;
            }

            if(ArgumentParser.TryFind(args, "-Json", out Argument argJson))
            {
                wArgs.Json = argJson.Value;
                wArgs.IsRaw = true;
            }

            return wArgs;
        }
    }
}