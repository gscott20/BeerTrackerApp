using System;
using System.Collections.Generic;
using AutoMapper;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using BeerTrackerAPI.Data;
using BeerTrackerAPI.Models.Player;
using Microsoft.AspNetCore.Mvc;
using System.Collections;

namespace BeerTrackerAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlayersController : ControllerBase
    {
        private readonly BeerTrackerDbContext _context;
        private readonly IMapper _mapper;

        public PlayersController(BeerTrackerDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // GET: api/Players
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ReadOnlyPlayerDto>>> GetPlayers()
        {
            var players = await _context.Players.ToListAsync();
            return Ok(_mapper.Map<IEnumerable<ReadOnlyPlayerDto>>(players));
        }

        // GET: api/Players/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ReadOnlyPlayerDto>> GetPlayer(int id)
        {
            var player = await _context.Players.FindAsync(id);
            if (player == null)
            {
                return NotFound();
            }

            return _mapper.Map<ReadOnlyPlayerDto>(player);
        }

        // POST: api/Players
        [HttpPost]
        public async Task<ActionResult<CreatePlayerDto>> CreatePlayer(CreatePlayerDto createPlayerDto)
        {
            var player = _mapper.Map<Player>(createPlayerDto);
            _context.Players.Add(player);
            await _context.SaveChangesAsync();

            var playerDto = _mapper.Map<CreatePlayerDto>(player);
            return CreatedAtAction(nameof(GetPlayer), new { id = player.Id }, playerDto);
        }

        // PUT: api/Players/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPlayer(int id, UpdatePlayerDto updatePlayerDto)
        {
            var player = await _context.Players.FindAsync(id);
            if (player == null)
            {
                return NotFound();
            }

            _mapper.Map(updatePlayerDto, player);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        // DELETE: api/Players/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePlayer(int id)
        {
            var player = await _context.Players.FindAsync(id);
            if (player == null)
            {
                return NotFound();
            }

            _context.Players.Remove(player);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
