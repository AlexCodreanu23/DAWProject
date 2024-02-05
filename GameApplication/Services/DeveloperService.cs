using GameApplication.Data;
using GameApplication.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GameApplication.Services
{
    public class DeveloperService : IDeveloperService
    {
        private readonly DataContext _context;

        public DeveloperService(DataContext context)
        {
            _context = context;
        }

        public async Task<List<Developer>> GetAllDevelopersAsync()
        {
            return await _context.Developers.ToListAsync();
        }

        public async Task<Developer> GetDeveloperByIdAsync(int id)
        {
            return await _context.Developers.FindAsync(id);
        }

        public async Task<Developer> CreateDeveloperAsync(Developer developer)
        {
            _context.Developers.Add(developer);
            await _context.SaveChangesAsync();
            return developer;
        }

        public async Task<bool> UpdateDeveloperAsync(int id, Developer developer)
        {
            if (id != developer.DeveloperId)
            {
                return false;
            }

            _context.Entry(developer).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
                return true;
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DeveloperExists(id))
                {
                    return false;
                }
                else
                {
                    throw;
                }
            }
        }

        public async Task<bool> DeleteDeveloperAsync(int id)
        {
            var developer = await _context.Developers.FindAsync(id);
            if (developer == null)
            {
                return false;
            }

            _context.Developers.Remove(developer);
            await _context.SaveChangesAsync();
            return true;
        }

        private bool DeveloperExists(int id)
        {
            return _context.Developers.Any(e => e.DeveloperId == id);
        }
    }
}