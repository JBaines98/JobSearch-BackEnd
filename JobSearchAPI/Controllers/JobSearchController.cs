using JobSearchAPI.Data;
using JobSearchAPI.Models;
using JobSearchAPI.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace JobSearchAPI.Controllers
{
    [Route("/api")]
    [ApiController]
    public class JobSearchController : ControllerBase
    {
        private readonly JobSearchService _jobSearchService;
        private readonly DataBaseContext _dataBaseContext;

        // CONSTRUCTOR
        public JobSearchController(JobSearchService jobSearchService, JobDetailsService jobDetailsService, DataBaseContext dataBaseContext)
        {
            this._dataBaseContext = dataBaseContext ?? throw new ArgumentNullException(nameof(dataBaseContext));
            this._jobSearchService = jobSearchService ?? throw new ArgumentNullException(nameof(jobSearchService));
        }

        [HttpPost]
        [Route("saveSearch")]
        public ActionResult saveSearch([FromBody] JobSearchDto jobSearch)
        {
            var saveSearch = _jobSearchService.saveSearch(jobSearch);
            return Ok();
        }



        [HttpGet]
        [Route("search")]
        public async Task<ActionResult> RetrieveJobs([FromQuery] JobSearchDto jobSearch)
        {
            
            var searchResults = await _jobSearchService.GetJobs(jobSearch);
            return Ok(searchResults);
        }

    }
}
