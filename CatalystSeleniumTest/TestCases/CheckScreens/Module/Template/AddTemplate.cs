﻿using System;
using CatalystSelenium.BaseClasses.LoginBaseClass;
using CatalystSelenium.ExtensionClass.LoggerExtClass;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CatalystSelenium.TestCases.CheckScreens.Module.Template
{
    [TestClass]
    public class Template : LoginBase
    {
        /// <summary>
        /// asdsa
        /// 
        /// asdas
        /// 
        /// </summary>

        [TestMethod,TestCategory("Error")]
        public void TemplateScrShot()
        {
            try
            {
               
               // var lpage = new LoginPage(ObjectRepository.Driver);
               // var hPage = lpage.LoginApplication(ObjectRepository.Config.GetUsername(), ObjectRepository.Config.GetPassword());
                var temPage = HPage.AddTemplate();
                temPage.TakeManageNotificationScrShot(string.Format("StageTemplates-{0}", DateTime.UtcNow.ToString("hh-mm-ss")));

                HPage.Logout();
            }
            catch (Exception exception)
            {
                Logger.Error(exception.StackTrace,exception);
                throw;
            }
            

          
           
          
        }
       


    }
}


