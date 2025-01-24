using Recipe.Data.Models.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recipe.Data.Repository.Interface
{
    public interface IFollowingRepository
    {
        Task<IEnumerable<Following>> GetFollowingsByID(Guid id);
        Task<int> GetFollowingsCountByID(Guid id);
        Task<bool> AddFollowing(Following following);
        Task<bool> DeleteFollowing(Following following);
    }
}
