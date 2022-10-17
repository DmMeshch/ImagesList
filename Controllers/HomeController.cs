using ImageList.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PagerApp.Models;
using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace ImageList.Controllers
{
    public class HomeController : Controller
    {
        ImageContext db;
        public HomeController(ImageContext context)
        {
            this.db = context;
            // добавляем начальные данные
         /*   String strBLOBFilePath = @"C:\Users\mescheriakov_ds\source\repos\ImagesList\ImagesList\qr_code_Meshcheriakov.PNG";
            FileStream fsBLOBFile = new FileStream(strBLOBFilePath, FileMode.Open, FileAccess.Read);
            byte[] img= new Byte[fsBLOBFile.Length];
            fsBLOBFile.Read(img, 0, img.Length);
            fsBLOBFile.Close();
           for (int i = 0; i < 100; i++)
           {
                Image image = new Image { Name = "Картинка "+(i+1), ImageByte = img };
                db.Add(image); 
                db.SaveChanges(); 
           }*/
                 
             

            
        }
        public ActionResult Index()
        {
            return View();
        }
        public async Task<IActionResult> ListView(int page = 1)
        {
            int pageSize = 10;   

            IQueryable<Image> source = db.Images.OrderBy(x=>x.ID);
            var count = await source.CountAsync();
            var items = await source.Skip((page - 1) * pageSize).Take(pageSize).ToListAsync();

            PageViewModel pageViewModel = new PageViewModel(count, page, pageSize);
            IndexViewModel viewModel = new IndexViewModel
            {
                PageViewModel = pageViewModel,
                Images = items
            };
            return View(viewModel);
        }
    }
}