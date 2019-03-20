using GestionDordreDeMission.API.Models;
using Microsoft.EntityFrameworkCore;

namespace GestionDordreDeMission.API.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base (options){}
        

        public DbSet<Employee> Employees {get; set;}

        public DbSet<User> Users {get; set;}
    }
}