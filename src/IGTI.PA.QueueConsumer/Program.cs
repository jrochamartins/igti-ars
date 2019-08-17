using IGTI.PA.Database;
using IGTI.PA.Database.Impl;
using IGTI.PA.Queue;
using IGTI.PA.QueueConsumer.Handlers;
using IGTI.PA.UseCases;
using IGTI.PA.UseCases.Adapters.Database;
using IGTI.PA.UseCases.Impl;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.ObjectModel;

namespace IGTI.PA.QueueConsumer
{
    public static class Program
    {
        public static IConfiguration Configuration { get; } = new ConfigurationBuilder()
            .AddEnvironmentVariables()
            .Build();

        public static void Main(string[] args)
        {
            Console.WriteLine("[xxx] - PA-ARS: QUEUE CONSUMER - [xxx]");

            // Setup DI
            var serviceProvider = new ServiceCollection()
                .Configure<DatabaseContextOptions>(Configuration)
                .Configure<QueueContextOptions>(Configuration)
                .AddSingleton<DatabaseContext>()
                .AddSingleton<QueueContext>()
                .AddTransient<ProspectRepository, ProspectRepositoryImpl>()
                .BuildServiceProvider();

            // Setup handlers
            var handlers = new Collection<Handler>
            {
                new RegisterModelHandler(serviceProvider),
                new LoginModelHandler(serviceProvider)
            };

            var queueContext = serviceProvider.GetService<QueueContext>();
            var consumer = queueContext.CreateConsumer();
            consumer.Received += (model, ea) =>
            {
                Console.WriteLine("{0}: Received message.", DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss"));
                foreach (var handler in handlers)
                    handler.Handle(ea.Body);
            };
            queueContext.RegisterConsumer(consumer);

            Console.ReadLine();
            queueContext.Dispose();
        }
    }
}
