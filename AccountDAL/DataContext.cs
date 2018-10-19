using System.Data.Entity;
using subDomain.Models;

namespace WebApplication1.AccountDAL
{
    public class DataContext:DbContext
    {
        public DataContext() : base(subDomain.Helpers.Helpers.GetUserManagementDb())
        {
        }

        public DbSet<Account> Accounts { get; set; }
    }
}