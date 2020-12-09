using System.Collections.Generic;
using System.Linq;
using JobPortal.Data;
using JobPortal.Models;
using Microsoft.AspNetCore.Identity;

namespace JobPortal.Services
{
    public class JobRepository: IJobRepository
    {
        
        private readonly ApplicationDbContext _context;

        public JobRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public List<Jobs> GetAllJobs()
        {
            return _context.Jobs.ToList();
        }

        public List<Jobs> GetJobByProviderId(string providerId)
        {
            return _context.Jobs.Where(x => x.ProviderId == providerId).ToList();
        }

        public Jobs GetJobById(string jobId)
        {
            return _context.Jobs.Find(jobId);
        }
    }
}