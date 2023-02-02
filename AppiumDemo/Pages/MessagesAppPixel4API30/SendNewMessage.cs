namespace AppiumDemo;

public class SendNewMessage: CommonDriver
{

    private ReadOnlyCollection<AndroidElement>? contactElements, messageElements;
    private string newMessage;
    private string messageNumber;
    private readonly ElementInteractions elementInteractions;
    private ExtentTest? extentTest;

    private readonly By messageAppBtn = By.XPath("//android.widget.TextView[@text='Messages']");
    private readonly By startChatBtn = By.XPath("//android.widget.Button[@text='Start chat']");
    private readonly By contactSearchTextBox = By.XPath("//android.widget.MultiAutoCompleteTextView[contains(@text,'Type a name')]");
    private readonly By textMessageTextBox = By.XPath("//android.widget.EditText[@text='Text message']");
    private readonly By sendMessageBtn = By.XPath("//android.widget.ImageView[@resource-id='com.google.android.apps.messaging:id/send_message_button_icon']");
    private readonly By navigateUpBtn = By.XPath("//android.widget.ImageButton[@content-desc='Navigate up']");
    private readonly By listOfMessages = By.XPath("//android.widget.TextView");
    private readonly By listofMessagesByContact = By.XPath("//android.widget.TextView");

    //Contructor
    public SendNewMessage()
    {
        elementInteractions = new ElementInteractions();
        extentTest = extentReports.CreateTest("Test_NewMessage " + DateTime.Now.ToString("_hhmmss")).Info("Sending a new message");
    }
    //Open messages app
    public void OpenMessagesApp()
    {
        elementInteractions.ClickOnElement(messageAppBtn);
        extentTest.Log(Status.Info, "Message app clicked");
    }

    //Click on new message button
    public void NewMessage()
    {
        elementInteractions.ClickOnElement(startChatBtn);
        extentTest.Log(Status.Info, "New message button clicked");
    }

    //Type a phone number/contact
    public void SelectAContact(string contactName)
    {
        messageNumber = contactName;
        elementInteractions.SendKeysToElement(contactSearchTextBox, contactName + @"\n");
        extentTest.Log(Status.Info, "Selected a contact");
    }

    //Calling compose message and lick send methods
    public void NewMessageSent(string message)
    {
        newMessage = message;
        ComposeNewMessage(message);
        SendMsgBtn();
    }

    //Composing a message
    public void ComposeNewMessage(string message)
    {
        elementInteractions.SendKeysToElement(textMessageTextBox, message);
        extentTest.Log(Status.Info, "New message composed");
    }

    //Clicking on send message button
    public void SendMsgBtn()
    {
        elementInteractions.ClickOnElement(sendMessageBtn);
        extentTest.Log(Status.Info, "Composed message sent");
    }

    //Clicking on navigate up button
    public void ClickNavigateUpButton()
    {
        elementInteractions.ClickOnElement(navigateUpBtn);
        extentTest.Log(Status.Info, "Naviage up button clicked");
    }

    //Getting all the message threads in the app
    public void GetListOfMessages()
    {
        contactElements = elementInteractions.GetAllElementsByLocator(listOfMessages);
        extentTest.Log(Status.Info, "Getting all the message threads in the app");
    }

    //Getting all the messages within a contact
    public void GetListOfMessagesByContact()
    {
        messageElements = messageElements = elementInteractions.GetAllElementsByLocator(listofMessagesByContact);
        extentTest.Log(Status.Info, "Getting all the messages within a contact");
    }

    //Assertion if the new message has been sent
    public bool NewMessageSentAssertion()
    {
        ClickNavigateUpButton();
        GetListOfMessages();
        if (CheckContact(contactElements))
        {
            GetListOfMessagesByContact();
            return CheckNewMessage(messageElements);
        }
        return false;
    }

    //Method to check if a contact exists in the message threads
    public bool CheckContact(ReadOnlyCollection<AndroidElement> elements)
    {
        for (int i = 0; i < elements.Count; i++)
        {
            if (elements[i].Text == messageNumber)
            {
                elements[i].Click();
                return true;
            }
        }
        return false;
    }

    //Method to check if a message exists within the contact message thread
    public bool CheckNewMessage(ReadOnlyCollection<AndroidElement> elements)
    {
        for (int i = 0; i < elements.Count; i++)
        {
            if (elements[i].Text == newMessage)
            {
                extentTest.Log(Status.Pass, "New message has been sent successfully");
                return true;
            }
        }
        return false;
    }

}
