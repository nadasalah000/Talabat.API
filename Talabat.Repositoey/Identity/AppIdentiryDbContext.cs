using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Talabat.Core.Entites.identity;

namespace Talabat.Repositoey.Identity
{
    public class AppIdentiryDbContext:IdentityDbContext<AppUser>
    {
        public AppIdentiryDbContext(DbContextOptions<AppIdentiryDbContext> options) : base(options) { }
    }
}
