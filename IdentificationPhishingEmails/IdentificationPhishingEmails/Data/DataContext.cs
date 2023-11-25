using IdentificationPhishingEmails.Models;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace IdentificationPhishingEmails.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        public DbSet<Email> Emails { get; set; }
    }
}
