using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server
{
    public class RequestHandlerB : IRequestHandler
    {
        private string response;

        public string GetResponse()
        {
            return response;
        }

        public void HandleRequest(string request)
        {
            // Handle Request B
        }
        public string ResponseToClient()
        {
            
            return response;
        }
        public void SetResponse(string response)
        {
            this.response = response;
        }

    }
}
