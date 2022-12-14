using EDAwareness.Core.Data.Models;

namespace EDAwareness.Core.Data.Repositories
{
    public class CommanderRepository
    {
        //private readonly SqlConnection _db;
        private Dictionary<int, Commander>? _commanders;

        /*public CommanderRepository(SqlConnection db)
        {
            _db = db;
        }*/

        public async Task<Commander> GetByIdAsync(int id, CancellationToken cancellationToken = default)
        {
            if (_commanders == null)
            {
                var commanders = await GetAllAsync(cancellationToken);
                _commanders = commanders.ToDictionary(x => x.Id);
            }

            return _commanders[id];
        }
        public async Task<IEnumerable<Commander>> GetAllAsync(CancellationToken cancellationToken = default)
        {
            return null;
        }
        public async Task AddAsync(Commander commander, CancellationToken cancellationToken = default) { }
        public async Task RemoveAsync(Commander commander, CancellationToken cancellationToken = default) { }
        public async Task UpdateAsync(Commander commannder, CancellationToken cancellationToken = default) { }
    }
}
