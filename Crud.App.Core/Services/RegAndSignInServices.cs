using Crud.App.Core.Interfaces;
using Crud.App.DataSource.ResponceAndRequest;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crud.App.Core.Services
{
    public class RegAndSignInServices:IRegAndSignIn
    {
        private readonly IRegAndSignInRepos regandsignin;
        public RegAndSignInServices(IRegAndSignInRepos regandsignin)
        {
            this.regandsignin = regandsignin;
        }

        public bool getalldatafromresource()
        {
            return regandsignin.getalldatafromresource();
        }

        public Task<bool> RegistrationManager(InsertManager signUp)
        {
            return regandsignin.RegistrationManager(signUp);
        }

        public Task<string> SignIn(GetManagerAuthent manAuth)
        {
         return regandsignin.SignIn(manAuth);   
        }
    }
}
