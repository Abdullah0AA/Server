using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server
{
    public class InvalidRequestHandler : IRequestHandler
    {
        string response;

        public string GetResponse()
        {
            return response;
        }

        public void HandleRequest(string request)
        {
            // Handle Request 
        }

        public string ResponseToClient()
        {
            // Respond
            return response;
        }
        public void SetResponse(string response)
        {
            this.response = response;
        }

    }
}
