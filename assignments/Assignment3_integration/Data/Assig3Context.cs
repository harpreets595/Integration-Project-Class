using Assignment3_integration.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Assignment3_integration.Data
{
    public class Assig3Context : DbContext
    {
        public Assig3Context (DbContextOptions<Assig3Context> options) : base(options)
        {

        }

        public DbSet<Contact> Contact { get; set; }
    }
}
