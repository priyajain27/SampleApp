using SampleMyApp.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SampleMyApp.ViewModels
{
    public class PostDetailsViewModel
    {
        public PostData SelectedPost{ get; set; }
        public List<CommentsData> CommentsList { get; set; } = null;

        public PostDetailsViewModel(PostData item = null)
        {
            CommentsList = new List<CommentsData>();
            SelectedPost = item;
            Task.Run(async () => { await FetchCommentsData(); }).Wait();


        }
        public async Task FetchCommentsData()
        {
            List<CommentsData> List = await App.RequestManager.GetCommentsAsync();
            foreach (var comment in List)
            {
                if (comment.postId== SelectedPost.id)
                    CommentsList.Add(comment);
            }
        }         

        }
    }

