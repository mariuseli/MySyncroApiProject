using MediatR;
using MySyncroAPI.Persistence;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace MySyncroAPI.Business.Queries
{
    public class GetAllContactsQueryHandler : IRequestHandler<GetAllContactsQuery, List<ContactDto>>
    {
        private MySyncroAPIDatabaseContext _dbContext = null;
        public GetAllContactsQueryHandler(MySyncroAPIDatabaseContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Task<List<ContactDto>> Handle(GetAllContactsQuery request, CancellationToken cancellationToken) 
            => _dbContext.MyContacts.Select(ct => ContactDto.Projection(ct)).ToListAsync(cancellationToken);
    }
}