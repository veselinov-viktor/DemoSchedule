using Quartz;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application
{
    internal class OptimizationListener : IJobListener
    {
        public string Name => "MyJoBlisterner";

        public Task JobExecutionVetoed(IJobExecutionContext context, CancellationToken cancellationToken = default)
        {
            return Task.CompletedTask;
        }

        public Task JobToBeExecuted(IJobExecutionContext context, CancellationToken cancellationToken = default)
        {
            return Task.CompletedTask;

        }

        public Task JobWasExecuted(IJobExecutionContext context, JobExecutionException? jobException, CancellationToken cancellationToken = default)
        {

            var dataStorageService = DataStorageService.GetInstance();
            var jobDataMap = context.JobDetail.JobDataMap;
            var url = jobDataMap.GetString("url");
            dataStorageService.Add(url, $"Cached version of page with url: {url}");
            return Task.CompletedTask;
        }
    }
}
