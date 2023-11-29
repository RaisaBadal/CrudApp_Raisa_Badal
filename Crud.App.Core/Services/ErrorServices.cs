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
    public class ErrorServices:IError
    {
        private readonly IErrorRepos errorRepos;
        public ErrorServices(IErrorRepos errorRepos)
        {
            this.errorRepos = errorRepos;
        }

        public List<Error> GetAllError()
        {
           return errorRepos.GetAllError();
        }

        public List<Error> GetAllErrorsBetWeenDate(ErrorBetweenData errorbetweendate)
        {
            return errorRepos.GetAllErrorsBetWeenDate(errorbetweendate);
        }
    }
}
