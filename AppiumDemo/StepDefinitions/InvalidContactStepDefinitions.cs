using AppiumDemo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobileAutomationAppium;
[Binding]
public class InvalidContactStepDefinitions
{
    private SendNewMessage sendNewMessage;

    public InvalidContactStepDefinitions()
    {
        sendNewMessage = new SendNewMessage();
    }

    [When(@"User selects an invalid '([^']*)'")]
    public void WhenUserSelectsAnInvalidContact(string invalidContact)
    {
        sendNewMessage.SelectAnInvalidContact(invalidContact);
    }


    [Then(@"The message is not sent succesfully")]
    public void ThenTheMessageIsNotSentSuccesfully()
    {
        sendNewMessage.invalidContact.Should().BeTrue(sendNewMessage.newMessage.ToString() + " is not a valid contact");
    }

}
