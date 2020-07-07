using SampleMyApp.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SampleMyApp
{
    public class WebRequestManager
    {
        IRestService restService;

        public WebRequestManager(IRestService service)
        {
            restService = service;
        }

        public Task<List<PostData>> GetPostAsync()
        {
            return restService.FetchPostDataAsync();
        }
        public Task<List<CommentsData>> GetCommentsAsync()
        {
            return restService.FetchCommentsDataAsync();
        }


    }
}
