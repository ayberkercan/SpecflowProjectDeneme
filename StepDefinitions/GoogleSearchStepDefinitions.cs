using SpecflowProjectDeneme.Pages;

namespace SpecflowProjectDeneme.StepDefinitions
{
    [Binding]
    public sealed class GoogleSearchStepDefinitions
    {
        GoogleAndSearchPage googleAndSearchPage = new();
        [Given(@"go to link adress ""([^""]*)""")]
        public void GivenGoToLinkAdress(string urlll)
        {
            googleAndSearchPage.GoToLink(urlll);
        }

        [When(@"click the search ""([^""]*)""")]
        public void WhenClickTheSearch(string nasa)
        {
            googleAndSearchPage.SearchNasa(nasa);
        }

        [When(@"click the web adress")]
        public void WhenClickTheWebAdress()
        {
            googleAndSearchPage.ClickTheNasa();
        }

        [Then(@"click the moontomars")]
        public void ThenClickTheMoontomars()
        {
            googleAndSearchPage.ClickToMoonToMarsMenu();
        }


    }
}