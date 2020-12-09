using System.Collections.Generic;
using JobPortal.Models;

namespace JobPortal.Services
{
    public interface IApplicantRepository
    {
        public List<Applicant> GetApplicantByJobId(string jobId);
    }
}