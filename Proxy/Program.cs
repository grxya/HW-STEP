using Proxy;
using Proxy.Enum;
using Proxy.Entities.Classes;

User user = new User("grxya", ConfidentialityLevel.Internal);
Document document = new Document("Secret Document", ConfidentialityLevel.Confidential);

user.OpenDocument(document); Console.WriteLine();
user.OpenDocument(new DocumentProxy(document)); Console.WriteLine();

document.Confidentiality = ConfidentialityLevel.Public;
user.OpenDocument(new DocumentProxy(document));