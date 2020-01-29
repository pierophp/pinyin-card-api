using CloudinaryDotNet;
using CloudinaryDotNet.Actions;
using Entities;
using Entities.Models;
using ImageMagick;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace Repository
{
    public class CardRepository : RepositoryBase<Card>
    {
        public CardRepository(RepositoryContext repositoryContext)
            : base(repositoryContext)
        {
        }

        public async Task<IEnumerable<Card>> GetAllAsync()
        {
            return await FindAll()
                .OrderBy(e => e.NameEn)
                .ToListAsync();
        }

        public async Task<IEnumerable<Card>> GetByCategoryIdAsync(int categoryId)
        {
            return await FindByCondition(e => e.CategoryId.Equals(categoryId))
                .OrderBy(e => e.NameEn)
                .ToListAsync();
        }

        public async Task<Card> GetByIdAsync(int id)
        {
            return await FindByCondition(e => e.Id.Equals(id))
                .FirstOrDefaultAsync();
        }

        public async Task<Card> SaveImage(Card card)
        {
            WebClient wc = new WebClient();
            byte[] bytes = wc.DownloadData(card.Image);
            MemoryStream memoryStream = new MemoryStream(bytes);

            MagickImage image = new MagickImage(memoryStream);

            Account account = new Account(
               "",
               "",
               ""
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

            var uploadParams = new ImageUploadParams()
            {
                File = new FileDescription(card.Image),
                PublicId = $"cards/{card.Id}",
                Transformation = tranformation,
            };

            var cloudinaryResponse = await cloudinary.UploadAsync(uploadParams);

            card.Image = cloudinaryResponse.Uri.ToString();

            return card;
        }


    }
}