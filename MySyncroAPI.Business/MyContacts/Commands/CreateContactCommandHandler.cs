using MediatR;
using MySyncroAPI.Persistence;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MySyncroAPI.Business.MyContacts.Commands
{
    public class CreateContactCommandHandler : IRequestHandler<CreateContactCommand, int>
    {
        private MySyncroAPIDatabaseContext _dbContext = null;
        public CreateContactCommandHandler(MySyncroAPIDatabaseContext dbContext)
        {
            _dbContext = dbContext;
        }
        public Task<int> Handle(CreateContactCommand request, CancellationToken cancellationToken)
        {
            var newContact = new Domain.MyContact
            {
                ContactDescription = request.ContactToCreate.ContactDescription,
                ContactEmail = request.ContactToCreate.ContactEmail,
                ContactName = request.ContactToCreate.ContactName,
                ContactPhoneNumber = request.ContactToCreate.ContactPhoneNumber,
                CreationDate = DateTime.UtcNow,
                RefId = request.ContactToCreate.RefId
            };
            _dbContext.MyContacts.AddAsync(newContact, cancellationToken);
            return _dbContext.SaveChangesAsync(cancellationToken);
        }
    }
}
