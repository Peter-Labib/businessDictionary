namespace businessDictionary.Dto
{
    public class DictionaryItem
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
    public class DictionaryResponse
    {
        public int CurrentPageIndex { get; set; }
        public int CurrentPageSize { get; set; }
        public List<DictionaryItem> Items { get; set; }
        public int RequestedPageSize { get; set; }
        public int TotalCount { get; set; }
    }
}
