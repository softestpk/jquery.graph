using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.DataVisualization.Charting;
using System.Drawing;
using System.Web.UI.WebControls;

namespace ob.graph.Controllers
{
    public class ChartController : Controller
    {

        public ActionResult Index()
        {
            return View();
        }
        /// <summary>
        /// The action will render an Image
        /// </summary>
        /// <param name="id"></param>
        /// <param name="width"></param>
        /// <param name="height"></param>
        /// <returns></returns>
        public ActionResult Graph(string id, double? width, double? height)
        {
            string title = "Data for Parameter " + id;
            //Get the Data by ID...
            double[] yValues = { 10, 27.5, 7, 12, 45.5 };
            string[] xNames = { "Visitor", "Added To Cart", "Entered Billing", "Created PaymentMethod", "Completed Purchase" };
            return File(GetChart(title,width, height, xNames, yValues), "image/png");
        }
        /// <summary>
        /// Can be placed at any place...
        /// Depending on type of Chart
        /// </summary>
        /// <param name="title"></param>
        /// <param name="width"></param>
        /// <param name="height"></param>
        /// <param name="xNames"></param>
        /// <param name="yValues"></param>
        /// <returns></returns>
        private byte[] GetChart(string title, double? width, double? height, string[] xNames, double[] yValues)
        {
            var reportData = new List<string>();
            byte[] data = new byte[256];
            Chart chart = new Chart();
            chart.Width = new Unit(width.Value);
            chart.Height = new Unit(height.Value);
            chart.Titles.Add(title);
            Series pieSeries = new Series();
            pieSeries.ChartType = SeriesChartType.Pie;
            pieSeries.Points.DataBindXY(xNames, yValues);
            pieSeries.Points[4]["Exploded"] = "True";
            chart.Series.Add(pieSeries);
            chart.ChartAreas.Add("basic");
            chart.ChartAreas[0].Area3DStyle  = new ChartArea3DStyle() { Enable3D=true};
            MemoryStream ms = new MemoryStream();
            chart.SaveImage(ms);
            data = ms.GetBuffer();
            return data;
        }








































































        [HttpPost]
        public ActionResult Draw(string id, double? width, double height, string[] xNames, double[] yValues)
        {
            yValues = new double[] { 10, 27.5, 7, 12, 45.5 };
            xNames = new string[] { "Visitor", "Added To Cart", "Entered Billing", "Created PaymentMethod", "Completed Purchase" };
            return File(GetPieChart(width, height,id, xNames, yValues), "image/png");
        }

        public byte[] GetPieChart(double? width, double? height, string title, string[] xNames, double[] yValues)
        {
            var reportData = new List<string>();
            byte[] data = new byte[256];
            Chart chart = new Chart();
            chart.Width = new Unit(width.Value);
            chart.Height = new Unit(height.Value);
            chart.Titles.Add(title);
            Series pieSeries = new Series();
            pieSeries.ChartType = SeriesChartType.Pie;
            ///////////////////
           
            pieSeries.Points.DataBindXY(xNames, yValues);
            //pieSeries["PieLabelStyle"] = "Outside";
            pieSeries.Points[4]["Exploded"] = "True";
            chart.Series.Add(pieSeries);
            ////////////////////

            chart.ChartAreas.Add("basic");
            chart.ChartAreas[0].Area3DStyle = new ChartArea3DStyle() { Enable3D = true };
            MemoryStream ms = new MemoryStream();
            chart.SaveImage(ms);
            data = ms.GetBuffer();
            return data;
        }
    }


}
