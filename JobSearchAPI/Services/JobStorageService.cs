using JobSearchAPI.Data;
using JobSearchAPI.Models;
using JobSearchAPI.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace JobSearchAPI.Services
{
    public class JobStorageService
    {
        private readonly DataBaseContext _dataBaseContext;

        public JobStorageService(DataBaseContext dataBaseContext)
        {
            this._dataBaseContext = dataBaseContext;
        }


        public IEnumerable<JobDetailsDto> GetJobs(string userName) 
        {
          var list= _dataBaseContext.JobDetails.Where(x => x.UserDetails.UserName == userName).ToList();
            return list;    

        }

        public Task<ActionResult>? saveJobsToDB(JobDetailsDto[] jobsToSave) 
        {
           // foreach (var job in jobsToSave)
            {
                _dataBaseContext.JobDetails.AddRange(jobsToSave);
                _dataBaseContext.SaveChanges();
                return null;
            }
        }

        public Task<ActionResult>? saveSearchToDB(JobSearchDto searchToSave)
        {
            {
                // load userdetails for searchToSave.usr.username
                //var userDetails = _dataBaseContext.UserDetails.Single(x => x.UserName == searchToSave.UserDetails.UserName);
                //searchToSave.UserId = userDetails.UserId;

                _dataBaseContext.JobSearches.AddRange(searchToSave);
                _dataBaseContext.SaveChanges();
                return null;
            }
        }

        public Task<ActionResult> deleteSavedJobs(int JobDetailId)
        {
            var found = _dataBaseContext.JobDetails.Single(x => x.JobDetailId == JobDetailId);
            _dataBaseContext.JobDetails.Remove(found);
            _dataBaseContext.SaveChanges();
            return null;
        }

        public Task<ActionResult> deleteSavedSearch(int JobSearchId)
        {
            var found = _dataBaseContext.JobSearches.Single(x => x.JobSearchId == JobSearchId);
            _dataBaseContext.JobSearches.Remove(found);
            _dataBaseContext.SaveChanges();
            return null;
        }

        public IEnumerable<JobSearchDto> getSavedSearches(string userName) 
        {
            var list = _dataBaseContext.JobSearches.Where(x => x.UserDetails.UserName == userName).ToList();
            return list;
        }
    }
}
