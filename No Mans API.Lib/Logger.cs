using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace No_Mans_API
{
    /// <summary>
    /// Which medium do you want the message to output to?
    /// </summary>
    public enum OutputType
    {
        Console, MsgBox, ConsoleAndMsgBox, Debug
    }

    public enum LogLevel
    {
        Normal, Warning, Error, Update
    }

    public class Logger
    {
        #region Properties

        /// <summary>
        /// Singleton instance of this class
        /// </summary>
        private static Logger instance;
        public static Logger Instance
        {
            get
            {
                if (instance == null)
                    instance = new Logger();

                return instance;
            }
        }
        #endregion

        #region Events
        public static event EventHandler<LogEvents> MessageLogged;

        public class LogEvents : EventArgs
        {
            public string Message { get; set; }
            public OutputType Output { get; set; }
            public LogLevel LogLevel { get; set; } = LogLevel.Normal;
        }

        /// <summary>
        /// When a message has been sent to the Output() function
        /// </summary>
        /// <param name="e">LogEvent args containing the output message</param>
        public void OnMessageLogged(LogEvents e)
        {
            EventHandler<LogEvents> handler = MessageLogged;
            if (handler != null)
                handler(this, e);
        }

        #endregion

        public static void Log(int number) => Log(number.ToString(), LogLevel.Normal, OutputType.Console);
        public static void Log(int number, LogLevel logLevel) => Log(number.ToString(), logLevel, OutputType.Console);
        public static void Log(int number, OutputType outputType) => Log(number.ToString(), LogLevel.Normal, outputType);

        public static void Log(string text) => Log(text, LogLevel.Normal, OutputType.Console);
        public static void Log(string text, LogLevel logLevel) => Log(text, logLevel, OutputType.Console);
        public static void Log(string text, OutputType outputType) => Log(text, LogLevel.Normal, outputType);

        /// <summary>
        /// Passes message to OnMessageLogged for Event Handling.
        /// </summary>
        /// <param name="text">Message to output to user</param>
        public static void Log(string text, LogLevel logLevel, OutputType output)
        {
            LogEvents args = new LogEvents();
            args.Output = output;
            args.Message = ">> " + text + Environment.NewLine;
            Instance.OnMessageLogged(args);
        }
    }
}