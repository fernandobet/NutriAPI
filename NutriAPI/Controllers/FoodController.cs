using MediatR;
using Microsoft.AspNetCore.Mvc;
using Nutri.Application.Features.Food.Commands.DeleteFood;
using Nutri.Application.Features.Food.Commands.ModifyFood;
using Nutri.Application.Features.Food.Commands.ModifyFoodFamily;
using Nutri.Application.Features.Food.Commands.SaveFood;
using Nutri.Application.Features.Food.Queries.GetFamilies;
using Nutri.Application.Features.Food.Queries.GetFamiliesFood;
using Nutri.Application.Features.Food.Queries.GetFamilyFood;
using Nutri.Application.Features.Food.Queries.GetFoodList;
using Nutri.Application.Features.Food.Queries.GetMeditionsFood;
using Nutri.Domain.Models;
using System.Net;

namespace NutriAPI.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class FoodController:ControllerBase
    {
        private readonly IMediator _mediator;
        public FoodController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpDelete]
        [Route("DeleteFoodCommand/{id}")]
        public async Task<ActionResult> DeleteFood(int id)
        {
            var command = new DeleteFoodCommand { Id = id };
            await this._mediator.Send(command);
            return Ok();
        }
        [HttpPut]
        [Route("ModifyFoodFamily")]
        public async Task<ActionResult> ModifyFoodFamily(ModifyFoodFamilyCommand command)
        {
            await _mediator.Send(command);
            return Ok();
        }
        [HttpGet]
        [Route("GetFamilies")]
        [ProducesDefaultResponseType]
        public async Task<ActionResult<IEnumerable<FamiliaAlimento>>> GetFamilies()
        {
            var data = await _mediator.Send(new GetFamiliesFoodQuery());
            return Ok(data);
        }
        [HttpGet]
        [Route("GetFamilyFood/{id}")]
        [ProducesDefaultResponseType]
        public async Task<ActionResult<FamiliaAlimento>> GetFamilyFood(int id)
        {
            var query = new GetFamilyFoodQuery { Id = id };
            var familyFood = await _mediator.Send(query);
            return Ok(familyFood);

        }
        [HttpGet]
        [Route("GetFoodByFamily/{id}")]
        [ProducesDefaultResponseType]
        public async Task<ActionResult<IEnumerable<Alimento>>> GetFoodByFamily( int id)
        {
            var familyList = await _mediator.Send(new GetFoodByFamilyQuery { IdFamily = id });
            return Ok(familyList);
        }
        [HttpGet]
        [Route("GetMeditionFood")]
        [ProducesDefaultResponseType]
        public async Task<ActionResult<IEnumerable<MedicionAlimento>>> GetMeditionFood()
        {
            var response = await _mediator.Send(new GetMeditionsFoodQuery());
            return Ok(response);
        }
        [HttpGet]
        [Route("GetFoodList")]
        [ProducesDefaultResponseType]
        public async Task<ActionResult<IEnumerable<Alimento>>> GetFoodList()
        {
            var foodList = await _mediator.Send(new GetFoodListQuery());
            return Ok(foodList);
        }
        [HttpPost]
        [Route("SaveFood")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> SaveFood([FromBody] SaveFoodCommand command)
        {
            await _mediator.Send(command);
            return Ok();
        }
        [HttpPut]
        [Route("ModifyFood")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> ModifyFood([FromBody] ModifyFoodCommand command)
        {
            await _mediator.Send(command);
            return Ok();
        }
    }
}
