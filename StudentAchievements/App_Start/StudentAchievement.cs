using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StudentAchievements
{
        public class StudentAchievement
        {
            public int Id { get; set; }
            public string School { get; set; }
            public string Sex { get; set; }
            public short Age { get; set; }
            public string Address { get; set; }
            public string FamilySize { get; set; }
            public string ParentStatus { get; set; }
            public short MotherEducation { get; set; }
            public short FatherEducation { get; set; }
            public string MotherJob { get; set; }
            public string FatherJob { get; set; }
            public string Reason { get; set; }
            public string Guardian { get; set; }
            public short TravelTime { get; set; }
            public short StudyTime { get; set; }
            public short Failures { get; set; }
            public bool SchoolSupport { get; set; }
            public bool FamilySupport { get; set; }
            public bool Paid { get; set; }
            public bool Activities { get; set; }
            public bool Nursery { get; set; }
            public bool Higher { get; set; }
            public bool Internet { get; set; }
            public bool Romantic { get; set; }
            public short FamilyRelations { get; set; }
            public short FreeTime { get; set; }
            public short GoOut { get; set; }
            public short DailyAlcohol { get; set; }
            public short WeeklyAlcohol { get; set; }
            public short Health { get; set; }
            public short Absences { get; set; }
            public short GradeFirst { get; set; }
            public short GradeSecond { get; set; }
            public short GradeFinal { get; set; }
        }
}