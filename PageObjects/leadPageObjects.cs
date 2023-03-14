using Microsoft.Playwright;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DynamicsCEPlayWright.PageObjects
{
    class leadPageObjects
    {
        //Login element
        private IPage _page;
        private readonly ILocator emaiAddressField;
        private readonly ILocator nextButton;
        private readonly ILocator sendNotificationButton;
        private readonly ILocator salesappLink;
        private readonly ILocator staysignedinYesButton;

        //Leads elements
        private readonly ILocator leadEntity;
        private readonly ILocator lead;
        private readonly ILocator qualifyBPF;
        private readonly ILocator nextstageBPF;
        private readonly ILocator newOpportunity;
        private readonly ILocator budgetAmount;
        private readonly ILocator description;
        private readonly ILocator saveAndClose;
        private readonly ILocator opportunityRecord;
        private readonly ILocator developBPF;
        private readonly ILocator stakeholderCheckBox;
        private readonly ILocator competitorsCehckBox;
        private readonly ILocator finishFlag;
        private readonly ILocator closeAsWon;
        private readonly ILocator confirmClose;
        private readonly ILocator readonlyIcon;
        private readonly ILocator setActiveButton;
        private readonly ILocator identifySalesTeamCheckBox;
        private readonly ILocator completeInternalReviewCheckBox;
        private readonly ILocator completeFinalProposalCheckBox;
        private readonly ILocator fileDebriefCheckBox;
        private readonly ILocator sendThankYouCheckBox;
        private readonly ILocator closeStageBPF;

        public leadPageObjects(IPage page)
        {
            _page = page;
            emaiAddressField = page.Locator("//input[@id='i0116']");
            nextButton = page.Locator("//input[@id='idSIButton9']");
            sendNotificationButton = page.Locator("//input[@id='idSIButton9']");
            staysignedinYesButton = page.Locator("//input[@id='idSIButton9']");
            salesappLink = page.Locator("//span[normalize-space()='Sales trial']");
            leadEntity = page.Locator("//img[contains(@title,'Leads')]");
            lead = page.Locator("//span[contains(.,'Test Jacobs')]");
            qualifyBPF = page.Locator("(//div[@id='MscrmControls.Containers.ProcessBreadCrumb-processHeaderStageName_f99b4d48-7aad-456e-864a-8e7d543f7495'])[1]");
            nextstageBPF = page.Locator("//label[contains(.,'Next Stage')]");
            setActiveButton = page.Locator("//label[contains(.,'Set Active')]");
            newOpportunity = page.Locator("//button[@aria-label='Create']");
            budgetAmount = page.Locator("//input[contains(@aria-label,'Budget Amount')]");
            description = page.Locator("//textarea[@aria-label='Description']");
            saveAndClose = page.Locator("//img[contains(@alt,'Save & Close')]");
            developBPF = page.Locator("//div[contains(@class,'pa-aj pa-e pa-ax pa-akx pa-av pa-bj pa-zd pa-zc pa-bz pa-aw pa-be pa-st ')]");
            stakeholderCheckBox = page.Locator("//input[@aria-label='Identify Stakeholders']");
            competitorsCehckBox = page.Locator("//input[@aria-label='Identify Stakeholders']");
            finishFlag = page.Locator("//label[contains(.,'Finish')]");
            closeAsWon = page.Locator("//img[@alt='Close as Won']");
            confirmClose = page.Locator("//span[contains(.,'OK')]");
            readonlyIcon = page.Locator("//span[@role='presentation'][contains(.,'Read-only  This record’s status: Won')]");
            opportunityRecord = page.Locator("//li[@aria-label='Test']");
            identifySalesTeamCheckBox = page.Locator("//input[@aria-label='Identify Sales Team']");
            completeInternalReviewCheckBox = page.Locator("//input[@aria-label='Complete Internal Review']");
            fileDebriefCheckBox = page.Locator("//input[@aria-label='File De-brief']");
            sendThankYouCheckBox = page.Locator("//input[@aria-label='Send Thank You']");
            completeFinalProposalCheckBox = page.Locator("//input[@aria-label='Complete Final Proposal']");
            closeStageBPF = page.Locator("//label[contains(.,'(3 min)')]");
        }

        //loginActions
        public async Task inputEmail()
        {
            await emaiAddressField.FillAsync("kennylofton315@hotmail.com");
        }

        public async Task clickNextButton()
        {
            await nextButton.ClickAsync();
        }

        public async Task clickSendNotificationButton()
        {
            await sendNotificationButton.ClickAsync();
        }

        //Wait for 2FA Code input
        public async Task waitforMFA()
        {
            await Task.Delay(TimeSpan.FromSeconds(8));
        }

        public async Task clickStaySignedInButton()
        {
            await staysignedinYesButton.ClickAsync();
        }

        public async Task waitForSystemtoLoad()
        {
            await Task.Delay(TimeSpan.FromSeconds(40));
        }
        //asset to validate element is present
        
        public async Task validateSalesLink()
        {
            await salesappLink.IsVisibleAsync();
        }

        //public async Task validateSalesLink() =>
        //await salesappLink.IsVisibleAsync();

        //Lead Actions
        public async Task selectLead()
        {
            await leadEntity.ClickAsync();
            await lead.ClickAsync();
        }

        public async Task bpfProcess()
        {
            await qualifyBPF.ClickAsync();
            await nextstageBPF.ClickAsync();
            await newOpportunity.ClickAsync();
            await budgetAmount.FillAsync("2000");
            await description.FillAsync("Contact has progressibve opportunity");
            await saveAndClose.ClickAsync();

            await qualifyBPF.ClickAsync();
            await setActiveButton.ClickAsync();
            await nextstageBPF.ClickAsync();
            await opportunityRecord.ClickAsync();

            await Task.Delay(TimeSpan.FromSeconds(5));
            await developBPF.IsVisibleAsync();
            await Task.Delay(TimeSpan.FromSeconds(5));
            await stakeholderCheckBox.ClickAsync();
            await competitorsCehckBox.ClickAsync();
            await nextstageBPF.ClickAsync();

            await Task.Delay(TimeSpan.FromSeconds(5));
            await identifySalesTeamCheckBox.ClickAsync();
            await completeInternalReviewCheckBox.ClickAsync();
            await closeStageBPF.IsVisibleAsync();
            await nextstageBPF.ClickAsync();
            

            await completeFinalProposalCheckBox.ClickAsync();
            await sendThankYouCheckBox.ClickAsync();
            await fileDebriefCheckBox.ClickAsync();

            await Task.Delay(TimeSpan.FromSeconds(10));
            await finishFlag.ClickAsync();
            await Task.Delay(TimeSpan.FromSeconds(10));
        }

        public async Task closeOpportunity()
        {
            await closeAsWon.ClickAsync();
            await confirmClose.ClickAsync();
        }

        public async Task validateOpportunityStatus()
        {
            await Task.Delay(TimeSpan.FromSeconds(5));
            await readonlyIcon.IsVisibleAsync();
        }

        //public async Task<bool> validateReadOnlyIcon() =>
            //await readonlyIcon.IsVisibleAsync();

    }
}
