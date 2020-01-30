using CloudinaryDotNet;
using CloudinaryDotNet.Actions;
using ImageMagick;
using Microsoft.Extensions.Configuration;
using System;
using System.IO;
using System.Net;
using System.Threading.Tasks;

namespace PinyinCardApi.Controllers.Cards
{

    public class CloudinaryManager
    {
        private IConfiguration _config;

        public CloudinaryManager(IConfiguration config)
        {
            _config = config;
        }

        public async Task<string> SaveImage(string imageUrl, int cardId)
        {
            if (imageUrl.Contains("cloudinary.com"))
            {
                return imageUrl;
            }

            if (_config["cloudinary:account"] == "" || _config["cloudinary:apiKey"] == "" || _config["cloudinary:apiSecret"] == "")
            {
                return imageUrl;
            }

            byte[] bytes;

            if (imageUrl.StartsWith("http"))
            {
                WebClient wc = new WebClient();
                bytes = wc.DownloadData(imageUrl);
            }
            else
            {
                var imageUrlSplit = imageUrl.Split("base64,");
                if (imageUrlSplit.Length > 1)
                {
                    bytes = Convert.FromBase64String(imageUrlSplit[1]);
                }
                else
                {
                    throw new Exception("Invalid image");
                }
            }

            MemoryStream memoryStream = new MemoryStream(bytes);

            MagickImage image = new MagickImage(memoryStream);

            Account account = new Account(
               _config["cloudinary:account"],
               _config["cloudinary:apiKey"],
               _config["cloudinary:apiSecret"]
           );

            Cloudinary cloudinary = new Cloudinary(account);

            var tranformation = new Transformation().Quality("auto:eco");

            if (image.Width > image.Height)
            {
                tranformation.Width(1024);
            }
            else
            {
                tranformation.Height(768);
            }

            var folder = _config["cloudinary:folder"];
            if (folder == "")
            {
                folder = "cards";
            }

            var uploadParams = new ImageUploadParams()
            {
                File = new FileDescription(imageUrl),
                PublicId = $"{folder}/{cardId}",
                Transformation = tranformation,
            };

            var cloudinaryResponse = await cloudinary.UploadAsync(uploadParams);

            var newImageUrl = cloudinaryResponse.Uri.ToString();

            if (newImageUrl != "")
            {
                return newImageUrl;
            }

            return imageUrl;
        }
    }
}