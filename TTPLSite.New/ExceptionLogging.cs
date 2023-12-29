using Microsoft.AspNetCore.Hosting;
using System;
using System.IO;
using System.Reflection;
using System.Text;

namespace TTPLSite.New
{

    public interface IExceptionLogging
    {
        void WriteError(Exception ex);
    }
    public class ExceptionLogging : IExceptionLogging
    {
        IWebHostEnvironment _hostingEnvironment { get; set; }
        public ExceptionLogging(IWebHostEnvironment hostingEnvironment)
        {
            _hostingEnvironment = hostingEnvironment;
        }
        public void WriteError(Exception ex)
        {
            //string webRootPath = _hostingEnvironment.WebRootPath;
            //string contentRootPath = _hostingEnvironment.ContentRootPath;
            try
            {
                string filepath = Path.GetDirectoryName(Assembly.GetEntryAssembly().Location) + "\\error";  //Text File Path

                if (!Directory.Exists(filepath))
                {
                    Directory.CreateDirectory(filepath);
                }
                filepath = Path.Combine(filepath, DateTime.Today.ToString("dd-MM-yyyy") + ".txt");   //Text File Name
                if (!File.Exists(filepath))
                {
                    File.Create(filepath).Dispose();
                }
                using (StreamWriter sw = File.AppendText(filepath))
                {
                    StringBuilder stringBuilder = new StringBuilder();
                    stringBuilder.AppendLine("-----------Exception Details on " + " " + DateTime.Now.ToString() + "-----------------");
                    stringBuilder.AppendLine($"Message: {ex.Message} ");
                    stringBuilder.AppendLine($"Source: {ex.Source} ");
                    stringBuilder.AppendLine($"HelpLink: {ex.HelpLink} ");
                    stringBuilder.AppendLine($"StackTrace: {ex.StackTrace} ");
                    stringBuilder.AppendLine($"GetType(): {ex.GetType()} ");
                    stringBuilder.AppendLine($"GetType().Name: {ex.GetType().Name}");

                    if (ex.InnerException != null)
                    {
                        stringBuilder.AppendLine("\nInner Exception Details: ");
                        stringBuilder.AppendLine($"Inner Exception Message: {ex.InnerException.Message} ");
                        stringBuilder.AppendLine($"Inner Exception Source: {ex.InnerException.Source} ");
                        stringBuilder.AppendLine($"Inner Exception StackTrace: {ex.InnerException.StackTrace} ");
                    }
                    stringBuilder.AppendLine("-------------------------------------------------------------------------------------");

                    sw.Write(stringBuilder.ToString());
                    sw.Flush();
                    sw.Close();
                }
            }
            catch (Exception e)
            {
                e.ToString();
            }
        }

    }
}
