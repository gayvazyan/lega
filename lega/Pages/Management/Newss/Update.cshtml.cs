using lega.Core;
using lega.Core.Entities;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace lega.Pages.Management.Newss
{
    public class UpdateModel : PageModel
    {
        private readonly INewsRepasitory _newsRepasitory;
        public UpdateModel(INewsRepasitory newsRepasitory)
        {
            _newsRepasitory = newsRepasitory;
            Update = new UpdateNewsModel();
        }

        public class UpdateNewsModel : News { }


        [BindProperty]
        public UpdateNewsModel Update { get; set; }

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
                Update.TitleEn = result.TitleEn;
                Update.Author = result.Author;
                Update.AuthorEn = result.AuthorEn;
                Update.ShortContext = result.ShortContext;
                Update.ShortContextEn = result.ShortContextEn;
                Update.Context = result.Context;
                Update.ContextEn = result.ContextEn;
                Update.Date = result.Date;
                Update.ImageUrl = result.ImageUrl;
                Update.Visible = result.Visible;
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
                try
                {
                    var news = _newsRepasitory.GetByID(Update.Id);

                    news.Title = Update.Title;
                    news.TitleEn = Update.TitleEn;
                    news.Author = Update.Author;
                    news.AuthorEn = Update.AuthorEn;
                    news.ShortContext = Update.ShortContext;
                    news.ShortContextEn = Update.ShortContextEn;
                    news.Context = Update.Context;
                    news.ContextEn = Update.ContextEn;
                    news.Date = Update.Date;
                    news.ImageUrl = Update.ImageUrl;
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
