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
    public class ToDoServices:IToDo
    {
        private readonly IToDoRepos todorepos;
        public ToDoServices(IToDoRepos todorepos)
        {
            this.todorepos = todorepos;
        }

        public List<ToDo> GetToDo()
        {
           return todorepos.GetToDo();
        }

        public List<ToDo> ToDoByUserId(GetToDoByUserID gettodo)
        {
            return todorepos.ToDoByUserId(gettodo);
        }
    }
}
