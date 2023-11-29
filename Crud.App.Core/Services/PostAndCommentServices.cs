using Crud.App.Core.Interfaces;
using Crud.App.Core.Models;
using Crud.App.DataSource.ResponceAndRequest;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crud.App.Core.Services
{
    public class PostAndCommentServices:IPostAndComment
    {
        private readonly IPostAndCommentRepos postcomRepo;
        public PostAndCommentServices(IPostAndCommentRepos postcomRepo)
        {
            this.postcomRepo = postcomRepo;
        }

        public List<Comment> GetAllCommentsByPostID(CommentByPostId commentbyId)
        {
            return postcomRepo.GetAllCommentsByPostID(commentbyId);
        }

        public List<Post> GetAllPost()
        {
           return postcomRepo.GetAllPost();
        }

        public List<Post> GetPostByUserID(PostByUserId userid)
        {
            return postcomRepo.GetPostByUserID(userid);
        }
    }
}
