﻿using System;
using System.Threading;
using CatalystSelenium.ExtensionClass.WebElementExtClass;
using log4net;
using OpenQA.Selenium;
using CatalystSelenium.Settings;

namespace CatalystSelenium.ComponentHelper
{
    public class CalenderHelper
    {
        private static readonly ILog Logger = LoggerHelper.GetLogger(typeof(CalenderHelper));


        private static string GetTodayButtonLocator(string label)
        {
            return "//label[contains(text(),'" + label + "')]/following-sibling::p//button[text()='Today']";
        }

        private static void ClickHeader(string tableXPath)
        {
            ObjectRepository.Driver.FindElement(By.XPath(tableXPath + "/thead/tr[1]//strong")).Click();
            Logger.Info(" Click on Calender Header " + tableXPath);
            Thread.Sleep(500);
        }

        private static void SelectMonth(string tableXPath, string month)
        {
            for (var i = 1; i <= 4; i++)
            {
                for (var j = 1; j <= 3; j++)
                {
                    if (
                        !GenericHelper.IsElementPresentQuick(
                            By.XPath(tableXPath + "/tbody/tr[" + i + "]/td[" + j + "]//span")))
                        continue;

                    var aMonth = ObjectRepository.Driver.FindElement(By.XPath(tableXPath + "/tbody/tr[" + i + "]/td[" + j + "]//span")).Text;
                    Logger.Debug(string.Format("Month : {0}", aMonth));
                    if (!month.Equals(aMonth, StringComparison.OrdinalIgnoreCase))
                        continue;
                    ObjectRepository.Driver.FindElement(By.XPath(tableXPath + "/tbody/tr[" + i + "]/td[" + j + "]//span")).Click();
                    return;
                }
            }
            Logger.Info(" Select Month " + month + " from " + tableXPath);
        }

        private static void SelectYear(string tableXPath, string year)
        {
            for (var i = 1; i <= 4; i++)
            {
                for (var j = 1; j <= 5; j++)
                {
                    if (
                        !GenericHelper.IsElementPresentQuick(
                            By.XPath(tableXPath + "/tbody/tr[" + i + "]/td[" + j + "]//span")))
                        continue;

                    var aYear = ObjectRepository.Driver.FindElement(By.XPath(tableXPath + "/tbody/tr[" + i + "]/td[" + j + "]//span")).Text;
                    Logger.Debug(string.Format("Year : {0}", aYear));
                    if (!year.Equals(aYear, StringComparison.OrdinalIgnoreCase))
                        continue;

                    ObjectRepository.Driver.FindElement(By.XPath(tableXPath + "/tbody/tr[" + i + "]/td[" + j + "]//span")).Click();
                    return;
                }
            }
            Logger.Info(" Select Year " + year + " from " + tableXPath);
        }

        private static void SelectDay(string tableXPath, string day)
        {
            for (var i = 1; i <= 6; i++)
            {
                for (var j = 2; j <= 8; j++)
                {
                    if (
                        !GenericHelper.IsElementPresentQuick(
                            By.XPath(tableXPath + "/tbody/tr[" + i + "]/td[" + j + "]//span")))
                        continue;

                    var xpath = tableXPath + "/tbody/tr[" + i + "]/td[" + j + "]//span";

                    var aday = ObjectRepository.Driver.FindElement(By.XPath(xpath)).Text;
                    Logger.Debug(string.Format("Day : {0}", aday));
                    if (!day.Equals(aday, StringComparison.OrdinalIgnoreCase))
                        continue;

                    if (ObjectRepository.Driver.FindElement(By.XPath(xpath))
                        .GetAttribute("class")
                        .Contains("text-muted"))
                        continue;

                    ObjectRepository.Driver.FindElement(By.XPath(xpath)).Click();
                    return;
                }
            }
            Logger.Info(" Select Day " + day + " from " + tableXPath);
        }

        #region Public

        public static void ClickOnTodayButton(string label)
        {
            GenericHelper.GetElement(By.XPath(GetTodayButtonLocator(label))).ScrollElementAndClick();
        }

        public static void SelectDate(string tableXPath, string day, string month, string year)
        {
            ClickHeader(tableXPath);
            Thread.Sleep(500);
            ClickHeader(tableXPath);
            Thread.Sleep(500);
            SelectYear(tableXPath, year);
            Thread.Sleep(500);
            SelectMonth(tableXPath, month);
            Thread.Sleep(500);
            SelectDay(tableXPath, day);
            Thread.Sleep(500);

        }

        #endregion

        
    }
}
