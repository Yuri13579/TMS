using Azure.Messaging.ServiceBus;
using System;  
using System.Text;  
using System.Threading.Tasks;  
using Microsoft.AspNetCore.Mvc;  
using Microsoft.Extensions.Configuration;  
using Newtonsoft.Json;
using Microsoft.Azure.ServiceBus;
using TMS.Model;
using TMS.Model.DTO;
using TaskStatus = TMS.Model.TaskStatus;

namespace TMS.Service.Impl
{
    public class ServiceBusSender : IServiceBusSender
    {
        string queueConnectionString = Environment.GetEnvironmentVariable("queueConnectionString");
        
        public Task<List<Model.Task>> Get(Model.Task task)
        {
            throw new NotImplementedException();
        }

        //IQueueClient queueClient = new QueueClient(_configuration["QueueConnectionString"], _configuration["QueueName"]);
        public async System.Threading.Tasks.Task Send(Model.Task task)
        {
            IQueueClient queueClient = new QueueClient(queueConnectionString, AppConst.QueueName);  
            var orderJSON = JsonConvert.SerializeObject(task);  
            var orderMessage = new Message(Encoding.UTF8.GetBytes(orderJSON))  
            {  
                MessageId = Guid.NewGuid().ToString(),  
                ContentType = "application/json"  
            };  
            await queueClient.SendAsync(orderMessage).ConfigureAwait(false);  
        }



    }
}
