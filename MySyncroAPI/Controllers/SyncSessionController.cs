using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.Xml;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MySyncroAPI.Business.MySyncSessions.Commands;
using MySyncroAPI.Business.MySyncSessions.Queries;
using MySyncroAPI.Models;

namespace MySyncroAPI.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class SyncSessionController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly ILogger<SyncSessionController> _logger;

        public SyncSessionController(IMediator mediator, ILogger<SyncSessionController> logger)
        {
            _logger = logger;
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetSyncSessions()
        {
            try
            {
                var sessions = await _mediator.Send(new GetAllSyncSessionsQuery());
                if (sessions.Any())
                    return new JsonResult(SyncSessionModel.FromDtoList(sessions.ToList()));
                else
                    return new JsonResult(new { ContentMessage  = "Aucune Donnée dans la base de données." });
            }catch(Exception exception)
            {
                _logger.LogError(exception.Message, exception);
                return StatusCode(500, $"{exception.Message} : {exception.StackTrace}");
            }

            return StatusCode(200);

        }

        [HttpGet]
        public async Task<IActionResult> GetSyncSessionById(int id)
        {
            try
            {
                var session = await _mediator.Send(new GetSyncSessionByIdQuery() { SearchedSessionId = id } );
                if (session != null)
                    return new JsonResult(SyncSessionModel.FromSingleDto(session));
                else
                    return new JsonResult(new { ContentMessage = "Aucune Donnée dans la base de données." });
            }
            catch (Exception exception)
            {
                _logger.LogError(exception.Message, exception);
                return StatusCode(500, $"{exception.Message} : {exception.StackTrace}");
            }
        }

        [HttpPost]
        public async Task<IActionResult> CreateSyncSession(SyncSessionModel newSyncSession)
        {
            try
            {
                var createMessage = await _mediator.Send(new CreateSyncSessionCommand { DataToInsert = SyncSessionModel.ToDto(newSyncSession) });
                return await GetSyncSessions();
            }
            catch (Exception creationException)
            {
                _logger.LogError(creationException.Message, creationException);
                return StatusCode(500, $"{creationException.Message} : {creationException.StackTrace}");
            }
        }
    }
}
