using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Net;
using System.Threading;

namespace SendToFtp
{
    class Program
    {
        static void Main(string[] args)
        {

            string filePath = @"";
            string ftpUsername = "";
            string ftpUserPassword = "";
            string ftpServer = "";

            try
            {



            foreach (var parameter in args)
            {
                String shortParameter = parameter.Substring(0, 3);
                switch (shortParameter)
                {
                    case "/s:":
                        ftpServer = parameter.Substring(3);
                        break;
                    case "/u:":
                        ftpUsername = parameter.Substring(3);
                        break;
                    case "/p:":
                        ftpUserPassword = parameter.Substring(3);
                        break;
                    case "/f:":
                        filePath = parameter.Substring(3);
                        break;
                    default:
                        ftpServer = "";
                        break;
                }
            }
            if (filePath == "" || ftpUsername == "" || ftpUserPassword == "" || ftpServer == "")
            {
                StringBuilder sb = new StringBuilder();

                sb.AppendLine("Invalid use of parameters");
                sb.AppendLine();
                sb.AppendLine("   /s:(Server Adress)");
                sb.AppendLine("   /u:(Username)");
                sb.AppendLine("   /p:(Password)");
                sb.AppendLine("   /f:(FilePath) ");

                Console.WriteLine(sb);
            }
            else
            {
                string[] fileList = Directory.GetFiles(filePath);



                using (WebClient client = new WebClient())
                {
                    client.Credentials = new NetworkCredential(ftpUsername, ftpUserPassword);
                    Console.WriteLine(DateTime.Now);
                    Console.WriteLine("---");

                    foreach (var file in fileList)
                    {
                        string target = @"ftp://" + ftpServer + @"/" + Path.GetFileName(file);

                        Byte[] result = client.UploadFile(target, WebRequestMethods.Ftp.UploadFile, file);

                        Console.WriteLine(file);
                        Console.WriteLine(result.ToString());
                        Console.WriteLine(DateTime.Now);
                        Console.WriteLine("---");
                    }
                }
            }

            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);

                Thread.Sleep(3000);
            }
        }
    }
}
