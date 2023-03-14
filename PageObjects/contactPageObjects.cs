using Microsoft.Playwright;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DynamicsCEPlayWright.PageObjects
{
    class contactPageObjects
    {
        //contact elements
        private IPage _page;
        private readonly ILocator contactEntity;
        private readonly ILocator newContact;
        private readonly ILocator firstName;
        private readonly ILocator LastName;
        private readonly ILocator JobTitle;
        private readonly ILocator email;
        private readonly ILocator saveButton;
        private readonly ILocator newCreatedContact;

        public contactPageObjects(IPage page)
        {
            _page = page;
            contactEntity = page.Locator("//img[contains(@title,'Contacts')]");
            newContact = page.Locator("//img[contains(@alt,'New')]");
            firstName = page.Locator("//input[@aria-label='First Name']");
            LastName = page.Locator("//input[contains(@aria-label,'Last Name')]");
            JobTitle = page.Locator("//input[contains(@aria-label,'Job Title')]");
            email = page.Locator("//input[contains(@aria-label,'Email')]");
            saveButton = page.Locator("//img[@alt='Save']");
            newCreatedContact = page.Locator("//span[@role='presentation'][contains(.,'Test Jacobs')]");
        }

        //Log into the system
        //select the contact entity
        public async Task selectContactEntity()
        {
            await contactEntity.ClickAsync();
        }
        //select to create a new contact
        public async Task selectNewContactButton()
        {
            await newContact.ClickAsync();
        }
        //provide the neccessary details
        public async Task provideUserDetails()
        {
            await firstName.FillAsync("Test");
            await LastName.FillAsync("Jacobs");
            await JobTitle.FillAsync("QA tester");
            await email.FillAsync("testjacobs@gmail.com");
        }
        //save the contact
        public async Task saveNewContactRecord()
        {
            await saveButton.ClickAsync();
        }
        
        //new contact is created 
        public async Task validateNewContactIsCreated()
        {
            await contactEntity.ClickAsync();
            await newCreatedContact.IsVisibleAsync();
        }

    }
}
