
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Event.Models.Domain
{
    public class Group
    {
        [Key]
        public int Id { get; set; }
        public string GroupTeamName { get; set; }
        public string GroupName { get; set; }
        public string GroupEmail { get; set; }
        public string GroupPhone { get; set; }
        public string GroupFieldStudy { get; set; }
        public string GroupLastDegree { get; set; }
        public string GroupCityOfStudy { get; set; }
        public string GroupAdress { get; set; }
        public string? GroupGrowHistory { get; set; }
        public string GroupIdeaTitle { get; set; }
        public string GroupRelatedTitle { get; set; }
        public string GroupGeographicalArea { get; set; }
        public string GroupDurationOfRun { get; set; }
        public string GroupTargetSociety { get; set; }
        public string GroupHaveConnectionToOther { get; set; }
        public string? GroupIntellectualProperty { get; set; }
        public string GroupInnovativenessOfTheIdea { get; set; }
        public string GroupProjectProgress { get; set; }
        public string GroupFinishedPrice { get; set; }
        public string GroupCompetitorsInMarket { get; set; }
        public string GroupChallengesAndRisks { get; set; }
        [NotMapped]
        public IFormFile? file { get; set; }
        public string? GroupFile { get; set; }
        public List<GroupUser>? GroupUsers { get; set; } //one -to-many for mr.mirshahi
        public List<GroupProject>? GroupProjects { get; set; }
    }
    public class GroupUser
    {
        public int Id { get; set; }
        public string? GroupUserName { get; set; }

        public string? GroupUserDegree { get; set; }
        public string? GroupUserCityOfStudy { get; set; }
        public string? GroupUserJob { get; set; }
        public string? GroupUserPhone { get; set; }
        public int GroupId { get; set; } // my foreign
        public Group? ParentGroup { get; set; }

    }
    public class GroupProject
    {
        public int Id { set; get; }

        public string? GroupPrTitle { get; set; }

        public string? GroupPrTime { get; set; }
        public string? GroupPrPrice { get; set; }
        public string? GroupPrJobLeader { get; set; }
        public string? GroupPrSeller { get; set; }
        public string? GroupPrStatus { get; set; }
        public int GroupId { set; get; }
        public Group? ParentGroup { get; set; }
    }
}
