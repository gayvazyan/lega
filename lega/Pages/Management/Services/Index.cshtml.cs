using lega.Core;
using lega.Core.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.Collections.Generic;
using System.Linq;

namespace lega.Pages.Management.Services
{
    public class IndexModel : PageModel
    {
        private readonly IServiceRepasitory _serviceRepasitory;
        public IndexModel(IServiceRepasitory serviceRepasitory)

        {
            _serviceRepasitory = serviceRepasitory;
            Input = new InputModel();
            InputList = new List<InputModel>();
        }


        [BindProperty]
        public InputModel Input { get; set; }

        public List<InputModel> InputList = new List<InputModel>();
        public class InputModel : Service { }

        //START Part Paging
        [BindProperty(SupportsGet = true)]
        public int CurrentPage { get; set; } = 1;
        public int Count { get; set; }
        public int PageSize { get; set; } = 10;

        public int TotalPages => (int)Math.Ceiling(decimal.Divide(Count, PageSize));

        public List<Service> ServiceList { get; set; }

        public bool ShowPrevious => CurrentPage > 1;
        public bool ShowNext => CurrentPage < TotalPages;
        public bool ShowFirst => CurrentPage != 1;
        public bool ShowLast => CurrentPage != TotalPages;
        //END Part Paging


        protected void PrepareData()
        {
            var serviceList = _serviceRepasitory.GetAll().ToList();

           

            if (Input.Title != null)
            {
                serviceList = serviceList.Where(p => p.Title.ToUpper().Contains(Input.Title.ToUpper())).ToList();
            }

            if (Input.Context != null)
            {
                serviceList = serviceList.Where(p => p.Context.ToUpper().Contains(Input.Context.ToUpper())).ToList();
            }


            ServiceList = _serviceRepasitory.GetPaginatedResult(serviceList, CurrentPage, PageSize);


            Count = _serviceRepasitory.GetCount(serviceList);

            InputList = ServiceList.Select(p =>
            {
                return new InputModel()
                {
                    Id = p.Id,
                    Title = p.Title,
                    TitleRu = p.TitleRu,
                    TitleEn = p.TitleEn,
                    Context = p.Context,
                    ContextRu = p.ContextRu,
                    ContextEn = p.ContextEn,
                    IconName = p.IconName,
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
