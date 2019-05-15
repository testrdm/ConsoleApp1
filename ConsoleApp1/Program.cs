using System;
using System.Collections.Generic;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Blob;

namespace ConsoleApp1
{
    class Program
    {
        static async System.Threading.Tasks.Task Main(string[] args)
        {
            string storageConnectionString = "DefaultEndpointsProtocol=https;AccountName=strrdm;AccountKey=jykbgp7GhLpHiqZIMtstB+tTLx+EtfELlrOHhPbNV4PUHDySga97Rv/jK68v9mSrFx6INL/jVFJpzv51uyWvqQ==;EndpointSuffix=core.windows.net";
            CloudStorageAccount storageAccount;
            if (CloudStorageAccount.TryParse(storageConnectionString, out storageAccount))
            {// Create the CloudBlobClient that represents the Blob storage endpoint for the storage account.
                CloudBlobClient cbc= storageAccount.CreateCloudBlobClient();
                var conroot =cbc.GetRootContainerReference();
                Console.WriteLine(conroot.Name);
                BlobContinuationToken token = null;
                var listcon = new List<CloudBlobContainer>();
                do {
                    var respon = await cbc.ListContainersSegmentedAsync(token);
                    listcon.AddRange(respon.Results);
                    token = respon.ContinuationToken;
                   
                        } while (token != null);
                foreach(var c in listcon)
                {
                    Console.WriteLine(c.Name);
                }
                Console.WriteLine(listcon.Count);
              
                                }
        }
    }
}
