using System;
using log4net;
using System.IO;
using System.Reflection;
using System.Web.Http.ExceptionHandling;

namespace IPTMPortal.Logger
{
    public class ExceptionManagerApi : ExceptionLogger
    {
        ILog _logger = null;
        public ExceptionManagerApi()
        {
            // Gets directory path of the calling application  
            // RelativeSearchPath is null if the executing assembly i.e. calling assembly is a  
            // stand alone exe file (Console, WinForm, etc).   
            // RelativeSearchPath is not null if the calling assembly is a web hosted application i.e. a web site  
            var log4NetConfigDirectory = AppDomain.CurrentDomain.RelativeSearchPath ?? AppDomain.CurrentDomain.BaseDirectory;

            var log4NetConfigFilePath = Path.Combine(log4NetConfigDirectory, "log4net.config");  
           // var log4NetConfigFilePath = "c:\\users\\user\\documents\\visual studio 2012\\Projects\\ErrorLogingDummy\\ErrorLogingDummy\\ExLogger\\log4net.config";
            log4net.Config.XmlConfigurator.ConfigureAndWatch(new FileInfo(log4NetConfigFilePath));
        }
        public override void Log(ExceptionLoggerContext context)
        {
            _logger = log4net.LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
            _logger.Error(context.Exception.ToString() + Environment.NewLine);
            //_logger.Error(Environment.NewLine +" Excetion Time: " + System.DateTime.Now + Environment.NewLine  
            //    + " Exception Message: " + context.Exception.Message.ToString() + Environment.NewLine  
            //    + " Exception File Path: " + context.ExceptionContext.ControllerContext.Controller.ToString() + "/" + context.ExceptionContext.ControllerContext.RouteData.Values["action"] + Environment.NewLine);   
        }
        public void Log(string ex)
        {
            _logger = log4net.LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
            _logger.Error(ex);
            //_logger.Error(Environment.NewLine +" Excetion Time: " + System.DateTime.Now + Environment.NewLine  
            //    + " Exception Message: " + context.Exception.Message.ToString() + Environment.NewLine  
            //    + " Exception File Path: " + context.ExceptionContext.ControllerContext.Controller.ToString() + "/" + context.ExceptionContext.ControllerContext.RouteData.Values["action"] + Environment.NewLine);   
        }

    }
}
