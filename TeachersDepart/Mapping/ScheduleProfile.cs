using AutoMapper;
using Microsoft.EntityFrameworkCore;
using TeachersDepart.Data;
using TeachersDepart.Models;
using TeachersDepart.ViewModels;

namespace TeachersDepart.Mapping
{
    public class ScheduleProfile : Profile
    {
        public ScheduleProfile()
        {
            
            CreateMap<TeachersGroupDiscipline, TeachersGroupDisciplineViewModel>()
                .ForMember(dest => dest.ClassType, opt => opt.MapFrom(src => src.ClassType.ClassTypeName))
                .ForMember(dest => dest.FullName, opt => opt.MapFrom(src => src.TeacherPassportNumberNavigation.FullName));

/*            CreateMap<TeachersGroupDisciplineViewModel, TeachersGroupDiscipline>()
                .ForMember(dest => dest.ClassTypeId, opt => opt.MapFrom(src => HelperClassTypeId(src.ClassType)))
                .ForMember(dest => dest.FullName, opt => opt.MapFrom(src => src.TeacherPassportNumberNavigation.FullName));*/
        }
        public int HelperClassTypeId(string classType)
        {
            int id = 0;
            switch (classType)
            {
                case "Лекция":
                    id = 2;
                    break;

                case "Семинар":
                    id = 4;
                    break;

                case "Лабораторная работа":
                    id = 3;
                    break;

                case "Курсовой проект":
                    id = 5;
                    break;

                case "Практика":
                    id = 1;
                    break;
                default:
                    id = 0;
                    break;
            }
            return id;
        }
    }
}
