using SampleMyApp.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace SampleMyApp.ViewModels
{
    public class PostDetailsViewModel
    {
        public PostData SelectedPost{ get; set; }
        public ObservableCollection<CommentData> CommentsList { get; set; } = null;
        public ICommand OnAddCommand { get; set; } = null;

        public ICommand OnDeleteCommand => new Command<CommentData>(DeleteComment);

        public PostDetailsViewModel(PostData item = null)
        {
            CommentsList = new ObservableCollection<CommentData>();
            SelectedPost = item;
            OnAddCommand = new Command<String>(AddComment);

            Task.Run(async () => { await FetchCommentsData(); }).Wait();


        }
        void DeleteComment(CommentData commentData)
        {
            if (CommentsList.Contains(commentData))
            {
                CommentsList.Remove(commentData);
            }
            App.RequestManager.DeleteCommentAsync(commentData);

        }
        async void AddComment(String comment) {
            var addedComment = new CommentData()
            {
                postId = SelectedPost.id,
                email = Application.Current.Properties["Email"].ToString(),
                body = comment,
                name= comment,


        };
            CommentsList.Add(addedComment);
            await App.RequestManager.SaveCommentAsync(addedComment,true);

        }
        public async Task FetchCommentsData()
        {
            List<CommentData> list = await App.RequestManager.GetCommentsAsync();

            foreach (var comment in list)
            {
                if (comment.postId== SelectedPost.id)
                    CommentsList.Add(comment);
            }
        }         

        }
    }

