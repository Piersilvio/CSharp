using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp3
{
    public class Logger
    {
        public delegate void StringLogWriter(DateTime timestamp, string message);

        private StringLogWriter writer;

        public Logger(StringLogWriter writer)
        {
            this.writer = writer;
        }
 
        public void Log(string message)
        {
            if (this.writer != null)
                this.writer(DateTime.Now, message);
        }
    }
}
