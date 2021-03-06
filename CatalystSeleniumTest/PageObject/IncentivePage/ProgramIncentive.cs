﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using CatalystSelenium.BaseClasses;
using CatalystSelenium.ComponentHelper;

namespace CatalystSelenium.PageObject.IncentivePage
{
    public class ProgramIncentive : PageBase 
    {
        public ProgramIncentive(IWebDriver _driver) : base(_driver)
        {
        }

        [FindsBy(How = How.XPath, Using = "//a[text()='Program Incentive']")]
        private IWebElement ProgramIncentives;

        [FindsBy(How = How.XPath,Using = "//label[text()='ACTIVITY_CODE']/following-sibling::div/input")]
        private IWebElement Activity_Code;

        [FindsBy(How = How.XPath,Using = "//label[text()='ACTIVITY_TYPE']/following-sibling::div/input")]
        private IWebElement Activity_Type;

        [FindsBy(How = How.XPath,Using = "//label[text()='DESCRIPTION']/following-sibling::div/input")]
        private IWebElement Description;

        [FindsBy(How = How.XPath,Using = "//label[text()='POINTS']/following-sibling::div/input")]
        private IWebElement Points;

        [FindsBy(How = How.XPath,Using = "//button[@type='submit' and text()='Submit']")]
        private IWebElement Submit;

        [FindsBy(How = How.XPath, Using = "//label[text()='PRODUCT_CLASS']/following-sibling::div/input")]
        private IWebElement ProductClass;

        [FindsBy(How = How.XPath, Using = "//label[text()='PRODUCT_DESCRIPTION']/following-sibling::div/input")]
        private IWebElement ProductDescp;

        [FindsBy(How = How.XPath, Using = "//label[text()='PRODUCT_FAMILY']/following-sibling::div/input")]
        private IWebElement ProductFamily;

        [FindsBy(How = How.XPath, Using = "//label[text()='PRODUCT_LINE']/following-sibling::div/input")]
        private IWebElement ProductLine;

        [FindsBy(How = How.XPath, Using = "//label[text()='PRODUCT_SKU']/following-sibling::div/input")]
        private IWebElement ProductSku;

        [FindsBy(How = How.XPath, Using = "//label[text()='PRODUCT_TYPE']/following-sibling::div/input")]
        private IWebElement ProductType;

        [FindsBy(How = How.XPath, Using = "//label[text()='UNITS_SOLD_MAX']/following-sibling::div/input")]
        private IWebElement UnitSoldMax;

        [FindsBy(How = How.XPath, Using = "//label[text()='UNITS_SOLD_MIN']/following-sibling::div/input")]
        private IWebElement UnitSoldMin;

        [FindsBy(How = How.XPath, Using = "//div[@id='accordion']/descendant::div[@id='rendered'][position()=4]/button")]
        private IWebElement ProgramIncentiveNext;

        public void AddProgramIncentive(string acCode, string acType, string desc, string points)
        {
            Activity_Code.SendKeys(acCode);
            Activity_Type.SendKeys(acType);
            Description.SendKeys(desc);
            Points.SendKeys(points);
            Submit.Click();
        }

        public void VerifyAddProgramIncentiveGrid(string gridXpath,string actvityCode,string descp,string activityType,string points)
        {
            DropDownHelper.SelectItemPerList("100");
            GridHelper.VerifyIncentiveGridEntry(gridXpath,actvityCode,descp,activityType,points);
        }

        public void AddProgramIncentive(string points,string prodSku, string prdDescp, string prodFamily, string prodClass,
            string prodLine, string prodType, string unitSoldMax,string unitSoldMin)
        {
            Points.SendKeys(points);
            ProductClass.SendKeys(prodClass);
            ProductDescp.SendKeys(prdDescp);
            ProductFamily.SendKeys(prodFamily);
            ProductLine.SendKeys(prodLine);
            ProductSku.SendKeys(prodSku);
            ProductType.SendKeys(prodType);
            UnitSoldMax.SendKeys(unitSoldMax);
            UnitSoldMin.SendKeys(unitSoldMin);
            Submit.Click();
            GenericHelper.WaitForLoadingMask();
        }

        public void ClickProgramIncentiveAndNext()
        {
            JavaScriptExecutorHelper.ScrollElementAndClick(ProgramIncentives);
            GenericHelper.WaitForLoadingMask();
            TakeScreenShot(string.Format("ProgramIncentives-{0}",DateTime.UtcNow.ToString("hh-mm-ss")));
            JavaScriptExecutorHelper.ScrollElementAndClick(ProgramIncentiveNext);
            GenericHelper.WaitForLoadingMask();
            JavaScriptExecutorHelper.ScrollElementAndClick(ProgramIncentives);
            GenericHelper.WaitForLoadingMask();
        }
    }
}
