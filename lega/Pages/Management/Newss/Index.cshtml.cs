using lega.Core;
using lega.Core.Entities;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace lega.Pages.Management.Newss
{

    public class IndexModel : PageModel
    {
        private readonly INewsRepasitory _newsRepasitory;
        public IndexModel(INewsRepasitory newsRepasitory)
     
        {
            _newsRepasitory = newsRepasitory;
            Input = new InputModel();
            InputList = new List<InputModel>();
        }


        [BindProperty]
        public InputModel Input { get; set; }

        public List<InputModel> InputList = new List<InputModel>();
        public class InputModel : News { }

        //START Part Paging
        [BindProperty(SupportsGet = true)]
        public int CurrentPage { get; set; } = 1;
        public int Count { get; set; }
        public int PageSize { get; set; } = 10;

        public int TotalPages => (int)Math.Ceiling(decimal.Divide(Count, PageSize));

        public List<News> NewsList { get; set; }

        public bool ShowPrevious => CurrentPage > 1;
        public bool ShowNext => CurrentPage < TotalPages;
        public bool ShowFirst => CurrentPage != 1;
        public bool ShowLast => CurrentPage != TotalPages;
        //END Part Paging


        protected void PrepareData()
        {
            var newsList = _newsRepasitory.GetAll().ToList();

           

            if (Input.Title != null)
            {
                newsList = newsList.Where(p => p.Title.ToUpper().Contains(Input.Title.ToUpper())).ToList();
            }

            if (Input.Context != null)
            {
                newsList = newsList.Where(p => p.Context.ToUpper().Contains(Input.Context.ToUpper())).ToList();
            }


            NewsList = _newsRepasitory.GetPaginatedResult(newsList, CurrentPage, PageSize);


            Count = _newsRepasitory.GetCount(newsList);

            InputList = NewsList.Select(p =>
            {
                return new InputModel()
                {
                    Id = p.Id,
                    Title = p.Title,
                    TitleEn = p.TitleEn,
                    Author = p.Author,
                    AuthorEn = p.AuthorEn,
                    ShortContext = p.ShortContext,
                    ShortContextEn = p.ShortContextEn,
                    Context = p.Context,
                    ContextEn = p.ContextEn,
                    ImageUrl = p.ImageUrl,
                    Visible = p.Visible,
                };
            }).ToList();
        }
        public void OnGet()
        {
            PrepareData();
        }

        public ActionResult OnPost()
        {
            PrepareData();
            return Page();
        }
    }
}
