using System;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DotNet.Highcharts;
using DotNet.Highcharts.Enums;
using DotNet.Highcharts.Helpers;
using DotNet.Highcharts.Options;
using System.Drawing;
using CYJ.Models;
using CYJ.Models.ViewModels;
using System.Collections.Generic;

namespace CYJ.Controllers
{
    public class RADController : Controller
    {

        // Connect to the cyjEntities database (entity framework)
        private cyjdatabaseEntities db = new cyjdatabaseEntities();

        // ChartsModel class that will get the charts when called 
      
        // CorpsMemberExperience() will return the charts to the Service Delivery view 
        public ActionResult RAD()
        {

            //RETENTION CHART
            Highcharts recruitmentChart = new Highcharts("chart6");


            recruitmentChart.InitChart(new Chart()
            {
                Type = DotNet.Highcharts.Enums.ChartTypes.Column,
                BackgroundColor = new BackColorOrGradient(System.Drawing.Color.White),

                Style = "fontWeight: 'bold', fontSize: '17px'",
                BorderColor = System.Drawing.Color.Gray,
                BorderRadius = 0,
                BorderWidth = 2

            });

            recruitmentChart.SetTitle(new Title()
            {
                Text = "RECRUITMENT"
            });


            // Create objects for X - Axis
            object[] Q1GoalRecruitment = Q1GoalsRecruitment().Cast<object>().ToArray();
            object[] Q1ActualRecruitment = Q1ActualsRecruitment().Cast<object>().ToArray();

            object[] Q2GoalRecruitment = Q2GoalsRecruitment().Cast<object>().ToArray();
            object[] Q2ActualRecruitment = Q2ActualsRecruitment().Cast<object>().ToArray();

            object[] Q3GoalRecruitment = Q3GoalsRecruitment().Cast<object>().ToArray();
            object[] Q3ActualRecruitment = Q3ActualsRecruitment().Cast<object>().ToArray();

            object[] Q4GoalRecruitment = Q4GoalsRecruitment().Cast<object>().ToArray();
            object[] Q4ActualRecruitment = Q4ActualsRecruitment().Cast<object>().ToArray();

            // Create objects for Y - Axis
            string[] Subcategories = subCat().ToArray();


            recruitmentChart.SetXAxis(new XAxis()
            {
                Type = AxisTypes.Category,
                Title = new XAxisTitle() { Text = "Goal vs Actual", Style = "fontWeight: 'bold', fontSize: '17px'" },
                Categories = Subcategories
            });

            recruitmentChart.SetYAxis(new YAxis()
            {
                Title = new YAxisTitle()
                {
                    Text = "# of applications to Jax",
                    Style = "fontWeight: 'bold', fontSize: '17px'"
                },
                ShowFirstLabel = true,
                ShowLastLabel = true,
                Min = 0
            });

            recruitmentChart.SetLegend(new Legend
            {
                Enabled = true,
                BorderRadius = 6,
                BackgroundColor = new BackColorOrGradient(ColorTranslator.FromHtml("#FFADD8E6"))
            });


            // Set series for quarterly goals + actuals
            recruitmentChart.SetSeries(new Series[]
            {
                new Series{

                    Name = "Q1 GOAL",
                    Data = new Data(Q1GoalRecruitment),
                   Color = ColorTranslator.FromHtml("#3EC2CF")

                },

                new Series
                {
                    Name = "Q1 ACTUAL",
                    Data = new Data(Q1ActualRecruitment),
                   Color = ColorTranslator.FromHtml("#aadbe0")
                },
                  new Series
                {
                    Name = "Q2 GOAL",
                    Data = new Data(Q2GoalRecruitment),
                   Color = ColorTranslator.FromHtml("#f1604a")
                },
                    new Series
                {
                    Name = "Q2 ACTUAL",
                    Data = new Data(Q2ActualRecruitment),
                   Color = ColorTranslator.FromHtml("#fcab9f")
                },
                      new Series
                {
                    Name = "Q3 GOAL",
                    Data = new Data(Q3GoalRecruitment),
                   Color = ColorTranslator.FromHtml("#FBAE3B")
                },
                        new Series
                {
                    Name = "Q3 ACTUAL",
                    Data = new Data(Q3ActualRecruitment),
                   Color = ColorTranslator.FromHtml("#f7cd8f")
                },
                          new Series
                {
                    Name = "Q4 GOAL",
                    Data = new Data(Q4GoalRecruitment),
                   Color = ColorTranslator.FromHtml("#bcc65d")
                },
                            new Series
                {
                    Name = "Q4 ACTUAL",
                    Data = new Data(Q4ActualRecruitment),
                   Color = ColorTranslator.FromHtml("#d1d6a7")
                }

            }
            );

            // ADMISSIONS CHART
            Highcharts admissionsChart = new Highcharts("admissionsChart");

            admissionsChart.InitChart(new Chart()
            {
                Type = DotNet.Highcharts.Enums.ChartTypes.Column,
                BackgroundColor = new BackColorOrGradient(System.Drawing.Color.White),

                Style = "fontWeight: 'bold', fontSize: '17px'",
                BorderColor = System.Drawing.Color.Gray,
                BorderRadius = 0,
                BorderWidth = 2

            });

            admissionsChart.SetTitle(new Title()
            {
                Text = "ADMISSIONS"
            });


            // Create objects for X - Axis
            object[] Q1GoalAdmissions = Q1GoalsAdmissions().Cast<object>().ToArray();
            object[] Q1ActualAdmissions = Q1ActualsAdmissions().Cast<object>().ToArray();

            object[] Q2GoalAdmissions = Q2GoalsAdmissions().Cast<object>().ToArray();
            object[] Q2ActualAdmissions = Q2ActualsAdmissions().Cast<object>().ToArray();

            object[] Q3GoalAdmissions = Q3GoalsAdmissions().Cast<object>().ToArray();
            object[] Q3ActualAdmissions = Q3ActualsAdmissions().Cast<object>().ToArray();

            object[] Q4GoalAdmissions = Q4GoalsAdmissions().Cast<object>().ToArray();
            object[] Q4ActualAdmissions = Q4ActualsAdmissions().Cast<object>().ToArray();

            // Create objects for Y - Axis
            string[] SubcategoriesAdmissions = subCat2().ToArray();


            admissionsChart.SetXAxis(new XAxis()
            {
                Type = AxisTypes.Category,
                Title = new XAxisTitle() { Text = "Goal vs Actual", Style = "fontWeight: 'bold', fontSize: '17px'" },
                Categories = SubcategoriesAdmissions
            });

            admissionsChart.SetYAxis(new YAxis()
            {
                Title = new YAxisTitle()
                {
                    Text = "# admitted",
                    Style = "fontWeight: 'bold', fontSize: '17px'"
                },
                ShowFirstLabel = true,
                ShowLastLabel = true,
                Min = 0
            });

            admissionsChart.SetLegend(new Legend
            {
                Enabled = true,
                BorderRadius = 6,
                BackgroundColor = new BackColorOrGradient(ColorTranslator.FromHtml("#FFADD8E6"))
            });


            // Set series for quarterly goals + actuals
            admissionsChart.SetSeries(new Series[]
            {
                new Series{

                    Name = "Q1 GOAL",
                    Data = new Data(Q1GoalAdmissions),
                   Color = ColorTranslator.FromHtml("#3EC2CF")

                },

                new Series
                {
                    Name = "Q1 ACTUAL",
                    Data = new Data(Q1ActualAdmissions),
                   Color = ColorTranslator.FromHtml("#aadbe0")
                },
                  new Series
                {
                    Name = "Q2 GOAL",
                    Data = new Data(Q2GoalAdmissions),
                   Color = ColorTranslator.FromHtml("#f1604a")
                },
                    new Series
                {
                    Name = "Q2 ACTUAL",
                    Data = new Data(Q2ActualAdmissions),
                   Color = ColorTranslator.FromHtml("#fcab9f")
                },
                      new Series
                {
                    Name = "Q3 GOAL",
                    Data = new Data(Q3GoalAdmissions),
                   Color = ColorTranslator.FromHtml("#FBAE3B")
                },
                        new Series
                {
                    Name = "Q3 ACTUAL",
                    Data = new Data(Q3ActualAdmissions),
                   Color = ColorTranslator.FromHtml("#f7cd8f")
                },
                          new Series
                {
                    Name = "Q4 GOAL",
                    Data = new Data(Q4GoalAdmissions),
                   Color = ColorTranslator.FromHtml("#bcc65d")
                },
                            new Series
                {
                    Name = "Q4 ACTUAL",
                    Data = new Data(Q4ActualAdmissions),
                   Color = ColorTranslator.FromHtml("#d1d6a7")
                }

            }
            );

            ChartModel model = new ChartModel();

            model.Chart1 = recruitmentChart;
            model.Chart2 = admissionsChart;


            return View(model);
        }

