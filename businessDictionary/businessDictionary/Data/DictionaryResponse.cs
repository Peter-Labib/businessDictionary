using System.Reflection.Emit;

public class DictionaryResponse
{
    public Tags tags { get; set; }
    public List<Label> labels { get; set; } = new List<Label>();
}

public class Tags
{
    public int currentPageIndex { get; set; }
    public int currentPageSize { get; set; }
    public List<Item> items { get; set; } = new List<Item>();
    public int requestedPageSize { get; set; }
    public int totalCount { get; set; }
}

public class Item
{
    public Guid id { get; set; }
    public string definition { get; set; }
    public string name { get; set; }
    public bool logEditsToHistory { get; set; }
    public bool definitionEffectiveFromEnabled { get; set; }
    public DateTime? effectiveDate { get; set; }
    public DateTime? lastUpdateDate { get; set; }
    public List<Label> labels { get; set; } = new List<Label>();
}

public class Label
{
    public Guid id { get; set; }
    public string name { get; set; }
    public string color { get; set; }
    public bool isChecked { get; set; }
    public bool isColorPickerOpen { get; set; }
}