using Microsoft.AspNetCore.Mvc;
using SagreEventi.Shared.Models;
using SagreEventi.Web.Server.Models.Services.Application;

namespace SagreEventi.Web.Server.Controllers;

[ApiController]
[Route("api/[controller]/[action]")]

public class EventiController : ControllerBase
{
    private readonly ILogger<EventiController> logger;
    private readonly IEventiService eventiService;

    public EventiController(ILogger<EventiController> logger, IEventiService eventiService)
    {
        this.logger = logger;
        this.eventiService = eventiService;
    }

    [HttpGet]
    public async Task<List<EventoModel>> GetEventi([FromQuery] DateTime since)
    {
        //return await appDbContext.Eventi.Where(x => x.DataOraUltimaModifica > since).ToListAsync();

        return await eventiService.GetEventi(since);
    }

    [HttpPut]
    public async Task<IActionResult> UpdateEventi(List<EventoModel> eventi)
    {
        await eventiService.UpdateEventi(eventi);
        return Ok();
    }
}