        // RETENTION DATA
        // Get the data for Q1 Goals

        public List<string> Q1GoalsRecruitment()
        {
            var cats = db.CATEGORIES;
            var subcats = db.SUBCATEGORIES;
            var goals = db.GOALACTUALS;

            var q1RECRUITMENTQuery = (from y in goals
                                      where y.subcategoryID == 41 && y.quarteroptionID == 1
                                      join x in cats
                                      on y.categoryID equals x.categoryID
                                      join z in subcats
                                      on y.subcategoryID equals z.subcategoryID
                                      select new
                                      {
                                          goalValue = y.goalValue
                                      }).ToList();

            List<string> q1Goals = new List<string>();

            foreach (var t in q1RECRUITMENTQuery)
            {

                q1Goals.Add(t.goalValue);

            }

            return q1Goals;

        }
        public List<string> Q2GoalsRecruitment()
        {
            var cats = db.CATEGORIES;
            var subcats = db.SUBCATEGORIES;
            var goals = db.GOALACTUALS;

            var q2RECRUITMENTQuery = (from y in goals
                                      where y.subcategoryID == 41 && y.quarteroptionID == 2
                                      join x in cats
                                      on y.categoryID equals x.categoryID
                                      join z in subcats
                                      on y.subcategoryID equals z.subcategoryID
                                      select new
                                      {
                                          goalValue = y.goalValue
                                      }).ToList();

            List<string> q2Goals = new List<string>();

            foreach (var t in q2RECRUITMENTQuery)
            {

                q2Goals.Add(t.goalValue);

            }

            return q2Goals;

        }
        public List<string> Q3GoalsRecruitment()
        {
            var cats = db.CATEGORIES;
            var subcats = db.SUBCATEGORIES;
            var goals = db.GOALACTUALS;

            var q3RECRUITMENTQuery = (from y in goals
                                      where y.subcategoryID == 41 && y.quarteroptionID == 3
                                      join x in cats
                                      on y.categoryID equals x.categoryID
                                      join z in subcats
                                      on y.subcategoryID equals z.subcategoryID
                                      select new
                                      {
                                          goalValue = y.goalValue
                                      }).ToList();

            List<string> q3Goals = new List<string>();

            foreach (var t in q3RECRUITMENTQuery)
            {

                q3Goals.Add(t.goalValue);

            }

            return q3Goals;

        }

