using DataApi.Helpers;
using DataApi.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace DataApi.ApplicationDbContext
{
    public class ApplicactionDbContext: IdentityDbContext
    {
        public ApplicactionDbContext() { }
        public ApplicactionDbContext(DbContextOptions<ApplicactionDbContext> options) : base(options) { }

        /// <summary>
        /// Overwrite the method onconfigure of DbContext and we configured Database Sql 
        /// </summary>
        /// <param name="optionsBuilder"></param>
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {           
            optionsBuilder.UseSqlServer(MySettingsDb.GetNetTestConecction(), options =>
            {
                options.CommandTimeout(200);
            });
        }


        public DbSet<ProductsModel> ProductsModel { get; set; }      
    }
}
