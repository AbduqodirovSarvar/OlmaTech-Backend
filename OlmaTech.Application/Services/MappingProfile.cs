using AutoMapper;
using OlmaTech.Application.Models;
using OlmaTech.Application.UseCases.AboutToDoList.Commands;
using OlmaTech.Application.UseCases.BlogPostToDoList.Commands;
using OlmaTech.Application.UseCases.ClientToDoList.Commands;
using OlmaTech.Application.UseCases.ContactToDoList.Commands;
using OlmaTech.Application.UseCases.HomePostToDoList.Commands;
using OlmaTech.Application.UseCases.MessageToDoList.Commands;
using OlmaTech.Application.UseCases.ProjectToDoList.Commands;
using OlmaTech.Application.UseCases.ServiceToDoList.Commands;
using OlmaTech.Application.UseCases.TeamToDoList.Commands;
using OlmaTech.Application.UseCases.UserToDoList.Commands;
using OlmaTech.Domain.Entities;
using OlmaTech.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OlmaTech.Application.Services
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            /*CreateMap<Enum, EnumViewModel>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => Convert.ToInt32(src)))
                .ForMember(dest => dest.Name, opt => opt.MapFrom<EnumNameResolver<Enum>>());*/

            // Enum -> EnumViewModel
            CreateMap<Enum, EnumViewModel>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => Convert.ToInt32(src)))
                .ForMember(dest => dest.Name, opt => opt.MapFrom(z => z.ToString()));

            /*CreateMap<Communication, EnumViewModel>()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => (int)src))
            .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.ToString()));

            CreateMap<Gender, EnumViewModel>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => (int)src))
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.ToString()));

            CreateMap<UserRole, EnumViewModel>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => (int)src))
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.ToString()));*/

            // About -> AboutViewModel
            CreateMap<About, AboutViewModel>()
                
                // Address
                .ForPath(x => x.Address.En, y => y.MapFrom(z => z.AddressEn))
                .ForPath(x => x.Address.Uz, y => y.MapFrom(z => z.AddressUz))
                .ForPath(x => x.Address.Ru, y => y.MapFrom(z => z.AddressRu))
                .ForPath(x => x.Address.Uzru, y => y.MapFrom(z => z.AddressUzRu))
                // Title
                .ForPath(x => x.Title.En, y => y.MapFrom(z => z.TitleEn))
                .ForPath(x => x.Title.Uz, y => y.MapFrom(z => z.TitleUz))
                .ForPath(x => x.Title.Ru, y => y.MapFrom(z => z.TitleRu))
                .ForPath(x => x.Title.Uzru, y => y.MapFrom(z => z.TitleUzRu))
                // Description
                .ForPath(x => x.Description.En, y => y.MapFrom(z => z.DescriptionEn))
                .ForPath(x => x.Description.Uz, y => y.MapFrom(z => z.DescriptionUz))
                .ForPath(x => x.Description.Ru, y => y.MapFrom(z => z.DescriptionRu))
                .ForPath(x => x.Description.Uzru, y => y.MapFrom(z => z.DescriptionUzRu))
                // Description footer
                .ForPath(x => x.DescriptionFooter.En, y => y.MapFrom(z => z.DescriptionFooterEn))
                .ForPath(x => x.DescriptionFooter.Uz, y => y.MapFrom(z => z.DescriptionFooterUz))
                .ForPath(x => x.DescriptionFooter.Ru, y => y.MapFrom(z => z.DescriptionFooterRu))
                .ForPath(x => x.DescriptionFooter.Uzru, y => y.MapFrom(z => z.DescriptionFooterUzRu));

            // BlogPost -> BlogPostViewModel
            CreateMap<BlogPost, BlogPostViewModel>()
                // Title
                .ForPath(x => x.Title.En, y => y.MapFrom(z => z.TitleEn))
                .ForPath(x => x.Title.Uz, y => y.MapFrom(z => z.TitleUz))
                .ForPath(x => x.Title.Ru, y => y.MapFrom(z => z.TitleRu))
                .ForPath(x => x.Title.Uzru, y => y.MapFrom(z => z.TitleUzRu))
                // Description
                .ForPath(x => x.Description.En, y => y.MapFrom(z => z.DescriptionEn))
                .ForPath(x => x.Description.Uz, y => y.MapFrom(z => z.DescriptionUz))
                .ForPath(x => x.Description.Ru, y => y.MapFrom(z => z.DescriptionRu))
                .ForPath(x => x.Description.Uzru, y => y.MapFrom(z => z.DescriptionUzRu))
                // Description
                .ForPath(x => x.Date.Year, y => y.MapFrom(z => z.CreatedAt.Year))
                .ForPath(x => x.Date.Month, y => y.MapFrom(z => z.CreatedAt.Month))
                .ForPath(x => x.Date.Day, y => y.MapFrom(z => z.CreatedAt.Day));

            // Contact -> ContactViewModel
            CreateMap<Contact, ContactViewModel>().ReverseMap();

            // Client -> ClientViewModel
            CreateMap<Client, ClientViewModel>()
                // FirstName
                .ForPath(x => x.Firstname.En, y => y.MapFrom(z => z.Firstname))
                .ForPath(x => x.Firstname.Uz, y => y.MapFrom(z => z.Firstname))
                .ForPath(x => x.Firstname.Ru, y => y.MapFrom(z => z.FirstnameRu))
                .ForPath(x => x.Firstname.Uzru, y => y.MapFrom(z => z.FirstnameRu))
                // LastName
                .ForPath(x => x.Lastname.En, y => y.MapFrom(z => z.Lastname))
                .ForPath(x => x.Lastname.Uz, y => y.MapFrom(z => z.Lastname))
                .ForPath(x => x.Lastname.Ru, y => y.MapFrom(z => z.LastnameRu))
                .ForPath(x => x.Lastname.Uzru, y => y.MapFrom(z => z.LastnameRu))
                // Position
                .ForPath(x => x.Position.En, y => y.MapFrom(z => z.PositionEn))
                .ForPath(x => x.Position.Uz, y => y.MapFrom(z => z.PositionUz))
                .ForPath(x => x.Position.Ru, y => y.MapFrom(z => z.PositionRu))
                .ForPath(x => x.Position.Uzru, y => y.MapFrom(z => z.PositionUzRu))
                // Description
                .ForPath(x => x.Comment.En, y => y.MapFrom(z => z.CommentEn))
                .ForPath(x => x.Comment.Uz, y => y.MapFrom(z => z.CommentUz))
                .ForPath(x => x.Comment.Ru, y => y.MapFrom(z => z.CommentRu))
                .ForPath(x => x.Comment.Uzru, y => y.MapFrom(z => z.CommentUzRu));

            // HomePost -> HomePostViewModel
            CreateMap<HomePost, HomePostViewModel>()
                // Subtitle
                .ForPath(x => x.Subtitle.En, y => y.MapFrom(z => z.SubtitleEn))
                .ForPath(x => x.Subtitle.Uz, y => y.MapFrom(z => z.SubtitleUz))
                .ForPath(x => x.Subtitle.Ru, y => y.MapFrom(z => z.SubtitleRu))
                .ForPath(x => x.Subtitle.Uzru, y => y.MapFrom(z => z.SubtitleUzRu))
                // Title
                .ForPath(x => x.Title.En, y => y.MapFrom(z => z.TitleEn))
                .ForPath(x => x.Title.Uz, y => y.MapFrom(z => z.TitleUz))
                .ForPath(x => x.Title.Ru, y => y.MapFrom(z => z.TitleRu))
                .ForPath(x => x.Title.Uzru, y => y.MapFrom(z => z.TitleUzRu))
                // Description
                .ForPath(x => x.Description.En, y => y.MapFrom(z => z.DescriptionEn))
                .ForPath(x => x.Description.Uz, y => y.MapFrom(z => z.DescriptionUz))
                .ForPath(x => x.Description.Ru, y => y.MapFrom(z => z.DescriptionRu))
                .ForPath(x => x.Description.Uzru, y => y.MapFrom(z => z.DescriptionUzRu));

            // Project -> ProjectViewModel
            CreateMap<Project, ProjectViewModel>()
                // Name
                .ForPath(x => x.Name.En, y => y.MapFrom(z => z.NameEn))
                .ForPath(x => x.Name.Uz, y => y.MapFrom(z => z.NameUz))
                .ForPath(x => x.Name.Ru, y => y.MapFrom(z => z.NameRu))
                .ForPath(x => x.Name.Uzru, y => y.MapFrom(z => z.NameUzRu))
                // Description
                .ForPath(x => x.Description.En, y => y.MapFrom(z => z.DescriptionEn))
                .ForPath(x => x.Description.Uz, y => y.MapFrom(z => z.DescriptionUz))
                .ForPath(x => x.Description.Ru, y => y.MapFrom(z => z.DescriptionRu))
                .ForPath(x => x.Description.Uzru, y => y.MapFrom(z => z.DescriptionUzRu));

            // Service -> ServiceViewModel
            CreateMap<Service, ServiceViewModel>()
                // Name
                .ForPath(x => x.Name.En, y => y.MapFrom(z => z.NameEn))
                .ForPath(x => x.Name.Uz, y => y.MapFrom(z => z.NameUz))
                .ForPath(x => x.Name.Ru, y => y.MapFrom(z => z.NameRu))
                .ForPath(x => x.Name.Uzru, y => y.MapFrom(z => z.NameUzRu))
                // Description
                .ForPath(x => x.Description.En, y => y.MapFrom(z => z.DescriptionEn))
                .ForPath(x => x.Description.Uz, y => y.MapFrom(z => z.DescriptionUz))
                .ForPath(x => x.Description.Ru, y => y.MapFrom(z => z.DescriptionRu))
                .ForPath(x => x.Description.Uzru, y => y.MapFrom(z => z.DescriptionUzRu));

            // Team -> TeamViewModel
            CreateMap<Team, TeamViewModel>()
                // Position
                .ForPath(x => x.Position.En, y => y.MapFrom(z => z.PositionEn))
                .ForPath(x => x.Position.Uz, y => y.MapFrom(z => z.PositionUz))
                .ForPath(x => x.Position.Ru, y => y.MapFrom(z => z.PositionRu))
                .ForPath(x => x.Position.Uzru, y => y.MapFrom(z => z.PositionUzRu))
                // FirstName
                .ForPath(x => x.Firstname.En, y => y.MapFrom(z => z.Firstname))
                .ForPath(x => x.Firstname.Uz, y => y.MapFrom(z => z.Firstname))
                .ForPath(x => x.Firstname.Ru, y => y.MapFrom(z => z.FirstnameRu))
                .ForPath(x => x.Firstname.Uzru, y => y.MapFrom(z => z.FirstnameRu))
                // LastName
                .ForPath(x => x.Lastname.En, y => y.MapFrom(z => z.Lastname))
                .ForPath(x => x.Lastname.Uz, y => y.MapFrom(z => z.Lastname))
                .ForPath(x => x.Lastname.Ru, y => y.MapFrom(z => z.LastnameRu))
                .ForPath(x => x.Lastname.Uzru, y => y.MapFrom(z => z.LastnameRu));

            // User -> UserViewModel
            CreateMap<User, UserViewModel>()
                // FirstName
                .ForPath(x => x.Firstname.En, y => y.MapFrom(z => z.Firstname))
                .ForPath(x => x.Firstname.Uz, y => y.MapFrom(z => z.Firstname))
                .ForPath(x => x.Firstname.Ru, y => y.MapFrom(z => z.FirstnameRu))
                .ForPath(x => x.Firstname.Uzru, y => y.MapFrom(z => z.FirstnameRu))
                // LastName
                .ForPath(x => x.Lastname.En, y => y.MapFrom(z => z.Lastname))
                .ForPath(x => x.Lastname.Uz, y => y.MapFrom(z => z.Lastname))
                .ForPath(x => x.Lastname.Ru, y => y.MapFrom(z => z.LastnameRu))
                .ForPath(x => x.Lastname.Uzru, y => y.MapFrom(z => z.LastnameRu));

            // CreateAboutCommand -> About
            CreateMap<CreateAboutCommand, About>()
                .ForMember(x => x.Photo, y => y.Ignore());

            // CreateBlogPostCommand -> BlogPost
            CreateMap<CreateBlogPostCommand, BlogPost>()
                .ForMember(x => x.Photo, y => y.Ignore());

            // CreateClientCommand -> Client
            CreateMap<CreateClientCommand, Client>()
                .ForMember(x => x.Photo, y => y.Ignore());

            // CreateContactCommand -> Contact
            CreateMap<CreateContactCommand, Contact>().ReverseMap();

            // CreateClientCommand -> Client
            CreateMap<CreateClientCommand, Client>().ReverseMap();

            // CreateHomePostCommand -> HomePost
            CreateMap<CreateHomePostCommand, HomePost>()
                .ForMember(x => x.Photo, y => y.Ignore());

            // CreateMessageCommand -> Message
            CreateMap<CreateMessageCommand, Message>()
                .ForMember(x => x.IsSeen, y => y.Ignore())
                .ForMember(x => x.IsReplied, y => y.Ignore());

            // CreateProjectCommand -> Project
            CreateMap<CreateProjectCommand, Project>()
                .ForMember(x => x.Photo, y => y.Ignore());

            // CreateServiceCommand -> Service
            CreateMap<CreateServiceCommand, Service>().ReverseMap();

            // CreateTeamCommand -> Team
            CreateMap<CreateTeamCommand, Team>()
                .ForMember(x => x.Photo, y => y.Ignore());

            // CreateUserCommand -> User
            CreateMap<CreateUserCommand, User>()
                .ForMember(x => x.Photo, y => y.Ignore())
                .ForMember(x => x.PasswordHash, y => y.Ignore());
        }
    }
}
