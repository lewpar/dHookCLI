namespace dHookCLI.Utils
{
    public class ArgumentParser
    {
        public static bool TryFind(string[] args, string name, out Argument argument)
        {
            argument = new Argument();

            try
            {
                for (int i = 0; i < args.Length; i++)
                {
                    string arg = args[i];

                    if (arg == name)
                    {
                        argument.Name = args[i];
                        argument.Value = args[i+1];

                        return true;
                    }
                }
            }
            catch(IndexOutOfRangeException)
            {
                return false;
            }

            return false;
        }
    }
}
