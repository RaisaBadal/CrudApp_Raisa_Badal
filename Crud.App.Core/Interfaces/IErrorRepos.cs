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
    public interface IErrorRepos
    {
        List<Error> GetAllError();
        List<Error> GetAllErrorsBetWeenDate(ErrorBetweenData errorbetweendate);
        void Action(string mesage, ErrorEnums type);
    }
}
