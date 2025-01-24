using Recipe.Data.Models.Domains;
using Recipe.Data.Models.DTOs.Followers;
using Recipe.Data.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recipe.Data.Services
{
    public class FollowingServices
    {
        private IFollowingRepository _following;

        public FollowingServices(IFollowingRepository following)
        {
            _following = following;
        }

        public async Task<bool> AddFollowing(FollowingDTO request)
        {
            var following = new Following()
            {
                FollowingID = request.FollowingID,
                UserID = request.UserID
            };

            var response = await _following.AddFollowing(following);
            return response;
        }

        public async Task<bool> DeleteFollowing(FollowingDTO request)
        {
            var following = new Following()
            {
                FollowingID = request.FollowingID,
                UserID = request.UserID
            };

            var response = await _following.DeleteFollowing(following);
            return response;
        }

        public async Task<IEnumerable<Following>> GetFollowingsByID(Guid id)
        {
            var response = await _following.GetFollowingsByID(id);
            return response;
        }

        public async Task<int> GetFollowingsCountByID(Guid id)
        {
            var response = await _following.GetFollowingsCountByID(id);
            return response;
        }
    }
}
