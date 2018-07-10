using Renci.SshNet;
using Renci.SshNet.Sftp;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SFTP
{
    class Program
    {
        static void Main(string[] args)
        {
            /*string host = @"ocxtransfer.oceanx.com";
            string username = "BI_OCEAN_MEDIA_TPC";
            string password = "Tacocat17";
            string remoteDirectory = "/WEB_DATA/";
            string localDirectory = @"C:\Users\tathagat.dwivedi\Downloads\";
            */
            string host = @args[0];
            string username = args[1];
            string password = args[2];
            string remoteDirectory = args[3]; ;
            string localDirectory = args[4]; ;
            
            using (var sftp = new SftpClient(host, username, password))
            {
                sftp.Connect();
                IEnumerable<SftpFile> sftpFiles = sftp.ListDirectory(remoteDirectory);
                foreach (SftpFile sftpFile in sftpFiles)
                {
                    string remoteFileName = sftpFile.Name;
                    if (!sftpFile.Name.StartsWith("."))
                    {
                        using (Stream fileStream = File.OpenWrite(localDirectory + remoteFileName))
                        {
                            sftp.DownloadFile(remoteDirectory + remoteFileName, fileStream);
                        }
                      //  sftp.DeleteFile(remoteDirectory + remoteFileName);
                    }
                }
            }

        }
    }
}
