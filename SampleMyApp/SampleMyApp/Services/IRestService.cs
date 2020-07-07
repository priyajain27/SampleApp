using SampleMyApp.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SampleMyApp.Utility
{
    public interface IRestService
    {
        Task<List<PostData>> FetchPostDataAsync();
        Task<List<CommentsData>> FetchCommentsDataAsync();

    }
}
