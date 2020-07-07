using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using SampleMyApp.Models;
using TodoREST;

namespace SampleMyApp
{
    public class RestService : IRestService
    {

        public List<PostData> DataPost { get; private set; }
        public List<CommentsData> DataComments { get; private set; }

        public RestService()
        {
        }

        public async Task<List<PostData>> FetchPostDataAsync()
        {
            DataPost = new List<PostData>();

            try
            {
                string _url = string.Format(Constants.PostDataUrl, string.Empty);

                var request = (HttpWebRequest)WebRequest.Create(_url);
                request.Method = "GET";
                request.ContentType = "application/x-www-form-urlencoded";
                using (WebResponse response = await request.GetResponseAsync())
                {
                    var responseStream = new StreamReader(response.GetResponseStream()).ReadToEnd();
                    DataPost = JsonConvert.DeserializeObject<List<PostData>>(responseStream);
                }

            }
            catch (WebException ex)
            {
                Debug.WriteLine(@"\tERROR {0}", ex.Message);

            }
            return DataPost;
        }
        public async Task<List<CommentsData>> FetchCommentsDataAsync()
        {
            DataComments = new List<CommentsData>();

            try
            {
                string _url = string.Format(Constants.CommentsDataUrl, string.Empty);

                var request = (HttpWebRequest)WebRequest.Create(_url);
                request.Method = "GET";
                request.ContentType = "application/x-www-form-urlencoded";
                using (WebResponse response = await request.GetResponseAsync())
                {
                    var responseStream = new StreamReader(response.GetResponseStream()).ReadToEnd();
                    DataComments = JsonConvert.DeserializeObject<List<CommentsData>>(responseStream);
                }

            }
            catch (WebException ex)
            {
                Debug.WriteLine(@"\tERROR {0}", ex.Message);

            }
            return DataComments;
        }


    }
}
