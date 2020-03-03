namespace PlanYourHeist {

  public class Member {
    public string MemberName { get; set; }
    public decimal SkillLevel { get; set; }
    public decimal CourageLevel { get; set; }

    public override string ToString () {
      return ($"Member Name: {MemberName}, Skill Level: {SkillLevel}, Courage Level: {CourageLevel}");
    }

  }
}