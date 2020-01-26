using System.Linq;
using AutoMapper;
using DatingApp.API.Dtos;
using DatingApp.API.Models;

namespace DatingApp.API.Helpers
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<User, UserForListDto>()
            .ForMember(
                dest => dest.PhotoUrl, opt => opt.MapFrom(scr => scr.Photos.FirstOrDefault(p => p.IsMain).Url))
            .ForMember(
                dest => dest.Age, opt => opt.MapFrom(scr => scr.DateOfBirth.CalculateAge()));

            CreateMap<User, UserForDetailedDto>()
            .ForMember(
                dest => dest.PhotoUrl, opt => opt.MapFrom(scr => scr.Photos.FirstOrDefault(p => p.IsMain).Url))
            .ForMember(
                dest => dest.Age, opt => opt.MapFrom(scr => scr.DateOfBirth.CalculateAge()));

            CreateMap<Photo, PhotoForDetailedDto>();
            CreateMap<UserToUpdateDto, User>();
            CreateMap<Photo, PhotoForReturnDto>();
            CreateMap<PhotoForCreationDto, Photo>();
            CreateMap<UserToRegisterDto, User>();
            CreateMap<MessageForCreationDto, Message>().ReverseMap();
            CreateMap<Message, MessageToReturnDto>()
             .ForMember(
                dest => dest.SenderPhotoUrl, opt => opt.MapFrom(scr => scr.Sender.Photos.FirstOrDefault(p => p.IsMain).Url))
            .ForMember(
                dest => dest.RecipientPhotoUrl, opt => opt.MapFrom(scr => scr.Recipient.Photos.FirstOrDefault(p => p.IsMain).Url));
        }
    }
}