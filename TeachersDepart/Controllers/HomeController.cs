using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using TeachersDepart.Data;
using TeachersDepart.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using TeachersDepart.ViewModels;
using System.Linq;
using AutoMapper;
using System.Data;

namespace TeachersDepart.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;
        public HomeController(ILogger<HomeController> logger, ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _logger = logger;
            _mapper = mapper;
        }

        public async Task<IActionResult> Index()
        {
             var teachers = await _context.Teachers
                .Include(t => t.AcademicTitle)
                .Include(t => t.AcademicDegree)
                .Include(t => t.Position)
                .ToListAsync();

            var teachersVM = _mapper.Map<List<TeacherViewModel>>(teachers);

            return View(teachersVM);
        }
        [HttpGet]
        public async Task<IActionResult> Create()
        {
            int number = await _context.Teachers
                .OrderBy(t => t.TeacherPassportNumber)
                .Select(t => t.TeacherPassportNumber)
                .LastOrDefaultAsync();
            var model = new TeacherViewModel
            {
                TeacherPassportNumber = ++number
            };
            ViewBag.TeacherPassportNumber = number;
            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> Create(TeacherViewModel teacherVM)
        {
            var teacher = _mapper.Map<Teacher>(teacherVM);
            _context.Teachers.Add(teacher);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }
        
        public async Task<IActionResult> Delete(int? id)
        {
            var teacher = await _context.Teachers.FindAsync(id);
            if (teacher == null)
            {
                return NotFound();
            }

            _context.Teachers.Remove(teacher);
            await _context.SaveChangesAsync();

            return RedirectToAction("Index");
            /*            if (id != null)
                        {
                            Teacher teacher = new Teacher { TeacherPassportNumber = id.Value };
                            _context.Entry(teacher).State = EntityState.Deleted;
                            await _context.SaveChangesAsync();
                            return RedirectToAction("Index");
                        }
                        return NotFound();*/
        }
        [HttpGet]
        public async Task<IActionResult> Edit(int? id)
        {
            Teacher? teacher = await _context.Teachers
               .Include(t => t.AcademicTitle)
               .Include(t => t.AcademicDegree)
               .Include(t => t.Position)
               .FirstOrDefaultAsync(t => t.TeacherPassportNumber == id.Value);


            TeacherViewModel? teacherVM = _mapper.Map<TeacherViewModel>(teacher);
            if (teacherVM != null)
            {
                return View(teacherVM);
            }
            return NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> Edit(TeacherViewModel teacherVM)
        {
            Teacher teacher = _mapper.Map<Teacher>(teacherVM);
            _context.Teachers.Update(teacher);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Details(int? id)
        {
            Teacher? teacher = await _context.Teachers
               .Include(t => t.AcademicTitle)
               .Include(t => t.AcademicDegree)
               .Include(t => t.Position)
               .FirstOrDefaultAsync(t => t.TeacherPassportNumber == id.Value);
            TeacherViewModel? teacherVM = _mapper.Map<TeacherViewModel>(teacher);

            string[] words = teacherVM.FullName.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            if (teacherVM != null )
            {
                if (words.Length == 3)
                {
                    string family = teacherVM.FullName.Substring(0, teacherVM.FullName.IndexOf(' '));
                    string name = teacherVM.FullName.Substring(teacherVM.FullName.IndexOf(' '), teacherVM.FullName.LastIndexOf(' ') - teacherVM.FullName.IndexOf(' ') - 1);
                    string secondName = teacherVM.FullName.Substring(teacherVM.FullName.LastIndexOf(' ') + 1);
                    ViewBag.Family = family;
                    ViewBag.Name = name;
                    ViewBag.SecondName = secondName;

                    DateTime today = DateTime.Now;
                    DateOnly todayDO = DateOnly.FromDateTime(DateTime.Now);
                    int yearNow = today.Year;
                    int yearOfBirth = teacherVM.BirthDate.Year;
                    int age = yearNow - yearOfBirth;
                    if (todayDO.Month > teacherVM.BirthDate.Month)
                    {
                        ViewBag.Age = age;
                    }
                    else if (todayDO.Month == teacherVM.BirthDate.Month)
                    {
                        if (todayDO.Day >= teacherVM.BirthDate.Day)
                        {
                            ViewBag.Age = age;
                        }
                        else
                        {
                            ViewBag.Age = age - 1;
                        }
                    }
                    else
                    {
                        ViewBag.Age = age - 1;
                    }
                }
                else
                {
                    ViewBag.Name = teacherVM.FullName; ViewBag.Family = ""; ViewBag.SecondName = "";                
                }
                return View(teacherVM);
            }
            return NotFound();
        }
    }
}
