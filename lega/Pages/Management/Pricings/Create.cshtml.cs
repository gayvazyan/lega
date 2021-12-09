﻿using lega.Core;
using lega.Core.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace lega.Pages.Management.Pricings
{
    public class CreateModel : PageModel
    {
        private readonly IPricingRepasitory _pricingRepasitory;
        public CreateModel(IPricingRepasitory pricingRepasitory)
        {
            _pricingRepasitory = pricingRepasitory;
            Create = new CreatePricingModel();
        }

        public class CreatePricingModel
        {
            public int Id { get; set; }

            [Required(ErrorMessage = "Անունը պարտադիր է")]
            public string Name { get; set; }

            [Required(ErrorMessage = "Անգլերեն անունը պարտադիր է")]
            public string NameEn { get; set; }
            public int? EmployeCount { get; set; }
            public string PriceText { get; set; }
            public string PriceTextEn { get; set; }

            [Required(ErrorMessage = "Տեքստը պարտադիր է")]
            public string Context { get; set; }

            [Required(ErrorMessage = "Անգլերեն տեքստը պարտադիր է")]
            public string ContextEn { get; set; }
        }

        [BindProperty]
        public CreatePricingModel Create { get; set; }


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
                    var pricings = new Pricing
                    {
                        Id = Create.Id,
                        Name = Create.Name,
                        NameEn = Create.NameEn,
                        EmployeCount = Create.EmployeCount,
                        PriceText = Create.PriceText,
                        PriceTextEn = Create.PriceTextEn,
                        Context = Create.Context,
                        ContextEn = Create.ContextEn,
                    };

                    var result = _pricingRepasitory.Insert(pricings);

                    if (result != null)
                        return RedirectToPage("/Management/Pricings/Index");
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
