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

        //private string ProcessUserImageBase64String(IFormFile uploadedImage)
        //{
        //    MemoryStream ms = new MemoryStream();

        //    uploadedImage.OpenReadStream().CopyTo(ms);

        //    Image image = Image.FromStream(ms);

        //    int x, iWidth, iHeight;
        //    if (image.Width <= image.Height)
        //    {
        //        iWidth = image.Width;
        //        iHeight = image.Width;
        //        x = 0;
        //    }
        //    else
        //    {
        //        iWidth = image.Height;
        //        iHeight = image.Height;
        //        x = (image.Width - image.Height) / 2;
        //    }

        //    int resulutionSize = 0;
        //    int diapason = 20;
        //    int base64StringLength = 0;
        //    bool braking = false;
        //    string base64String = "";
        //    int maxLength = 10000;
        //    do
        //    {
        //        resulutionSize = resulutionSize + diapason;
        //        var destRect = new Rectangle(0, 0, resulutionSize, resulutionSize);
        //        var destImage = new Bitmap(resulutionSize, resulutionSize);

        //        destImage.SetResolution(image.HorizontalResolution, image.VerticalResolution);

        //        using (var graphics = Graphics.FromImage(destImage))
        //        {
        //            graphics.CompositingMode = CompositingMode.SourceCopy;
        //            graphics.CompositingQuality = CompositingQuality.HighQuality;
        //            graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
        //            graphics.SmoothingMode = SmoothingMode.HighQuality;
        //            graphics.PixelOffsetMode = PixelOffsetMode.HighQuality;

        //            using (var wrapMode = new ImageAttributes())
        //            {
        //                wrapMode.SetWrapMode(WrapMode.TileFlipXY);
        //                graphics.DrawImage(image, destRect, x, 0, iWidth, iHeight, GraphicsUnit.Pixel, wrapMode);
        //            }
        //        }

        //        MemoryStream oMemoryStream = new MemoryStream();
        //        destImage.Save(oMemoryStream, image.RawFormat);

        //        base64String = Convert.ToBase64String(oMemoryStream.ToArray());
        //        base64StringLength = base64String.Length;

        //        if (braking && base64StringLength < maxLength)
        //        {
        //            break;
        //        }

        //        if (base64StringLength >= maxLength)
        //        {
        //            base64StringLength = maxLength - 1;
        //            braking = true;
        //            if ((resulutionSize - (2 * diapason)) > 0)
        //            {
        //                resulutionSize -= (2 * diapason);
        //            }
        //            else
        //            {
        //                resulutionSize = 0;
        //                diapason -= 1;
        //            }
        //        }
        //    }
        //    while (base64StringLength < maxLength);

        //    return base64String;
        //}
    }
}
