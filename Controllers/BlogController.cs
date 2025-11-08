using Microsoft.AspNetCore.Mvc;
using BlogApp.Models;

namespace BlogApp.Controllers
{
    public class BlogController : Controller
    {
        // Mock list of blog posts
        private static List<Post> GetMockPosts()
        {
            return new List<Post>
            {
                new Post
                {
                    Id = 1,
                    Title = "Getting Started with ASP.NET Core MVC",
                    Content = "ASP.NET Core MVC is a powerful framework for building web applications. It follows the Model-View-Controller pattern which helps in separation of concerns and makes code more maintainable.",
                    Author = "Desmond"
                },
                new Post
                {
                    Id = 2,
                    Title = "Understanding the MVC Pattern",
                    Content = "The MVC pattern divides your application into three main components: Models (data), Views (UI), and Controllers (logic). This separation makes it easier to manage complex applications.",
                    Author = "Lawrence"
                },
                new Post
                {
                    Id = 3,
                    Title = "Building Your First Web App",
                    Content = "Starting with web development can be challenging, but with the right tools and frameworks, you can build amazing applications. This post will guide you through the basics.",
                    Author = "Reymel"
                },
                new Post
                {
                    Id = 4,
                    Title = "Best Practices in Web Development",
                    Content = "Following best practices is crucial for building scalable and maintainable applications. Always write clean code, use proper naming conventions, and keep security in mind.",
                    Author = "Ken"
                }
            };
        }

        // Index action - displays all blog posts
        public IActionResult Index()
        {
            var posts = GetMockPosts();
            return View(posts);
        }

        // Details action - displays a single blog post by Id
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var posts = GetMockPosts();
            var post = posts.FirstOrDefault(p => p.Id == id);

            if (post == null)
            {
                return NotFound();
            }

            return View(post);
        }
    }
}
