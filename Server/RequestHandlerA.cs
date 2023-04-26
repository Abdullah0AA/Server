namespace Server
{
    public class RequestHandlerA : IRequestHandler
    {

        private string response;

        public void HandleRequest(string request)
        {
            // Handle Request 
        }

        public string ResponseToClient()
        {
            return GetResponse();
        }

        public string GetResponse()
        {
            return response;
        }
        public void SetResponse(string response)
        {
            this.response = response;
        }
    }
}

