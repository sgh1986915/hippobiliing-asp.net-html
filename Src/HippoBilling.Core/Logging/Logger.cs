using log4net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HippoBilling.Core.Logging
{
    public abstract class Logger
    {
         protected readonly ILog log;

         private static readonly Logger _errorLogger;
         private static readonly Logger _debugLogger;
        public static Logger Error
        {
            get { return _errorLogger; }
        }
        public static Logger Debug
        {
            get { return _debugLogger; }
        }

        protected Logger(ILog log)
        {
            this.log = log;
        }

        static Logger()
        {
            log4net.Config.XmlConfigurator.Configure();
            _errorLogger = new ErrorLogger(LogManager.GetLogger("logerror"));
            _debugLogger = new DebugLogger(LogManager.GetLogger("logdebug"));
        }

        public abstract void Log(object message);

        public abstract void Log(object message, System.Exception exception);
    }

    internal class ErrorLogger : Logger
    {
        internal ErrorLogger(ILog log):base(log)
        { }
        public override void Log(object message)
        {
            log.Error(message);
        }

        public override void Log(object message, System.Exception exception)
        {
            log.Error(message, exception);
        }
    }

    internal class DebugLogger : Logger
    {
        internal DebugLogger(ILog log)
            : base(log)
        { }
        public override void Log(object message)
        {
            log.Debug(message);
        }

        public override void Log(object message, System.Exception exception)
        {
            log.Debug(message, exception);
        }
    }
}
