using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Test_Practice_as3.Models;

namespace Test_Practice_as3.Data
{
    public class as3Context : DbContext
    {
        public as3Context (DbContextOptions<as3Context> options): base(options)
        {

        }

        public DbSet<Contact> Contact { get; set; }
    }
}
