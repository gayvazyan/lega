using lega.Core;
using lega.Core.Entities;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace lega.Pages.Management.Newss
{
    public class UpdateModel : PageModel
    {
        private readonly INewsRepasitory _newsRepasitory;
        private readonly IHostingEnvironment _hostingEnvironment;
        public UpdateModel(INewsRepasitory newsRepasitory, IHostingEnvironment hostingEnvironment)
        {
            _newsRepasitory = newsRepasitory;
            _hostingEnvironment = hostingEnvironment;
            Update = new UpdateNewsModel();
        }

        public class UpdateNewsModel
       
        {
            public int Id { get; set; }

            [Required(ErrorMessage = "Վերնագիրը պարտադիր է")]
            public string Title { get; set; }

            [Required(ErrorMessage = "Ռուսերեն վերնագիրը պարտադիր է")]
            public string TitleRu { get; set; }

            [Required(ErrorMessage = "Անգլերեն վերնագիրը պարտադիր է")]
            public string TitleEn { get; set; }

            //[Required(ErrorMessage = "Հեղինակը պարտադիր է")]
            public string Author { get; set; }

            //[Required(ErrorMessage = "Ռուսերեն հեղինսկը պարտադիր է")]
            public string AuthorRu { get; set; }

           // [Required(ErrorMessage = "Անգլերեն հեղինսկը պարտադիր է")]
            public string AuthorEn { get; set; }

            [Required(ErrorMessage = "Կարճ տեքստը պարտադիր է")]
            public string ShortContext { get; set; }

            [Required(ErrorMessage = "Ռուսերեն կարճ տեքստը պարտադիր է")]
            public string ShortContextRu { get; set; }

            [Required(ErrorMessage = "Անգլերեն կարճ տեքստը պարտադիր է")]
            public string ShortContextEn { get; set; }

            [Required(ErrorMessage = "Տեքստը պարտադիր է")]
            public string Context { get; set; }

            [Required(ErrorMessage = "Ռուսերեն տեքստը պարտադիր է")]
            public string ContextRu { get; set; }

            [Required(ErrorMessage = "Անգլերեն տեքստը պարտադիր է")]
            public string ContextEn { get; set; }

            [Required(ErrorMessage = "Նկարը պարտադիր է")]
            public string ImageUrl { get; set; }

            [Required(ErrorMessage = "Ամսաթիվը պարտադիր է")]
            public DateTime Date { get; set; }
            public bool Visible { get; set; }
        }

        [BindProperty]
        public UpdateNewsModel Update { get; set; }

        [BindProperty]
        public string UniqueFileName { get; set; }

        private List<ServiceError> _errors;
        public List<ServiceError> Errors
        {
            get => _errors ?? (_errors = new List<ServiceError>());
            set => _errors = value;
        }

        protected void PrepareData(int id)
        {
           
            var result = _newsRepasitory.GetByID(id);

            if (result != null)
            {
                Update.Id = result.Id;
                Update.Title = result.Title;
                Update.TitleRu = result.TitleRu;
                Update.TitleEn = result.TitleEn;
                Update.Author = result.Author;
                Update.AuthorRu = result.AuthorRu;
                Update.AuthorEn = result.AuthorEn;
                Update.ShortContext = result.ShortContext;
                Update.ShortContextRu = result.ShortContextRu;
                Update.ShortContextEn = result.ShortContextEn;
                Update.Context = result.Context;
                Update.ContextRu = result.ContextRu;
                Update.ContextEn = result.ContextEn;
                Update.Date = result.Date;
                Update.ImageUrl = "/images/News/" + result.ImageUrl;
                Update.Visible = result.Visible;

                UniqueFileName = result.ImageUrl;
            }
        }
        public void OnGet(int id)
        {
            PrepareData(id);
        }

        public ActionResult OnPost()
        {
            if (ModelState.IsValid)
            {
                //save Image to Folder

                if (Update.ImageUrl != null && Update.ImageUrl.ToString().Contains("data:image/jpeg;base64"))
                {
                    var folderPath = Path.Combine(_hostingEnvironment.WebRootPath, "images\\News");
                    var oldFilePath = Path.Combine(folderPath, UniqueFileName);

                    UniqueFileName = Guid.NewGuid().ToString() + ".jpg";
                    var filePath = Path.Combine(folderPath, UniqueFileName);

                    var stringImage = Update.ImageUrl.ToString().Split(',')[1];

                    byte[] bytes = Convert.FromBase64String(stringImage);

                    using (MemoryStream stream = new MemoryStream(bytes))
                    {
                        IFormFile file = new FormFile(stream, 0, bytes.Length, UniqueFileName, UniqueFileName);
                        file.CopyTo(new FileStream(filePath, FileMode.Create));
                        stream.Close();
                    }

                    //delete old image from folder 
                    if (System.IO.File.Exists(oldFilePath))
                    {
                        System.IO.File.Delete(oldFilePath);
                    }
                }


                try
                {
                    var news = _newsRepasitory.GetByID(Update.Id);

                    news.Title = Update.Title;
                    news.TitleRu = Update.TitleRu;
                    news.TitleEn = Update.TitleEn;
                    news.Author = Update.Author;
                    news.AuthorRu = Update.AuthorRu;
                    news.AuthorEn = Update.AuthorEn;
                    news.ShortContext = Update.ShortContext;
                    news.ShortContextRu = Update.ShortContextRu;
                    news.ShortContextEn = Update.ShortContextEn;
                    news.Context = Update.Context;
                    news.ContextRu = Update.ContextRu;
                    news.ContextEn = Update.ContextEn;
                    news.Date = Update.Date;
                    news.ImageUrl = UniqueFileName;
                    news.Visible = Update.Visible;


                  _newsRepasitory.Update(news);

                    return RedirectToPage("/Management/Newss/Index");


                }
                catch (Exception ex)
                {
                    Errors.Add(new ServiceError { Code = "005", Description = ex.Message });
                    PrepareData(Update.Id);
                }
            }
            else
            {
                PrepareData(Update.Id);
            }

            return Page();
        }
    }
}
