using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TeachersDepart.Data;
using TeachersDepart.Models;
using TeachersDepart.ViewModels;

namespace TeachersDepart.Controllers
{
    public class ScheduleController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;
        private List<TeachersGroupDisciplineViewModel> _scheduleVM;
        public ScheduleController(ILogger<HomeController> logger, ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _logger = logger;
            _mapper = mapper;
        }
        public async Task<IActionResult> IndexAsync()
        {
            List<TeachersGroupDiscipline> schedule = await _context.TeacherGroupDisciplines
                .Include(d => d.ClassType)
                .Include(d => d.TeacherPassportNumberNavigation)
                .Include(d => d.CourseNameNavigation)
                .Include(d => d.GroupNumberNavigation).ToListAsync();

            _scheduleVM = _mapper.Map<List<TeachersGroupDisciplineViewModel>>(schedule);
            return View(_scheduleVM);
        }
        public IActionResult Details()
        {
            return View();
        }

    }
}
