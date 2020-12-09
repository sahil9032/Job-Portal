using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using JobPortal.Data;
using JobPortal.Models;
using JobPortal.Services;
using JobPortal.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace JobPortal.Controllers
{
    [Authorize(Roles = "JobSeeker")]
    public class SeekerController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IJobRepository _jobRepository;

        public SeekerController(
            ApplicationDbContext context,
            IJobRepository jobRepository)
        {
            _context = context;
            _jobRepository = jobRepository;
        }

        public async Task<IActionResult> Index()
        {
            var applicants = await _context.Applicants
                .Where(x => x.UserId == User.FindFirstValue(ClaimTypes.NameIdentifier)).ToListAsync();
            return View(_context.Jobs.AsEnumerable()
                .Where(x => x.Active == true && applicants.All(y => y.JobId != x.JobId)).ToList());
        }

        [HttpGet]
        public IActionResult Apply(string jobid)
        {
            var job = _jobRepository.GetJobById(jobid);
            if (job == null)
            {
                return NotFound();
            }

            var model = new ApplyJobViewModel
            {
                JobId = jobid
            };
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Apply(ApplyJobViewModel model)
        {
            if (ModelState.IsValid)
            {
                var job = _jobRepository.GetJobById(model.JobId);
                if (job == null)
                {
                    return NotFound();
                }

                var applicant = new Applicant
                {
                    JobId = model.JobId,
                    UserId = User.FindFirstValue(ClaimTypes.NameIdentifier),
                    ResumeLink = model.ResumeLink
                };
                _context.Add(applicant);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            return View();
        }

        public async Task<IActionResult> ListJobs()
        {
            var applicants = await _context.Applicants
                .Where(x => x.UserId == User.FindFirstValue(ClaimTypes.NameIdentifier)).ToListAsync();
            return View(_context.Jobs.AsEnumerable().Where(x => applicants.Any(y => y.JobId == x.JobId)).ToList());
        }
    }
}