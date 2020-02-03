using Simplerjiang.SimpleHttpRequest.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Net;

namespace Simplerjiang.SimpleHttpRequest
{
    public class HttpWorker
    {
        internal static HttpResult HttpGet(string url)
        {
            HttpResult httpResult = new HttpResult();
            try
            {
                //ServicePointManager.ServerCertificateValidationCallback = new RemoteCertificateValidationCallback(CheckValidationResult);
                Encoding encoding = Encoding.UTF8;
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
                request.Method = "GET";
                request.Accept = "text/html, application/xhtml+xml, */*";
                request.ContentType = "application/json";
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                using (StreamReader reader = new StreamReader(response.GetResponseStream(), Encoding.UTF8))
                {
                    httpResult.result = reader.ReadToEnd();
                    httpResult.stat = response.StatusCode;
                    return httpResult;
                }
            }
            catch (Exception ex)
            {
                httpResult.errorMessage = ex.Message;
                httpResult.stat = HttpStatusCode.BadRequest;
                return httpResult;
            }
        }
        internal static HttpResult HttpPost(string url, string body)
        {
            HttpResult httpResult = new HttpResult();
            try
            {
                //ServicePointManager.ServerCertificateValidationCallback = new RemoteCertificateValidationCallback(CheckValidationResult);
                Encoding encoding = Encoding.UTF8;
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
                request.Method = "POST";
                request.Accept = "text/html, application/xhtml+xml, */*";
                request.ContentType = "application/json";

                byte[] buffer = encoding.GetBytes(body);
                request.ContentLength = buffer.Length;
                request.GetRequestStream().Write(buffer, 0, buffer.Length);
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                using (StreamReader reader = new StreamReader(response.GetResponseStream(), Encoding.UTF8))
                {
                    httpResult.result = reader.ReadToEnd();
                    httpResult.stat = response.StatusCode;
                    return httpResult;
                }
            }
            catch (Exception ex)
            {
                httpResult.errorMessage = ex.Message;
                httpResult.stat = HttpStatusCode.BadRequest;
                return httpResult;
            }
        }
    }
}
