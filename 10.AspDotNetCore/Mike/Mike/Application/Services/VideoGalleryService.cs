using AutoMapper;
using Mike.Application.Share.Dtos.VideoGallery;
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
    public class VideoGalleryService : IVideoGalleryService
    {
        private readonly IMapper _mapper;
        private readonly MikeDbContext _context;

        public VideoGalleryService(IMapper mapper, MikeDbContext context)
        {
            _mapper = mapper;
            _context = context;
        }

        private class QueryInput
        {
            public int? Id { get; set; }
        }
        private IQueryable<VideoGalleryDto> VideoGalleryQuery(QueryInput queryInput)
        {
            var id = queryInput.Id;

            var query = from obj in _context.VideoGalleries
                    .Where(o =>o.IsActive && (!id.HasValue || o.Id == id))
                    .OrderBy(o => o.Order)
                        select new VideoGalleryDto
                        {
                            Id = obj.Id,
                            Name = obj.Name,
                            Video = obj.Video,
                            Order = obj.Order,
                            IsActive = obj.IsActive,
                        };
            return query;
        }


        public Task<PagedList<VideoGalleryDto>> GetPagedVideoGallery(VideoGalleryParameters videoGalleryParameters)
        {
            var queryInput = new QueryInput();
            return Task.FromResult(PagedList<VideoGalleryDto>.ToPagedList(VideoGalleryQuery(queryInput),
                videoGalleryParameters.PageNumber,
                videoGalleryParameters.PageSize));
        }

        public async Task<VideoGalleryDto> GetVideoGalleryById(int id)
        {
            var queryInput = new QueryInput()
            {
                Id = id
            };
            var objQuery = VideoGalleryQuery(queryInput);

            var res = await objQuery.FirstOrDefaultAsync();
            return res;
        }

        public async Task<VideoGallery> CreateOrEdit(CreateOrEditVideoGalleryDto input)
        {
            input.Video = $"{GlobalConfig.ImageFolderUrl}/{input.Video}";
            if (input.Id == null)
            {
                return await Create(input);
            }
            else
            {
                return await Update(input);
            }
        }

        private async Task<VideoGallery> Create(CreateOrEditVideoGalleryDto input)
        {
            var obj = _mapper.Map<VideoGallery>(input);
            await _context.AddAsync(obj);
            await _context.SaveChangesAsync();
            return obj;
        }

        private async Task<VideoGallery> Update(CreateOrEditVideoGalleryDto input)
        {
            var obj = await _context.VideoGalleries.FirstOrDefaultAsync(o => o.Id == input.Id);
            if (obj == null) return null;

            _mapper.Map(input, obj);
            await _context.SaveChangesAsync();
            return obj;
        }

        public async Task<VideoGallery> Delete(int id)
        {
            var obj = await _context.VideoGalleries.FirstOrDefaultAsync(o => o.Id == id);
            if (obj == null) return null;

            _context.VideoGalleries.Remove(obj);
            await _context.SaveChangesAsync();
            return obj;
        }
    }
}
