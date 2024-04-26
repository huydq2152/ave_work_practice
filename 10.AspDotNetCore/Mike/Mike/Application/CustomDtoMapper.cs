using AutoMapper;
using Mike.Application.Share.Dtos.Announcement;
using Mike.Application.Share.Dtos.Document;
using Mike.Application.Share.Dtos.DocumentCategory;
using Mike.Application.Share.Dtos.Event;
using Mike.Application.Share.Dtos.How;
using Mike.Application.Share.Dtos.ImageGallery;
using Mike.Application.Share.Dtos.Navigation;
using Mike.Application.Share.Dtos.New;
using Mike.Application.Share.Dtos.QuickLink;
using Mike.Application.Share.Dtos.VideoGallery;
using Mike.Models.Entities;

namespace Mike.Application
{
    public class CustomDtoMapper : Profile
    {
        public CustomDtoMapper()
        {
            CreateMap<NavigationDto, Navigation>().ReverseMap();
            CreateMap<CreateOrEditNavigationDto, Navigation>().ReverseMap();
            CreateMap<NavigationDto, CreateOrEditNavigationDto>().ReverseMap();

            CreateMap<AnnouncementDto, Announcement>().ReverseMap();
            CreateMap<CreateOrEditAnnouncementDto, Announcement>().ReverseMap();
            CreateMap<AnnouncementDto, CreateOrEditAnnouncementDto>().ReverseMap();

            CreateMap<NewDto, New>().ReverseMap();
            CreateMap<CreateOrEditNewDto, New>().ReverseMap();
            CreateMap<NewDto, CreateOrEditNewDto>().ReverseMap();

            CreateMap<ImageGalleryDto, ImageGallery>().ReverseMap();
            CreateMap<CreateOrEditImageGalleryDto, ImageGallery>().ReverseMap();
            CreateMap<ImageGalleryDto, CreateOrEditImageGalleryDto>().ReverseMap();

            CreateMap<VideoGalleryDto, VideoGallery>().ReverseMap();
            CreateMap<CreateOrEditVideoGalleryDto, VideoGallery>().ReverseMap();
            CreateMap<VideoGalleryDto, CreateOrEditVideoGalleryDto>().ReverseMap();

            CreateMap<QuickLinkDto, QuickLink>().ReverseMap();
            CreateMap<CreateOrEditQuickLinkDto, QuickLink>().ReverseMap();
            CreateMap<QuickLinkDto, CreateOrEditQuickLinkDto>().ReverseMap();
            
            CreateMap<EventDto, Event>().ReverseMap();
            CreateMap<CreateOrEditEventDto, Event>().ReverseMap();
            CreateMap<EventDto, CreateOrEditEventDto>().ReverseMap();

            CreateMap<HowDto, How>().ReverseMap();
            CreateMap<CreateOrEditHowDto, How>().ReverseMap();
            CreateMap<HowDto, CreateOrEditHowDto>().ReverseMap();

            CreateMap<DocumentDto, Document>().ReverseMap();
            CreateMap<CreateOrEditDocumentDto, Document>().ReverseMap();
            CreateMap<DocumentDto, CreateOrEditDocumentDto>().ReverseMap();

            CreateMap<DocumentCategoryDto, DocumentCategory>().ReverseMap();
            CreateMap<CreateOrEditDocumentCategoryDto, DocumentCategory>().ReverseMap();
            CreateMap<DocumentCategoryDto, CreateOrEditDocumentCategoryDto>().ReverseMap();
        }
    }
}
