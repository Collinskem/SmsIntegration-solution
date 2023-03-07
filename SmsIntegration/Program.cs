using Newtonsoft.Json;
using RestSharp;
using System.Net.Http.Headers;
using System.Text.Json.Serialization;
using static Program;

class Program
{
    static void Main(string[] args)
    {
        var baseURl = "https://89qzx3.api.infobip.com/sms/2/text/advanced";
        //string API_KEY = "aa750532ddb18d9a304f89fe92144ca9-85459541-11e3-428b-8019-9455f9cd23a9";
       
        var client = new RestClient(baseURl);        
        var request = new RestRequest();
        request.Method = Method.Post;


        List<Destination> destinations = new List<Destination>();
        Destination contact = new Destination();
        contact.to = "254708733460";
        destinations.Add(contact);
        List<Messages> messages = new List<Messages>();
        Messages message = new Messages();
        message.destinations = destinations;
        message.from = "InfoSMS";
        message.text = "When the code works it feels so awesome";
        messages.Add(message);
        RootModel sms = new RootModel();
        sms.messages = messages;
        var result = JsonConvert.SerializeObject(sms);

        request.AddHeader("Authorization", "App aa750532ddb18d9a304f89fe92144ca9-85459541-11e3-428b-8019-9455f9cd23a9");
        request.AddHeader("Content-Type", "application/json");
        request.AddHeader("Accept", "application/json");
        request.AddParameter("application/json", sms, ParameterType.RequestBody);
        RestResponse response = client.Execute(request);
        Console.WriteLine(response.Content);
    }



    // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse);
    public class Destination
    {
        public string to { get; set; }
    }

    public class Messages
    {
        public List<Destination>? destinations { get; set; }
        public string? from { get; set; }
        public string? text { get; set; }
     }

    public class RootModel
    {
        public List<Messages>? messages { get; set; }
    }
}
