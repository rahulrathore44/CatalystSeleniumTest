﻿using System;
using CatalystSelenium.BaseClasses.LoginBaseClass;
using CatalystSelenium.ExtensionClass.LoggerExtClass;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CatalystSelenium.TestCases.CheckScreens.Module.Llibrary
{
    [TestClass,Ignore]
    public class Library : LoginBase
    {
        [TestMethod]
        public void TestLibrary()
        {
            try
            {
                var libpage = HPage.NavigateToLibrary();
                libpage.EntertAssetURL("http://www.google.com");
                libpage.EntertAssetName("AssetAutomation");
                libpage.EntertAssetDescription("Desciption");
                libpage.SelectEligibleGroup("StaticStage1");
                // libpage.SelectEndDatetoday("12", "February", "2016");
                libpage.SelectEndDatetoday();
                libpage.SelectLanguage("US English");

                // libpage.Logout();
            }
            catch (Exception exception)
            {
                Logger.LogException(exception);
                throw;
            }
            
        }
    }
}
