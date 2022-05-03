using lega.Core;
using lega.Core.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

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


        public class UpdatePricingModel
        {
            public int Id { get; set; }

            [Required(ErrorMessage = "Անունը պարտադիր է")]
            public string Name { get; set; }

            [Required(ErrorMessage = "Ռուսերեն անունը պարտադիր է")]
            public string NameRu { get; set; }

            [Required(ErrorMessage = "Անգլերեն անունը պարտադիր է")]
            public string NameEn { get; set; }
            public int? EmployeCount { get; set; }
            public string PriceText { get; set; }
            public string PriceTextRu { get; set; }
            public string PriceTextEn { get; set; }

            [Required(ErrorMessage = "Տեքստը պարտադիր է")]
            public string Context { get; set; }

            [Required(ErrorMessage = "Ռուսերեն տեքստը պարտադիր է")]
            public string ContextRu { get; set; }

            [Required(ErrorMessage = "Անգլերեն տեքստը պարտադիր է")]
            public string ContextEn { get; set; }

            public string Price { get; set; }
            public string PriceValue { get; set; }
            public string PriceValueRu { get; set; }
            public string PriceValueEn { get; set; }
        }


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
                Update.NameRu = result.NameRu;
                Update.NameEn = result.NameEn;
                Update.PriceText = result.PriceText;
                Update.PriceTextRu = result.PriceTextRu;
                Update.PriceTextEn = result.PriceTextEn;
                Update.EmployeCount = result.EmployeCount;
                Update.Context = result.Context;
                Update.ContextRu = result.ContextRu;
                Update.ContextEn = result.ContextEn;

                Update.Price = result.Price;
                Update.PriceValue = result.PriceValue;
                Update.PriceValueRu = result.PriceValueRu;
                Update.PriceValueEn = result.PriceValueEn;
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
                    pricing.NameRu = Update.NameRu;
                    pricing.NameEn = Update.NameEn;
                    pricing.PriceText = Update.PriceText;
                    pricing.PriceTextRu = Update.PriceTextRu;
                    pricing.PriceTextEn = Update.PriceTextEn;
                    pricing.EmployeCount = Update.EmployeCount;
                    pricing.Context = Update.Context;
                    pricing.ContextRu = Update.ContextRu;
                    pricing.ContextEn = Update.ContextEn;

                    pricing.Price = Update.Price;
                    pricing.PriceValue = Update.PriceValue;
                    pricing.PriceValueEn = Update.PriceValueEn;
                    pricing.PriceValueRu = Update.PriceValueRu;


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
