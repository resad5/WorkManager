using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using YSKProje.ToDo.DTO.DTOs.AppUserDTOs;
using YSKProje.ToDo.DTO.DTOs.BildirisDTOs;
using YSKProje.ToDo.DTO.DTOs.IsDTOs;
using YSKProje.ToDo.DTO.DTOs.RaporDTOs;
using YSKProje.ToDo.DTO.DTOs.VaciblikDTOs;
using YSKProje.ToDo.Entities.Concrete;

namespace YSKProje.ToDo.Web.Maping.AutoMaperProfile
{
    public class MapProfile : Profile
    {

        public MapProfile()
        {
            #region Vaciblik-VaciblikDTO
            CreateMap<VaciblikAddDTO, Vaciblik>();
            CreateMap<Vaciblik, VaciblikAddDTO>();
            CreateMap<VaciblikListDTO, Vaciblik>();
            CreateMap<Vaciblik, VaciblikListDTO>();
            CreateMap<VaciblikUpdateDTO, Vaciblik>();
            CreateMap<Vaciblik, VaciblikUpdateDTO>();
            #endregion

            #region AppUser-AppUserDTO
            CreateMap<AppUserAddDTO, AppUser>();
            CreateMap<AppUser, AppUserAddDTO>();
            CreateMap<AppUserListDTO, AppUser>();
            CreateMap<AppUser, AppUserListDTO>();
            CreateMap<AppUserSignInDTO, AppUser>();
            CreateMap<AppUser, AppUserSignInDTO>();
            #endregion

            #region Bildiris-BildirisDTO
            CreateMap<BildirisListDTO, Bildiris>();
            CreateMap<Bildiris, BildirisListDTO>();
            #endregion;


            #region Is-IsDTO
            CreateMap<IsListDTO, Is>();
            CreateMap<Is, IsListDTO>();
            CreateMap<IsAddDTO, Is>();
            CreateMap<Is, IsAddDTO>();
            CreateMap<IsUpdateDTO, Is>();
            CreateMap<Is, IsUpdateDTO>();
            CreateMap<IsListAllDTO, Is>();
            CreateMap<Is, IsListAllDTO>();
            #endregion

            #region Rapor-RaporDTo
            CreateMap<RaporAddDTO, Rapor>();
            CreateMap<Rapor, RaporAddDTO>();
            CreateMap<RaporUpdateDTO, Rapor>();
            CreateMap<Rapor, RaporUpdateDTO>();
            CreateMap<RaporFileDTO, Rapor>();
            CreateMap<Rapor, RaporFileDTO>();
            #endregion



        }
    }

}
