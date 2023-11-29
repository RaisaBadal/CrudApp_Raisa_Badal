using Crud.App.Core.DbContexti;
using Crud.App.Core.Interfaces;
using Crud.App.Core.Models;
using Crud.App.DataSource.ResponceAndRequest;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crud.App.Presentation.Repositories
{
    public class LogServiceRepos:ILogRepos
    {
        public readonly DbRaisa dbraisa;
        public LogServiceRepos(DbRaisa dbraisa)
        {
            this.dbraisa= dbraisa;
        }

        #region ActionLog
        public void ActionLog(string message)
        {
            if (message != null)
            {
                dbraisa.Logs.Add(new Log
                {
                    LogText = message,
                    LogDate = DateTime.Now,
                });
                dbraisa.SaveChanges();
            }
        }
        #endregion

        #region GetAllLogs
        public List<Log> GetAllLogs()
        {
            return dbraisa.Logs.ToList();
        }
        #endregion

        #region GetAllLogsBetweenDate
        public List<Log> GetAllLogsBetweenDate(LogsBetweenDate logsbetweendate)
        {
            return dbraisa.Logs.Where(i => i.LogDate >= logsbetweendate.StartDate && i.LogDate <= logsbetweendate.EndDate).ToList();
        }
        #endregion


    }
}
