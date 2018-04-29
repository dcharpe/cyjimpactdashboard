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
using System.Collections.Generic;
using CYJ.Models.ViewModels;

namespace CYJ.Controllers
{
    [Authorize(Roles = "Admin, Observer")]
    public class GRAPHsController : Controller
    {

        // Database 
        private cyjdatabaseEntities db = new cyjdatabaseEntities();

        // Charts for Service Delivery View
        public ActionResult ServiceDelivery()
        {

            //ENROLLMENT CHART
            Highcharts enrollmentChart = new Highcharts("enrollmentChart");



            enrollmentChart.InitChart(new Chart()
            {
                Type = DotNet.Highcharts.Enums.ChartTypes.Column,
                BackgroundColor = new BackColorOrGradient(System.Drawing.Color.White),
                Style = "fontWeight: 'bold', fontSize: '17px'",
                BorderColor = System.Drawing.Color.Gray,
                BorderRadius = 0,
                BorderWidth = 2

            });

            enrollmentChart.SetTitle(new Title()
            {
                Text = "ENROLLMENT"
            });


            // Create objects for X - Axis
            object[] Q1Goal = Q1GoalsEnrollment().Cast<object>().ToArray();
            object[] Q1Actual = Q1ActualsEnrollment().Cast<object>().ToArray();

            // Create objects for Y - Axis
            string[] Subcategories = subCat().ToArray();


            enrollmentChart.SetXAxis(new XAxis()
            {
                Type = AxisTypes.Category,
                Title = new XAxisTitle() { Text = "Goal vs Actual", Style = "fontWeight: 'bold', fontSize: '17px'" },
                Categories = Subcategories
            });

            enrollmentChart.SetYAxis(new YAxis()
            {
                Title = new YAxisTitle()
                {
                    Text = "# Of students",
                    Style = "fontWeight: 'bold', fontSize: '17px'"
                },
                ShowFirstLabel = true,
                ShowLastLabel = true,
                Min = 0
            });

            enrollmentChart.SetLegend(new Legend
            {
                Enabled = true,
                BorderRadius = 6,
                BackgroundColor = new BackColorOrGradient(ColorTranslator.FromHtml("#FFADD8E6"))
            });


            // Set series for quarterly goals + actuals
            enrollmentChart.SetSeries(new Series[]
            {
                new Series{

                    Name = "Q1 GOAL",
                    Data = new Data(Q1Goal),
                   Color = ColorTranslator.FromHtml("#3EC2CF")

                },

                new Series
                {
                    Name = "Q1 ACTUAL",
                    Data = new Data(Q1Actual),
                   Color = ColorTranslator.FromHtml("#bedde0")
                }

            }
            );



            return View(enrollmentChart);
        }



        // Get the data for Q1 Goals
        public List<string> Q1GoalsEnrollment()
        {
            var cats = db.CATEGORIES;
            var subcats = db.SUBCATEGORIES;
            var goals = db.GOALACTUALS;

            var q1enrollmentQuery = (from y in goals
                                     where y.subcategoryID == 4 && y.quarteroptionID == 1
                                     join x in cats
                                     on y.categoryID equals x.categoryID
                                     join z in subcats
                                     on y.subcategoryID equals z.subcategoryID
                                     select new
                                     {
                                         goalValue = y.goalValue
                                     }).ToList();

            List<string> q1Goals = new List<string>();

            foreach (var t in q1enrollmentQuery)
            {

                q1Goals.Add(t.goalValue);

            }

            return q1Goals;

        }

        // Enrollment - Quarter 1 ACTUALS
        public List<string> Q1ActualsEnrollment()
        {

            var cats = db.CATEGORIES;
            var subcats = db.SUBCATEGORIES;
            var goals = db.GOALACTUALS;

            var q1enrollmentQuery = (from y in goals
                                     where y.subcategoryID == 4 && y.quarteroptionID == 1
                                     join x in cats
                                     on y.categoryID equals x.categoryID
                                     join z in subcats
                                     on y.subcategoryID equals z.subcategoryID
                                     select new
                                     {
                                         actualGoal = y.actualGoal
                                     }).ToList();


            List<string> q1Actuals = new List<string>();

            foreach (var t in q1enrollmentQuery)
            {

                q1Actuals.Add(t.actualGoal);

            }

            return q1Actuals;



        }

        public List<string> subCat()
        {
            var cats = db.CATEGORIES;
            var subcats = db.SUBCATEGORIES;
            var goals = db.GOALACTUALS;

            var enrollmentQuery = (from y in goals
                                   where y.subcategoryID == 1
                                   join x in cats
                                   on y.categoryID equals x.categoryID
                                   join z in subcats
                                   on y.subcategoryID equals z.subcategoryID
                                   select new
                                   {
                                       subcatTypes = x.categoryName
                                   }).ToList();

            List<string> subCats = new List<string>();

            foreach (var t in enrollmentQuery)
            {

                subCats.Add(t.subcatTypes);

            }

            return subCats;
        }

