using BoDi;
using AbsaTechAssessment.ReusableMethods;
using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TechTalk.SpecFlow;

namespace AbsaTechAssessment
{
    [Binding]
    public sealed class Hooks : Validations
    {
        [ThreadStatic]

        private readonly IObjectContainer _container;

        public Hooks(IObjectContainer container)
        {
            _container = container;
        }

        [AfterScenario]
        public void AfterScenario()
        {
            Base.driver.Close();
            Base.driver.Quit();
        }
    }
}
