jquery.graph
============

MS Chart with MVC3 is rendered through jquery plugin


The jQuery plugin created for rendering chart on web pages. This works along with a MVC3 server at the background.

The MVC3 server takes the server side 'Chart' control provided by Microsoft Chart Control available in the form of 'System.Web.UI.DataVisualization.Charting' namespaces.

The example is available on ..\ob.graph\Views\Chart\Index.chtml page. 
The controller code is on ..\ob.graph\Controller\ChartController.cs

The jQuery Plugin, is on ..\ob.graph\Scripts\jquery.graph.js



The current realease limitation:

This is basic version and only renders a Pie chart.
This is designed to work only with GET operations.