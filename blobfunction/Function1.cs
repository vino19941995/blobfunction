using System;
using System.IO;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.Extensions.Logging;

namespace blobfunction
{
    public static class Function1
    {
        [FunctionName("Function1")]
        public static void Run([BlobTrigger("dev/{name}", Connection = "AzureWebJobsStorage")]Stream myBlob,string BlobTrigger, string name, ILogger log)
        {
            StreamReader reader = new StreamReader(myBlob);
            log.LogInformation($"C# Blob trigger function Processed blob\n Name:{name} \n Size: {myBlob.Length} Bytes \n Content:{reader.ReadToEnd()}");
        }
    }
}
