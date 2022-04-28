using lega.Core;
using lega.Core.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

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


        public class UpdateCustomerModel
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
                Update.TitleRu = result.TitleRu;
                Update.TitleEn = result.TitleEn;
                Update.Context = result.Context;
                Update.ContextRu = result.ContextRu;
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
                    customer.TitleRu = Update.TitleRu;
                    customer.TitleEn = Update.TitleEn;
                    customer.Context = Update.Context;
                    customer.ContextRu = Update.ContextRu;
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
