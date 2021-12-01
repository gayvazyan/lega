using lega.Core;
using lega.Core.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.Collections.Generic;

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

        public class CreateCustomerModel : Customer { }

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
                        TitleEn = Create.TitleEn,
                        Context = Create.Context,
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
