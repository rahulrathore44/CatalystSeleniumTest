﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using CatalystSelenium.BaseClasses;
using CatalystSelenium.ComponentHelper;
using CatalystSelenium.ExtensionClass.WebElementExtClass;

namespace CatalystSelenium.PageObject.Reports
{
    public class ReportPage : PageBase
    {
        private IWebDriver _driver;

        [FindsBy(How = How.XPath, Using = "//a[contains(text(),'Partner Detail Report')]")]
        private IWebElement pdReport;

        [FindsBy(How = How.XPath, Using = "//a[contains(text(),'Point Balance Detail Report')]")]
        private IWebElement pbdReport;

        [FindsBy(How = How.XPath, Using = "//a[contains(text(),'Incentive Claim Detail Report')]")]
        private IWebElement icdReport;

        [FindsBy(How = How.XPath, Using = "//a[contains(text(),'User Detail Report')]")]
        private IWebElement udReport;

        [FindsBy(How = How.XPath, Using = "//a[contains(text(),'Incentive Performance Summary')]")]
        private IWebElement ipSummary;

        public ReportPage(IWebDriver driver) : base(driver)
        {
            _driver = driver;
        }

        private void TakeReportPageScrShot(IWebElement element, string name)
        {
            //JavaScriptExecutorHelper.ScrollElementAndClick(element);
            element.ScrollElementAndClick();
            BrowserHelper.SwitchToWindow(1);
            Thread.Sleep(500);
            TakeScreenShot(name);
            BrowserHelper.SwitchToParentWithClose();
        }

        public void PartnerDetailReportScrShot(string name)
        {
            TakeReportPageScrShot(pdReport,name);
        }

        public void PointBalanceDetailReportScrShot(string name)
        {
            TakeReportPageScrShot(pbdReport, name);
        }

        public void IncentiveClaimDetailReportScrShot(string name)
        {
            TakeReportPageScrShot(icdReport, name);
        }

        public void UserDetailReportScrShot(string name)
        {
            TakeReportPageScrShot(udReport, name);
        }
        public void IncentivePerformanceSummaryScrShot(string name)
        {
            TakeReportPageScrShot(ipSummary, name);
        }
    }
}
