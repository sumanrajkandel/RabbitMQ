// See https://aka.ms/new-console-template for more information
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Text;

Console.WriteLine("== RabbitMQ uses Demo App for Producer ==");
////
///Need to install Earlang
///then install RabitMQ
///Run RabbitMQ locally on browser > login
////
///1. create Exchange : and add
///2. Create Queues by selecting Queues and Streams > add
///3. then both needs to be mapped : to map select the created queue From exchange .... , Routing key ..., then click on Bind

var factory = new ConnectionFactory();
var connection = factory.CreateConnection();

var channel = connection.CreateModel();

//==============Producer Code=====================

for (int i = 0; i < 1000; i++)
{
    string message = "This is sample message - Order" + i;
    var bodyMessage = Encoding.UTF8.GetBytes(message);
    channel.BasicPublish(exchange: "Product Exchange"/*"Amazon fanout exch"*/, routingKey: "ProductRoute", basicProperties: null, body: bodyMessage);
    Console.WriteLine(message);
}

Console.WriteLine("Message Sent!");
Console.ReadLine();





