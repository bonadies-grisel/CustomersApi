using customers.domain;

namespace customers.data
{
    public class CityQuery : Repository<Customer>
    {
        private readonly ApplicationDbContext _context;

        public CityQuery(ApplicationDbContext context) : base(context)
        {
        }
    }
}

