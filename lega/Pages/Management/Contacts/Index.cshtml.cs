using lega.Core;
using lega.Core.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.Collections.Generic;
using System.Linq;

namespace lega.Pages.Management.Contacts
{
    public class IndexModel : PageModel
    {
        private readonly IContactRepasitory _contactRepasitory;
        public IndexModel(IContactRepasitory contactRepasitory)

        {
            _contactRepasitory = contactRepasitory;
            Input = new InputModel();
            InputList = new List<InputModel>();
        }


        [BindProperty]
        public InputModel Input { get; set; }

        public List<InputModel> InputList = new List<InputModel>();
        public class InputModel : Contact { }

        //START Part Paging
        [BindProperty(SupportsGet = true)]
        public int CurrentPage { get; set; } = 1;
        public int Count { get; set; }
        public int PageSize { get; set; } = 10;

        public int TotalPages => (int)Math.Ceiling(decimal.Divide(Count, PageSize));

        public List<Contact> ContactList { get; set; }

        public bool ShowPrevious => CurrentPage > 1;
        public bool ShowNext => CurrentPage < TotalPages;
        public bool ShowFirst => CurrentPage != 1;
        public bool ShowLast => CurrentPage != TotalPages;
        //END Part Paging


        protected void PrepareData()
        {
            var contactList = _contactRepasitory.GetAll().ToList();

           

            if (Input.Title != null)
            {
                contactList = contactList.Where(p => p.Title.ToUpper().Contains(Input.Title.ToUpper())).ToList();
            }

            if (Input.Address != null)
            {
                contactList = contactList.Where(p => p.Address.ToUpper().Contains(Input.Address.ToUpper())).ToList();
            }


            ContactList = _contactRepasitory.GetPaginatedResult(contactList, CurrentPage, PageSize);


            Count = _contactRepasitory.GetCount(contactList);

            InputList = ContactList.Select(p =>
            {
                return new InputModel()
                {
                    Id = p.Id,
                    Title = p.Title,
                    TitleEn = p.TitleEn,
                    Address = p.Address,
                    AddressEn = p.Address,
                    Phone = p.Phone,
                    Email = p.Email,
                    Website = p.Website,
                    Visible = p.Visible,
                };
            }).ToList();
        }
        public void OnGet()
        {
            PrepareData();
        }

        public ActionResult OnPost()
        {
            PrepareData();
            return Page();
        }
    }
}
