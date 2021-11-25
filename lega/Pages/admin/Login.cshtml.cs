using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using lega.Core;
using lega.Core.Entities;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;


namespace lega.Pages.admin
{
    public class LoginModel : PageModel
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IUserRepasitory _userRepasitory;
        //private readonly IWebHostEnvironment _env;
        public LoginModel(IUserRepasitory userRepasitory,
                         IWebHostEnvironment env,
                          IHttpContextAccessor httpContextAccessor)

        {
            _httpContextAccessor = httpContextAccessor;
            _userRepasitory = userRepasitory;
            //_env = env;
            Input = new InputModel();
            UserList = new List<Users>();
        }


        [BindProperty]
        public InputModel Input { get; set; }

        [BindProperty]
        public List<Users> UserList { get; set; }

        public class InputModel : Users { }


        private List<ServiceError> _errors;
        public List<ServiceError> Errors
        {
            get => _errors ?? (_errors = new List<ServiceError>());
            set => _errors = value;
        }


        protected void PrepareData()
        {
            //var resultDir = Path.Combine(_env.WebRootPath, "csv");
            //var resultFileName = "users.csv";
            //string resultFilePath = Path.Combine(resultDir, resultFileName);

            //if (System.IO.File.Exists(resultFilePath))
            //{
            //    using (var reader = new StreamReader(@resultFilePath))
            //    {
            //        while (!reader.EndOfStream)
            //        {
            //            var line = reader.ReadLine();
            //            var values = line.Split('|');

            //            var user = new Users
            //            {
            //                Id = !String.IsNullOrEmpty(values[0]) ? Convert.ToInt32(values[0]) : 0,
            //                Login = values[1],
            //                Password = values[2],
            //                FirstName = values[3],
            //                LastName = values[4],
            //            };
            //            UserList.Add(user);
            //        }
            //    }
            //}
            UserList= _userRepasitory.GetAll().ToList();
        }

        public void OnGet()
        {
           
            // _httpContextAccessor.HttpContext.Session.SetString("user", "login");
        }

        public IActionResult OnPost()
        {
            PrepareData();
            if (ModelState.IsValid)
            {
                try
                {
                    var user = new Users
                    {
                        Login = Input.Login,
                        Password = Input.Password,
                    };



                    foreach (var item in UserList)
                    {
                        if (String.Equals(user.Login, item.Login) && String.Equals(user.Password , item.Password))
                           
                        {
                            _httpContextAccessor.HttpContext.Session.SetString("user", "login");
                        }
                    }

                    if (_httpContextAccessor.HttpContext.Session.GetString("user") == "login")
                    {
                        return RedirectToPage("/Management/Index");
                    }
                    else
                    {
                        Errors.Add(new ServiceError { Code = "Մուտքի սխալ", Description = "Մուտքագրված տվյալներով օգտատեր չի գտնվել։" });
                        PrepareData();
                        return Page();
                    }



                }
                catch (Exception ex)
                {
                    Errors.Add(new ServiceError { Code = "005", Description = ex.Message });
                    PrepareData();
                }
            }
            return Page();
        }
    }
}
