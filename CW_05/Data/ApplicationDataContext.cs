using CW_05.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace CW_05.Data
{
    public class ApplicationDataContext: DbContext
    {
        
        public virtual DbSet<Subject> Subjects { get; set;}
        public virtual DbSet<Teacher> Teachers { get; set; }

        public ApplicationDataContext() : base("name=ApplicationConnectionString")
        {

        }
    }
}