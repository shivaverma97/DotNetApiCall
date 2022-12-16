using System;
using System.IO;
using System.Net;
using System.Text;

namespace KoreAiApiCall
{
    internal class Program
    {
        static void Main()
        {
            //add function call before running
        }

        public void PostApiCallThroughJsonBody()
        {
            try
            {
                string url = "https://localhost:7230/api/KoreAiCustomerInformation";
                var httpWebRequest = (HttpWebRequest)WebRequest.Create(url);
                httpWebRequest.ContentType = "application/json";
                httpWebRequest.Method = "POST";

                Encoding encoding = new UTF8Encoding();

                string json = "{\"customerName\":\"test\"," +
                                  "\"customerEmail\":\"bla\"," +
                                  "\"customerPhoneNo\":98," +
                                  "\"customerAge\":21," +
                                  "\"customerGender\":\"bla\"}";

                byte[] data = encoding.GetBytes(json);

                Stream stream = httpWebRequest.GetRequestStream();
                stream.Write(data, 0, data.Length);
                stream.Close();

                Console.WriteLine(json);

                var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
                using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
                {
                    var result = streamReader.ReadToEnd();
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public void PostApiCallThroughQueryParams()
        {
            try
            {
                string url = "https://localhost:7230/api/KoreAiCustomerInformation?customerId=4&emailId=test%40mail.com";
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
                request.AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate;
                request.Method = "Post";
                using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
                using (Stream stream = response.GetResponseStream())
                using (StreamReader reader = new StreamReader(stream))
                {
                    reader.ReadToEnd();
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}