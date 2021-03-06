﻿using Microsoft.EntityFrameworkCore;
using Rocky.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Rocky.Data
{
    public class ApplicationDBContext : DbContext
    {
        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options) : base(options)
        {

        }

        public DbSet<Category> Category { get; set; }
        public DbSet<Application_Model> ApplicationType { get; set; }
        public DbSet<Product> Product { get; set; }
        public IEnumerable<Category> Application_Model { get; internal set; }

        
    }
}
