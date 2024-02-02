using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using GameApplication.Data;
using GameApplication.Models;

namespace GameApplication.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class GamesController : ControllerBase
    {
        private readonly DataContext _context;

        public GamesController(DataContext context)
        {
            _context = context;
        }

        
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Game>>> GetGames()
        {
            return await _context.Games.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Game>> GetGame(int id)
        {
            var game = await _context.Games.FindAsync(id);

            if (game == null)
            {
                return NotFound();
            }

            return game;
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult<Game>> PostGame(Game game)
        {
            _context.Games.Add(game);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetGame), new { id = game.GameId }, game);
        }

        [HttpPut("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> PutGame(int id, Game game)
        {
            if (id != game.GameId)
            {
                return BadRequest();
            }

            _context.Entry(game).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!GameExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> DeleteGame(int id)
        {
            var game = await _context.Games.FindAsync(id);
            if (game == null)
            {
                return NotFound();
            }

            _context.Games.Remove(game);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpGet("WithMoreThanFourReviews")]
        public async Task<ActionResult<IEnumerable<string>>> GetGamesWithMoreThanFourReviews()
        {
            var gamesWithMoreThanFourReviews = await _context.Games
                .Where(g => g.Reviews.Count > 4) 
                .Select(g => g.Title) 
                .ToListAsync();
            return gamesWithMoreThanFourReviews;
        }

        [HttpGet("WithSystemRequirements")]
        public async Task<ActionResult<IEnumerable<Game>>> GetGamesWithSR()
        {
            var gamesWithSystemRequirements = await _context.Games
                .Include(g => g.SystemRequirements)
                .ToListAsync();
            return gamesWithSystemRequirements;
        }

        [HttpGet("DeveloperGameCounts")]
        public async Task<ActionResult<IEnumerable<DeveloperGameCount>>> GetDeveloperGameCounts()
        {
            var developerGameCounts = await _context.GameDevelopers
                .Join(_context.Developers,
                      gameDeveloper => gameDeveloper.DeveloperId,
                      developer => developer.DeveloperId,
                      (gameDeveloper, developer) => new { gameDeveloper, developer })
                .GroupBy(joinResult => joinResult.developer)
                .Select(group => new DeveloperGameCount
                {
                    DeveloperName = group.Key.Name,
                    GameCount = group.Count()
                })
                .ToListAsync();

            return developerGameCounts;
        }

        public class DeveloperGameCount
        {
            public string DeveloperName { get; set; }
            public int GameCount { get; set; }
        }


        private bool GameExists(int id)
        {
            return _context.Games.Any(e => e.GameId == id);
        }
    }
}
