using JORDAN_2T.Infrastructure.Interfaces;
using JORDAN_2T.ApplicationCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JORDAN_2T.Infrastructure.Data
{
    public class ApplicationUserRepository : Repository<ApplicationUser>, IApplicationUserRepository
    {
        private MvcMovieContext _context;

        public ApplicationUserRepository(MvcMovieContext context) : base(context)
        {
            _context = context;
        }
        public ApplicationUser GetMovie(string id)
        {
            var movie = _dbSet.Single(i => i.Id == id);
            // Populate the photo collection. Lazy loading is not
            // turned on so we have to do it explicitly. When you
            // read up on eager, lazy, and explicit loading, make
            // sure you are reading about EF Core, not just EF.
            
            return movie;
        }

    }
}