        public List<string> Q4GoalsRecruitment()
        {
            var cats = db.CATEGORIES;
            var subcats = db.SUBCATEGORIES;
            var goals = db.GOALACTUALS;

            var q4RECRUITMENTQuery = (from y in goals
                                      where y.subcategoryID == 41 && y.quarteroptionID == 4
                                      join x in cats
                                      on y.categoryID equals x.categoryID
                                      join z in subcats
                                      on y.subcategoryID equals z.subcategoryID
                                      select new
                                      {
                                          goalValue = y.goalValue
                                      }).ToList();

            List<string> q4Goals = new List<string>();

            foreach (var t in q4RECRUITMENTQuery)
            {

                q4Goals.Add(t.goalValue);

            }

            return q4Goals;

        }


        // Quarter 1 ACTUALS
        public List<string> Q1ActualsRecruitment()
        {

            var cats = db.CATEGORIES;
            var subcats = db.SUBCATEGORIES;
            var goals = db.GOALACTUALS;

            var q1RECRUITMENTQuery = (from y in goals
                                      where y.subcategoryID == 41 && y.quarteroptionID == 1
                                      join x in cats
                                      on y.categoryID equals x.categoryID
                                      join z in subcats
                                      on y.subcategoryID equals z.subcategoryID
                                      select new
                                      {
                                          actualGoal = y.actualGoal
                                      }).ToList();


            List<string> q1Actuals = new List<string>();

            foreach (var t in q1RECRUITMENTQuery)
            {

                q1Actuals.Add(t.actualGoal);

            }

            return q1Actuals;



        }

