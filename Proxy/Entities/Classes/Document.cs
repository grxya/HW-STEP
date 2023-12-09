using Proxy.Entities.Interfaces;
using Proxy.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proxy.Entities.Classes
{
    class Document : IDocument
    {
        public string Title { get; set; }
        public ConfidentialityLevel Confidentiality { get; set; }

        public Document(string title, ConfidentialityLevel confidentiality)
        {
            Title = title;
            Confidentiality = confidentiality;
        }

        public void OpenDocument(User user)
        {
            Console.WriteLine($"Document '{Title}' is opened");
        }
    }
}
