using Recipe.Data.Models.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recipe.Data.Repository.Interface
{
    public interface IHashtagRepository
    {
        Task<IEnumerable<Hashtag>> GetAllHashtags();
        Task<Hashtag> GetHashtagById(Guid id);
        Task<bool> AddHashtag(Hashtag hashtag);
    }
}
