using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using GameApplication.Data;
using GameApplication.Models;

[Route("api/[controller]")]
[ApiController]
public class GameDeveloperController : ControllerBase
{
    private readonly DataContext _context;

    public GameDeveloperController(DataContext context)
    {
        _context = context;
    }

    // POST: api/GameDeveloper
    [HttpPost]
    public async Task<ActionResult<GameDeveloper>> PostGameDeveloper(GameDeveloper gameDeveloper)
    {
        _context.GameDevelopers.Add(gameDeveloper);
        await _context.SaveChangesAsync();

        return CreatedAtAction("GetGameDeveloper", new { id = gameDeveloper.GameDeveloperId }, gameDeveloper);
    }

    // DELETE: api/GameDeveloper
    [HttpDelete("{id}")]
    public async Task<ActionResult<GameDeveloper>> DeleteGameDeveloper(int id)
    {
        var gameDeveloper = await _context.GameDevelopers.FindAsync(id);
        if (gameDeveloper == null)
        {
            return NotFound();
        }

        _context.GameDevelopers.Remove(gameDeveloper);
        await _context.SaveChangesAsync();

        return gameDeveloper;
    }

    // GET: api/GameDeveloper/Games
    [HttpGet("Games/{developerId}")]
    public async Task<ActionResult<IEnumerable<Game>>> GetGamesByDeveloper(int developerId)
    {
        return await _context.GameDevelopers
            .Where(gd => gd.DeveloperId == developerId)
            .Select(gd => gd.Game)
            .ToListAsync();
    }

    // GET: api/GameDeveloper/Developers
    [HttpGet("Developers/{gameId}")]
    public async Task<ActionResult<IEnumerable<Developers>>> GetDevelopersByGame(int gameId)
    {
        return await _context.GameDevelopers
            .Where(gd => gd.GameId == gameId)
            .Select(gd => gd.Developers)
            .ToListAsync();
    }
}
