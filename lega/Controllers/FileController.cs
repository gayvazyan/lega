using System;
using System.IO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using lega.Core.Model;

namespace lega.Controllers
{
    [Route("[controller]/[action]")]
    public class FileController : Controller
    {
        public class ImageResult
        {
            public string Code { get; set; }
            public string Data { get; set; }
        }


        public FileController()
       
        {
        }


        [HttpPost]
        public JsonResult GetPicture(IFormFile file)
        {
            IFormFile uploadedImage = file;
            if (uploadedImage == null)
            {
                return Json(new ImageResult {Code = "null", Data="Նկար չի ընտրվել։" });
            }
            if (!uploadedImage.ContentType.ToLower().StartsWith("image/"))
            {
                return Json(new ImageResult { Code = "no-image", Data = "Ընտրված ֆայլը նկար չէ։" });
            }
            if (uploadedImage.Length > 20971520)
            {
                return Json(new ImageResult { Code = "big-file", Data = "Ընտրված ֆայլի չափը մեծ է 20Մբ-ից։" });
            }

            MemoryStream ms = new MemoryStream();
            uploadedImage.OpenReadStream().CopyTo(ms);
            byte[] bytes = ms.ToArray();
            var imageBase64String = Convert.ToBase64String(bytes);

            //var base64 = ProcessUserImageBase64String(uploadedImage);
            var imageSource = ImageSourceType.Base64Prefix + imageBase64String;

            return Json(new ImageResult { Code = "ok", Data = imageSource });
        }

       
    }
}