        public ActionResult CorpMemberExperience()
        {
            return View();
        }

        public ActionResult External2Affairs()
        {
            return View();
        }
      
        public ActionResult OpEx()
        {

            ViewBag.categoryID = new SelectList(db.CATEGORIES, "categoryID", "categoryName");
            ViewBag.subcategoryID = new SelectList(db.SUBCATEGORIES, "subcategoryID", "subcategoryName");
            ViewBag.fiscalYearID = new SelectList(db.FISCALYEARS, "fiscalYearID", "fiscalYear1");
            ViewBag.QuarterOptionID = new SelectList(db.QUARTEROPTIONS, "QuarterOptionID", "QuarterOptionName");

            return View();

        }

        [HttpPost]
        public ActionResult ExternalAffairs(RADViewModel model)
        {
         

            var obj = new Apt();
            obj.categoryID = model.categoryID;
            obj.subcategoryID = model.subcategoryID;
            obj.fiscalYearID = model.fiscalYearID;
            //obj.QuarterOptionID = model.quarteroptionID;




            //ENROLLMENT CHART
            Highcharts apptoJaxChart = new Highcharts("apptoJaxChart");
            apptoJaxChart.InitChart(new Chart()
            {
                Type = DotNet.Highcharts.Enums.ChartTypes.Column,
                BackgroundColor = new BackColorOrGradient(System.Drawing.Color.White),
                Style = "fontWeight: 'bold', fontSize: '17px'",
                BorderColor = System.Drawing.Color.Gray,
                BorderRadius = 0,
                BorderWidth = 2

            });

            apptoJaxChart.SetTitle(new Title()
            {

                Text = " "
            });


            // Create objects for X - Axis
            object[] Q1Goal = Q1GoalsCityCouncil(obj.subcategoryID, obj.categoryID, obj.fiscalYearID).Cast<object>().ToArray();
            object[] Q1Actual = Q1ActualCityCouncil(obj.subcategoryID, obj.categoryID, obj.fiscalYearID).Cast<object>().ToArray();
            //object[] xaxis = Q2GoalsCityCouncil(obj.subcategoryID, obj.categoryID, obj.fiscalYearID).cast<object>().ToArray();
            //object[] Q2Actual = Q2GoalCityCouncil().cast<object>().ToArray();
            //object[] Q3Goal = Q3GoalCityCouncil().cast<object>().ToArray();
            //object[] Q3Actual = Q3GoalCityCouncil().cast<object>().ToArray();
            //object[] Q4Goal = Q4GoalCityCouncil().cast<object>().ToArray();
            //object[] Q4Actual = Q4GoalCityCouncil().cast<object>().ToArray();

            // Create objects for Y - Axis
            string[] Quarters = Qter().ToArray();


            apptoJaxChart.SetXAxis(new XAxis()
            {
                Type = AxisTypes.Category,
                Title = new XAxisTitle() { Text = "Goal vs Actual", Style = "fontWeight: 'bold', fontSize: '17px'" },
                Categories = Quarters
            });

            apptoJaxChart.SetYAxis(new YAxis()
            {
                Title = new YAxisTitle()
                {
                    Text = "# Of Applications",
                    Style = "fontWeight: 'bold', fontSize: '17px'"
                },
                ShowFirstLabel = true,
                ShowLastLabel = true,
                Min = 0
            });

            apptoJaxChart.SetLegend(new Legend
            {
                Enabled = true,
                BorderRadius = 6,
                BackgroundColor = new BackColorOrGradient(ColorTranslator.FromHtml("#FFADD8E6"))
            });


            // Set series for quarterly goals + actuals
            apptoJaxChart.SetSeries(new Series[]
            {
                new Series{

                    Name = "Q1 GOAL",
                    Data = new Data(Q1Goal),
                   Color = ColorTranslator.FromHtml("#3EC2CF")

                },

                new Series
                {
                    Name = "Q1 ACTUAL",
                    Data = new Data(Q1Actual),
                   Color = ColorTranslator.FromHtml("#bedde0")
                }

            });



            ChartModel modelChart = new ChartModel();
            modelChart.Chart6 = apptoJaxChart;

            return View(apptoJaxChart);
        }

        public class Apt
        {
            public int categoryID { get; set; }
            public int subcategoryID { get; set; }
            public int fiscalYearID { get; set; }
            public int QuarterOptionID { get; set; }

        }

