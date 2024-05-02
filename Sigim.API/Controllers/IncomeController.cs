using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Sigim.Application.Features.IncomeFeature.Commands.CreateIncome;
using Sigim.Application.Features.IncomeFeature.Queries.GetAllIncome;
using Sigim.Application.Features.IncomeFeature.Queries.GetIncomesBetweenDates;
using Sigim.Application.Models;

namespace Sigim.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IncomeController : ControllerBase
    {
        private IMediator _mediator;

        public IncomeController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<ActionResult<ApiResult<List<IncomeResult>>>> GetAllIncomes()
        {
            return Ok(await _mediator.Send(new GetAllIncomeQuery()));   
        }

        [HttpGet]
        [Route("Dates")]
        public async Task<ActionResult<ApiResult<List<IncomeResult>>>> GetIncomesBetweenDates([FromBody] GetIncomesBetweenDatesQuery request)
        {
            return Ok(await _mediator.Send(request));
        }

        [HttpPost]
        public async Task<ActionResult<ApiResult<bool>>> CreateIncome([FromBody] CreateIncomeCommand request)
        {
            return Ok(await _mediator.Send(request));
        }
    }
}
