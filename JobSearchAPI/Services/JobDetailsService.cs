using JobSearchAPI.Data;
using JobSearchAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System.Reflection.Metadata.Ecma335;

namespace JobSearchAPI.Services
{
    public class JobDetailsService
    {
        private readonly DataBaseContext _dataBaseContext;

        public JobDetailsService(DataBaseContext dataBaseContext) 
        {
            this._dataBaseContext = dataBaseContext;
        }


        public JobDetailsDto[]? saveJobs(JobDetailsDto[] jobDetails)
        {
            var saveJobDetails = new JobDetailsDto
            {
                //JobDetailId = 10,
                UserId = 1,
                JobTitle = "Software Developer",
                JobId = 123456789,
                EmployerId = 987654321,
                EmployerName = "Reed",
                LocationPlace = "SS95FQ",
                MinimumSalary = 30000,
                MaximumSalary = 40000,
                ExpirationDate = new string("2023 09 22 00 00 00"),
                DatePosted = new string("2023 01 22 00 00 00"),
                JobDescription = "Great job. Reasonable working hours, positive working environment. Benefits include private healthcare and yearly bonus.",
                JobUrl = "https://www.reed.co.uk/",
                JobRating = 5,
                JobLiked = true,
            };
            _dataBaseContext.JobDetails.Add(saveJobDetails);
            _dataBaseContext.SaveChanges();

            return null;
        }
        
    }
}
