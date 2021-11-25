using lega.Core;
using lega.Core.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.Collections.Generic;

namespace lega.Pages.Management.Services
{
    public class UpdateModel : PageModel
    {
        private readonly IServiceRepasitory _serviceRepasitory;
        public UpdateModel(IServiceRepasitory serviceRepasitory)
      
        {
            _serviceRepasitory = serviceRepasitory;
            Update = new UpdateServiceModel();
        }


        public class UpdateServiceModel : Service { }


        [BindProperty]
        public UpdateServiceModel Update { get; set; }

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
                Update.Id = result.Id;
                Update.Title = result.Title;
                Update.TitleEn = result.TitleEn;
                Update.Context = result.Context;
                Update.ContextEn = result.ContextEn;
                Update.IconName = result.IconName;
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
                    var service = _serviceRepasitory.GetByID(Update.Id);

                    service.Title = Update.Title;
                    service.TitleEn = Update.TitleEn;
                    service.Context = Update.Context;
                    service.ContextEn = Update.ContextEn;
                    service.IconName = Update.IconName;


                    _serviceRepasitory.Update(service);

                    return RedirectToPage("/Management/Services/Index");
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
