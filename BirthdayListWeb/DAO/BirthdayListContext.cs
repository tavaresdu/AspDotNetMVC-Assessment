using BirthdayListWeb.Models;
using System.Data.Entity;

namespace BirthdayManagerWeb.DAO
{
    public class BirthdayListContext : DbContext
    {
        public DbSet<Person> People { get; set; }
    }
}