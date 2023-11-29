using Crud.App.Core.DbContexti;
using Crud.App.Core.Interfaces;
using Crud.App.Core.Models;
using Crud.App.DataSource.Enums;
using Crud.App.DataSource.ResponceAndRequest;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crud.App.Infrastructure.Repositories
{
    public class PostAndCommentServiceRepos:IPostAndCommentRepos
    {
        private readonly DbRaisa dbraisa;
        private readonly IErrorRepos errorRepos;
        private readonly ILogRepos logRepos;
        public PostAndCommentServiceRepos(DbRaisa dbraisa, IErrorRepos errorRepos, ILogRepos logRepos)
        {
            this.dbraisa = dbraisa;
            this.errorRepos = errorRepos;
            this.logRepos = logRepos;
        }

        #region GetAllPost
        public List<Post> GetAllPost()
        {
            return dbraisa.Posts.ToList();
        }
        #endregion

        #region GetAllCommentsByPostID
        public List<Comment> GetAllCommentsByPostID(CommentByPostId commentbypostID)
        {
            try
            {
                var comment = dbraisa.Comments.Where(i => i.PostID == commentbypostID.PostId).ToList();
                return comment;
            }
            catch (Exception ex)
            {
                errorRepos.Action(ex.StackTrace + " " + ex.Message, ErrorEnums.Fatal);
                throw;
            }
        }
        #endregion

        #region GetPostByUserID
        public List<Post> GetPostByUserID(PostByUserId userid)
        {
            try
            {
                var post = dbraisa.Posts.Where(i => i.UserID == userid.UserId).ToList();
                return post;
            }
            catch (Exception ex)
            {
                errorRepos.Action(ex.Message, ErrorEnums.Fatal);
                throw;
            }
        }
        #endregion
    }
}
