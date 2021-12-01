using lega.Core;
using lega.Core.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.Collections.Generic;

namespace lega.Pages.Management.Customers
{
    public class UpdateModel : PageModel
    {
        private readonly ICustomerRepasitory _customerRepasitory;
        public UpdateModel(ICustomerRepasitory customerRepasitory)
      
        {
            _customerRepasitory = customerRepasitory;
            Update = new UpdateCustomerModel();
        }


        public class UpdateCustomerModel : Customer { }


        [BindProperty]
        public UpdateCustomerModel Update { get; set; }

        private List<ServiceError> _errors;
        public List<ServiceError> Errors
        {
            get => _errors ?? (_errors = new List<ServiceError>());
            set => _errors = value;
        }

        protected void PrepareData(int id)
        {
            var result = _customerRepasitory.GetByID(id);

            if (result != null)
            {
                Update.Id = result.Id;
                Update.Title = result.Title;
                Update.TitleEn = result.TitleEn;
                Update.Context = result.Context;
                Update.ContextEn = result.ContextEn;
                Update.ImageURL = result.ImageURL;
                Update.LogoURL = result.LogoURL;
                Update.OrderNumber = result.OrderNumber;
                Update.TabState = result.TabState;
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
                    var customer = _customerRepasitory.GetByID(Update.Id);

                    customer.Title = Update.Title;
                    customer.TitleEn = Update.TitleEn;
                    customer.Context = Update.Context;
                    customer.ContextEn = Update.ContextEn;
                    customer.ImageURL = Update.ImageURL;
                    customer.OrderNumber = Update.OrderNumber;
                    customer.LogoURL = Update.LogoURL;
                    customer.TabState = Update.TabState;


                    _customerRepasitory.Update(customer);

                    return RedirectToPage("/Management/Customers/Index");
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