        public List<string> Q2ActualsRecruitment()
        {

            var cats = db.CATEGORIES;
            var subcats = db.SUBCATEGORIES;
            var goals = db.GOALACTUALS;

            var q2RECRUITMENTQuery = (from y in goals
                                      where y.subcategoryID == 41 && y.quarteroptionID == 2
                                      join x in cats
                                      on y.categoryID equals x.categoryID
                                      join z in subcats
                                      on y.subcategoryID equals z.subcategoryID
                                      select new
                                      {
                                          actualGoal = y.actualGoal
                                      }).ToList();


            List<string> q2Actuals = new List<string>();

            foreach (var t in q2RECRUITMENTQuery)
            {

                q2Actuals.Add(t.actualGoal);

            }

            return q2Actuals;



        }
        public List<string> Q3ActualsRecruitment()
        {

            var cats = db.CATEGORIES;
            var subcats = db.SUBCATEGORIES;
            var goals = db.GOALACTUALS;

            var q3RECRUITMENTQuery = (from y in goals
                                      where y.subcategoryID == 41 && y.quarteroptionID == 3
                                      join x in cats
                                      on y.categoryID equals x.categoryID
                                      join z in subcats
                                      on y.subcategoryID equals z.subcategoryID
                                      select new
                                      {
                                          actualGoal = y.actualGoal
                                      }).ToList();


            List<string> q3Actuals = new List<string>();

            foreach (var t in q3RECRUITMENTQuery)
            {

                q3Actuals.Add(t.actualGoal);

            }

            return q3Actuals;



        }

        public List<string> Q4ActualsRecruitment()
        {

            var cats = db.CATEGORIES;
            var subcats = db.SUBCATEGORIES;
            var goals = db.GOALACTUALS;

            var q4RECRUITMENTQuery = (from y in goals
                                      where y.subcategoryID == 41 && y.quarteroptionID == 4
                                      join x in cats
                                      on y.categoryID equals x.categoryID
                                      join z in subcats
                                      on y.subcategoryID equals z.subcategoryID
                                      select new
                                      {
                                          actualGoal = y.actualGoal
                                      }).ToList();


            List<string> q4Actuals = new List<string>();

            foreach (var t in q4RECRUITMENTQuery)
            {

                q4Actuals.Add(t.actualGoal);

            }

            return q4Actuals;



        }

