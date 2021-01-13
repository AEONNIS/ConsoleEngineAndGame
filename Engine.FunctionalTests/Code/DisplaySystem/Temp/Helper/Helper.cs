namespace Engine.FunctionalTests.DisplaySystem
{
    public class Helper
    {
        public void Run()
        {
            InitialMessages();
        }

        private void InitialMessages()
        {
            HelperData.Messages.Keys.Enter.Write();
            HelperData.Messages.InputConfirmation.Write(before: " - ", after: " ");
            HelperData.Messages.Keys.Backspace.Write();
            HelperData.Messages.DeleteChar.WriteLine(before: " - ", after: "\n");
            HelperData.Messages.Initial.WriteLine();
        }
    }
}
