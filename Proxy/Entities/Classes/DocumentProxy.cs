using Proxy.Entities.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proxy.Entities.Classes
{
    class DocumentProxy : IDocument
    {
        private Document _document;

        public DocumentProxy(Document document)
        {
            _document = document;
        }

        public void OpenDocument(User user)
        {
            Console.WriteLine("Checking access...");

            if (user.AccessType >= _document.Confidentiality) 
            { 
                _document.OpenDocument(user);
            }
            else
            {
                Console.WriteLine("Access denied due to confidentiality level of the document");
            }
        }
    }
}
