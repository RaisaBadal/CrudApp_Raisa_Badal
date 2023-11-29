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
    public class ToDoServiceRepos:IToDoRepos
    {
        public readonly DbRaisa dbraisa;
        public readonly IErrorRepos errorRepos;
        public readonly ILogRepos logRepos;
        public ToDoServiceRepos(DbRaisa dbraisa, IErrorRepos errorRepos,ILogRepos logRepos)
        {
            this.dbraisa = dbraisa;
            this.errorRepos = errorRepos;
            this.logRepos = logRepos;
        }
        #region GetToDo
          public List<ToDo> GetToDo()
        {
            return dbraisa.ToDos.ToList();
        }
        #endregion

        #region GetToDoByUserId
         public List<ToDo> ToDoByUserId(GetToDoByUserID gettodo)
          {
            try
            {
                var todo = dbraisa.ToDos.Where(i => i.UserId == gettodo.UserID).ToList();
                if (todo == null)
                {
                    errorRepos.Action("No ToDo for This User", ErrorEnums.None);
                }
                return todo;
            }
            catch (Exception ex)
            {
                errorRepos.Action(ex.Message+" "+ex.StackTrace, ErrorEnums.None);
                throw;
            }
          
           }
        #endregion
    }
}
