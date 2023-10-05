using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace JobSearchAPI.Models
{
    public class JobDetailsDto
    {
        public JobDetailsDto() { 
            this.UserDetails = new UserDetailsDto();
        }
        [Key]
        public int? JobDetailId { get; set; } 
        public int? UserId { get; set; }
        public string? JobTitle { get; set; }
        public int? JobId { get; set; }
        public int? EmployerId { get; set; }
        public string? EmployerName { get; set; }
        public string? LocationPlace { get; set; }
        public decimal? MinimumSalary { get; set; }
        public decimal? MaximumSalary { get; set; }
        public string? ExpirationDate { get; set; }
        public string? DatePosted { get; set; }
        public string? JobDescription { get; set; }
        public string? JobUrl { get; set; }
        public int? JobRating { get; set; }
        public bool? JobLiked { get; set; }

        [ForeignKey("UserId")]
        public virtual UserDetailsDto? UserDetails { get; set; }
    }
}
