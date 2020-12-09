#nullable enable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JobPortal.Data;
using JobPortal.Models;
using JobPortal.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace JobPortal.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AdminController : Controller
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly IUserRepository _userRepository;
        private readonly IJobRepository _jobRepository;
        private readonly ApplicationDbContext _context;

        public AdminController(UserManager<IdentityUser> userManager,
            IUserRepository userRepository,
            IJobRepository jobRepository,
            ApplicationDbContext context)
        {
            _context = context;
            _userManager = userManager;
            _userRepository = userRepository;
            _jobRepository = jobRepository;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult ListUsers()
        {
            string roleId = _userRepository.GetRoleId("Admin");
            List<string> userIds = _userRepository.GetUserIds(roleId);
            return View(_userRepository.GetUsers(userIds));
        }

        public IActionResult ListJobs()
        {
            return View(_jobRepository.GetAllJobs());
        }

        [HttpPost]
        public async Task<IActionResult> DeleteJob(string? jobid)
        {
            if (jobid == null)
            {
                return NotFound();
            }
            Jobs job = _jobRepository.GetJobById(jobid);
            if (job == null)
            {
                return NotFound();
            }

            _context.Remove(job);
            await _context.SaveChangesAsync();
            Response.Redirect("/Admin/ListJobs");
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> DeleteUser(string? userid)
        {
            if (userid == null)
            {
                return NotFound();
            }
            IdentityUser user = await _userManager.FindByIdAsync(userid);
            if (user == null)
            {
                return NotFound();
            }

            List<Jobs> jobsList = await _context.Jobs.Where(x => x.ProviderId == user.Id).ToListAsync();
            foreach (var job in jobsList)
            {
                _context.Remove(job);
            }
            await _context.SaveChangesAsync();
            var lockoutEndDate = new DateTime(2999,01,01);
            await _userManager.SetLockoutEnabledAsync(user, true);
            await _userManager.SetLockoutEndDateAsync(user, lockoutEndDate);
            Response.Redirect("/Admin/ListUsers");
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> UnBanUser(string? userid)
        {
            if (userid == null)
            {
                return NotFound();
            }
            IdentityUser user = await _userManager.FindByIdAsync(userid);
            if (user == null)
            {
                return NotFound();
            }
            await _userManager.SetLockoutEnabledAsync(user, false);
            Response.Redirect("/Admin/ListUsers");
            return RedirectToAction(nameof(Index));
        }
    }
}