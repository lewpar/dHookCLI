using dHookCLI.Models;
using dHookCLI.Utils;

namespace dHookCLI
{
    internal class Program
    {
        static void Main(string[] args)
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

            Console.ReadLine();
        }
    }
}