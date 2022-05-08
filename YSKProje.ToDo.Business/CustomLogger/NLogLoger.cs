using NLog;
using System;
using System.Collections.Generic;
using System.Text;
using YSKProje.ToDo.Business.Interfaces;

namespace YSKProje.ToDo.Business.CustomLogger
{
    public class NLogLoger : ICustomLogger
    {
        public void LogError( string message)
        {
          Logger  logger=  LogManager.GetLogger("loggerFile");
            logger.Log(LogLevel.Error, message);
        }
    }
}
