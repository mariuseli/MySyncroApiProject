using Microsoft.AspNetCore.Mvc;
using MediatR;
using System;
using MySyncroAPI.Models;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.Extensions.Logging;
using MySyncroAPI.Business.Queries;
using MySyncroAPI.Business.MyContacts.Commands;
using Microsoft.AspNetCore.Mvc.Diagnostics;

namespace MySyncroAPI.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class ContactsController : ControllerBase
    {
        private IMediator _mediator;
        public ContactsController(IMediator mediator,ILogger<WeatherForecastController> logger)
        {
            _mediator = mediator;
        }

        //[HttpPost("RegisterContact")]
        //public async Task<IActionResult> RegisterContact(string contactToAdd)
        //{
        //    var fromTxt = ContactModel.FromText(contactToAdd);
        //    var dto = fromTxt.ToDto();
        //    await _mediator.Send(new CreateContactCommand { ContactToCreate = dto });
        //    return Ok();
        //}

        [HttpPost("RegisterContact")]
        public async Task<IActionResult> RegisterContact(ContactModel? contactToAdd)
        {
            var dto = contactToAdd.ToDto();
            await _mediator.Send(new CreateContactCommand { ContactToCreate = dto });
            return Ok();
        }

        [HttpGet(nameof(GetAllContacts))]
        public async Task<IActionResult> GetAllContacts()
        {
            try
            {
                var dto = await _mediator.Send(new GetAllContactsQuery());
                if (dto.Any())
                {
                    var results =  dto.Select(e=> ContactModel.FromDTO(e));
                    return new JsonResult(results);
                }else{
                    return NotFound();
                }
            }
            catch(Exception exception)
            {
                return StatusCode(500);
            }

        }
    }
}