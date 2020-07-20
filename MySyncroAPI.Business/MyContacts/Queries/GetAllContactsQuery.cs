using MediatR;
using System.Collections.Generic;

namespace MySyncroAPI.Business.Queries
{
    public class GetAllContactsQuery : IRequest<List<ContactDto>>
    {

    }
}