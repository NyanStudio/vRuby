using System;
using System.IO;
using System.Text;

namespace tw.nyan.vRuby.StandardLibrary
{
    public class Logger
    {
        #region Public Const Variables

        public const int DEBUG = 0;
        public const int INFO = 1;
        public const int WARN = 2;
        public const int ERROR = 3;
        public const int FATAL = 4;
        public const int UNKNOWN = 5;

        #endregion

        #region Local Varibles

        private Formatter default_formatter;

        #endregion

        #region Public Properties

        public Formatter formatter { get; set; }

        public int level { get; set; }

        public string logdev { get; set; }

        public string progname { get; set; }

        #endregion

        #region Constructors

        public Logger(string logdev)
        {
            this.progname = null;
            this.level = DEBUG;
            this.default_formatter = new Formatter();
            this.formatter = null;
            this.logdev = null;

            if (!string.IsNullOrEmpty(logdev))
                this.logdev = logdev;
        }

        #endregion

        #region Local Methods

        private string format_message(string severity, DateTime datetime, string progname, Exception msg)
        {
            if (this.formatter == null)
                return this.default_formatter.call(severity, datetime, progname, msg);
            else
                return this.formatter.call(severity, datetime, progname, msg);
        }

        private string format_message(string severity, DateTime datetime, string progname, string msg)
        {
            if (this.formatter == null)
                return this.default_formatter.call(severity, datetime, progname, msg);
            else
                return this.formatter.call(severity, datetime, progname, msg);
        }

        private string format_severity(int severity)
        {
            if (severity == 0)
                return "DEBUG";
            else if (severity == 1)
                return "INFO";
            else if (severity == 2)
                return "WARN";
            else if (severity == 3)
                return "ERROR";
            else if (severity == 4)
                return "FATAL";
            else
                return "UNKNOWN";
        }

        #endregion

        #region Public Methods

        public void add(int severity, Exception message, string progname)
        {
            if (string.IsNullOrEmpty(this.logdev) || severity < this.level)
                return;

            if (progname == null)
                progname = this.progname;

            using (StreamWriter w = File.AppendText(this.logdev))
            {
                w.WriteLine(format_message(format_severity(severity), DateTime.Now, progname, message));
                w.Close();
            }
        }

        public void add(int severity, string message, string progname)
        {
            if (string.IsNullOrEmpty(this.logdev) || severity < this.level)
                return;

            if (progname == null)
                progname = this.progname;

            using (StreamWriter w = File.AppendText(this.logdev))
            {
                w.WriteLine(format_message(format_severity(severity), DateTime.Now, progname, message));
                w.Close();
            }
        }

        public void debug(Exception message, string progname)
        {
            add(DEBUG, message, progname);
        }

        public void debug(string message, string progname)
        {
            add(DEBUG, message, progname);
        }

        public void info(Exception message, string progname)
        {
            add(INFO, message, progname);
        }

        public void info(string message, string progname)
        {
            add(INFO, message, progname);
        }

        public void warn(Exception message, string progname)
        {
            add(WARN, message, progname);
        }

        public void warn(string message, string progname)
        {
            add(WARN, message, progname);
        }

        public void error(Exception message, string progname)
        {
            add(ERROR, message, progname);
        }

        public void error(string message, string progname)
        {
            add(ERROR, message, progname);
        }

        public void fatal(Exception message, string progname)
        {
            add(FATAL, message, progname);
        }

        public void fatal(string message, string progname)
        {
            add(FATAL, message, progname);
        }

        public void unknown(Exception message, string progname)
        {
            add(UNKNOWN, message, progname);
        }

        public void unknown(string message, string progname)
        {
            add(UNKNOWN, message, progname);
        }

        #endregion

        public class Formatter
        {
            public string datetime_format { get; set; }

            public Formatter()
            {
                this.datetime_format = null;
            }

            #region Local Methods

            private string format_datetime(DateTime time)
            {
                if (this.datetime_format == null)
                    return time.ToString("yyyy-MM-dd HH:mm:ss.ffffff");
                else
                    return time.ToString(@datetime_format);
            }

            private string msg2str(Exception msg)
            {
                return string.Format("{0}\n{1}\n", msg.Message, msg.StackTrace);
            }

            #endregion

            #region Public Methods

            public string call(string severity, DateTime time, string progname, Exception msg)
            {
                return call(severity, time, progname, msg2str(msg));
            }

            public string call(string severity, DateTime time, string progname, string msg)
            {
                return string.Format("{0}, [{1}] {2} -- {3}: {4}",
                    severity.Substring(0, 1), format_datetime(time), severity, progname, msg);
            }

            #endregion
        }
    }
}
