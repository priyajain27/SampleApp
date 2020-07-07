using SampleMyApp.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using TodoREST;

namespace SampleMyApp
{
    public interface IRestService
    {
        Task<List<PostData>> FetchPostDataAsync();
        Task<List<CommentsData>> FetchCommentsDataAsync();

    }
}
