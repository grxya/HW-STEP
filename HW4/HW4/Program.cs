using RestSharp;

#region GET

RestClient restClient = new("http://localhost:5222");

RestRequest restRequest = new("getallsellers");

var restResponse = await restClient.ExecuteAsync(restRequest);
Console.WriteLine(restResponse.Content);

////

HttpClient httpClient = new(){BaseAddress = new("http://localhost:5222")};

HttpRequestMessage httpMessage = new(HttpMethod.Get, "getproductlists");

var httpResponse = await httpClient.SendAsync(httpMessage);
Console.WriteLine(await httpResponse.Content.ReadAsStringAsync());

#endregion


#region POST

restRequest = new("addnewuser", Method.Post);

Dictionary<string, string> headers = new();

Console.WriteLine("Enter username: ");
headers.Add("username", Console.ReadLine());
Console.WriteLine("Enter password: ");
headers.Add("password", Console.ReadLine());
Console.WriteLine("Enter email: ");
headers.Add("email", Console.ReadLine());

restRequest.AddHeaders(headers);

restResponse = await restClient.ExecuteAsync(restRequest);
Console.WriteLine(restResponse.Content);

////

httpMessage = new(HttpMethod.Post, "addnewcolor");

Console.WriteLine("Enter color name: ");
httpMessage.Headers.Add("color", Console.ReadLine());

httpResponse = await httpClient.SendAsync(httpMessage);
Console.WriteLine(await httpResponse.Content.ReadAsStringAsync());

#endregion


#region PUT

restRequest = new("changeusername", Method.Put);

Console.WriteLine("Enter current username: ");
restRequest.AddHeader("currentUsername", Console.ReadLine());
Console.WriteLine("Enter new username: ");
restRequest.AddHeader("newUsername", Console.ReadLine());

restResponse = await restClient.ExecuteAsync(restRequest);
Console.WriteLine(restResponse.Content);

////

httpMessage = new(HttpMethod.Put, "changecompanynamenumber");

Console.WriteLine("Enter company name: ");
httpMessage.Headers.Add("currentName", Console.ReadLine());
Console.WriteLine("Enter new company name: ");
httpMessage.Headers.Add("newName", Console.ReadLine());
Console.WriteLine("Enter new contact number: ");
httpMessage.Headers.Add("newnumber", Console.ReadLine());

httpResponse = await httpClient.SendAsync(httpMessage);
Console.WriteLine(await httpResponse.Content.ReadAsStringAsync());

#endregion


#region DELETE

restRequest = new("deleteproduct", Method.Delete);

Console.WriteLine("Enter id of product: ");
restRequest.AddHeader("id", Console.ReadLine());

restResponse = await restClient.ExecuteAsync(restRequest);
Console.WriteLine(restResponse.Content);

////

httpMessage = new(HttpMethod.Delete, "deleteuser");

Console.WriteLine("Enter username: ");
httpMessage.Headers.Add("username", Console.ReadLine());

httpResponse = await httpClient.SendAsync(httpMessage);
Console.WriteLine(await httpResponse.Content.ReadAsStringAsync());

#endregion