using SampleMyApp.Models;
using SampleMyApp.Services;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SampleMyApp.Utility
{
    public class WebRequestManager
    {
       private IRestService _restService;
       
        public WebRequestManager(IRestService service=null)
        {
            _restService = service?? new RestService();
        }
        // better to use below if use any dependency injection framework in app
        /*public WebRequestManager(IRestService service)
        {
            _restService = service;
        }*/

        public Task<List<PostData>> GetPostAsync()
        {
            return _restService.FetchPostListAsync();
        }
        public Task SavePostAsync(PostData item, bool isNewItem = false)
        {
            return _restService.SavePostAsync(item, isNewItem);
        }
        public Task DeletePostAsync(PostData data)
        {
            return _restService.DeletePostAsync(data.id);
        }
        public Task<List<CommentData>> GetCommentsAsync()
        {
            return _restService.FetchCommentListAsync();
        }
        public Task SaveCommentAsync(CommentData item, bool isNewItem = false)
        {
            return _restService.SaveCommentAsync(item, isNewItem);
        }
        public Task DeleteCommentAsync(CommentData data)
        {
            return _restService.DeleteCommentAsync(data.id);
        }

    }
}
