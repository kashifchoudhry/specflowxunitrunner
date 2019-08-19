using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;

namespace _xUnitSpecflow
{
    [Binding]
    public sealed class StepDefinition1
    {
        // For additional details on SpecFlow step definitions see https://go.specflow.org/doc-stepdef

        private readonly ScenarioContext context;

        public StepDefinition1(ScenarioContext injectedContext)
        {
            context = injectedContext;
        }

        [Given("I have entered (.*) into the calculator")]
        public void GivenIHaveEnteredSomethingIntoTheCalculator(int number)
        {
            //TODO: implement arrange (precondition) logic
            // For storing and retrieving scenario-specific data see https://go.specflow.org/doc-sharingdata 
            // To use the multiline text or the table argument of the scenario,
            // additional string/Table parameters can be defined on the step definition
            // method. 

            context.Pending();
        }

        [Given(@"I run test '(.*)'")]
        public void GivenIRunTest(string p0)
        {
            Console.WriteLine("Running Test '{0}'", p0);
            //Console.WriteLine("Hooksvar: '{0}'", Hooks.hooksVar);
            //Hooks.hooksVar = "set in GivenIRunTest";
        }

        [When(@"I click the link")]
        public void WhenIClickTheLink()
        {
            Console.WriteLine("  - Clicked link");
            //Console.WriteLine("Hooksvar: '{0}'", Hooks.hooksVar);
            //Hooks.hooksVar = "set in WhenIClickTheLink";
        }

        [Then(@"the information is displayed")]
        public void ThenTheInformationIsDisplayed()
        {
            Console.WriteLine("  - Information displayed");
            //Console.WriteLine("Hooksvar: '{0}'", Hooks.hooksVar);
            //Hooks.hooksVar = "set in ThenTheInformationIsDisplayed";
        }
    }
}
