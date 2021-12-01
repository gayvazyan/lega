using lega.Core;
using lega.Core.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.Collections.Generic;

namespace lega.Pages.Management.Contacts
{
    public class DeleteModel : PageModel
    {
        private readonly IContactRepasitory _contactRepasitory;
        public DeleteModel(IContactRepasitory contactRepasitory)
        {
            _contactRepasitory = contactRepasitory;
            Delete = new DeleteContactModel();
        }

        public class DeleteContactModel : Contact { }

        [BindProperty]
        public DeleteContactModel Delete { get; set; }


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
                Delete.Id = result.Id;
                Delete.Title = result.Title;
                Delete.TitleEn = result.TitleEn;
                Delete.Address = result.Address;
                Delete.AddressEn = result.AddressEn;
                Delete.Phone = result.Phone;
                Delete.Email = result.Email;
                Delete.Website = result.Website;
                Delete.Visible = result.Visible;
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
                    var contact = _contactRepasitory.GetByID(Delete.Id);

                    _contactRepasitory.Delete(contact);

                    return RedirectToPage("/Management/Contacts/Index");

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
