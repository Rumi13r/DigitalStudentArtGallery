using DigitalStudentArtGallery.Repositories;
using Microsoft.AspNetCore.Mvc;
using DigitalStudentArtGallery.ViewModels.Comment;
using DigitalStudentArtGallery.Entities;
using DigitalStudentArtGallery.Extentions;
using System.Xml.Linq;

namespace DigitalStudentArtGallery.Controllers
{
    public class Comment : Controller
    {
        private object commentRepository;

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

        public IActionResult Index(IndexVM vm)
        {
            return Index(vm, commentRepository);
        }

        private IActionResult Index(IndexVM vm, object commentRepository)
        {
            throw new NotImplementedException();
        }

        [HttpPost]
        public IActionResult Index(IndexVM vm, CommentRepository commentRepository, CommentRepository commentRepo)
        {
            CommentRepository commentRepoInstance = new CommentRepository();
            Comment comment = commentRepoInstance.GetById(vm.Id);
            comment.Likes++;

            commentRepoInstance.Save(comment);

            return View();
        }
        [HttpGet]
        public IActionResult Create(CreateVM vm)
        {
            Comments comment = new Comments();

            comment.OwnerId = HttpContext.Session.GetObject<User>("loggedUser").Id;
            comment.PostId = vm.PostId;
            comment.Text = vm.Text;
            comment.CreatedAt = DateTime.Now;

            CommentRepository commentRepository = new CommentRepository();
            commentRepository.Save(comment);

            return RedirectToAction("Index", "Comment");
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            CommentRepository commentRepository = new CommentRepository();
            Comments comment = CommentRepository.GetById(id);

            EditVM vm = new EditVM();
            vm.OwnerId = id;
            vm.PostId = comment.PostId;
            vm.Text = comment.Text;
            return View(vm);
        }

        [HttpPost]
        public IActionResult Edit(EditVM vm)
        {
            Comments comment = Comments();

            vm.OwnerId = id;
            vm.PostId = comment.PostId;
            vm.Text = comment.Text;

            CommentRepository commentRepository = new CommentRepository();
            commentRepository.Save(comment);

            return RedirectToAction("Index", "Comment");
        }

        public IActionResult Delete(int id)
        {
            CommentRepository repo = new CommentRepository();

            Comments toDelete = repo.GetById(id);

            if (toDelete != null)
                repo.Delete(toDelete);

            return RedirectToAction("Index", "Comments");
        }
    }
}
