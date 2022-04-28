using lega.Core;
using lega.Core.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace lega.Pages.Management.Contacts
{
    public class UpdateModel : PageModel
    {
        private readonly IContactRepasitory _contactRepasitory;
        public UpdateModel(IContactRepasitory contactRepasitory)
      
        {
            _contactRepasitory = contactRepasitory;
            Update = new UpdateContactModel();
        }


        public class UpdateContactModel
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
        public UpdateContactModel Update { get; set; }

        private List<ServiceError> _errors;
        public List<ServiceError> Errors
        {
            get => _errors ?? (_errors = new List<ServiceError>());
            set => _errors = value;
        }

        protected void PrepareData(int id)
        {
            var result = _contactRepasitory.GetByID(id);

            if (result != null)
            {
                Update.Id = result.Id;
                Update.Title = result.Title;
                Update.TitleRu = result.TitleRu;
                Update.TitleEn = result.TitleEn;
                Update.Address = result.Address;
                Update.AddressRu = result.AddressRu;
                Update.AddressEn = result.AddressEn;
                Update.Phone = result.Phone;
                Update.Email = result.Email;
                Update.Website = result.Website;
                Update.Visible = result.Visible;
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
                    var contact = _contactRepasitory.GetByID(Update.Id);

                    contact.Title = Update.Title;
                    contact.TitleRu = Update.TitleRu;
                    contact.TitleEn = Update.TitleEn;
                    contact.Address = Update.Address;
                    contact.AddressRu = Update.AddressRu;
                    contact.AddressEn = Update.AddressEn;
                    contact.Phone = Update.Phone;
                    contact.Email = Update.Email;
                    contact.Website = Update.Website;
                    contact.Visible = Update.Visible;


                    _contactRepasitory.Update(contact);

                    return RedirectToPage("/Management/Contacts/Index");
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
