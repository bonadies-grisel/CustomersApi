using customers.domain;
using Microsoft.EntityFrameworkCore;

namespace customers.data
{
    public class CustomerQuery : Repository<Customer>
    {
        private readonly ApplicationDbContext _context;

        public CustomerQuery(ApplicationDbContext context) : base(context)
        {
        }

    }
}
