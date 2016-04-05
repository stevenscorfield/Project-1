using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;
using System.Web.Razor.Editor;

namespace MarineTankCalculations.Controllers
{
    public class CalculationsController : Controller
    {
        public double litreConv = 0.1117443781;
        public double litreSize = 3.81;
        public double gallonConv = 0.2;
        public double gallonSize = 1.5;
        public double conversionFW = 4.54;
        public double volume;
        private double salinity;
        public double length;
        public string message = "You have entered an incorrect value. Please only use numbers.";
        public string small = "You're tank is too small to have marine fish!";
        public string large = "Is this Poseidon? If so you don't have to worry about fish stock in the oceans!";

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult FishCalculator(string Units, string Result)
        {
            try
            {
                double volume1 = Convert.ToDouble(Result);
                if (Result == null)
                {
                    ViewBag.Output = "";
                    return View();
                }
            

                if (Units == "Litres")
                {
                    double result = (volume1 * litreConv) / litreSize;
                    result = Math.Round(result, 0);

                    if (volume1 < 30)
                    {
                        ViewBag.Number = "0";
                        ViewBag.Message = small;
                        return View();
                    }
                    else
                    {
                        if (volume1 > 4500)
                        {
                            ViewBag.Number = result;
                            ViewBag.Message = large;
                            return View();
                        }

                        else
                        {
                            ViewBag.Number = result;
                            return View();
                        }
                    }
                }
                else
                {
                    double result = (volume1 * gallonConv) / gallonSize;
                    result = Math.Round(result, 0);

                    if (volume1 < 10)
                    {
                        ViewBag.Number = "0";
                        ViewBag.Message = small;
                        return View();
                    }

                    else
                    {
                        if (volume1 > 1000)
                        {
                            ViewBag.Number = result;
                            ViewBag.Message = large;
                            return View();
                        }

                        else
                        {
                            ViewBag.Number = result;
                            return View();
                        }
                    }
                }
            }
            catch
            {
                ViewBag.Output = message;
                return View();
            }
        }
        public ActionResult Volume(string Units, string Shape)
        {
            return View();
        }
        public ActionResult Salinity()
        {
            return View();
        }
        public ActionResult SalinityIncrease(string volume, string curSal, string reqSal, string change)
        {
            try {
                double volume1 = Convert.ToDouble(volume);
                double reqSal1 = Convert.ToDouble(reqSal);
                double curSal1 = Convert.ToDouble(curSal);
                double change1 = Convert.ToDouble(change);

                if (change == null)
                {
                    ViewBag.Salinity = " ";
                    return View();
                }

                double requiredSalinity = ((volume1 * reqSal1) - ((volume1 - change1) * curSal1)) / change1;
                string requiredSalinity1 = Convert.ToString(requiredSalinity);
                ViewBag.Salinity = requiredSalinity1;
                return View();
            }
            catch
            {
                ViewBag.Output = message;
                return View();
            }
        }
        public ActionResult SalinityDecrease(string Units, string Salinity, string volume, string curSal, string reqSal)
        {
            try { 
                double volume1 = Convert.ToDouble(volume);
                double reqSal1 = Convert.ToDouble(reqSal);
                double curSal1 = Convert.ToDouble(curSal);
                double fwAddition = 0;
                fwAddition = Math.Round(fwAddition, 0);

                if (volume == null)
                {
                    ViewBag.Output = " ";
                    return View();
                }
                else
                {
                    if (Salinity == "SSG")
                    {
                        salinity = 0.037681159;
                    }
                    else
                    {
                        salinity = 0.027777777;
                    }
                    if (Units == "Gallons")
                    {
                        fwAddition = (((curSal1 - reqSal1) + 1) * salinity) * volume1;
                        fwAddition = Math.Round(fwAddition, 0);
                        ViewBag.fwAddition = fwAddition + " " + Units;
                        return View();
                    }
                    else
                    {
                        fwAddition = ((((curSal1 - reqSal1) + 1) * salinity) * volume1) * conversionFW;
                        fwAddition = Math.Round(fwAddition, 0);
                        ViewBag.fwAddition = fwAddition + " " + Units;
                        return View();
                    }
                }
            }
            catch
            {
                ViewBag.Output = message;
                return View();
            }
        }
        public ActionResult Cube(string Units, string length)
        {
            try
            {
                string volType;
                double conversion;
                double calculatedVol;
                double length1 = Convert.ToDouble(length);
                calculatedVol = 0;

                if (length == null)
                {
                    ViewBag.Result = " ";
                    return View();
                }
                else
                {

                    if (Units == "Imperial")
                    {
                        conversion = 0.00360465;
                        volType = "Gallons";
                    }
                    else
                    {
                        conversion = 0.001;
                        volType = "Litres";
                    }


                    calculatedVol = (Math.Pow(length1, 3)) * conversion;
                    calculatedVol = Math.Round(calculatedVol, 0);
                    ViewBag.Result = calculatedVol + " " + volType;
                    return View();
                }
            }
            catch
            {
                ViewBag.Output = message;
                return View();
            }
        }
        public ActionResult Rectangle(string Units, string length, string width, string height)
        {
            try
            {
                string volType;
                double conversion;
                double calculatedVol;
                double length1 = Convert.ToDouble(length);
                double width1 = Convert.ToDouble(width);
                double height1 = Convert.ToDouble(height);
                calculatedVol = 0;
                if (length == null)
                {
                    ViewBag.Result = " ";
                    return View();
                }
                else
                {
                    if (Units == "Imperial")
                    {
                        conversion = 0.00360465;
                        volType = "Gallons";
                    }
                    else
                    {
                        conversion = 0.001;
                        volType = "Litres";
                    }
                    calculatedVol = (width1 * length1 * height1) * conversion;
                    calculatedVol = Math.Round(calculatedVol, 0);
                    calculatedVol = Math.Round(calculatedVol, 0);
                    ViewBag.Result = calculatedVol + " " + volType;
                    return View();
                }
            }
            catch
            {
                ViewBag.Output = message;
                return View();
            }
        }
        public ActionResult Cylinder(string Units, string height, string radius)
        {
            try
            {
                string volType;
                double conversion;
                double calculatedVol;
                double height1 = Convert.ToDouble(height);
                double radius1 = Convert.ToDouble(radius);
                calculatedVol = 0;

                if (height == null)
                {
                    ViewBag.Result = " ";
                    return View();
                }
                else
                {
                    if (Units == "Imperial")
                    {
                        conversion = 0.00360465;
                        volType = "Gallons";
                    }
                    else
                    {
                        conversion = 0.001;
                        volType = "Litres";
                    }
                    calculatedVol = (3.14159265358979 * (Math.Pow(radius1, 2)) * height1) * conversion;
                    calculatedVol = Math.Round(calculatedVol, 0);
                    ViewBag.Result = calculatedVol + " " + volType;
                    return View();
                }
            }
            catch
            {
                ViewBag.Output = message;
                return View();
            }
        }
        public ActionResult Hexagon(string Units, string height, string side)
        {
            try
            {
                string volType;
                double conversion;
                double calculatedVol;
                double height1 = Convert.ToDouble(height);
                double side1 = Convert.ToDouble(side);
                calculatedVol = 0;

                if (height == null)
                {
                    ViewBag.Output = " ";
                    return View();
                }
                else
                {
                    if (Units == "Imperial")
                    {
                        conversion = 0.00360465;
                        volType = "Gallons";
                    }
                    else
                    {
                        conversion = 0.001;
                        volType = "Litres";
                    }
                    calculatedVol = (3 * Math.Sqrt(3) / 2) * (Math.Pow(side1, 2) * height1) * conversion;
                    calculatedVol = Math.Round(calculatedVol, 0);
                    ViewBag.Result = calculatedVol + " " + volType;
                    return View();
                }
            }
            catch
            {
                ViewBag.Output = message;
                return View();
            }
        }
        public ActionResult Substrate()
        {
            return View();
        }

    }
}