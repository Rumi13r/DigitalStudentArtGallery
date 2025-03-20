using DigitalStudentArtGallery.Repositories;
using Microsoft.AspNetCore.Mvc;
using DigitalStudentArtGallery.Entities;
using DigitalStudentArtGallery.Extentions;
using DigitalStudentArtGallery.ViewModels.Posts;
using Microsoft.Extensions.Hosting;

namespace DigitalStudentArtGallery.Controllers
{
    public class PostController : Controller
    {
        private readonly PostRepository _postRepository;
        private readonly CommentRepository _commentRepository;

        public PostController()
        {
            _postRepository = new PostRepository();
            _commentRepository = new CommentRepository();
        }

        [HttpGet]
        public IActionResult Index()
        {
            IndexVM vm = new IndexVM();
            vm.Posts = _postRepository.GetAll();
            vm.Comments = _commentRepository.GetAll();
            return View(vm);
        }

        private IActionResult View(IndexVM vm)
        {
            throw new NotImplementedException();
        }

        [HttpPost]
        public IActionResult Index(IndexVM vm)
        {
            PostsEntities post = _postRepository.GetById(vm.Id);
            post.Likes++;

            _postRepository.Save(post);

            return View();
        }

        private IActionResult View(EditVM vm)
        {
            throw new NotImplementedException();
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(CreateVM vm)
        {
            PostsEntities post = new PostsEntities();

            post.OwnerId = HttpContext.Session.GetObject<User>("loggedUser").Id;
            post.Title = vm.Title;
            post.Description = vm.Description;
            post.Type = vm.Type;
            post.CreatedAt = DateTime.Now;

            _postRepository.Save(post);

            return RedirectToActionResult("Index", "Post");
        }

        private IActionResult RedirectToActionResult(string v1, string v2)
        {
            throw new NotImplementedException();
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            PostRepository PostRepository = new PostRepository();

            PostsEntities post = PostRepository.GetById(id);

            EditVM vm = new EditVM();
            vm.Id = id;
            vm.Title = post.Title;
            vm.Description = post.Description;
            vm.Type = post.Type;
            return View(vm);
        }

        [HttpPost]
        public IActionResult Edit(EditVM vm)
        {
            PostsEntities post = new PostsEntities();

            post.Id = vm.Id;
            post.Title = vm.Title;
            post.Description = vm.Description;
            post.Type = vm.Type;
            post.CreatedAt = DateTime.Now;

            _postRepository.Save(post);

            return RedirectToActionResult("Index", "Post");
        }

        public IActionResult Delete(int id)
        {
            PostsEntities toDelete = _postRepository.GetById(id);
            if (toDelete != null)
                _postRepository.Delete(toDelete);

            return RedirectToActionResult("Index", "Posts");
        }
    }
}
