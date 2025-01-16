using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WebAPIPortal.Models;

namespace WebAPIPortal.Data
{
    public class WebAPIPortalContext : DbContext
    {
        public WebAPIPortalContext (DbContextOptions<WebAPIPortalContext> options)
            : base(options)
        {
        }

        public DbSet<WebAPIPortal.Models.Student> Student { get; set; } = default!;
    }
}
