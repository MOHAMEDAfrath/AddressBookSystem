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
            //connects with the local host url
            client = new RestClient("http://localhost:4000");
        }
        public IRestResponse Retrieve()
        {
            RestRequest request = new RestRequest("/contacts", Method.GET);
            IRestResponse response = client.Execute(request);
            return response;
        }
        //retrieval
        [TestMethod]
        public void Retrieval_Test()
        {
            IRestResponse response = Retrieve();
            //deserialize from JSON to list of new member type
            List<NewMember> list = JsonConvert.DeserializeObject<List<NewMember>>(response.Content);
            Assert.AreEqual(4, list.Count);
            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
            foreach (var mem in list)
                System.Console.WriteLine(mem.firstname + " " + mem.lastname + " " + mem.emailId+" "+mem.phonenumber+" "+mem.Address+" "+mem.State);
        }
        //add data to json server
        public void add(JsonObject jsonObject)
        {
            //opens the server with post method
            RestRequest request = new RestRequest("/contacts", Method.POST);
            request.AddParameter("application/json", jsonObject, ParameterType.RequestBody);
            IRestResponse response = client.Execute(request);

        }
        //add multiple data to json server
        [TestMethod]
        public void TestMethod_ToTest_MultipleInsertion()
        {
            List<JsonObject> list = new List<JsonObject>();
            JsonObject jsonObject = new JsonObject();
            jsonObject.Add("firstname", "Priya");
            jsonObject.Add("lastname", "Devi");
            jsonObject.Add("emailId", "priyadevi@gmail.com");
            jsonObject.Add("Phonenumber", "7784841454");
            jsonObject.Add("Address","Thirunelveli");
            jsonObject.Add("State", "TamilNadu");
            list.Add(jsonObject);
            JsonObject jsonObject1 = new JsonObject();
            jsonObject1.Add("firstname", "Ramya");
            jsonObject1.Add("lastname", "Devika");
            jsonObject1.Add("emailId", "ramyapriyadevi@gmail.com");
            jsonObject1.Add("Phonenumber", "7784541454");
            jsonObject1.Add("Address", "Menod");
            jsonObject1.Add("State", "Karnataka");
            list.Add(jsonObject1);
            foreach (var mem in list)
                add(mem);
            //retrieve to check the count after insertion
            IRestResponse response = Retrieve();
            List<NewMember> result = JsonConvert.DeserializeObject<List<NewMember>>(response.Content);
            Assert.AreEqual(6, result.Count);
            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);

        }
    }
}
