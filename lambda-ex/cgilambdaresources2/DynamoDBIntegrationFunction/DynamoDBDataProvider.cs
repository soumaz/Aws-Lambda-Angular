using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

using Amazon.Lambda.Core;
using Amazon.Lambda.APIGatewayEvents;
using Amazon.DynamoDBv2;
using Amazon.DynamoDBv2.Model;
using Newtonsoft.Json;
using Amazon.Runtime;

[assembly: LambdaSerializer(typeof(Amazon.Lambda.Serialization.Json.JsonSerializer))]

namespace DynamoDBIntegrationFunction
{
    public class DynamoDBDataProvider
    {
        public async Task<APIGatewayProxyResponse> GetAsync(APIGatewayProxyRequest request, ILambdaContext context)
        {
            context.Logger.LogLine("Get Request\n");

            var response = new APIGatewayProxyResponse
            {
                StatusCode = (int)HttpStatusCode.OK,
                Body = await ScanReadingListAsync(),
                Headers = new Dictionary<string, string> { { "Content-Type", "text/plain" } }
            };

            return response;
        }

        private async Task<string> ScanReadingListAsync()
        {
            var readingListJson = default(string);

            //var awsCreds = new BasicAWSCredentials("AKIAJ4N5T4GYXQCU4Z3A", "x4q2NzfcGmgxm0Npk2aFxzhNPFXNziE8QGJhnWCM");
            using (var client = new AmazonDynamoDBClient(Amazon.RegionEndpoint.APSoutheast1))
            {
                var response = await client.ScanAsync(new ScanRequest("readingList"));

                readingListJson = JsonConvert.SerializeObject(response.Items);
            }

            return readingListJson;
        }
    }
}
