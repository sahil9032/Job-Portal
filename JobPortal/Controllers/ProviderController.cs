#nullable enable
using System;
using System.Collections.Generic;
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
    [Authorize(Roles = "JobProvider")]
    public class ProviderController : Controller
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly ApplicationDbContext _context;
        private readonly IJobRepository _jobRepository;
        private readonly IApplicantRepository _applicantRepository;

        public ProviderController(UserManager<IdentityUser> userManager,
            ApplicationDbContext context,
            IJobRepository jobRepository,
            IApplicantRepository applicantRepository)
        {
            _context = context;
            _userManager = userManager;
            _jobRepository = jobRepository;
            _applicantRepository = applicantRepository;
        }

        public IActionResult Index()
        {
            string userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            return View(_jobRepository.GetJobByProviderId(userId));
        }

        [HttpGet]
        public IActionResult AddJob()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddJob(AddJobViewModel model)
        {
            if (ModelState.IsValid)
            {
                var job = new Jobs
                {
                    JobId = Guid.NewGuid().ToString(),
                    Active = true,
                    Location = model.Location,
                    Company = model.Company,
                    Salary = model.Salary,
                    ProviderId = User.FindFirstValue(ClaimTypes.NameIdentifier),
                    ToolsAndTechnologies = model.ToolsAndTechnologies
                };
                _context.Add(job);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            return View();
        }

        public async Task<IActionResult> ListApplicant(string jobid)
        {
            var job = _jobRepository.GetJobById(jobid);
            if (job == null || job.ProviderId != User.FindFirstValue(ClaimTypes.NameIdentifier))
            {
                Response.Redirect("/Identity/Account/AccessDenied");
            }

            List<Applicant> applicants = _applicantRepository.GetApplicantByJobId(jobid);
            List<ListApplicantViewModel> model = new List<ListApplicantViewModel>();
            if (applicants != null)
            {
                foreach (var applicant in applicants)
                {
                    var user = await _userManager.FindByIdAsync(applicant.UserId);
                    model.Add(new ListApplicantViewModel
                    {
                        ResumeLink = applicant.ResumeLink,
                        Email = user.Email
                    });
                }
            }

            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> UpdateJob(string? jobid)
        {
            if (jobid == null)
            {
                return NotFound();
            }

            var job = await _context.Jobs.FindAsync(jobid);
            if (job == null)
            {
                return NotFound();
            }

            return View(job);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateJob(string jobid,
            [Bind("JobId, Active, Location, Company, Salary, ToolsAndTechnologies, ProviderId")]
            Jobs job)
        {
            if (jobid != job.JobId || job.ProviderId != User.FindFirstValue(ClaimTypes.NameIdentifier))
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                _context.Update(job);
                await _context.SaveChangesAsync();

                return RedirectToAction(nameof(Index));
            }

            return View(job);
        }

        public async Task<IActionResult> CloseApplications()
        {
            string userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            return View(await _context.Jobs.Where(x => x.ProviderId == userId && x.Active).ToListAsync());
        }

        public async Task<IActionResult> Close(string jobid)
        {
            var job = await _context.Jobs.FindAsync(jobid);
            if (job == null || job.ProviderId != User.FindFirstValue(ClaimTypes.NameIdentifier))
            {
                return NotFound();
            }

            job.Active = false;

            _context.Update(job);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}