using JobSearchAPI.Models;
using JobSearchAPI.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace JobSearchAPI.Controllers
{
    [Route("api/JobStorage")]
    [ApiController]
    public class JobStorageController : ControllerBase
    {
        private readonly JobStorageService _jobStorageService;

        public JobStorageController(JobStorageService jobStorageService)
        {
            _jobStorageService = jobStorageService;
        }

        [HttpGet]
        [Route("getSavedJobs")]
        public async Task<ActionResult<IEnumerable<JobDetailsDto[]>>> RetrieveJobs(string userName)
        {
            var savedJobsDB = _jobStorageService.GetJobs(userName);

            return Ok(savedJobsDB);
        }

        [HttpPost]
        [Route("saveMyJobs")]
        public ActionResult SaveJobs(JobDetailsDto[] jobsToSave)
        {
            _jobStorageService.saveJobsToDB(jobsToSave);
            return Ok();
        }

        [HttpPost]
        [Route("saveMySearch")]
        public ActionResult SaveSearch(JobSearchDto searchToSave)
        {
            _jobStorageService.saveSearchToDB(searchToSave);
            return Ok();
        }


        [HttpGet]
        [Route("getSavedSearch")]
        public async Task<ActionResult<IEnumerable<JobSearchDto[]>>> getSavedSearches(string userName)
        {
            var savedSearches = _jobStorageService.getSavedSearches(userName);
            return Ok(savedSearches);
        }

        [HttpDelete]
        [Route("deleteSavedJob")]
        public ActionResult deleteJob([FromQuery] int JobDetailId)
        {
            _jobStorageService.deleteSavedJobs(JobDetailId);
            return Ok();
        }

        [HttpDelete]
        [Route("deleteSavedSearch")]
        public ActionResult deleteSearch([FromQuery] int JobSearchId)
        {
            _jobStorageService.deleteSavedSearch(JobSearchId);
            return Ok();
        }
    }
}
