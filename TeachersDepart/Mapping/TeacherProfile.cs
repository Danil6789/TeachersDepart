using TeachersDepart.Models;
using TeachersDepart.ViewModels;
using AutoMapper;

namespace TeachersDepart.Mapping
{
    public class TeacherProfile : Profile
    {
        public TeacherProfile()
        {
            CreateMap<Teacher, TeacherViewModel>()
                .ForMember(dest => dest.AcademicTitleName, opt => opt.MapFrom(src => src.AcademicTitle!.AcademicTitleName))
                .ForMember(dest => dest.AcademicDegreeName, opt => opt.MapFrom(src => src.AcademicDegree!.AcademicDegreeName))
                .ForMember(dest => dest.PositionName, opt => opt.MapFrom(src => src.Position!.PositionName));


            CreateMap<TeacherViewModel, Teacher>()
                .ForMember(dest => dest.AcademicTitleId, opt => opt.MapFrom(src => HelperAcademicTitleId(src.AcademicTitleName)))
                .ForMember(dest => dest.AcademicDegreeId, opt => opt.MapFrom(src => HelperAcademicDegreeId(src.AcademicDegreeName)))
                .ForMember(dest => dest.PositionId, opt => opt.MapFrom(src => HelperPositionId(src.PositionName)));
        }
        public int HelperPositionId(string positionName)
        {
            int id = 0;
            switch (positionName)
            {
                case "Заведующий кафедры":
                    id = 2;
                    break;

                case "Заместитель заведующего кафедры":
                    id = 4;
                    break;

                case "Заместитель преподавателя":
                    id = 7;
                    break;

                case "Лаборант":
                    id = 3;
                    break;

                case "Младший сотрудник кафедры":
                    id = 5;
                    break;
                case "Помощник преподавателя":
                    id = 6;
                    break;
                case "Преподаватель":
                    id = 1;
                    break;
                default:
                    id = 0;
                    break;
            }
            return id;
        }
        public int HelperAcademicDegreeId(string acadDegreeName)
        {
            int id = 0;
            switch (acadDegreeName)
            {
                case "к.т.н.":
                    id = 1;
                    break;

                case "д.т.н.":
                    id = 2;
                    break;

                case "к.ф.-м.н.":
                    id = 3;
                    break;

                case "д.ф-м.н.":
                    id = 4;
                    break;

                case "к.х.н.":
                    id = 5;
                    break;
                default:
                    id = 0;
                    break;
            }
            return id;
        }
        public int HelperAcademicTitleId(string acadTitleName)
        {
            int id = 0;
            switch (acadTitleName)
            {
                case "Профессор":
                    id = 1;
                    break;
                case "Доцент":
                    id = 2;
                    break;
                case "Академик":
                    id = 3;
                    break;
                case "Ассистент":
                    id = 4;
                    break;
                case "Член-корреспондент":
                    id = 5;
                    break;
                case "Учёный":
                    id = 6;
                    break;
                case "Главный учёный":
                    id = 7;
                    break;
                default:
                    id = 0;
                    break;
            }
            return id;
        }
    }
}
