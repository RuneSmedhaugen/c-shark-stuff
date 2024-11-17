using Microsoft.EntityFrameworkCore;
using SwoyerOrbiloUniverse.Model;

namespace SwoyerOrbiloUniverse.Services
{
    public class WikiService
    {
        private readonly WikiDbContext _context;

        public WikiService(WikiDbContext context)
        {
            _context = context;
        }

        // Entities
        public async Task<List<Entity>> GetEntitiesAsync()
        {
            return await _context.Entities.ToListAsync();
        }

        public async Task<Entity> GetEntityByIdAsync(int id)
        {
            return await _context.Entities.FindAsync(id);
        }

        public async Task AddEntityAsync(Entity entity)
        {
            _context.Entities.Add(entity);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateEntityAsync(Entity entity)
        {
            _context.Entities.Update(entity);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteEntityAsync(int id)
        {
            var entity = await _context.Entities.FindAsync(id);
            if (entity != null)
            {
                _context.Entities.Remove(entity);
                await _context.SaveChangesAsync();
            }
        }

        // Humans
        public async Task<List<Human>> GetHumansAsync()
        {
            return await _context.Humans.ToListAsync();
        }

        public async Task<Human> GetHumanByIdAsync(int id)
        {
            return await _context.Humans.FindAsync(id);
        }

        public async Task AddHumanAsync(Human human)
        {
            _context.Humans.Add(human);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateHumanAsync(Human human)
        {
            _context.Humans.Update(human);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteHumanAsync(int id)
        {
            var human = await _context.Humans.FindAsync(id);
            if (human != null)
            {
                _context.Humans.Remove(human);
                await _context.SaveChangesAsync();
            }
        }

        // Groups
        public async Task<List<Group>> GetGroupsAsync()
        {
            return await _context.Groups.ToListAsync();
        }

        public async Task<Group> GetGroupByIdAsync(int id)
        {
            return await _context.Groups.FindAsync(id);
        }

        public async Task AddGroupAsync(Group group)
        {
            _context.Groups.Add(group);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateGroupAsync(Group group)
        {
            _context.Groups.Update(group);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteGroupAsync(int id)
        {
            var group = await _context.Groups.FindAsync(id);
            if (group != null)
            {
                _context.Groups.Remove(group);
                await _context.SaveChangesAsync();
            }
        }
    }
}
