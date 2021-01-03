using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Milestone_4A.Models;

namespace Milestone_4A.Models {
    public class Milestone_4AContext : DbContext {
        public Milestone_4AContext(DbContextOptions<Milestone_4AContext> options)
            : base(options) {
        }

        public DbSet<Milestone_4A.Models.Contact> Contact { get; set; }
    }
}
