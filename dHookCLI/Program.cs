﻿using dHookCLI.Models;
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

            Console.WriteLine("Sending POST request..");
            var result = Webhook.Send(wArgs);

            if (!result.IsSuccessStatusCode)
            {
                Console.WriteLine("POST request failed with response:");
                Console.WriteLine(result.ToString());

                Console.WriteLine("WebhookArguments:");
                Console.WriteLine(wArgs.ToString());
            }

            Console.ReadLine();
        }

        static WebhookArguments ParseArguments(string[] args)
        {
            var wArgs = new WebhookArguments();

            if (ArgumentParser.TryFind(args, "-Url", out Argument argUrl))
            {
                wArgs.Url = argUrl.Value;
            }

            if (ArgumentParser.TryFind(args, "-Name", out Argument argName))
            {
                wArgs.Name = argName.Value;
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