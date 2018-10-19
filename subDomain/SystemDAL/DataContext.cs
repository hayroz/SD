using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using WebApplication1.Models;

namespace WebApplication1.SystemDAL
{
    public class DataContext : DbContext
    {
        public DataContext() : base(subDomain.Helpers.Helpers.GetCompanyDbConnectionString())
        {
        }

        public DbSet<Job> Jobs { get; set; }
    }
}