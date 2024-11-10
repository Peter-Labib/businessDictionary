namespace businessDictionary.Client.Pages
{
    public partial class TagModal
    {
        private bool IsModalVisible = false;

        // Show the modal
        private void ShowModal() => IsModalVisible = true;

        // Hide the modal
        private void HideModal() => IsModalVisible = false;
    }
}
