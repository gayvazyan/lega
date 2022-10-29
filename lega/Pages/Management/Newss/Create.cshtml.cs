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

namespace lega.Pages.Management.Newss
{
    public class CreateModel : PageModel
    {
        private readonly INewsRepasitory _newsRepasitory;
        private readonly IHostingEnvironment _hostingEnvironment;
        public CreateModel(INewsRepasitory newsRepasitory, IHostingEnvironment hostingEnvironment)
        {
            _newsRepasitory = newsRepasitory;
            _hostingEnvironment = hostingEnvironment;
            Create = new CreateNewsModel();
        }

        public class CreateNewsModel
        {
            public int Id { get; set; }

            [Required(ErrorMessage = "Վերնագիրը պարտադիր է")]
            public string Title { get; set; }

            [Required(ErrorMessage = "Ռուսերեն վերնագիրը պարտադիր է")]
            public string TitleRu { get; set; }

            [Required(ErrorMessage = "Անգլերեն վերնագիրը պարտադիր է")]
            public string TitleEn { get; set; }

           // [Required(ErrorMessage = "Հեղինակը պարտադիր է")]
            public string Author { get; set; }

           // [Required(ErrorMessage = "Ռուսերեն հեղինսկը պարտադիր է")]
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
        public CreateNewsModel Create { get; set; }

        private string _uniqueFileName;


        private List<ServiceError> _errors;
        public List<ServiceError> Errors
        {
            get => _errors ?? (_errors = new List<ServiceError>());
            set => _errors = value;
        }
        public void OnGet()
        {
        }

        public ActionResult OnPost()
        {
            if (ModelState.IsValid)
            {
                try
                {
                    //save Image to Folder
                    if (Create.ImageUrl != null)
                    {
                        var folderPath = Path.Combine(_hostingEnvironment.WebRootPath, "images\\News");
                        _uniqueFileName = Guid.NewGuid().ToString() + ".jpg";
                        var filePath = Path.Combine(folderPath, _uniqueFileName);

                        var stringImage = Create.ImageUrl.ToString().Split(',')[1];

                        byte[] bytes = Convert.FromBase64String(stringImage);
                        using (MemoryStream stream = new MemoryStream(bytes))
                        {
                            IFormFile file = new FormFile(stream, 0, bytes.Length, _uniqueFileName, _uniqueFileName);
                            file.CopyTo(new FileStream(filePath, FileMode.Create));
                            stream.Close();
                        }
                            
                        
                    }

                    var news = new News
                    {
                        Id = Create.Id,
                        Author = Create.Author,
                        AuthorRu = Create.AuthorRu,
                        AuthorEn = Create.AuthorEn,
                        Title = Create.Title,
                        TitleRu = Create.TitleRu,
                        TitleEn = Create.TitleEn,
                        ShortContext = Create.ShortContext,
                        ShortContextRu = Create.ShortContextRu,
                        ShortContextEn = Create.ShortContextEn,
                        Context = Create.Context,
                        ContextRu = Create.ContextRu,
                        ContextEn = Create.ContextEn,
                        Date = Create.Date,
                        ImageUrl = _uniqueFileName,
                        Visible = Create.Visible,
                    };

                    var result = _newsRepasitory.Insert(news);

                    if (result != null)
                        return RedirectToPage("/Management/Newss/Index");
                   
                }
                catch (Exception ex)
                {
                    Errors.Add(new ServiceError { Code = "005", Description = ex.Message });
                }
            }
            return Page();
        }
    }
}
