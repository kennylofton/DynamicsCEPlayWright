using DynamicsCEPlayWright.PageObjects;
using SpecflowPlaywrightProject.Drivers;
using System;
using System.Threading.Tasks;
using TechTalk.SpecFlow;

namespace DynamicsCEPlayWright.Steps
{
    [Binding]
    public class Feature1Steps
    {
        private readonly Driver _driver;

        //call page objects
        private readonly leadPageObjects _leadPageObjects;
        private readonly contactPageObjects _contactPageObjects;

        //constructor for driver
        public Feature1Steps(Driver driver)
        {
            _driver = driver;
            _leadPageObjects = new leadPageObjects(_driver.Page);
            _contactPageObjects = new contactPageObjects(_driver.Page);
        }

        [Given(@"I ahve logged into the system")]
        public async Task GivenIAhveLoggedIntoTheSystem()
        {
            await _driver.Page.GotoAsync("https://org9ef88703.crm11.dynamics.com/main.aspx?appid=ea5b3de8-4298-ed11-aad1-6045bd0f97a0&forceUCI=1&pagetype=dashboard&id=eaa6e6bb-4712-ec11-b6e7-00224820f09b&type=system&_canOverride=true");
            await _leadPageObjects.inputEmail();
            await _leadPageObjects.clickNextButton();
            await _leadPageObjects.clickSendNotificationButton();
            await _leadPageObjects.waitforMFA();
            await _leadPageObjects.clickStaySignedInButton();
            await _leadPageObjects.waitForSystemtoLoad();
            await _leadPageObjects.validateSalesLink();
            await Task.Delay(TimeSpan.FromSeconds(40));
        }

        [Given(@"I select the contact entity")]
        public async Task GivenISelectTheContactEntity()
        {
            await _contactPageObjects.selectContactEntity();
        }
        
        [Given(@"I select to create a new contact")]
        public async Task GivenISelectToCreateANewContact()
        {
            await _contactPageObjects.selectNewContactButton();
        }
        
        [Given(@"I provide the neccessary details")]
        public async Task GivenIProvideTheNeccessaryDetails()
        {
            await _contactPageObjects.provideUserDetails();
        }
        
        [Given(@"I save the contact")]
        public async Task GivenISaveTheContact()
        {
            await _contactPageObjects.saveNewContactRecord();
        }
        
        [Then(@"the new contact is created with the new tagged record")]
        public async Task ThenTheNewContactIsCreatedWithTheNewTaggedRecord()
        {
            await _contactPageObjects.validateNewContactIsCreated();
        }
    }
}
