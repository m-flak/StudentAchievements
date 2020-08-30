using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Dapper;

namespace StudentAchievements
{
    public partial class Inquire : System.Web.UI.Page
    {
        private readonly List<StudentAchievement> studentAchievements = new List<StudentAchievement>();

        protected string? Query => (string) ViewState["Query"];
        protected Dictionary<string, int> CategoriesAverages { get; } = new Dictionary<string, int>();

        protected void Page_Load(object sender, EventArgs e)
        {
            this.ResultsPlaceHolder.Controls.Clear();

            if (studentAchievements.Count == 0)
            {
                using (var con = Global.SQLDatabase.GetConnection())
                {
                    Dapper.DefaultTypeMap.MatchNamesWithUnderscores = true;

                    con.Open();
                    var list = con.Query<StudentAchievement>("SELECT * FROM student_achievements;").ToList();
                    studentAchievements.AddRange(list);
                }
            }
        }

        protected void InquireButton_Click(object sender, EventArgs e)
        {
            ViewState["Query"] = this.QuerySelector.SelectedItem.Text;
        }

        protected void ResultsPlaceHolder_Load(object sender, EventArgs e)
        {
            if (Query?.Length > 0)
            {
                switch (Query)
                {
                    case "Internet":
                        AddInternetAverages();
                        break;
                    case "Past Failures":
                        AddPastFailures();
                        break;
                    case "Study Time":
                        AddStudyTime();
                        break;
                    case "Absences":
                        AddAbsences();
                        break;
                    default:
                        break;
                }
            }
        }

        private void AddInternetAverages()
        {
            var withInternet = studentAchievements.Where(sa => sa.Internet == true);
            var withoutInternet = studentAchievements.Where(sa => sa.Internet == false);

            var avgInternet = withInternet.Aggregate(0, (acc, val) => acc + val.GradeFinal, avg => avg / withInternet.Count());
            var avgNoInternet = withoutInternet.Aggregate(0, (acc, val) => acc + val.GradeFinal, avg => avg / withoutInternet.Count());
            CategoriesAverages.Add("With Internet", avgInternet);
            CategoriesAverages.Add("Without Internet", avgNoInternet);
        }

        private void AddPastFailures()
        {
            for (int i = 0; i < Int32.MaxValue; i++)
            {
                var withFailures = studentAchievements.Where(sa => sa.Failures == i);
                if (!withFailures.Any())
                {
                    break;
                }

                var avgWithFailure = withFailures.Aggregate(0, (acc, val) => acc + val.GradeFinal, avg => avg / withFailures.Count());
                CategoriesAverages.Add($"{i} Past Failures", avgWithFailure);
            }
        }

        private void AddStudyTime()
        {
            for (int i = 1; i < Int32.MaxValue; i++)
            {
                var withStudyTimes = studentAchievements.Where(sa => sa.StudyTime == i);
                if (!withStudyTimes.Any())
                {
                    break;
                }

                var avgWithStudyTime = withStudyTimes.Aggregate(0, (acc, val) => acc + val.GradeFinal, avg => avg / withStudyTimes.Count());
                CategoriesAverages.Add($"Study Time of {i}", avgWithStudyTime);
            }
        }

        private void AddAbsences()
        {
            for (int i = 0; i < Int32.MaxValue; i++)
            {
                var withAbsences = studentAchievements.Where(sa => sa.Absences == i);
                if (!withAbsences.Any())
                {
                    break;
                }

                var avgWithAbsences = withAbsences.Aggregate(0, (acc, val) => acc + val.GradeFinal, avg => avg / withAbsences.Count());
                CategoriesAverages.Add($"{i} Absences", avgWithAbsences);
            }
        }
    }
}