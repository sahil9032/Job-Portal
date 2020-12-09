using System.Collections.Generic;
using JobPortal.Models;

namespace JobPortal.Services
{
    public interface IJobRepository
    {
        
        public List<Jobs> GetAllJobs();
        public List<Jobs> GetJobByProviderId(string providerId);
        public Jobs GetJobById(string jobId);
    }
}