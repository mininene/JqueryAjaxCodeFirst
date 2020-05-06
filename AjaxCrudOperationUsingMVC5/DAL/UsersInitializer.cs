using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AjaxCrudOperationUsingMVC5.DAL
{
    public class UsersInitializer : System.Data.Entity.DropCreateDatabaseAlways<UsersContext>
    {
        protected override void Seed(UsersContext context)
        {
            { }
        }
    }
}