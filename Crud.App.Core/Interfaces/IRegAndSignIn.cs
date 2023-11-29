﻿using Crud.App.DataSource.ResponceAndRequest;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crud.App.Core.Interfaces
{
    public interface IRegAndSignIn
    {
        Task<bool>RegistrationManager(InsertManager signUp);
        Task<string> SignIn(GetManagerAuthent manAuth);
        bool getalldatafromresource();
    }

}
