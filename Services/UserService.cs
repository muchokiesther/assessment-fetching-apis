using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using assesment.Models;
using assessment.Models;
using assessment.Services.IServices;
using Newtonsoft.Json;

namespace assesment.Services
{
  internal class  UserService : IUsersInterface
    {
        private readonly HttpClient _httpClient;
        private readonly string _url = "https://jsonplaceholder.typicode.com/users";
        public UserService()
        {
            _httpClient = new HttpClient();

        }

         public async Task<List<User>> GetAllUsersAsync()
        {
            var response = await _httpClient.GetAsync(_url);
            var users = JsonConvert.DeserializeObject<List<User>>(await response.Content.ReadAsStringAsync());

            if (response.IsSuccessStatusCode)
            {
                return users;
            }

            throw new Exception("Cannot retrieve users");
        }

          public async Task<User> GetUserAsync(string id)
        {
            var response = await _httpClient.GetAsync(_url + "/" + id);
            var user = JsonConvert.DeserializeObject<User>(await response.Content.ReadAsStringAsync());
            if (response.IsSuccessStatusCode)
            {
                return user;
            }
            throw new Exception("User not found");
        }
public async Task<List<Post>> GetUserPostsAsync(int userId)
{
    var response = await _httpClient.GetAsync($"https://jsonplaceholder.typicode.com/posts?userId={userId}");
    var posts = JsonConvert.DeserializeObject<List<Post>>(await response.Content.ReadAsStringAsync());

    if (response.IsSuccessStatusCode)
    {
        return posts;
    }

    throw new Exception("Cannot retrieve user posts");
}

    public async Task<List<Comment>> GetPostCommentsAsync(int postId)
        {
            var response = await _httpClient.GetAsync($"{_url}/{postId}/comments");
            var comments = JsonConvert.DeserializeObject<List<Comment>>(await response.Content.ReadAsStringAsync());

            if (response.IsSuccessStatusCode)
            {
                return comments;
            }

            throw new Exception("Cannot retrieve post comments");
        }
    }
}
    
