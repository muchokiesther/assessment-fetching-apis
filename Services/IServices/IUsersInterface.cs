using System.Collections.Generic;
using System.Threading.Tasks;
using assesment.Models;
using assessment.Models;  

namespace assessment.Services.IServices
{
    internal interface IUsersInterface
    {
        Task<List<User>> GetAllUsersAsync();
         Task<List<Post>> GetUserPostsAsync(int userId);
          Task<List<Comment>> GetPostCommentsAsync(int postId);
    }
}
