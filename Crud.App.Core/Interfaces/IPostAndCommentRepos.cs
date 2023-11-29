using Crud.App.Core.DbContexti;
using Crud.App.Core.Models;
using Crud.App.DataSource.Enums;
using Crud.App.DataSource.ResponceAndRequest;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crud.App.Core.Interfaces
{
    public interface IPostAndCommentRepos
    {
        List<Post> GetAllPost();
        List<Comment> GetAllCommentsByPostID(CommentByPostId commentbyId);
        List<Post> GetPostByUserID(PostByUserId userid);



    }
}
