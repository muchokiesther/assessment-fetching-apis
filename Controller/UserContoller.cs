using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using assesment.Helpers;
using assesment.Services;
using assessment.Models; 

namespace assesment.Controller
{
    public class UserContoller
    {
        private readonly UserService userService = new UserService();

        public static async Task Init()
        {
            Console.WriteLine("Here are our users");
            Console.WriteLine("1. View Users");
            Console.WriteLine("2. See Posts");
            Console.WriteLine("3. See Comments");
            var input = Console.ReadLine();
            var validateResults = Validation.Validate(new List<string> { input });
            if (!validateResults)
            {
                await Init();
            }
            else
            {
                var userController = new UserContoller();
                await userController.MenuRedirectAsync(input);
            }
        }

        public async Task MenuRedirectAsync(string Id)
        {
            switch (Id)
            {
                case "1":
                    await ViewUsers();
                    break;
                case "2":
                    await ViewUserPosts();
                    break;
                case "3":
                    Console.WriteLine("Enter Post ID:");
                    if (int.TryParse(Console.ReadLine(), out int postId))
                    {
                        await ViewPostComments(postId);
                    }
                    else
                    {
                        Console.WriteLine("Invalid Post ID.");
                        await Init();
                    }
                    break;
                default:
                    Init();
                    break;
            }
        }

        public async Task ViewUsers()
        {
            try
            {
                var users = await userService.GetAllUsersAsync();
                foreach (var user in users)
                {
                    Console.WriteLine($"User ID: {user.id}");
                    Console.WriteLine($"Name: {user.name}");
                    Console.WriteLine($"Username: {user.username}");
                    Console.WriteLine($"Email: {user.email}");
                    Console.WriteLine("-----");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            await Init();
        }

        public async Task ViewUserPosts()
        {
            Console.WriteLine("Enter Username:");
            var username = Console.ReadLine();

            try
            {
                var users = await userService.GetAllUsersAsync();
                var user = users.FirstOrDefault(u => u.username == username);

                if (user != null)
                {
                    var posts = await userService.GetUserPostsAsync(user.id);
                    foreach (var post in posts)
                    {
                        Console.WriteLine($"Post ID: {post.id}");
                        Console.WriteLine($"Title: {post.title}");
                        Console.WriteLine($"Body: {post.body}");
                        Console.WriteLine("-----");
                    }

                }
                else
                {
                    Console.WriteLine("User not found.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            await Init();
        }


        public async Task ViewPostComments(int postId)
        {
            try
            {
                var comments = await userService.GetPostCommentsAsync(postId);
                foreach (var comment in comments)
                {
                    Console.WriteLine($"Comment ID: {comment.id}");
                    Console.WriteLine($"Name: {comment.title}");
                    Console.WriteLine($"Email: {comment.email}");
                    Console.WriteLine($"Body: {comment.body}");
                    Console.WriteLine("-----");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            await Init();
        }

    }
}
