using lega.Core;
using lega.Core.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.Collections.Generic;

namespace lega.Pages.Management.Pricings
{
    public class DeleteModel : PageModel
    {
        private readonly IPricingRepasitory _pricingRepasitory;
        public DeleteModel(IPricingRepasitory pricingRepasitory)
        {
            _pricingRepasitory = pricingRepasitory;
            Delete = new DeletePricingModel();
        }

        public class DeletePricingModel : Pricing { }

        [BindProperty]
        public DeletePricingModel Delete { get; set; }


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
                Delete.Id = result.Id;
                Delete.Name = result.Name;
                Delete.NameEn = result.NameEn;
                Delete.PriceText = result.PriceText;
                Delete.PriceTextEn = result.PriceTextEn;
                Delete.EmployeCount = result.EmployeCount;
                Delete.Context = result.Context;
                Delete.ContextEn = result.ContextEn;
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
                    var pricing = _pricingRepasitory.GetByID(Delete.Id);

                    _pricingRepasitory.Delete(pricing);

                    return RedirectToPage("/Management/Pricings/Index");

                }
                catch (Exception ex)
                {
                    Errors.Add(new ServiceError { Code = "005", Description = ex.Message });
                    PrepareData(Delete.Id);
                }
            }

            return Page();
        }
    }
}