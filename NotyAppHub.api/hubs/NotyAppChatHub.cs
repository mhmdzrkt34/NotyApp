using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;

using NotyAppHub.api.models;
using RestSharp;
using Newtonsoft.Json;

namespace NotyAppHub.api.hubs
{
    [Authorize]
    public sealed class NotyAppChatHub:Hub
    {


        public async override Task OnConnectedAsync()
        {

            /*Console.WriteLine($"{Context.ConnectionId} is connected");
            Console.WriteLine($"Identifier:{Context.UserIdentifier} is connected");*/
            
        }

        public async override Task OnDisconnectedAsync(Exception? exception)
        {
            /*Console.WriteLine($"{Context.ConnectionId} is dissconnected");

            Console.WriteLine($"Identifier:{Context.UserIdentifier} is dissconnected");*/
        }


        public async Task<IActionResult> SendMessage(MessageRequest request)
        {
            var token = Context.GetHttpContext().Request.Headers["Authorization"].ToString();
            Console.WriteLine(token);

            var client = new RestClient("https://localhost:7115/User");


            var req = new RestRequest("/sendMessage", Method.Post);
            req.AddHeader("Authorization", token);




            var body = new
            {

                type = request.type,
                message = request.message,
                sender_id = Context.UserIdentifier,
                reciever_id = request.reciever_id
            };
            req.AddJsonBody(body);

            RestResponse response = await client.ExecuteAsync(req);
            Console.WriteLine(response.Content);

            Message message= JsonConvert.DeserializeObject<Message>(response.Content);




  


            await Clients.User(message.reciever_id).SendAsync("recieved", message);

            return new JsonResult(new
            {
                message

            });

          

        }


    }
}

