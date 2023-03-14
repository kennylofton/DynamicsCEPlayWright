using DynamicsCEPlayWright.PageObjects;
using NUnit.Framework;
using SpecflowPlaywrightProject.Drivers;
using System;
using System.Threading.Tasks;
using TechTalk.SpecFlow;

namespace DynamicsCEPlayWright.Steps
{
    [Binding]
    public class Feature2Steps
    {
        private readonly Driver _driver;

        //call page objects
        private readonly leadPageObjects _leadPageObjects;

        //constructor for driver
        public Feature2Steps(Driver driver)
        {
            _driver = driver;
            _leadPageObjects = new leadPageObjects(_driver.Page);
        }

        [Given(@"I am logged in to the sales app")]
        public async Task GivenIAmLoggedInToTheSalesApp()
        {
            await _driver.Page.GotoAsync("https://org9ef88703.crm11.dynamics.com/main.aspx?appid=ea5b3de8-4298-ed11-aad1-6045bd0f97a0&forceUCI=1&pagetype=dashboard&id=eaa6e6bb-4712-ec11-b6e7-00224820f09b&type=system&_canOverride=true");
        }
        
        [Given(@"I select the leads entity")]
        public async Task GivenISelectTheLeadsEntity()
        {
            await _leadPageObjects.inputEmail();
            await _leadPageObjects.clickNextButton();
            await _leadPageObjects.clickSendNotificationButton();
            await _leadPageObjects.waitforMFA();
            await _leadPageObjects.clickStaySignedInButton();
            await _leadPageObjects.waitForSystemtoLoad();
            await _leadPageObjects.validateSalesLink();
            
        }
        
        [Given(@"I select an existing leads")]
        public async Task GivenISelectAnExistingLeads()
        {
            await _leadPageObjects.selectLead();
        }
        
        [Given(@"I progress the lead to the close stage of the BPF")]
        public async Task GivenIProgressTheLeadToTheCloseStageOfTheBPF()
        {
            await _leadPageObjects.bpfProcess();
        }
        
        [When(@"I selec to close the lead as a win")]
        public async Task WhenISelecToCloseTheLeadAsAWin()
        {
            await _leadPageObjects.closeOpportunity();
        }
        
        [Then(@"the status of the record changes to read only")]
        public async Task ThenTheStatusOfTheRecordChangesToReadOnly()
        {
            await _leadPageObjects.validateOpportunityStatus();
        }
    }
}
