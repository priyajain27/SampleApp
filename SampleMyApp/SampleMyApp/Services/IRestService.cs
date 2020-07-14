using SampleMyApp.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SampleMyApp.Services
{
    public interface IRestService
    {
        Task<List<PostData>> FetchPostListAsync();
        Task<List<CommentData>> FetchCommentListAsync();
        
        Task SavePostAsync(PostData item, bool isNewItem = false);
        Task DeletePostAsync(int id);

        Task SaveCommentAsync(CommentData item, bool isNewItem = false);
        Task DeleteCommentAsync(int id);
    }
}
