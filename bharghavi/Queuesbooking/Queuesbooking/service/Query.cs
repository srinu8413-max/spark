using Microsoft.EntityFrameworkCore;
using Queuesbooking.Data;
using Queuesbooking.Model;

namespace Queuesbooking.service
{
    public class Query
    {
        private readonly AppDbcontext _context;

        public Query(AppDbcontext context)
        {
            _context = context;
        }

        // ➕ Join Queue
        public async Task JoinQueue(int userId)
        {
            var entry = new QueryEntry
            {
                UserId = userId
            };

            _context.queryEntry.Add(entry);
            await _context.SaveChangesAsync();
        }

        // 📍 Get Position
        public async Task<int?> GetPosition(int userId)
        {
            var queue = await _context.queryEntry
                .Where(q => !q.IsServed)
                .OrderBy(q => q.JoinedAt)
                .ToListAsync();

            var position = queue.FindIndex(q => q.UserId == userId);

            if (position == -1)
                return null;

            return position + 1; // position starts from 1
        }
    }
}