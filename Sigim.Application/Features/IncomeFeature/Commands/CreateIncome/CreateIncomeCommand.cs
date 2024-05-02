using MediatR;
using Sigim.Application.Models;

namespace Sigim.Application.Features.IncomeFeature.Commands.CreateIncome
{
    public class CreateIncomeCommand : IRequest<ApiResult<bool>>
    {
        public string IdUsuario { get; set; } = string.Empty;
    }
}
