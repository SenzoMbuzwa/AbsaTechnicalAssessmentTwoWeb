namespace AbsaTechAssessmentOne
{
    [TestClass]
    public class UnitTest1
    {
        // Create a RestSharp client
        RestClient client = new RestClient("https://dog.ceo/api");

        [TestMethod]
        public void ListAllDogBreeds()
        {
            // Create a RestRequest for the specific endpoint
            RestRequest request = new RestRequest("breeds/list/all", Method.Get);

            // Execute the request
            RestResponse response = client.Execute(request);

            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                string responseBody = response.Content;
                // Parse the JSON response and extract the list of dog breeds here
                Console.WriteLine(responseBody);
            }
            else
            {
                Assert.Fail("Failed to retrieve the list of dog breeds. Status code: " + response.StatusCode);
            }
        }

        [TestMethod]
        public void VerifyIfBreedIsWithinLIst()
        {
            string breed = "retriever";

            // Create a RestRequest for the specific endpoint
            RestRequest request = new RestRequest("breeds/list/all", Method.Get);

            // Send the request and retrieve the response
            RestResponse response = client.Execute(request);

            // Check if the request was successful (status code 200)
            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                // Parse the JSON response
                string jsonResponse = response.Content;

                // Use a JSON parser to deserialize the JSON response
                // and check if the breed is in the list of breeds
                BreedList breedList = Newtonsoft.Json.JsonConvert.DeserializeObject<BreedList>(jsonResponse);

                if (breedList.message.ContainsKey(breed))
                {
                    Console.WriteLine($"The {breed} breed is in the list of dog breeds.");
                }
                else
                {
                    Assert.Fail($"The {breed} breed is not in the list of dog breeds.");
                }
            }
            else
            {
                Assert.Fail($"Failed to retrieve data from the API. Status code : {response.StatusCode}");
            }
        }

        [TestMethod]
        public void ListSubBreeds()
        {
            string breed = "retriever";

            // Create a RestRequest for the specific endpoint
            RestRequest request = new RestRequest($"breed/{breed}/list", Method.Get);

            // Execute the request and get the response
            var response = client.Execute(request);

            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                // Parse the response content as JSON
                string responseContent = response.Content;

                // Deserialize the JSON to a class or use dynamic
                dynamic responseData = Newtonsoft.Json.JsonConvert.DeserializeObject(responseContent);

                // Access the sub-breeds
                var subBreeds = responseData.message;

                Console.WriteLine($"Sub-breeds of {breed} :");
                foreach (var subBreed in subBreeds)
                {
                    Console.WriteLine(subBreed);
                }
            }
            else
            {
                Assert.Fail("Failed to retrieve data. Status code : " + response.StatusCode);
            }
        }


        [TestMethod]
        public void RandomImageLink()
        {
            string subBreed = "golden";

            // Define the resource and parameters for the request
            var request = new RestRequest("breeds/image/random", Method.Get);
            request.AddParameter("sub-breed", subBreed);

            // Execute the request
            RestResponse response = client.Execute(request);

            if (response.IsSuccessful)
            {
                // Parse the JSON response to get the image URL
                DogApiResponse dogApiResponse = Newtonsoft.Json.JsonConvert.DeserializeObject<DogApiResponse>(response.Content);

                if (dogApiResponse != null)
                {
                    string imageUrl = dogApiResponse.message;
                    Console.WriteLine("Random image URL : " + imageUrl);
                }
                else
                {
                    Assert.Fail("Failed to parse the API response.");
                }
            }
            else
            {
                Assert.Fail("Failed to fetch the image. Status code : " + response.StatusCode);
            }
        }


        public class BreedList
        {
            public Dictionary<string, List<string>> message { get; set; }
        }

        class DogApiResponse
        {
            public string message { get; set; }
        }
    }
}