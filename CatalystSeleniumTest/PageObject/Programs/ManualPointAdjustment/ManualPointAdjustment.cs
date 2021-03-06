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
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CatalystSelenium.PageObject.Programs.ManualPointAdjustment
{
    public class ManualPointAdjustment : PageBase
    {
        private IWebDriver _driver;
        private readonly PointTypeDetail _detail;

        [FindsBy(How = How.Id, Using = "PointTypes")]
        private IWebElement PointType;

        [FindsBy(How = How.Id, Using = "IncentiveInstance")]
        private IWebElement ProgramNames;

        [FindsBy(How = How.XPath, Using = "//a[text()='Go To File Management']")]
        private IWebElement FileManagment;

        [FindsBy(How = How.Id, Using = "pointAdjustmentBtn")]
        public IWebElement PointAdjustmet;

        public ManualPointAdjustment(IWebDriver driver) : base(driver)
        {
            _driver = driver;
            _detail = new PointTypeDetail(_driver);
        }

        public void SelectPointAndProgram(string pointTy, string programName)
        {
            //DropDownHelper.SelectByVisibleText(PointType, pointTy);
            DropDownHelper.SelectFromDropDownWithLabel("Point Types", pointTy);
            Thread.Sleep(200);
            //DropDownHelper.SelectByVisibleText(ProgramNames, programName);
            DropDownHelper.SelectFromDropDownWithLabel("Program Names", programName);
            Thread.Sleep(2000);
            GenericHelper.WaitForLoadingMask();
        }

        public void SelectPointTypInGrid(string gridXpath, int row, int column)
        {
            var element = GridHelper.GetGridElement(gridXpath, row, column);
            JavaScriptExecutorHelper.ScrollElementAndClick(element);
        }

        public void ClickPointToAdjust()
        {
            JavaScriptExecutorHelper.ScrollElementAndClick(PointAdjustmet);
        }

        public void ClickPointAdjTakeScrShot(string name)
        {
            ClickPointToAdjust();
            _detail.WaitForModalDialog();
            Thread.Sleep(300);
            _detail.ValidateElemetInPage(); // validate the element in the dialog box
            TakeScreenShot(name);
            _detail.ClickClose();
            Thread.Sleep(100);
        }

        public void ManualPointAdjustmentValidateElements()
        {

            Assert.IsTrue(GenericHelper.IsElementPresentQuick(GetLocatorOfWebElement("FileManagment")), "FileManagment Element Not Found");
        }
    }
}
