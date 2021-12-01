﻿using lega.Core;
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


        public class UpdateContactModel : Contact
        {
            [EmailAddress(ErrorMessage = "Մուտքագրեք վավեր էլ․ հասցե")]
            new public string Email { get; set; }
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
                Update.TitleEn = result.TitleEn;
                Update.Address = result.Address;
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
                    contact.TitleEn = Update.TitleEn;
                    contact.Address = Update.Address;
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
