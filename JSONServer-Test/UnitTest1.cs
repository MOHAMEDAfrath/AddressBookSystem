using AddressBookSystem;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using RestSharp;
using System.Collections.Generic;
using System.Net;

namespace JSONServer_Test
{
    [TestClass]
    public class UnitTest1
    {
        RestClient client;
        [TestInitialize]
        public void SetUp()
        {
            client = new RestClient("http://localhost:4000");
        }
        public IRestResponse Retrieve()
        {
            RestRequest request = new RestRequest("/contacts", Method.GET);
            IRestResponse response = client.Execute(request);
            return response;
        }
        [TestMethod]
        public void Retrieval_Test()
        {
            IRestResponse response = Retrieve();
            List<NewMember> list = JsonConvert.DeserializeObject<List<NewMember>>(response.Content);
            Assert.AreEqual(4, list.Count);
            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
            foreach (var mem in list)
                System.Console.WriteLine(mem.firstname + " " + mem.lastname + " " + mem.emailId+" "+mem.phonenumber+" "+mem.Address+" "+mem.State);
        }
    }
}
