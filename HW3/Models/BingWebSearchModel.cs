using Newtonsoft.Json;

namespace HW3.Models;

public class BingWebSearchModel
{
    [JsonProperty("request")]
    public Request Request { get; set; }

    [JsonProperty("data")]
    public WebData Data { get; set; }

    [JsonProperty("in_seconds")]
    public float InSeconds { get; set; }
}

public class WebData
{
    [JsonProperty("items")]
    public List<Item> Items { get; set; }

    [JsonProperty("keyword_related")]
    public List<string> KeywordRelated { get; set; }

    [JsonProperty("question")]
    public List<object> Question { get; set; }
}

public class Item
{
    [JsonProperty("title")]
    public string Title { get; set; }

    [JsonProperty("link")]
    public string Link { get; set; }

    [JsonProperty("description")]
    public string Description { get; set; }
}
