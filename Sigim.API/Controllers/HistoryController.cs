using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Sigim.Application.Features.HistoryFeature.queries.GetAllHistory;
using Sigim.Application.Models;

namespace Sigim.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HistoryController : ControllerBase
    {
        private readonly IMediator _mediator;

        public HistoryController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        [Authorize(Roles = "Deportista")]
        public async Task<ActionResult<ApiResult<List<HistoryResult>>>> GetAllHistories()
        {
            return Ok(await _mediator.Send(new GetAllHistoryQuery()));
        }
    }
}
