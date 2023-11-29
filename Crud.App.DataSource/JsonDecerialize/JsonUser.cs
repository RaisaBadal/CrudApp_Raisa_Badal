using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crud.App.DataSource.JsonDecerialize
{
    public class JsonUser
    {
        public int id { get; set; }
        public  string name { get; set; }
        public string username { get; set; }
        public string email { get; set; }

        public JsonAdrress JsonAdrress { get; set; }
        public JsonCompany jsoncompany { get; set; }
   
    }
}
