using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace CMDLauncher.Utils
{
    public class DownloadUtils
    {

    }

    public class DownloadTask : Task
    {
        public string Url;
        public string Filename;
        public bool ForceDownload;

        public DownloadTask(string Url, string Filename, bool ForceDownload = true) : base("Download " + Path.GetFileName(Filename))
        {
            this.Url = Url;
            this.Filename = Filename;
            this.ForceDownload = ForceDownload;
        }

        public override bool CanBeThreaded()
        {
            return true;
        }

        public override bool CanDoMultiTasking()
        {
            return true;
        }

        public override bool RequiresInternetConnection()
        {
            return true;
        }

        private HttpWebRequest request;
        private IAsyncResult _responseAsyncResult;

        private void ResponseCallback(object state)
        {
            var response = request.EndGetResponse(_responseAsyncResult) as HttpWebResponse;
            long contentLength = response.ContentLength;
            if (contentLength == -1)
            {
                // You'll have to figure this one out.
            }
            Stream responseStream = response.GetResponseStream();
            GetContentWithProgressReporting(responseStream, contentLength);
            response.Close();
        }

        private byte[] GetContentWithProgressReporting(Stream responseStream, long contentLength)
        {
            if (bar != null)
                bar.StartStep((int) contentLength);

            // Allocate space for the content
            var data = new byte[contentLength];
            int currentIndex = 0;
            int bytesReceived = 0;
            var buffer = new byte[256];
            do
            {
                bytesReceived = responseStream.Read(buffer, 0, 256);
                Array.Copy(buffer, 0, data, currentIndex, bytesReceived);
                currentIndex += bytesReceived;

                // Report percentage
                if (bar != null)
                    bar.SetProgress(currentIndex);
            } while (currentIndex < contentLength);

            if (bar != null)
                bar.FinishStep();
            return data;
        }

        private IProgressBar bar;

        protected override bool RunTask(IProgressBar bar)
        {
            if (!ForceDownload && File.Exists(Filename))
            {
                if (new FileInfo(Filename).Length > 0)
                    return true;
            }

            if (File.Exists(Filename) && new FileInfo(Filename).IsReadOnly)
            {
                logger.LogLastLine("{0} cannot be overwritten!", Path.GetFileName(Filename));
                return false;
            }

            this.bar = bar;

            request = HttpWebRequest.CreateHttp(Url);
            request.UserAgent = "Mozilla/5.0";
            request.AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate;
            _responseAsyncResult = request.BeginGetResponse(ResponseCallback, null);

            int tries = 0;

            while (tries < 6)
            {
                try
                {
                    HttpWebResponse response = (HttpWebResponse) request.GetResponse();
                    using (Stream stream = response.GetResponseStream())
                    using (StreamReader reader = new StreamReader(stream))
                    {
                        File.WriteAllText(Filename, reader.ReadToEnd());
                        logger.LogLastLine("Downloaded {0} successfully", Path.GetFileName(Filename));
                        this.bar = null;
                        return true;
                    }
                }
                catch (WebException)
                {
                    tries++;
                }
                catch(Exception e)
                {
                    logger.Log("Failed to download file url={0}, path{1}. Exception: {2}", Url, Filename, e);
                    this.bar = null;
                    return false;
                }
            }

            logger.Log("Could not to download file url={0}, path{1}.", Url, Filename);
            this.bar = null;
            return false;
        }
    }
}
