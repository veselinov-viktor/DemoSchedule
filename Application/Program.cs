// See https://aka.ms/new-console-template for more information
using Application;
using Quartz;
using Quartz.Impl;

internal class Program
{
    private static async Task Main(string[] args)
    {
        var dataStorageService = DataStorageService.GetInstance();
        StdSchedulerFactory factory = new StdSchedulerFactory();
        IScheduler scheduler = await factory.GetScheduler();
        var myJobListener = new OptimizationListener();

        string url = Console.ReadLine();

        while (url != "End!")
        {
            if (!dataStorageService.ContainsKey(url))
            {
                scheduler.ListenerManager.AddJobListener(myJobListener);
                scheduler.Start();
                IJobDetail job = JobBuilder.Create<ApiCallJob>()
                    .UsingJobData("url", url)
                    .WithIdentity($"{Guid.NewGuid()}", "group1") // name "myJob", group "group1"
                    .Build();

                // Trigger the job to run now, and then every 40 seconds
                ITrigger trigger = TriggerBuilder.Create()
                    .WithIdentity($"{Guid.NewGuid()}", "group1")
                    .StartNow()
                    .Build();

                // Tell quartz to schedule the job using our trigger
                await scheduler.ScheduleJob(job, trigger);
            }
            else
            {
                Console.WriteLine(dataStorageService[url]);
            }
            url = Console.ReadLine();
        }
        Console.WriteLine();
    }
}