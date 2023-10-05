using JobSearchAPI.Data;
using JobSearchAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace JobSearchAPI.Services
{
    public class JobSearchService
    {
        private readonly DataBaseContext _dataBaseContext;

        public JobSearchService(DataBaseContext dataBaseContext)
        {
            this._dataBaseContext = dataBaseContext;
        }


        public async Task<JobDetailsDto[]> GetJobs(JobSearchDto jobSearch) 
        {
            var client = new HttpClient();
            client.DefaultRequestHeaders.Add("Authorization", "Basic Nzk1YzM0OTktZDc0NS00ZGEyLTg5OTAtZGYwY2M2MjMyOTljOg ==");
            client.BaseAddress = new Uri("https://www.reed.co.uk/api/1.0/search");

            var jsonResult = await client.GetStringAsync(client.BaseAddress);
            var resultObject = JsonConvert.DeserializeObject<ResultsValues>(jsonResult);

            //var result = JsonConvert.DeserializeObject<JobDetailsDto[]>(jsonResult);

            return resultObject!.Results;
        }

        public JobSearchDto? saveSearch(JobSearchDto jobsearch) 
        {
            var saveJobSearch = new JobSearchDto()
            {
                UserId = 987654321,
                SearchName = "JackTest",
                JobTitle = "Firefighter",
                EmployerName = "Leigh Fire",
                MinimumSalary = 35000,
                DatePosted = new string("2023 09 22 00 00 00"),
                Keywords = "Fire",
                FullTime = true,
                ContractEmployment = false,
            };
            _dataBaseContext.JobSearches.Add(saveJobSearch);
            _dataBaseContext.SaveChanges();

            return null;
        }




       // private IActionResult Ok(string result)
        //{
          //  throw new NotImplementedException();
       // }

        //private IActionResult BadRequest()
        //{
        //    throw new NotImplementedException();
        //}
    }
}
