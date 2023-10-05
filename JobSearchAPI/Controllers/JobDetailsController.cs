using JobSearchAPI.Data;
using JobSearchAPI.Models;
using JobSearchAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace JobSearchAPI.Controllers
{
    [ApiController]
    [Route("jobdetails")]
    public class JobDetailsController: ControllerBase
    {
        private readonly JobDetailsService _jobDetailsService;
        private readonly DataBaseContext _dataBaseContext;
        
        public JobDetailsController(JobDetailsService jobDetailsService, DataBaseContext dataBaseContext) 
        {
            this._dataBaseContext = dataBaseContext ?? throw new ArgumentNullException(nameof(dataBaseContext));
            this._jobDetailsService = jobDetailsService ?? throw new ArgumentNullException( nameof(jobDetailsService));
        }

        [HttpPost]
        [Route("save")]
        public ActionResult saveJobs([FromBody] JobDetailsDto[] jobDetails) 
        {
            var saveJobs = _jobDetailsService.saveJobs(jobDetails);
            return Ok();
        }
    }
}
