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
                    Title = "My first blog",
                    Content = "Hello, this is my first blog post! I like to share my thoughts with you all. Stay tuned for more updates and interesting content in the future.",
                    Author = "Desmond"
                },
                new Post
                {
                    Id = 2,
                    Title = "Understanding human connections",
                    Content = "Holabels! May kwento akizkis, gorabels ang lola nyey sa nyinistop para mag-buyla meslu ng mga nyoging syempre kailangan ko mag-breakfastlu diba! Syempre sayla ko yung mga nyoging pila akez ganyan oh nyoging nyoging pak! Pag ka getlas mes ng nyoging eto ang nabili kes.......Mars..ang dako..ang daks ems! Mars, kasing laki ng fesang mey..oh! Mars parang ano eh....Mars nakakamatay oh oh look oh hanggang ditobels eh..Laki mars oh..oh..Mars grabe ngayon lang ako makakakain ng ganitong nyoging.....oh diba..hello oh oh saan ka na? nandito na ako..oo, diba pwedeng gawing nyelphone oh diba..pwedeng gawing face..pwedeng iganyan-ganyan sa fesang..emsss..eme..laki SiSss ngayon lang ako makakakain ng ganito kalaking nyoging ang daks talaga sis!",
                    Author = "Lawrence"
                },
                new Post
                {
                    Id = 3,
                    Title = "My first massage session",
                    Content = "Humingang malalim, pumikit na muna At baka-sakaling namamalikmata lang Ba't nababahala? 'Di ba't ako'y mag-isa? 'Kala ko'y payapa, boses mo'y tumatawag pa Binaon naman na ang lahat Tinakpan naman na 'king sugat Ngunit ba't ba andito pa rin? Hirap na 'kong intindihin Tanging panalangin, lubayan na sana Dahil sa bawat tingin, mukha mo'y nakikita Kahit sa'n man mapunta ay anino mo'y kumakapit sa 'king kamay Ako ay dahan-dahang nililibing nang buhay pa Hindi na makalaya Dinadalaw mo 'ko bawat gabi Wala mang nakikita Haplos mo'y ramdam pa rin sa dilim.",
                    Author = "Reymel"
                },
                new Post
                {
                    Id = 4,
                    Title = "Best Practices in Software Development",
                    Content = "Following best practices is crucial for building software applications. Always write clean code, use proper naming conventions, and keep performance in mind.",
                    Author = "Ken"
                }
            };
        }

        // Index action - displays all blog posts, with optional search
        public IActionResult Index(string search)
        {
            var posts = GetMockPosts();
            if (!string.IsNullOrWhiteSpace(search))
            {
                var lowerSearch = search.ToLower();
                posts = posts.Where(p =>
                    (p.Title != null && p.Title.ToLower().Contains(lowerSearch)) ||
                    (p.Content != null && p.Content.ToLower().Contains(lowerSearch)) ||
                    (p.Author != null && p.Author.ToLower().Contains(lowerSearch))
                ).ToList();
            }
            ViewBag.Search = search;
            return View(posts);
        }

        // AJAX search endpoint - returns filtered posts as JSON
        [HttpGet]
        public IActionResult Search(string search)
        {
            var posts = GetMockPosts();
            if (!string.IsNullOrWhiteSpace(search))
            {
                var lowerSearch = search.ToLower();
                posts = posts.Where(p =>
                    (p.Title != null && p.Title.ToLower().Contains(lowerSearch)) ||
                    (p.Content != null && p.Content.ToLower().Contains(lowerSearch)) ||
                    (p.Author != null && p.Author.ToLower().Contains(lowerSearch))
                ).ToList();
            }
            return Json(posts);
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
