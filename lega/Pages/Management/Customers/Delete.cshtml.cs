using lega.Core;
using lega.Core.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.Collections.Generic;

namespace lega.Pages.Management.Customers
{
    public class DeleteModel : PageModel
    {
        private readonly ICustomerRepasitory _customerRepasitory;
        public DeleteModel(ICustomerRepasitory customerRepasitory)
        {
            _customerRepasitory = customerRepasitory;
            Delete = new DeleteCustomerModel();
        }

        public class DeleteCustomerModel : Customer { }

        [BindProperty]
        public DeleteCustomerModel Delete { get; set; }


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
                Delete.Id = result.Id;
                Delete.Title = result.Title;
                Delete.TitleEn = result.TitleEn;
                Delete.Context = result.Context;
                Delete.ContextEn = result.ContextEn;
                Delete.ImageURL = result.ImageURL;
                Delete.LogoURL = result.LogoURL;
                Delete.OrderNumber = result.OrderNumber;
                Delete.TabState = result.TabState;
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
                    var customer = _customerRepasitory.GetByID(Delete.Id);

                    _customerRepasitory.Delete(customer);

                    return RedirectToPage("/Management/Customers/Index");

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
