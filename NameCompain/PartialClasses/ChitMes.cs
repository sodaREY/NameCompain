using NameCompain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

namespace NameCompain.PartialClasses
{
    public partial class ChitMes
    {
        private user23Entities db = new user23Entities();

        public string GetInfo
        {
            get
            {
                var emp = db.Info.Where(i => i.login == Login.Text || i.password == Password.Text).FirstOfDefault();
                return Info;
            }
        }
    }
}