        // Get the data for Q1 Goals
        public List<string> Q1GoalsCityCouncil(int subcatID, int catID, int fiscaly)
        {
            var cats = db.CATEGORIES;
            var subcats = db.SUBCATEGORIES;
            var goals = db.GOALACTUALS;
         

            var q1CityCouncilQuery = (from g in goals
                                      where g.categoryID == catID && g.subcategoryID == subcatID && g.fiscalYearID == fiscaly
                                      join x in cats
                                      on g.categoryID equals x.categoryID
                                      join z in subcats
                                      on g.subcategoryID equals z.subcategoryID
                                      select new
                                      {
                                          goalValue = g.goalValue
                                         
                                      }).ToList();

            List<string> q1Goals = new List<string>();

            foreach (var t in q1CityCouncilQuery)
            {

                q1Goals.Add(t.goalValue);
           

            }

            return q1Goals;
        }

        // Enrollment - Quarter 1 ACTUALS
        public List<string> Q1ActualCityCouncil(int subcatID, int catID, int fiscaly)
        {

            var cats = db.CATEGORIES;
            var subcats = db.SUBCATEGORIES;
            var goals = db.GOALACTUALS;

            var q1CityCouncilQuery = (from y in goals
                                      where y.subcategoryID == subcatID && y.categoryID == catID && y.fiscalYearID == fiscaly
                                      join x in cats
                                      on y.categoryID equals x.categoryID
                                      join z in subcats
                                      on y.subcategoryID equals z.subcategoryID
                                      select new
                                      {
                                          actualGoal = y.actualGoal
                                      }).ToList();


            List<string> q1Actuals = new List<string>();

            foreach (var t in q1CityCouncilQuery)
            {

                q1Actuals.Add(t.actualGoal);

            }

            return q1Actuals;
        }


        public List<string> Qter()
        {
            var cats = db.CATEGORIES;
            var subcats = db.SUBCATEGORIES;
            var goals = db.GOALACTUALS;
            var Qters = db.QUARTEROPTIONS;

            var QuartersQuery = (from y in Qters
                                 select new
                                 {
                                     quarterOptions = y.quarteroptionName
                                 }).ToList();

            List<string> Quarters = new List<string>();

            foreach (var t in QuartersQuery)
            {
                Quarters.Add(t.quarterOptions);
            }

            return Quarters;
        }

    


        public ActionResult RAD()
        {
            {

                //ENROLLMENT CHART
                Highcharts apptoJax = new Highcharts("apptoJax");



                apptoJax.InitChart(new Chart()
                {
                    Type = DotNet.Highcharts.Enums.ChartTypes.Column,
                    BackgroundColor = new BackColorOrGradient(System.Drawing.Color.White),
                    Style = "fontWeight: 'bold', fontSize: '17px'",
                    BorderColor = System.Drawing.Color.Gray,
                    BorderRadius = 0,
                    BorderWidth = 2

                });

                apptoJax.SetTitle(new Title()
                {
                    Text = "Applications to Jacksonville"
                });


                // Create objects for X - Axis
                object[] Q1Goal = Q1GoalsEnrollment().Cast<object>().ToArray();
                object[] Q1Actual = Q1ActualsEnrollment().Cast<object>().ToArray();

                // Create objects for Y - Axis
                string[] Subcategories = subCat().ToArray();


                apptoJax.SetXAxis(new XAxis()
                {
                    Type = AxisTypes.Category,
                    Title = new XAxisTitle() { Text = "Goal vs Actual", Style = "fontWeight: 'bold', fontSize: '17px'" },
                    Categories = Subcategories
                });

                apptoJax.SetYAxis(new YAxis()
                {
                    Title = new YAxisTitle()
                    {
                        Text = "# Of Applications",
                        Style = "fontWeight: 'bold', fontSize: '17px'"
                    },
                    ShowFirstLabel = true,
                    ShowLastLabel = true,
                    Min = 0
                });

                apptoJax.SetLegend(new Legend
                {
                    Enabled = true,
                    BorderRadius = 6,
                    BackgroundColor = new BackColorOrGradient(ColorTranslator.FromHtml("#FFADD8E6"))
                });


                // Set series for quarterly goals + actuals
                apptoJax.SetSeries(new Series[]
                {
                new Series{

                    Name = "Q1 GOAL",
                    Data = new Data(Q1Goal),
                   Color = ColorTranslator.FromHtml("#3EC2CF")

                },

                new Series
                {
                    Name = "Q1 ACTUAL",
                    Data = new Data(Q1Actual),
                   Color = ColorTranslator.FromHtml("#bedde0")
                }

                }
                );



                return View(apptoJax);
            }
        }

        public ActionResult Revenue()
        {
            return View();
        }

    }



}