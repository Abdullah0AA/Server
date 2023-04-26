using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server
{
    public interface IRequestHandler
    {
        void HandleRequest(string request);
        string ResponseToClient();
        string GetResponse();
        void SetResponse(string response);
    }
}
