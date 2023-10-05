using System.ComponentModel.DataAnnotations;

namespace JobSearchAPI.Models
{
    public class UserDetailsDto
    {
        public UserDetailsDto() {
            this.JobDetails = new HashSet<JobDetailsDto>();
            this.JobSearches = new HashSet<JobSearchDto>();
        }

        [Key]
        public int? UserId { get; set; }
        public string? UserName { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? DateJoined { get; set; }
        public int? Age { get; set; }
        public string? AddressFirstLine { get; set; }
        public string? AddressSecondLine { get; set; }
        public string? City { get; set; }
        public string? County { get; set; }
        public string? Postcode { get; set; }

        public ICollection<JobDetailsDto> JobDetails { get; set; }
        public ICollection<JobSearchDto> JobSearches { get; set; }
    }
}
