using FirebaseAdmin;
using FirebaseAdmin.Messaging;
using Google.Apis.Auth.OAuth2;

namespace LottGameApi.Service
{
    public class FirebaseService
    {
        List<string> registrationTokens = new List<string>(); //Lista dos tokens que vão receber a mensagem

        public void StartSdk()
        {
            FirebaseApp.Create(new AppOptions()
            {
                Credential = GoogleCredential.FromFile("tokenPath"),
            });
        }

        public void RegisterTokens() { } //Implementar logica para registrar os tokens

        public async Task<BatchResponse> SendMessageAsync(string message)
        {
            
            var messageDict = new Dictionary<string, string>()
            {
                {"Message", message }
            };

            var multicastMessage = new MulticastMessage
            {
                Tokens = registrationTokens,
                Data = messageDict,
            };

            return await FirebaseMessaging.DefaultInstance.SendMulticastAsync(multicastMessage);
        }
    }
}
