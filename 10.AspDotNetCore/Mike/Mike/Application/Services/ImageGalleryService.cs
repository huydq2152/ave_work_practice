using AutoMapper;
using Mike.Application.Share.Dtos.ImageGallery;
using Mike.Application.Share.Interface;
using Mike.Models.Common.Helpers;
using Mike.Models.Common;
using Mike.Models.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Mike.Application.Services
{
    public class ImageGalleryService : IImageGalleryService
    {
        private readonly IMapper _mapper;
        private readonly MikeDbContext _context;

        public ImageGalleryService(IMapper mapper, MikeDbContext context)
        {
            _mapper = mapper;
            _context = context;
        }

        private class QueryInput
        {
            public int? Id { get; set; }
        }
        private IQueryable<ImageGalleryDto> ImageGalleryQuery(QueryInput queryInput)
        {
            var id = queryInput.Id;

            var query = from obj in _context.ImageGalleries
                    .Where(o =>o.IsActive && (!id.HasValue || o.Id == id))
                    .OrderBy(o => o.Order)
                        select new ImageGalleryDto
                        {
                            Id = obj.Id,
                            Name = obj.Name,
                            Image = obj.Image,
                            IsActive = obj.IsActive,
                            Order = obj.Order
                        };
            return query;
        }


        public Task<PagedList<ImageGalleryDto>> GetPagedImageGallery(ImageGalleryParameters imageGalleryParameters)
        {
            var queryInput = new QueryInput();
            return Task.FromResult(PagedList<ImageGalleryDto>.ToPagedList(ImageGalleryQuery(queryInput),
                imageGalleryParameters.PageNumber,
                imageGalleryParameters.PageSize));
        }

        public async Task<ImageGalleryDto> GetImageGalleryById(int id)
        {
            var queryInput = new QueryInput()
            {
                Id = id
            };
            var objQuery = ImageGalleryQuery(queryInput);

            var res = await objQuery.FirstOrDefaultAsync();
            return res;
        }

        public async Task<ImageGallery> CreateOrEdit(CreateOrEditImageGalleryDto input)
        {
            input.Image = $"{GlobalConfig.ImageFolderUrl}/{input.Image}";
            if (input.Id == null)
            {
                return await Create(input);
            }
            else
            {
                return await Update(input);
            }
        }

        private async Task<ImageGallery> Create(CreateOrEditImageGalleryDto input)
        {
            var obj = _mapper.Map<ImageGallery>(input);
            await _context.AddAsync(obj);
            await _context.SaveChangesAsync();
            return obj;
        }

        private async Task<ImageGallery> Update(CreateOrEditImageGalleryDto input)
        {
            var obj = await _context.ImageGalleries.FirstOrDefaultAsync(o => o.Id == input.Id);
            if (obj == null) return null;

            _mapper.Map(input, obj);
            await _context.SaveChangesAsync();
            return obj;
        }

        public async Task<ImageGallery> Delete(int id)
        {
            var obj = await _context.ImageGalleries.FirstOrDefaultAsync(o => o.Id == id);
            if (obj == null) return null;

            _context.ImageGalleries.Remove(obj);
            await _context.SaveChangesAsync();
            return obj;
        }
    }
}
