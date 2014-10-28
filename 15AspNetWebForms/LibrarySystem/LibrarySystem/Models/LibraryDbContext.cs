using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

using Microsoft.AspNet.Identity.EntityFramework;
using LibrarySystem.Migrations;

namespace LibrarySystem.Models
{
    public class LibraryDbContext : IdentityDbContext<User>
    {
        public LibraryDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<LibraryDbContext, Configuration>());
        }

        public IDbSet<Book> Books { get; set; }

        public IDbSet<Category> Categories { get; set; }

        public static LibraryDbContext Create()
        {
            return new LibraryDbContext();
        }
    }
}