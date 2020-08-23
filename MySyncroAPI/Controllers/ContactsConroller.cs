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
        private readonly IMediator _mediator;
        private readonly ILogger<ContactsController> _logger;
        public ContactsController(IMediator mediator,ILogger<ContactsController> logger)
        {
            _logger = logger;
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> RegisterContact(ContactModel? contactToAdd)
        {
            try
            {
                var dto = contactToAdd.ToDto();
                await _mediator.Send(new CreateContactCommand { ContactToCreate = dto });
            }catch(Exception registerException)
            {
                _logger.Log(LogLevel.Error, registerException, registerException.Message);
                _logger.LogInformation(System.IO.File.Exists("./Data/MySyncroDatabase.db") ? "File Exists" : "File is not acessible");
            }
            return await GetAllContacts();
        }

        [HttpGet]
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
                    return new JsonResult(new { ContentMessage = "No data found from DB" });
                }
            }
            catch(Exception exception)
            {
                _logger.LogError(exception.Message, nameof(GetAllContacts));
                return StatusCode(500, $"{exception.Message} : {exception.StackTrace}");
            }

        }
    }
}