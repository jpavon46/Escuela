using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Escuela.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace Escuela.Data
{
    public class EscuelaContext : IdentityDbContext
    {
        public EscuelaContext (DbContextOptions<EscuelaContext> options)
            : base(options)
        {
        }

        public DbSet<Escuela.Models.Course> Course { get; set; } = default!;
        public DbSet<Escuela.Models.School> School { get; set; } = default!;
        public DbSet<Escuela.Models.Student> Student { get; set; } = default!;
        public DbSet<Escuela.Models.Teacher> Teacher { get; set; } = default!;
    }
}
