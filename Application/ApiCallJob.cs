using Quartz;
using RestSharp;

namespace Application
{
    public class ApiCallJob : IJob
    {
        public async Task Execute(IJobExecutionContext context)
        {
            JobDataMap jobDataMap = context.JobDetail.JobDataMap;
            var url = jobDataMap.GetString("url");
            var client = new RestClient(@"https://petstore.swagger.io/v2");
            var getPet = new RestRequest($"/pet/{1}");
            getPet.AddHeader("api_key", "viktor");
            Thread.Sleep(20000);
            await client.GetAsync(getPet);
        }
    }
}
