using lega.Core;
using lega.Core.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace lega.Pages.Management.Customers
{
    public class CreateModel : PageModel
    {
        private readonly ICustomerRepasitory _customerRepasitory;
        public CreateModel(ICustomerRepasitory customerRepasitory)
        {
            _customerRepasitory = customerRepasitory;
            Create = new CreateCustomerModel();
        }

        public class CreateCustomerModel
        {
            public int Id { get; set; }

            [Required(ErrorMessage = "Վերնագիրը պարտադիր է")]
            public string Title { get; set; }

            [Required(ErrorMessage = "Ռուսերեն վերնագիրը պարտադիր է")]
            public string TitleRu { get; set; }

            [Required(ErrorMessage = "Անգլերեն վերնագիրը պարտադիր է")]
            public string TitleEn { get; set; }

            [Required(ErrorMessage = "Տեքստը պարտադիր է")]
            public string Context { get; set; }

            [Required(ErrorMessage = "Ռուսերեն տեքստը պարտադիր է")]
            public string ContextRu { get; set; }

            [Required(ErrorMessage = "Անգլերեն տեքստը պարտադիր է")]
            public string ContextEn { get; set; }

            [Required(ErrorMessage = "Լոգոն պարտադիր է")]
            public string LogoURL { get; set; }

            [Required(ErrorMessage = "Նկարը պարտադիր է")]
            public string ImageURL { get; set; }
            public int OrderNumber { get; set; }
            public string TabState { get; set; }
        }

        [BindProperty]
        public CreateCustomerModel Create { get; set; }


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
                    var customer = new Customer
                    {
                        Id = Create.Id,
                        Title = Create.Title,
                        TitleRu = Create.TitleRu,
                        TitleEn = Create.TitleEn,
                        Context = Create.Context,
                        ContextRu = Create.ContextRu,
                        ContextEn = Create.ContextEn,
                        LogoURL = Create.LogoURL,
                        ImageURL = Create.ImageURL,
                        OrderNumber = Create.OrderNumber,
                        TabState = Create.TabState
                    };

                    var result = _customerRepasitory.Insert(customer);

                    if (result != null)
                        return RedirectToPage("/Management/Customers/Index");
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
