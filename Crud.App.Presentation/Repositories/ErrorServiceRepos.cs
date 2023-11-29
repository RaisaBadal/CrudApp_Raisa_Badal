using Crud.App.Core.DbContexti;
using Crud.App.Core.Interfaces;
using Crud.App.Core.Models;
using Crud.App.DataSource.Enums;
using Crud.App.DataSource.ResponceAndRequest;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.JavaScript;
using System.Text;
using System.Threading.Tasks;

namespace Crud.App.Presentation.Repositories
{
    public class ErrorServiceRepos:IErrorRepos
    {
        private readonly DbRaisa dbraisa;
        public ErrorServiceRepos(DbRaisa dbraisa)
        {
            this.dbraisa = dbraisa;
        }

        #region Action
        public void Action(string mesage, ErrorEnums type)
        {
            //funqcia romelic chawers bazashi ra errori moxda
            if (mesage != null)
            {
                dbraisa.Errors.Add(new Error()
                {
                    ErrorType = type,
                    TimeofOccured = DateTime.Now,
                    Text = mesage
                });
                dbraisa.SaveChanges();
            }
        }
        #endregion

        #region GetAllErrors
        public List<Error> GetAllError()
        {
            //error cxrilshi chawerili yvela chanaweris dabruneba
             return dbraisa.Errors.ToList();
        }
        #endregion

        #region GetAllErrorsBetweenDate
        public List<Error> GetAllErrorsBetWeenDate(ErrorBetweenData errorbetweendate)
        {
            //mocemul drois shualedshi momxdari errorebis wamogheba
            return dbraisa.Errors.Where(i => i.TimeofOccured >= errorbetweendate.StartDate && i.TimeofOccured <= errorbetweendate.EndDate).ToList();
        }

  

        #endregion
    }
}
