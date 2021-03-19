using System;

namespace SampleApp
{
    public class Logger_class
    {
        private string _filename = string.Empty;

        public void WriteLog(string message = "")
        {
            if (message.Equals(string.Empty))
            {
                Console.WriteLine();
                return;
            }

            Console.WriteLine(DateTime.Now.ToString() + ": " + message);
        }
    }
}
