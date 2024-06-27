using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RedSocial.Core.Application.Interfaces.Services;
using RedSocial.Core.Application.ViewModels.Post;


namespace RedSocial.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IPostService _postService;
        private readonly IMapper _mapper;

        public HomeController(ILogger<HomeController> logger, IPostService postService, IMapper mapper)
        {
            _logger = logger;
            _postService = postService;
            _mapper = mapper;
        }

        public async Task<IActionResult> EditPost([FromRoute] int id)
        {
            SavePostViewModel vm = _mapper.Map<SavePostViewModel>(await _postService.GetByIdViewModel(id));
            return View(vm);
        }



        [HttpPost]
        public async Task<IActionResult> EditPost(SavePostViewModel vm)
        {


            vm.Created = DateTime.Now;
            if (vm.VideoUrl == null && vm.Photo != null)
            {
                vm.ImageURL = UploadFile(vm.Photo, vm.ID, true, vm.ImageURL);
                await _postService.Update(vm, vm.ID);
            }
            await _postService.Update(vm, vm.ID);



            return RedirectToRoute(new { controller = "Home", action = "Index" });
        }

        public async Task<IActionResult> Index()
        {

            return View(await _postService.GetAllViewModel());

        }

        [HttpGet]
        public async Task<IActionResult> DeletePost([FromRoute] int id)
        {
            await _postService.Delete(id);
            return RedirectToRoute(new { controller = "Home", action = "Index" });

        }




        [HttpPost]
        public async Task<IActionResult> AddPost(SavePostViewModel vm)
        {
            if (!ModelState.IsValid)
            {
               
                return View("Index");

            }
            vm.Created = DateTime.Now;
            var PublicacinGuardada = await _postService.Add(vm);

            if (vm.VideoUrl == null && vm.Photo != null)
            {
                PublicacinGuardada.ImageURL = UploadFile(vm.Photo, PublicacinGuardada.ID);
                await _postService.Update(PublicacinGuardada, PublicacinGuardada.ID);
            }



            if (PublicacinGuardada != null)
            {
                return RedirectToRoute(new { controller = "Home", action = "Index" });
            }
            
            return View("Index");


        }

        private string UploadFile(IFormFile file, int ID, bool isEditMode = false, string imageURL = "")
        {
            if (isEditMode && file == null)
            {
                return imageURL;
            }
            /* Get file directory */

            string basePath = $"/images/imagePost/{ID}";
            string path = Path.Combine(Directory.GetCurrentDirectory(), $"wwwroot{basePath}");

            // Create user folder if not exists
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }

            /* Get file path */

            // Gets the name of the original file
            FileInfo fileInfo = new(file.FileName);

            //Create a unique ID
            Guid guid = Guid.NewGuid();

            string fileName = guid + fileInfo.Extension;
            string fileNameWithPath = Path.Combine(path, fileName);

            using (var stream = new FileStream(fileNameWithPath, FileMode.Create))
            {
                file.CopyTo(stream);
            }

            if (isEditMode)
            {
                string[] oldImagePart = imageURL.Split('/');
                string oldImageName = oldImagePart[^1];
                string completeImageOldPath = Path.Combine(path, oldImageName);

                if (System.IO.File.Exists(completeImageOldPath))
                {
                    System.IO.File.Delete(completeImageOldPath);
                }
            }

            return $"{basePath}/{fileName}";
        }


        public IActionResult Perfil()
        {
            return View();
        }

        public IActionResult Amigos()
        {
            return View();
        }
    }
}
