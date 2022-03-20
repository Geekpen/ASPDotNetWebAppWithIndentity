using ASPDotNetWebApp.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASPDotNetWebApp.Data
{
    public class DotNetCoreMySQLContext : DbContext
    {
        public DotNetCoreMySQLContext(DbContextOptions<DotNetCoreMySQLContext> options) : base(options) { }
        public DbSet<User> Users { get; set; }
        public DbSet<ContactInfo> ContactInfo { get; set; }
        public DbSet<Department> Department { get; set; }
        public DbSet<Student> Student { get; set; }
        public DbSet<Teacher> Teacher { get; set; }
        public DbSet<StudentTeacher> StudentTeacher { get; set; }
    }
}