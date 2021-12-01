using lega.Core;
using lega.Core.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.Collections.Generic;

namespace lega.Pages.Management.Pricings
{
    public class UpdateModel : PageModel
    {
        private readonly IPricingRepasitory _pricingRepasitory;
        public UpdateModel(IPricingRepasitory pricingRepasitory)
      
        {
            _pricingRepasitory = pricingRepasitory;
            Update = new UpdatePricingModel();
        }


        public class UpdatePricingModel : Pricing { }


        [BindProperty]
        public UpdatePricingModel Update { get; set; }

        private List<ServiceError> _errors;
        public List<ServiceError> Errors
        {
            get => _errors ?? (_errors = new List<ServiceError>());
            set => _errors = value;
        }

        protected void PrepareData(int id)
        {
            var result = _pricingRepasitory.GetByID(id);

            if (result != null)
            {
                Update.Id = result.Id;
                Update.Name = result.Name;
                Update.NameEn = result.NameEn;
                Update.PriceText = result.PriceText;
                Update.PriceTextEn = result.PriceText;
                Update.EmployeCount = result.EmployeCount;
                Update.Context = result.Context;
                Update.ContextEn = result.ContextEn;
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
                    var pricing = _pricingRepasitory.GetByID(Update.Id);

                    pricing.Name = Update.Name;
                    pricing.NameEn = Update.NameEn;
                    pricing.PriceText = Update.PriceText;
                    pricing.PriceTextEn = Update.PriceTextEn;
                    pricing.EmployeCount = Update.EmployeCount;
                    pricing.Context = Update.Context;
                    pricing.ContextEn = Update.ContextEn;


                    _pricingRepasitory.Update(pricing);

                    return RedirectToPage("/Management/Pricings/Index");
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
