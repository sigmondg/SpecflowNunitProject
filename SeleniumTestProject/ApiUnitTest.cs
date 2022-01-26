using Newtonsoft.Json;
using NUnit.Framework;
using RestSharp;
using RiverTestTestProject;
using System;
using System.Net;
using System.Threading.Tasks;

namespace SeleniumTestProject
{
    class Tests
    {
        private const string base_url = "https://petstore.swagger.io/v2";
        RestClient client;

        [SetUp]
        public void Setup()
        {
            client = new RestClient(base_url);
        }

        [Test]
        public async Task createAUser()
        {
            RestRequest request = new RestRequest("/user", Method.Post);

            
            request.AddJsonBody(new
            {
                id= 1,
                username = "sigmondgatt",
                firstName = "sigmond",
                lastName = "gatt",
                email = "gattsigmond@gmail.com",
                password= "1234",
                phone =  "12345678",
                userStatus = 0
            });
            
            RestResponse response = await client.ExecuteAsync(request);
            Assert.IsTrue(response.IsSuccessful);
          
        }
        
        [Test]
        public async Task getAValidUserAndValidateData()
        {
            RestRequest request = new RestRequest("/user/sigmondgatt", Method.Get);

            await createAUser();

            RestResponse response = await client.ExecuteAsync(request);
            ApiResProperty data = JsonConvert.DeserializeObject<ApiResProperty>(response.Content);
            Assert.AreEqual(1,data.Id);
            Assert.AreEqual("sigmondgatt", data.Username);
            Assert.AreEqual("sigmond", data.FirstName);
            Assert.AreEqual("gatt", data.LastName);
            Assert.AreEqual("gattsigmond@gmail.com",data.Email);
            Assert.AreEqual("1234", data.Password);
            Assert.AreEqual("12345678", data.Phone);
            Assert.AreEqual(0, data.UserStatus);
            
        }

        [Test]
        public async Task updateAUser()
        { 
            
            RestRequest request = new RestRequest("/user/sigmondgatt", Method.Put);
            request.AddJsonBody(new
            {
                id = 1,
                username = "sigmondgatt",
                firstName = "sigmond",
                lastName = "testingSurname",
                email = "gattsigmond@gmail.com",
                password = "1234",
                phone = "12345678",
                userStatus = 0
            });

            RestResponse response = await client.ExecuteAsync(request);
            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);

        }

        [Test]
        public async Task validateUpdatedUser() 
        {
            
            await updateAUser();
            
            RestRequest request = new RestRequest("/user/sigmondgatt", Method.Get);

            RestResponse response = await client.ExecuteAsync(request);
            ApiResProperty data = JsonConvert.DeserializeObject<ApiResProperty>(response.Content);
            Assert.AreEqual("testingSurname", data.LastName);


        }
        [Test]
        public async Task getAnInvalidUser()
        {
            RestRequest request = new RestRequest("/user/abcdefg", Method.Get);
            RestResponse response = await client.ExecuteAsync(request);
            Assert.AreEqual(HttpStatusCode.NotFound, response.StatusCode);

        }

        [Test]
        public async Task deleteValidUsername() 
        {
            RestRequest request = new RestRequest("/user/sigmondgatt", Method.Delete);
            RestResponse response = await client.ExecuteAsync(request);
            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
        }

        [Test]
        public async Task deleteInvalidUsername()
        {
            RestRequest request = new RestRequest("/user/abcdefg", Method.Delete);
            RestResponse response = await client.ExecuteAsync(request);
            Assert.AreEqual(HttpStatusCode.NotFound, response.StatusCode);
        }

        [Test]
        public async Task loginWithValidCredentials()
        {
            await createAUser();
            RestRequest request = new RestRequest("/user/login?username=sigmondgatt&password=1234'", Method.Get);
            RestResponse response = await client.ExecuteAsync(request);
            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);

        }

        //could not test invalid credentials as the api will log everyone in ,regardless the credentials

        [Test]
        public async Task logoutWithValidCredentials()
        {

            await loginWithValidCredentials();
            RestRequest request = new RestRequest("/user/logout?username=sigmondgatt&password=1234'", Method.Get);
            RestResponse response = await client.ExecuteAsync(request);
            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);

        }

        [Test]
        public async Task TestUrlWithInvalidPath()
        {
            RestRequest request = new RestRequest("/urers/1", Method.Get);
            RestResponse response = await client.ExecuteAsync(request);
            Console.WriteLine(response.IsSuccessful);
            Assert.IsFalse(response.IsSuccessful);
        }

        [TearDown]
        public void cleanUp()
        {
            client.Dispose();

        }
    }
}