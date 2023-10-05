using Microsoft.OpenApi.Any;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace JobSearchAPI.Models
{
    public class JobSearchDto
    {
        public JobSearchDto()
        {
            //this.UserDetails = new UserDetailsDto();
        }
        [Key]
        public int? JobSearchId { get; set; }
        public int? UserId { get; set; }
        public string? SearchName { get; set; }
        public string? JobTitle { get; set; }
        public string? EmployerName { get; set; }
        public decimal? MinimumSalary { get; set; }
        public string? DatePosted { get; set; }
        public string? Keywords { get; set; }
        public bool? FullTime { get; set; }
        public bool? ContractEmployment { get; set; }

        [ForeignKey("UserId")]
        public virtual UserDetailsDto? UserDetails { get; set; }


    }
}
