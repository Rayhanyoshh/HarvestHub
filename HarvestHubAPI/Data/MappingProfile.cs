using AutoMapper;
using HarvestHubAPI.Models.DTO.Authentication;
using HarvestHubAPI.Models.Entities;
using HarvestHubProjectAPI.Models.DTO.Crop;
using HarvestHubProjectAPI.Models.DTO.FarmField;
using HarvestHubProjectAPI.Models.DTO.FarmSite;
using HarvestHubProjectAPI.Models.DTO.WorkTask;
using HarvestHubProjectAPI.Models.DTO.WorkTaskType;

namespace HarvestHubAPI.Models
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // User mappings
            CreateMap<RegisterRequestDto, User>()
                .ForMember(dest => dest.PasswordHash, opt => opt.Ignore())
                .ForMember(dest => dest.PasswordSalt, opt => opt.Ignore())
                .ForMember(dest => dest.CreatedDate, opt => opt.Ignore())
                .ForMember(dest => dest.ModifiedDate, opt => opt.Ignore())
                .ForMember(dest => dest.IsDeleted, opt => opt.Ignore())
                .ForMember(dest => dest.UserStatus, opt => opt.Ignore())
                .ForMember(dest => dest.UserId, opt => opt.Ignore());

            // WorkTask mappings
            CreateMap<CreateWorkTaskDto, WorkTask>()
                .ForMember(dest => dest.CreatedDate, opt => opt.Ignore())
                .ForMember(dest => dest.ModifiedDate, opt => opt.Ignore())
                .ForMember(dest => dest.IsCompleted, opt => opt.Ignore())
                .ForMember(dest => dest.IsDeleted, opt => opt.Ignore())
                .ForMember(dest => dest.IsStarted, opt => opt.Ignore())
                .ForMember(dest => dest.IsCancelled, opt => opt.Ignore());

            CreateMap<WorkTask, WorkTaskDTO>();

            // WorkTaskType mappings
            CreateMap<CreateWorkTaskTypeDto, WorkTaskType>()
                .ForMember(dest => dest.CreatedDate, opt => opt.Ignore())
                .ForMember(dest => dest.ModifiedDate, opt => opt.Ignore())
                .ForMember(dest => dest.IsDeleted, opt => opt.Ignore());

            CreateMap<WorkTaskType, WorkTaskTypeDTO>();

            // FarmField mappings
            CreateMap<FarmField, FarmFieldDTO>().ReverseMap();
            CreateMap<CreateFarmFieldDto, FarmField>()
                .ForMember(dest => dest.FarmFieldId, opt => opt.Ignore())
                .ForMember(dest => dest.CreatedDate, opt => opt.Ignore())
                .ForMember(dest => dest.ModifiedDate, opt => opt.Ignore())
                .ForMember(dest => dest.IsDeleted, opt => opt.Ignore());

            // FarmSite mappings
            CreateMap<FarmSite, FarmSiteDTO>().ReverseMap();
            CreateMap<CreateFarmSiteDto, FarmSite>()
                .ForMember(dest => dest.CreatedDate, opt => opt.Ignore())
                .ForMember(dest => dest.ModifiedDate, opt => opt.Ignore())
                .ForMember(dest => dest.IsDeleted, opt => opt.Ignore())
                .ForMember(dest => dest.CreatedUserId, opt => opt.Ignore())
                .ForMember(dest => dest.ModifiedUserId, opt => opt.Ignore());

            // Crop mappings
            CreateMap<CreateCropDto, Crop>()
                .ForMember(dest => dest.CreatedDate, opt => opt.Ignore())
                .ForMember(dest => dest.ModifiedDate, opt => opt.Ignore())
                .ForMember(dest => dest.IsDeleted, opt => opt.Ignore());

            CreateMap<Crop, CropDTO>();
        }
    }
}
