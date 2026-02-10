using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using api.Models;

namespace api.Data
{
    public class ApplicationDbContext :DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        public DbSet<AppUser> AppUsers { get; set; }
        public DbSet<JournalEntry> JournalEntries { get; set; }
        public DbSet<Struggle> Struggles { get; set; }
        public DbSet<Scripture> Scriptures { get; set; }
        public DbSet<JournalEntryStruggle> JournalEntryStruggles { get; set; }
        public DbSet<StruggleScripture> StruggleScriptures { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<JournalEntryStruggle>().HasKey(js => new { js.JournalEntryId, js.StruggleId });
            modelBuilder.Entity<StruggleScripture>().HasKey(ss => new { ss.StruggleId, ss.ScriptureId });
        }
    }
}