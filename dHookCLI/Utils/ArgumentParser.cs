using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
                    if (args[i] == name)
                    {
                        argument.Name = args[i];
                        argument.Value = args[i+1];
                    }
                }
            }
            catch(IndexOutOfRangeException)
            {
                return false;
            }

            return true;
        }
    }
}
