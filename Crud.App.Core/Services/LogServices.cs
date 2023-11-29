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
    public class LogServices:ILog
    {
        private readonly ILogRepos logrepos;
        public LogServices(ILogRepos logrepos)
        {
            this.logrepos = logrepos;
        }

        public List<Log> GetAllLogs()
        {
            return logrepos.GetAllLogs();
        }

        public List<Log> GetAllLogsBetweenDate(LogsBetweenDate logsbetweendate)
        {
            return logrepos.GetAllLogsBetweenDate(logsbetweendate);
        }
    }
}