        //ADMISSIONS DATA
        // Get the data for Q1 Goals
        public List<string> Q1GoalsAdmissions()
        {
            var cats = db.CATEGORIES;
            var subcats2 = db.SUBCATEGORIES;
            var goals = db.GOALACTUALS;

            var q1AdmissionsQuery = (from y in goals
                                     where y.subcategoryID == 42 || y.subcategoryID == 43 && y.quarteroptionID == 1
                                     join x in cats
                                     on y.categoryID equals x.categoryID
                                     join z in subcats2
                                     on y.subcategoryID equals z.subcategoryID
                                     select new
                                     {
                                         goalValue = y.goalValue
                                     }).ToList();

            List<string> Q1GoalsAdmissions = new List<string>();

            foreach (var t in q1AdmissionsQuery)
            {

                Q1GoalsAdmissions.Add(t.goalValue);

            }

            return Q1GoalsAdmissions;

        }
        public List<string> Q2GoalsAdmissions()
        {
            var cats = db.CATEGORIES;
            var subcats2 = db.SUBCATEGORIES;
            var goals = db.GOALACTUALS;

            var q2AdmissionsQuery = (from y in goals
                                     where y.subcategoryID == 42 || y.subcategoryID == 43 && y.quarteroptionID == 2
                                     join x in cats
                                     on y.categoryID equals x.categoryID
                                     join z in subcats2
                                     on y.subcategoryID equals z.subcategoryID
                                     select new
                                     {
                                         goalValue = y.goalValue
                                     }).ToList();

            List<string> Q2GoalsAdmissions = new List<string>();

            foreach (var t in q2AdmissionsQuery)
            {

                Q2GoalsAdmissions.Add(t.goalValue);

            }

            return Q2GoalsAdmissions;

        }
        public List<string> Q3GoalsAdmissions()
        {
            var cats = db.CATEGORIES;
            var subcats2 = db.SUBCATEGORIES;
            var goals = db.GOALACTUALS;

            var q3AdmissionsQuery = (from y in goals
                                     where y.subcategoryID == 42 || y.subcategoryID == 43 && y.quarteroptionID == 3
                                     join x in cats
                                     on y.categoryID equals x.categoryID
                                     join z in subcats2
                                     on y.subcategoryID equals z.subcategoryID
                                     select new
                                     {
                                         goalValue = y.goalValue
                                     }).ToList();

            List<string> Q3GoalsAdmissions = new List<string>();

            foreach (var t in q3AdmissionsQuery)
            {

                Q3GoalsAdmissions.Add(t.goalValue);

            }

            return Q3GoalsAdmissions;

        }
        public List<string> Q4GoalsAdmissions()
        {
            var cats = db.CATEGORIES;
            var subcats2 = db.SUBCATEGORIES;
            var goals = db.GOALACTUALS;

            var q4AdmissionsQuery = (from y in goals
                                     where y.subcategoryID == 42 || y.subcategoryID == 43 && y.quarteroptionID == 4
                                     join x in cats
                                     on y.categoryID equals x.categoryID
                                     join z in subcats2
                                     on y.subcategoryID equals z.subcategoryID
                                     select new
                                     {
                                         goalValue = y.goalValue
                                     }).ToList();

            List<string> Q4GoalsAdmissions = new List<string>();

            foreach (var t in q4AdmissionsQuery)
            {

                Q4GoalsAdmissions.Add(t.goalValue);

            }

            return Q4GoalsAdmissions;

        }
        // Admissions - Quarter 1 ACTUALS
        public List<string> Q1ActualsAdmissions()
        {

            var cats = db.CATEGORIES;
            var subcats2 = db.SUBCATEGORIES;
            var goals = db.GOALACTUALS;

            var q1AdmissionsQuery = (from y in goals
                                     where y.subcategoryID == 42 || y.subcategoryID == 43 && y.quarteroptionID == 1
                                     join x in cats
                                     on y.categoryID equals x.categoryID
                                     join z in subcats2
                                     on y.subcategoryID equals z.subcategoryID
                                     select new
                                     {
                                         actualGoal = y.actualGoal
                                     }).ToList();


            List<string> Q1ActualsAdmissions = new List<string>();

            foreach (var t in q1AdmissionsQuery)
            {

                Q1ActualsAdmissions.Add(t.actualGoal);

            }

            return Q1ActualsAdmissions;
        }
        public List<string> Q2ActualsAdmissions()
        {

            var cats = db.CATEGORIES;
            var subcats2 = db.SUBCATEGORIES;
            var goals = db.GOALACTUALS;

            var q2AdmissionsQuery = (from y in goals
                                     where y.subcategoryID == 42 || y.subcategoryID == 43 && y.quarteroptionID == 2
                                     join x in cats
                                     on y.categoryID equals x.categoryID
                                     join z in subcats2
                                     on y.subcategoryID equals z.subcategoryID
                                     select new
                                     {
                                         actualGoal = y.actualGoal
                                     }).ToList();


            List<string> Q2ActualsAdmissions = new List<string>();

            foreach (var t in q2AdmissionsQuery)
            {

                Q2ActualsAdmissions.Add(t.actualGoal);

            }

            return Q2ActualsAdmissions;
        }

