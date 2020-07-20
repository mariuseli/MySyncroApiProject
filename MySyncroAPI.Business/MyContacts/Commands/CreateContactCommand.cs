using MediatR;

namespace MySyncroAPI.Business.MyContacts.Commands
{
    public class CreateContactCommand : IRequest<int>
    {
        public ContactDto ContactToCreate { get; set; }
    }
}
