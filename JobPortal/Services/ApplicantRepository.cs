using System.Collections.Generic;
using System.Linq;
using JobPortal.Data;
using JobPortal.Models;
using Microsoft.AspNetCore.Identity;

namespace JobPortal.Services
{
    public class ApplicantRepository : IApplicantRepository
    {
        private readonly ApplicationDbContext _context;

        public ApplicantRepository(
            ApplicationDbContext context)
        {
            _context = context;
        }

        public List<Applicant> GetApplicantByJobId(string jobId)
        {
            return _context.Applicants.Where(x => x.JobId == jobId).ToList();
        }
    }
}