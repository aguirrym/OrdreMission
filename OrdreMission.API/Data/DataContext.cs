using Microsoft.EntityFrameworkCore;
using OrdreMission.API.Models;

namespace GestionDordreDeMission.API.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base (options){}
        public DbSet<Value> Values {get; set;}
        public DbSet<User> Users {get; set;}
        public DbSet<Photo> Photos { get; set; }
        public DbSet<EmployeesRed> EmployeeRed { get; set; }




        
    }
}