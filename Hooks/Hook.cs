using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AventStack.ExtentReports;
using AventStack.ExtentReports.Gherkin.Model;
using AventStack.ExtentReports.Reporter;

namespace SpecflowProjectDeneme.Hooks
{
    [Binding]
    //public sealed class Hooks
    public sealed class Hook
    {

        //Selenium ekleme
        public static IWebDriver driver;

        //Extend Report
        private static ScenarioContext _scenarioContext;//scenario bağlam kurmak için
        private static FeatureContext _featueContext; //feature bağlam kurmak için
        private static ExtentHtmlReporter _extentHtmlReporter; //1.
        private static ExtentReports _extentReports; //2.
        private static ExtentTest _feature;
        private static ExtentTest _scenario;

        //Extent Rapor çalışacak Metot
        [BeforeTestRun]
        public static void BeforeTestRun()
        {
            //HTML Rapor 
            string path = @"C:\Users\ayberk.ercan\Desktop\SpecFlowProjectt\SpecflowProjectDeneme\TestReports\ExtentReport\";

            var name = DateTime.Now.ToShortDateString();
            System.IO.Directory.CreateDirectory(path + name);
            var p = path + name + "\\";
            _extentHtmlReporter = new ExtentHtmlReporter(p);
            //_extentHtmlReporter.Config.Theme = AventStack.ExtentReports.Reporter.Configuration.Theme.Dark;
            _extentReports = new ExtentReports();
            _extentReports.AttachReporter(_extentHtmlReporter);
            //  degisken.WhenResultSurecNo();

        }
        //Feature çalışacak
        [BeforeFeature]
        public static void BeforeFeatureStart(FeatureContext featureContext)
        {
            if (featureContext != null)
            {
                _feature = _extentReports.CreateTest<Feature>(featureContext.FeatureInfo.Title, featureContext.FeatureInfo.Description);
            }

        }

        [BeforeScenario]
        public static void BeforeScenarioStart(ScenarioContext scenarioContext)
        {
            // driver = new ChromeDriver();

            if (scenarioContext != null)
            {
                _scenarioContext = scenarioContext;
                _scenario = _feature.CreateNode<Scenario>(scenarioContext.ScenarioInfo.Title, scenarioContext.ScenarioInfo.Description);

                driver = new ChromeDriver();
                driver.Manage().Window.Maximize();
                driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            }
        }
        //Scenario Her Bir adımları Raporlama
        [AfterStep]
        public void AfterEachStep()
        {
            //logic-->Given, When or Then
            //add note
            ScenarioBlock scenarioBlock = _scenarioContext.CurrentScenarioBlock;

            //swich case
            switch (scenarioBlock)
            {
                case ScenarioBlock.Given:
                    if (_scenarioContext.TestError != null)
                    {
                        _scenario.CreateNode<Given>(_scenarioContext.StepContext.StepInfo.Text).Fail
                            (_scenarioContext.TestError.Message + "\n" + _scenarioContext.TestError.StackTrace);
                    }
                    else
                    {
                        _scenario.CreateNode<Given>(_scenarioContext.StepContext.StepInfo.Text).Pass("Test Başarılı");
                    }
                    //CreateNote<Given>();
                    break;

                case ScenarioBlock.When:
                    if (_scenarioContext.TestError != null)
                    {
                        _scenario.CreateNode<When>(_scenarioContext.StepContext.StepInfo.Text).Fail
                            (_scenarioContext.TestError.Message + "\n" + _scenarioContext.TestError.StackTrace);
                    }
                    else
                    {
                        _scenario.CreateNode<When>(_scenarioContext.StepContext.StepInfo.Text).Pass("Test Başarılı");
                    }
                    // CreateNote<When>();
                    break;

                case ScenarioBlock.Then:
                    if (_scenarioContext.TestError != null)
                    {
                        _scenario.CreateNode<Then>(_scenarioContext.StepContext.StepInfo.Text).Fail
                            (_scenarioContext.TestError.Message + "\n" + _scenarioContext.TestError.StackTrace);
                    }
                    else
                    {
                        _scenario.CreateNode<Then>(_scenarioContext.StepContext.StepInfo.Text).Pass("Test Başarılı");
                    }
                    // CreateNote<Then>();
                    break;

                default:
                    if (_scenarioContext.TestError != null)
                    {
                        _scenario.CreateNode<And>(_scenarioContext.StepContext.StepInfo.Text).Fail(_scenarioContext.TestError.Message + "\n" +
                                 _scenarioContext.TestError.StackTrace);
                    }
                    else
                    {
                        _scenario.CreateNode<And>(_scenarioContext.StepContext.StepInfo.Text).Pass("Test Başarılı");
                    }
                    // CreateNote<And>();
                    break;
            }

        }

        //tüm testlerin Sonucu yazdırır.
        [AfterTestRun]
        public static void AfterTestRun()
        {
            _extentReports.Flush();
        }

        [AfterScenario]
        public void AfterScenario()
        {
            //driver.Quit();
            //driver.Dispose();
        }
    }
}
