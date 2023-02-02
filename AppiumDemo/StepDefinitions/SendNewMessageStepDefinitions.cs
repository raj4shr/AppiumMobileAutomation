namespace AppiumDemo;

[Binding]
public class SendNewMessageStepDefinitions : CommonDriver
{
    private SendNewMessage messages;

    public SendNewMessageStepDefinitions()
    {
        messages = new SendNewMessage();
    }

    [Given(@"Message app is open")]
    public void GivenMessageAppIsOpen()
    {
        messages.OpenMessagesApp();
    }

    [When(@"User clicks on new message")]
    public void WhenUserClicksOnNewMessage()
    {
        messages.NewMessage();
    }
   

    [Then(@"The message is sent succesfully")]
    public void ThenTheMessageIsSentSuccesfully()
    {
        messages.NewMessageSentAssertion().Should().BeTrue();
    }

    [When(@"User selects a '([^']*)'")]
    public void WhenUserSelectsAContact(string contact)
    {
        messages.SelectAContact(contact);
    }


    [When(@"User enters a '([^']*)' and clicks send")]
    public void WhenUserEntersAMessageAndClicksSend(string message)
    {
        messages.NewMessageSent(message);
    }

}