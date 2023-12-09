using Proxy.Entities.Interfaces;
using Proxy.Enum;
using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proxy
{
    class User
    {
        public string UserName { get; set; }
        public ConfidentialityLevel AccessType { get; set; }

        public User(string userName, ConfidentialityLevel accessType)
        {
            UserName = userName;
            AccessType = accessType;
        }

        public void OpenDocument(IDocument document)
        {
            document.OpenDocument(this);
        }
    }
}
