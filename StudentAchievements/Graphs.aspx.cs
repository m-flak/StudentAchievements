using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.DataVisualization.Charting;
using System.Web.UI.WebControls;

namespace StudentAchievements
{
    public partial class Graphs : System.Web.UI.Page
    {
        protected string? SelectedCorrelation => (string) ViewState["SelectedCorrelation"];
        protected string? SelectedCorrelationProper => (string) ViewState["SelectedCorrelationProper"];

        protected void Page_Load(object sender, EventArgs e)
        {
            if (SelectedCorrelation != null)
            {
                Chart1.Series.FindByName("Series1").XValueMember = SelectedCorrelation;
                Chart1.Series.FindByName("Series1").YValueMembers = "grade_final";
            }
        }

        protected void GraphButton_Click(object sender, EventArgs e)
        {
            ViewState["SelectedCorrelation"] = this.CorrelationList.SelectedValue;
            ViewState["SelectedCorrelationProper"] = this.CorrelationList.SelectedItem.Text;
        }
    }
}
