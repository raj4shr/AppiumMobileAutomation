namespace AppiumDemo;

public class DeleteMessageThread
{
    #region Private variables
    private readonly ElementInteractions elementInteractions;
    private ReadOnlyCollection<AndroidElement>? messageThreads;
    private bool deleted = false;
    #endregion

    #region Element repository for POM
    private readonly By moreOptionsBtn = By.XPath("//android.widget.ImageView[@content-desc='More options']");
    private readonly By deleteBtn = By.XPath("//android.widget.TextView[@text='Delete']");
    private readonly By confirmDeleteBtn = By.XPath("//android.widget.Button[@text='Delete']");
    private readonly By getAllMessageThreadElements = By.XPath("//android.widget.TextView");
    #endregion

    #region Constructor
    public DeleteMessageThread()
    {
        elementInteractions = new ElementInteractions();
    }
    #endregion

    #region Element actions
    //Click on more options button
    public void ClickOnMoreOptions()
    {
        elementInteractions.ClickOnElement(moreOptionsBtn);
    }

    //Click on delete button inside more options
    public void ClickOnDeleteBtn()
    {
        elementInteractions.ClickOnElement(deleteBtn);
    }

    //Clicking on delete in confirm delete window
    public void ConfirmDelete()
    {
        elementInteractions.ClickOnElement(confirmDeleteBtn);
    }

    //Getting all the message threads inside the app
    public void GetAllMessageThreads()
    {
        messageThreads = elementInteractions.GetAllElementsByLocator(getAllMessageThreadElements);
    }
    #endregion

    #region Methods
    //Checking for the contact inside the message thread and clicking on the contact message thread
    public void ClickOnContact(string contact)
    {
        for (int i = 0; i < messageThreads.Count; i++)
        {
            if (messageThreads[i].Text == contact)
            {
                messageThreads[i].Click();
                break;
            }
        }
    }
    #endregion
}
