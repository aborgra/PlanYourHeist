using System;
using System.Collections.Generic;

namespace PlanYourHeist {
    class Program {
        static void Main (string[] args) {
            Console.WriteLine ("Plan Your Heist!");

            Dictionary<int, string> memberName = new Dictionary<int, string> ();
            Dictionary<int, int> memberSkillLevel = new Dictionary<int, int> ();
            Dictionary<int, decimal> memberCourage = new Dictionary<int, decimal> ();

            while (true) {
                Console.WriteLine ("Enter team member's name");
                string singleMemberName = Console.ReadLine ();
                if (singleMemberName == "") {
                    foreach (KeyValuePair<int, string> member in memberName) {
                        int skillLevel = memberSkillLevel[member.Key];
                        decimal courageLevel = memberCourage[member.Key];
                        Console.WriteLine ($"Name: {member.Value} Skill Level: {skillLevel} Courage Level: {courageLevel}");
                    }
                    break;
                }
                memberName.Add (memberName.Count, singleMemberName);
                Console.WriteLine ("Enter member skill level (1-50)");
                memberSkillLevel.Add (memberSkillLevel.Count, int.Parse (Console.ReadLine ()));
                Console.WriteLine ("Enter member courage level (0.0 - 2.0)");
                memberCourage.Add (memberCourage.Count, decimal.Parse (Console.ReadLine ()));
            }
        }

    }
}