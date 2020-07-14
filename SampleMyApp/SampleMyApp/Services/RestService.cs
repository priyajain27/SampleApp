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
using SampleMyApp.Utility;

namespace SampleMyApp.Services
{
    public class RestService : IRestService
    {
        HttpClient client;

        public List<PostData> DataPost { get; private set; }
        public List<CommentData> DataComment { get; private set; }

        public RestService()
        {
            client = new HttpClient();
        }

        public async Task<List<PostData>> FetchPostListAsync()
        {
            DataPost = new List<PostData>();

            try
            {
                string _url = string.Format(Constants.PostDataUrl, string.Empty);
                HttpResponseMessage response = await client.GetAsync(_url);


                if (response.IsSuccessStatusCode)
                {
                    string content = await response.Content.ReadAsStringAsync();
                    DataPost = JsonConvert.DeserializeObject<List<PostData>>(content);
                }
                /*  var request = (HttpWebRequest)WebRequest.Create(_url);

                    /request.Method = "GET";
                    request.ContentType = "application/x-www-form-urlencoded";
                    using (WebResponse response = await request.GetResponseAsync())
                    {
                        var responseStream = new StreamReader(response.GetResponseStream()).ReadToEnd();
                        DataPost = JsonConvert.DeserializeObject<List<PostData>>(responseStream);

                    }*/
            }
            catch (Exception ex)
            {
                Debug.WriteLine(@"\tERROR {0}", ex.Message);

            }
            return DataPost;
        }
        public async Task SavePostAsync(PostData item, bool isNewItem = false)
        {
            Uri uri = new Uri(string.Format(Constants.PostDataUrl, string.Empty));

            try
            {
                string json = JsonConvert.SerializeObject(item);
                StringContent content = new StringContent(json, Encoding.UTF8, "application/json");

                HttpResponseMessage response = null;
                if (isNewItem)
                {
                    response = await client.PostAsync(uri, content);
                }
                else
                {
                    response = await client.PutAsync(uri, content);
                }

                if (response.IsSuccessStatusCode)
                {
                    
                    Debug.WriteLine(@"\t successfully saved.");
                }

            }
            catch (Exception ex)
            {
                Debug.WriteLine(@"\tERROR {0}", ex.Message);
            }
        }

        public async Task DeletePostAsync(int id)
        {
            Uri uri = new Uri(string.Format(Constants.PostDataUrl, id));

            try
            {
                HttpResponseMessage response = await client.DeleteAsync(uri);

                if (response.IsSuccessStatusCode)
                {
                    Debug.WriteLine(@"\t successfully deleted.");
                }

            }
            catch (Exception ex)
            {
                Debug.WriteLine(@"\tERROR {0}", ex.Message);
            }
        }
        public async Task<List<CommentData>> FetchCommentListAsync()
        {
            DataComment = new List<CommentData>();

            try
            {
                string _url = string.Format(Constants.CommentsDataUrl, string.Empty);
                HttpResponseMessage response = await client.GetAsync(_url);


                if (response.IsSuccessStatusCode)
                {
                    string content = await response.Content.ReadAsStringAsync();
                    DataComment = JsonConvert.DeserializeObject<List<CommentData>>(content);
                }
                
                
            }
            catch (WebException ex)
            {
                Debug.WriteLine(@"\tERROR {0}", ex.Message);

            }
            return DataComment;
        }

        public async Task SaveCommentAsync(CommentData item, bool isNewItem = false)
        {
            Uri uri = new Uri(string.Format(Constants.CommentsDataUrl, string.Empty));

            try
            {
                string json = JsonConvert.SerializeObject(item);
                StringContent content = new StringContent(json, Encoding.UTF8, "application/json");

                HttpResponseMessage response = null;
                if (isNewItem)
                {
                    response = await client.PostAsync(uri, content);
                }
                else
                {
                    response = await client.PutAsync(uri, content);
                }

                if (response.IsSuccessStatusCode)
                {
                    Debug.WriteLine(@"\ successfully saved.");
                }

            }
            catch (Exception ex)
            {
                Debug.WriteLine(@"\tERROR {0}", ex.Message);
            }
        }

        public async Task DeleteCommentAsync(int id)
        {
            Uri uri = new Uri(string.Format(Constants.CommentsDataUrl, id));

            try
            {
                HttpResponseMessage response = await client.DeleteAsync(uri);

                if (response.IsSuccessStatusCode)
                {
                    Debug.WriteLine(@"\ successfully deleted.");
                }

            }
            catch (Exception ex)
            {
                Debug.WriteLine(@"\tERROR {0}", ex.Message);
            }
        }
    }
}
