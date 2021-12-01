using lega.Core;
using lega.Core.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace lega.Pages.Management.Contacts
{
    public class CreateModel : PageModel
    {
        private readonly IContactRepasitory _contactRepasitory;
        public CreateModel(IContactRepasitory contactRepasitory)
        {
            _contactRepasitory = contactRepasitory;
            Create = new CreateContactModel();
        }

        public class CreateContactModel : Contact
        {
            [EmailAddress(ErrorMessage = "Մուտքագրեք վավեր էլ․ հասցե")]
            new public string Email { get; set; }
        }

        [BindProperty]
        public CreateContactModel Create { get; set; }


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
                    var about = new Contact
                    {
                        Id = Create.Id,
                        Title = Create.Title,
                        TitleEn = Create.TitleEn,
                        Address = Create.Address,
                        AddressEn = Create.AddressEn,
                        Phone = Create.Phone,
                        Email = Create.Email,
                        Website = Create.Website,
                        Visible = Create.Visible,
                    };

                    var result = _contactRepasitory.Insert(about);

                    if (result != null)
                        return RedirectToPage("/Management/Contacts/Index");
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
