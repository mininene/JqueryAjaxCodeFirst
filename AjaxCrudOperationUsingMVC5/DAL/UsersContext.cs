using AjaxCrudOperationUsingMVC5.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace AjaxCrudOperationUsingMVC5.DAL
{
    public class UsersContext : DbContext
    {
        public UsersContext() : base("UsersContext")
        { }

        public DbSet<Users> Users { get; set; }
    }
    
}