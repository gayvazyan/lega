using lega.Core;
using lega.Core.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.Collections.Generic;

namespace lega.Pages.Management.Services
{
    public class DeleteModel : PageModel
    {
        private readonly IServiceRepasitory _serviceRepasitory;
        public DeleteModel(IServiceRepasitory serviceRepasitory)
        {
            _serviceRepasitory = serviceRepasitory;
            Delete = new DeleteAboutModel();
        }

        public class DeleteAboutModel : Service { }

        [BindProperty]
        public DeleteAboutModel Delete { get; set; }


        private List<ServiceError> _errors;
        public List<ServiceError> Errors
        {
            get => _errors ?? (_errors = new List<ServiceError>());
            set => _errors = value;
        }
        protected void PrepareData(int id)
        {
            var result = _serviceRepasitory.GetByID(id);

            if (result != null)
            {
                Delete.Id = result.Id;
                Delete.Title = result.Title;
                Delete.TitleEn = result.TitleEn;
                Delete.Context = result.Context;
                Delete.ContextEn = result.ContextEn;
                Delete.IconName = result.IconName;
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
                    var service = _serviceRepasitory.GetByID(Delete.Id);

                    _serviceRepasitory.Delete(service);

                    return RedirectToPage("/Management/Services/Index");

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
