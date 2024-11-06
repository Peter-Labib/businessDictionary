
using Microsoft.AspNetCore.Components;
using static System.Net.WebRequestMethods;

namespace businessDictionary.Components.Pages.Dictionary
{
    public partial class Dictionary
    {
        //private DictionaryResponse? dictionaryData;
        //private bool isLoading = true;
        //private string? errorMessage;
        //[Inject]
        //public required HttpClient HttpClient { get; set; }
        //protected override async Task OnInitializedAsync()
        //{
        //    try
        //    {
        //        // Example of adding parameters to the endpoint URL
        //        var pageIndex = 1;
        //        var pageSize = 10;

        //        string requestUrl = $"Sbusinessdictionary?pageIndex={pageIndex}&pageSize={pageSize}";

        //        // Send GET request to the endpoint
        //        dictionaryData = await HttpClient.GetFromJsonAsync<DictionaryResponse>(requestUrl);

        //        isLoading = false; // Set loading to false once data is loaded
        //    }
        //    catch (Exception ex)
        //    {
        //        // Handle any errors that occur during the request
        //        errorMessage = $"Error fetching data: {ex.Message}";
        //        isLoading = false;
        //    }
        //}
    }
    internal class DictionaryItem
    {
        public string Id { get; set; }
        public string Definition { get; set; }
        public string Name { get; set; }
        public bool LogEditsToHistory { get; set; }
        public bool DefinitionEffectiveFromEnabled { get; set; }
        public DateTime? EffectiveDate { get; set; }
        public DateTime? LastUpdateDate { get; set; }
        public object Labels { get; set; }
        public object History { get; set; }
        public object RelatedEntities { get; set; }
    }
    internal class DictionaryResponse
    {
        public int CurrentPageIndex { get; set; }
        public int CurrentPageSize { get; set; }
        public List<DictionaryItem> Items { get; set; }
        public int RequestedPageSize { get; set; }
        public int TotalCount { get; set; }
    }
}