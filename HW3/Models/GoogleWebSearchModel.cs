using Newtonsoft.Json;

namespace HW3.Models;

public class GoogleWebSearchModel
{
    [JsonProperty("result")]
    public List<WebResult> Result { get; set; }
}

public class WebResult
{
    [JsonProperty("title")]
    public string Title { get; set; }

    [JsonProperty("image")]
    public string Image { get; set; }

    [JsonProperty("thumbnail")]
    public string Thumbnail { get; set; }

    [JsonProperty("url")]
    public string Url { get; set; }

    [JsonProperty("height")]
    public int Height { get; set; }

    [JsonProperty("width")]
    public int Width { get; set; }

    [JsonProperty("source")]
    public string Source { get; set; }
}
