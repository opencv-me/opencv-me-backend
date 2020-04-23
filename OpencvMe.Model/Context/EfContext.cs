using Microsoft.EntityFrameworkCore;
using OpencvMe.Model.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace OpencvMe.Model.Context
{
    public class EfContext:DbContext
    {


        public EfContext(DbContextOptions<EfContext> options) : base(options)   {}


        public DbSet<Company> Company { get; set; }
        public DbSet<Cv> Cv { get; set; }
        public DbSet<School> School { get; set; }
        public DbSet<User> User { get; set; }

        public DbSet<UserSchool> UserSchool { get; set; }
        public DbSet<UserCompany> UserCompany { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }
        //83.150.213.114\MSSQLSERVER2017 opencv Bk616161++3142
    }
}
