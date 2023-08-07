using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using FirstWebProject.Models;

namespace FirstWebProject.Data
{
    public class interest_ratesContext : DbContext
    {
        public interest_ratesContext(DbContextOptions<interest_ratesContext> options)
            : base(options)
        {
        }

        public DbSet<ProcentBase> ProcentBase { get; set; } = default!;
    }
}
