using MediatR;
using Microsoft.AspNetCore.Mvc;
using RecruitApi.Models;

namespace RecruitApi.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class EquipmentController : ControllerBase
  {
    private readonly SystemDbContext _context;
    private readonly IMediator _mediator;

    public EquipmentController(SystemDbContext context, IMediator mediator)
    {
      _context = context;
      _mediator = mediator;
    }

    [HttpGet("equipmentList")]
    public async Task<ActionResult<GetEquipmentListResponse>> GetEquipmentList()
    {
      var result = await _mediator.Send(new GetEquipmentListRequest());
      return result;
    }

    [HttpGet("equipment/{id}")]
    public async Task<ActionResult<GetEquipmentResponse>> GetEquipmentById([FromRoute] int id)
    {
      try
      {
        var result = await _mediator.Send(new GetEquipmentRequest { IdEquipment = id });
        return result;
      }
      catch (NotFoundException ex)
      {
        return NotFound(ex.Message);
      }
    }

    [HttpPost("create")]
    public async Task<ActionResult<int>> CreateEquipment([FromBody] CreateEquipmentCommand request)
    {
      try
      {
        var result = await _mediator.Send(request);
        return Ok(result);
      }
      catch (ArgumentNullException ex)
      {
        return BadRequest(ex.Message);
      }
    }

    [HttpPut("{id}/update")]
    public async Task<ActionResult> UpdateEquipment([FromRoute] int id, [FromBody] UpdateEquipmentCommand request)
    {
      try
      {
        request.IdEquipment = id;
        await _mediator.Send(request);
        return Ok();
      }
      catch (NotFoundException ex)
      {
        return NotFound(ex.Message);
      }
      catch (ArgumentNullException ex)
      {
        return BadRequest(ex.Message);
      }
    }

    [HttpDelete("{id}/delete")]
    public async Task<ActionResult> DeleteEquipment([FromRoute] int id)
    {
      try
      {
        await _mediator.Send(new DeleteEquipmentCommand { IdEquipment = id });
        return Ok();
      }
      catch (NotFoundException ex)
      {
        return NotFound(ex.Message);
      }
    }

  }
}
