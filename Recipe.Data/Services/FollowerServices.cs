using Microsoft.EntityFrameworkCore;
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
    public class FollowerServices
    {
        private IFollowerRepository _follower;

        public FollowerServices(IFollowerRepository follower)
        {
            _follower = follower;
        }

        public async Task<bool> AddFollower(FollowerDTO request)
        {
            var follower = new Follower()
            {
                FollowerID = request.FollowerID,
                UserID = request.UserID
            };

            var response = await _follower.AddFollower(follower);
            return response;
        }

        public async Task<bool> DeleteFollower(FollowerDTO request)
        {
            var follower = new Follower()
            {
                FollowerID = request.FollowerID,
                UserID = request.UserID
            };

            var response = await _follower.DeleteFollower(follower);
            return response;
        }

        public async Task<IEnumerable<Follower>> GetFollowersByID(Guid id)
        {
            var response = await _follower.GetFollowersByID(id);
            return response;
        }

        public async Task<int> GetFollowersCountByID(Guid id)
        {
            var response = await _follower.GetFollowersCountByID(id);
            return response;
        }
    }
}
