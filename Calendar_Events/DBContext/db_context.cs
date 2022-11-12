using Calendar_Events.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Calendar_Events.DBContext
{
    public class db_context : DbContext
    {
        public db_context(DbContextOptions option) : base(option)
        {

        }
        public DbSet<Events> Events { get; set; }
    }
}
