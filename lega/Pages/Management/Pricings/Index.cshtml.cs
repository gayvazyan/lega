using lega.Core;
using lega.Core.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.Collections.Generic;
using System.Linq;

namespace lega.Pages.Management.Pricings
{
    public class IndexModel : PageModel
    {
        private readonly IPricingRepasitory _pricingRepasitory;
        public IndexModel(IPricingRepasitory pricingRepasitory)

        {
            _pricingRepasitory = pricingRepasitory;
            Input = new InputModel();
            InputList = new List<InputModel>();
        }


        [BindProperty]
        public InputModel Input { get; set; }

        public List<InputModel> InputList = new List<InputModel>();
        public class InputModel : Pricing { }

        //START Part Paging
        [BindProperty(SupportsGet = true)]
        public int CurrentPage { get; set; } = 1;
        public int Count { get; set; }
        public int PageSize { get; set; } = 10;

        public int TotalPages => (int)Math.Ceiling(decimal.Divide(Count, PageSize));

        public List<Pricing> PricingsList { get; set; }

        public bool ShowPrevious => CurrentPage > 1;
        public bool ShowNext => CurrentPage < TotalPages;
        public bool ShowFirst => CurrentPage != 1;
        public bool ShowLast => CurrentPage != TotalPages;
        //END Part Paging


        protected void PrepareData()
        {
            var pricingsList = _pricingRepasitory.GetAll().ToList();

           

            if (Input.Name != null)
            {
                pricingsList = pricingsList.Where(p => p.Name.ToUpper().Contains(Input.Name.ToUpper())).ToList();
            }

            if (Input.Context != null)
            {
                pricingsList = pricingsList.Where(p => p.Context.ToUpper().Contains(Input.Context.ToUpper())).ToList();
            }


            PricingsList = _pricingRepasitory.GetPaginatedResult(pricingsList, CurrentPage, PageSize);


            Count = _pricingRepasitory.GetCount(pricingsList);

            InputList = PricingsList.Select(p =>
            {
                return new InputModel()
                {
                    Id = p.Id,
                    Name = p.Name,
                    NameRu = p.NameRu,
                    NameEn = p.NameEn,
                    EmployeCount = p.EmployeCount,
                    PriceText = p.PriceText,
                    PriceTextRu = p.PriceTextRu,
                    PriceTextEn = p.PriceTextEn,
                    Context = p.Context,
                    ContextRu = p.ContextRu,
                    ContextEn = p.ContextEn,
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
