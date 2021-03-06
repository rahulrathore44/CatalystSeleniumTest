﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using CatalystSelenium.ComponentHelper;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using CatalystSelenium.BaseClasses;

namespace CatalystSelenium.PageObject.IncentivePage
{
    public class EligibleGroupPage : PageBase
    {
        public EligibleGroupPage(IWebDriver _driver) : base(_driver)
        {
        }

            [FindsBy(How = How.XPath,Using = "//a[text()='Eligible Group(s)']")]
            private IWebElement EligibleGroup;

            [FindsBy(How = How.XPath,Using = "//select[@title='Group']")]
            private IWebElement EligibleGroupDropown;

            [FindsBy(How = How.XPath, Using = "//select[@title='Nomination Group']")]
            private IWebElement NominationGroupDropown;

            [FindsBy(How = How.XPath,Using = "//div[@id='accordion']/descendant::div[@id='rendered'][position()=5]/button")]
            private IWebElement EligibleGroupNext;

            [FindsBy(How = How.Name,Using = "USE_NOMINATION")]
            private IWebElement UseNominationCheckBox;

            public void AddEligibleGroup(string grpName)
            {
                JavaScriptExecutorHelper.ScrollElementAndClick(EligibleGroup);
                GenericHelper.WaitForLoadingMask();
                DropDownHelper.SelectByVisibleText(EligibleGroupDropown, grpName);
                EligibleGroupNext.Click();
                Thread.Sleep(500);
                EligibleGroup.Click();
                GenericHelper.WaitForLoadingMask();
            }

        public void AddEligibleGroup(string grpName,bool useNomination,string nominationGrpName)
        {
            JavaScriptExecutorHelper.ScrollElementAndClick(EligibleGroup);
            GenericHelper.WaitForLoadingMask();
            JavaScriptExecutorHelper.ScrollToElement(EligibleGroupDropown);
            DropDownHelper.SelectByVisibleText(EligibleGroupDropown, grpName);
            UseNominationCheckBox.Click();
            JavaScriptExecutorHelper.ScrollToElement(NominationGroupDropown);
            DropDownHelper.SelectByVisibleText(NominationGroupDropown,nominationGrpName);
            EligibleGroupNext.Click();
            Thread.Sleep(500);
            EligibleGroup.Click();
            GenericHelper.WaitForLoadingMask();
        }

        public void ClickEligibelGrpAndNext()
        {
            JavaScriptExecutorHelper.ScrollElementAndClick(EligibleGroup);
            GenericHelper.WaitForLoadingMask();
            TakeScreenShot(string.Format("EligibleGroup-{0}",DateTime.UtcNow.ToString("hh-mm-ss")));
            JavaScriptExecutorHelper.ScrollElementAndClick(EligibleGroupNext);
            GenericHelper.WaitForLoadingMask();
            JavaScriptExecutorHelper.ScrollElementAndClick(EligibleGroup);
            GenericHelper.WaitForLoadingMask();
        }
    }
}
