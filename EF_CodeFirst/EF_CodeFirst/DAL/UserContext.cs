using EF_CodeFirst.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace EF_CodeFirst.DAL
{
    public class UserContext: DbContext
    {
        public DbSet<User> Users { get; set; }
    }
}