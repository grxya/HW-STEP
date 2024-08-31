using Newtonsoft.Json;

namespace HW3.Models;

public class BingImageSearchModel
{
    [JsonProperty("request")]
    public Request Request { get; set; }

    [JsonProperty("data")]
    public ImageData Data { get; set; }

    [JsonProperty("in_seconds")]
    public float InSeconds { get; set; }
}

public class Request
{
    [JsonProperty("keyword")]
    public string Keyword { get; set; }

    [JsonProperty("page")]
    public int Page { get; set; }

    [JsonProperty("size")]
    public int Size { get; set; }
}

public class ImageData
{
    [JsonProperty("images")]
    public List<Image> Images { get; set; }

    [JsonProperty("suggest")]
    public List<Suggest> Suggest { get; set; }
}

public class Image
{
    [JsonProperty("id")]
    public string Id { get; set; }

    [JsonProperty("title")]
    public string Title { get; set; }

    [JsonProperty("purl")]
    public string Purl { get; set; }

    [JsonProperty("murl")]
    public string Murl { get; set; }

    [JsonProperty("turl")]
    public string Turl { get; set; }

    [JsonProperty("md5")]
    public string Md5 { get; set; }

    [JsonProperty("desc")]
    public string Desc { get; set; }
}

public class Suggest
{
    [JsonProperty("title")]
    public string Title { get; set; }

    [JsonProperty("src")]
    public string Src { get; set; }
}