        public List<string> Q3ActualsAdmissions()
        {

            var cats = db.CATEGORIES;
            var subcats2 = db.SUBCATEGORIES;
            var goals = db.GOALACTUALS;

            var q3AdmissionsQuery = (from y in goals
                                     where y.subcategoryID == 42 || y.subcategoryID == 43 && y.quarteroptionID == 3
                                     join x in cats
                                     on y.categoryID equals x.categoryID
                                     join z in subcats2
                                     on y.subcategoryID equals z.subcategoryID
                                     select new
                                     {
                                         actualGoal = y.actualGoal
                                     }).ToList();


            List<string> Q3ActualsAdmissions = new List<string>();

            foreach (var t in q3AdmissionsQuery)
            {

                Q3ActualsAdmissions.Add(t.actualGoal);

            }

            return Q3ActualsAdmissions;
        }
        public List<string> Q4ActualsAdmissions()
        {

            var cats = db.CATEGORIES;
            var subcats2 = db.SUBCATEGORIES;
            var goals = db.GOALACTUALS;

            var q4AdmissionsQuery = (from y in goals
                                     where y.subcategoryID == 42 || y.subcategoryID == 43 && y.quarteroptionID == 4
                                     join x in cats
                                     on y.categoryID equals x.categoryID
                                     join z in subcats2
                                     on y.subcategoryID equals z.subcategoryID
                                     select new
                                     {
                                         actualGoal = y.actualGoal
                                     }).ToList();


            List<string> Q4ActualsAdmissions = new List<string>();

            foreach (var t in q4AdmissionsQuery)
            {

                Q4ActualsAdmissions.Add(t.actualGoal);

            }

            return Q4ActualsAdmissions;
        }




        public List<string> subCat()
        {
            var cats = db.CATEGORIES;
            var subcatsRecruitment = db.SUBCATEGORIES;
            var goals = db.GOALACTUALS;

            var RECRUITMENTQuery = (from y in goals
                                    where y.subcategoryID == 41
                                    join x in cats
                                    on y.categoryID equals x.categoryID
                                    join z in subcatsRecruitment
                                    on y.subcategoryID equals z.subcategoryID
                                    select new
                                    {
                                        subcatTypes = x.categoryName
                                    }).ToList();

            List<string> subCats = new List<string>();

            foreach (var t in RECRUITMENTQuery)
            {

                subCats.Add(t.subcatTypes);

            }

            return subCats;
        }

        public List<string> subCat2()
        {
            var cats = db.CATEGORIES;
            var subcats = db.SUBCATEGORIES;
            var goals = db.GOALACTUALS;

            var admissionQuery = (from y in goals

                                  where y.subcategoryID == 42 || y.subcategoryID == 43
                                  join z in subcats
                                  on y.subcategoryID equals z.subcategoryID
                                  select new
                                  {
                                      subcatTypes = z.subcategoryName
                                  }).ToList();

            List<string> subCats2 = new List<string>();

            foreach (var t in admissionQuery)
            {

                subCats2.Add(t.subcatTypes);

            }

            return subCats2;
        }




    }


}

