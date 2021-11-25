using lega.Core;
using lega.Core.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.Collections.Generic;

namespace lega.Pages.Management.Services
{
    public class CreateModel : PageModel
    {
        private readonly IServiceRepasitory _serviceRepasitory;
        public CreateModel(IServiceRepasitory serviceRepasitory)
        {
            _serviceRepasitory = serviceRepasitory;
            Create = new CreateServiceModel();
        }

        public class CreateServiceModel : Service { }

        [BindProperty]
        public CreateServiceModel Create { get; set; }


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
                    var service = new Service
                    {
                        Id = Create.Id,
                        Title = Create.Title,
                        TitleEn = Create.TitleEn,
                        Context = Create.Context,
                        ContextEn = Create.ContextEn,
                        IconName = Create.IconName,
                    };

                    var result = _serviceRepasitory.Insert(service);

                    if (result != null)
                        return RedirectToPage("/Management/Services/Index");
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
