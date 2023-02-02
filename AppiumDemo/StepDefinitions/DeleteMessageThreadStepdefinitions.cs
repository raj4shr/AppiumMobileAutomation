

namespace AppiumDemo;

[Binding]
public class DeleteMessageThreadStepdefinitions
{
    DeleteMessageThread deleteMessageThread;

    public DeleteMessageThreadStepdefinitions()
    {
        deleteMessageThread = new DeleteMessageThread();
    }


    [When(@"clicks on delete")]
    public void WhenClicksOnDelete()
    {
        deleteMessageThread.ClickOnDeleteBtn();
    }

    [When(@"clicks on more opens")]
    public void WhenClicksOnMoreOpens()
    {
        deleteMessageThread.ClickOnMoreOptions();
    }


    [Then(@"The message thread should be deleted successfully")]
    public void ThenTheMessageThreadShouldBeDeletedSuccessfully()
    {
        deleteMessageThread.ConfirmDelete();
    }


    [When(@"User clicks on the '([^']*)' message thread")]
    public void WhenUserClicksOnTheMessageThread(string contact)
    {
        deleteMessageThread.GetAllMessageThreads();
        deleteMessageThread.ClickOnContact(contact);
    }
}
