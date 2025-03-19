using DigitalStudentArtGallery.Repositories;
using DigitalStudentArtGallery.ViewModels;
using DigitalStudentArtGallery.ViewModels.Comment;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting;

namespace DigitalStudentArtGallery.Controllers
{
    public class PostController
    {
        [HttpGet]
        public IActionResult Index()
        {
            IndexVM vm = new IndexVM();

            PostRepository postRepository = new PostRepository();
            CommentRepository commentRepository = new CommentRepository();
            vm.Posts = postRepository.GetAll();
            vm.Comments = commentRepository.GetAll();

            return View(vm);
        }

        private IActionResult View(IndexVM vm)
        {
            throw new NotImplementedException();
        }

        [HttpPost]
        public IActionResult Index(IndexVM vm)
        {
            PostRepository postRepository = new PostRepository();
            Posts post = postRepository.GetById(vm.Id);
            post.Likes++;

            postRepository.Save(post);

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
            Posts post = new Posts();

            post.OwnerId = HttpContext.Session.GetObject<User>("loggedUser").Id;
            post.Title = vm.Title;
            post.Description = vm.Description;
            post.Type = vm.Type;
            post.CreatedAt = DateTime.Now;

            PostRepository postRepository = new PostRepository();
            postRepository.Save(post);

            return RedirectToActionResult("Index", "Post");
        }

        private IActionResult RedirectToActionResult(string v1, string v2)
        {
            throw new NotImplementedException();
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            PostRepository postRepository = new PostRepository();
            Posts post = postRepository.GetById(id);

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
            Posts post = new Posts();

            post.Id = vm.Id;
            post.Title = vm.Title;
            post.Description = vm.Description;
            post.Type = vm.Type;
            post.CreatedAt = DateTime.Now;

            PostRepository postRepository = new PostRepository();
            postRepository.Save(post);

            return RedirectToActionResult("Index", "Post");
        }

        public IActionResult Delete(int id)
        {
            PostRepository repo = new PostRepository();

            Posts toDelete = repo.GetById(id);

            if (toDelete != null)
                repo.Delete(toDelete);

            return RedirectToActionResult("Index", "Posts");
        }
    }
}
