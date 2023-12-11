using MassTransit;
using Newtonsoft.Json;
using SuperLandscapes_Blog.WebUI.Models;

namespace SuperLandscapes_Blog.WebUI.Consumers
{
    public class BlogConsumer : IConsumer<OrderCreated>
    {

        public async Task Consume(ConsumeContext<OrderCreated> context)
        {
            var jsonMessage = JsonConvert.SerializeObject(context.Message);
            Console.WriteLine($"OrderCreated message: {jsonMessage}");
        }
    }
}
