using Recipe.Data.Models.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recipe.Data.Repository.Interface
{
    public interface IFollowerRepository
    {
        Task<IEnumerable<Follower>> GetFollowersByID(Guid id);
        Task<int> GetFollowersCountByID(Guid id);
        Task<bool> AddFollower(Follower follower);
        Task<bool> DeleteFollower(Follower follower);
    }
}
