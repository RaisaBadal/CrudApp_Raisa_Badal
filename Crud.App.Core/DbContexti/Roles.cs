using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crud.App.Core.DbContexti
{
    public class Roles:IdentityRole<int>
    {
        public Roles(string text):base(text)
        {

        }
        public Roles()
        {

        }

    }
}
