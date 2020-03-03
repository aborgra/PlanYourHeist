using System;
using System.Collections.Generic;

namespace PlanYourHeist {
    class Program {
        static void Main (string[] args) {
            Console.WriteLine ("Plan Your Heist!");

            Console.WriteLine ("Enter bank difficulty level");
            int bankDifficulty = int.Parse (Console.ReadLine ());

            List<Member> team = new List<Member> ();
            decimal tempSkillLevels = 0;
            while (true) {

                Console.WriteLine ("Enter team member's name");
                string singleMemberName = Console.ReadLine ();
                if (singleMemberName == "") {
                    break;
                }

                Member member = new Member ();
                member.MemberName = singleMemberName;
                Console.WriteLine ("Enter member skill level (1-50)");
                member.SkillLevel = decimal.Parse (Console.ReadLine ());
                Console.WriteLine ("Enter member courage level (0.0 - 2.0)");
                member.CourageLevel = decimal.Parse (Console.ReadLine ());

                decimal skillLevel = member.SkillLevel;
                decimal courageLevel = member.CourageLevel / 2;

                tempSkillLevels += skillLevel * courageLevel;

                Console.WriteLine ($"Current total skill levels: {tempSkillLevels}");

                team.Add (member);

            }

            Console.WriteLine ("Enter number of trial runs");
            int trialRuns = int.Parse (Console.ReadLine ());
            int successRun = 0;
            int unsuccessRun = 0;

            for (int i = 0; i < trialRuns; i++) {
                int tempBankDifficulty = bankDifficulty;
                decimal allMembersSkills = 0;

                Random rand = new Random ();
                int luckValue = rand.Next (-10, 11);

                tempBankDifficulty += luckValue;

                foreach (Member member in team) {
                    decimal skillLevel = member.SkillLevel;
                    decimal courageLevel = member.CourageLevel / 2;
                    decimal adjustedSkillLevel = skillLevel * courageLevel;
                    allMembersSkills += adjustedSkillLevel;
                    Console.WriteLine (member.ToString ());
                }

                Console.WriteLine ($"Members combined skill levels: {allMembersSkills}");
                Console.WriteLine ($"Bank difficulty: {tempBankDifficulty}");
                if (allMembersSkills >= tempBankDifficulty) {
                    Console.WriteLine ("You've got a chance!");
                    Console.WriteLine ("____________________________");
                    successRun += 1;
                } else {
                    Console.WriteLine ("Maybe find a day job?");
                    Console.WriteLine ("____________________________");

                    unsuccessRun += 1;
                }
            }
            Console.WriteLine ($"Successful trial runs: {successRun}  Unsuccessful trial runs: {unsuccessRun}");
        }
    }
}