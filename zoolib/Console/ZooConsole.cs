using System.Collections.Generic;

namespace ZooLib.Console
{
    public class ZooConsole : IConsole
    {
        public List<string> Messages { get; set; } = new List<string>();

        public void WriteLine(string text)
        {
            Messages.Add(text);
        }
    }
}
