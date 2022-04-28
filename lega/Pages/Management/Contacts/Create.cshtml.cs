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

        public class CreateContactModel 
        {
            public int Id { get; set; }

            [Required(ErrorMessage = "Վերնագիրը պարտադիր է")]
            public string Title { get; set; }

            [Required(ErrorMessage = "Ռուսերեն վերնագիրը պարտադիր է")]
            public string TitleRu { get; set; }

            [Required(ErrorMessage = "Անգլերեն վերնագիրը պարտադիր է")]
            public string TitleEn { get; set; }

            [Required(ErrorMessage = "Հասցեն պարտադիր է")]
            public string Address { get; set; }

            [Required(ErrorMessage = "Ռուսերեն հասցեն պարտադիր է")]
            public string AddressRu { get; set; }

            [Required(ErrorMessage = "Անգլերեն հասցեն պարտադիր է")]
            public string AddressEn { get; set; }

            [Required(ErrorMessage = "Հեռախոսահամարը պարտադիր է")]
            public string Phone { get; set; }

            [EmailAddress(ErrorMessage = "Մուտքագրեք վավեր էլ․ հասցե")]
            public string Email { get; set; }

            [Required(ErrorMessage = "Վեբ կայքը պարտադիր է")]
            public string Website { get; set; }
            public bool Visible { get; set; }
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
                        TitleRu = Create.TitleRu,
                        TitleEn = Create.TitleEn,
                        Address = Create.Address,
                        AddressRu = Create.AddressRu,
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
