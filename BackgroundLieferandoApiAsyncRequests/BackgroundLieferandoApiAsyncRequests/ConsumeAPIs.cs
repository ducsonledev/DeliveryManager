using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Net;
using System.Text;

namespace BackgroundLieferandoApiAsyncRequests
{
    public class ConsumeAPIs
    {
        //public class Order
        //{
        //    [JsonProperty("id")]
        //    public string Id { get; set; }
        //    [JsonProperty("key")]
        //    public string Key { get; set; }
        //}
        //  

        // Model for JSON from Server API
        public class ownCustomer
        {
            public string customerName { get; set; }
            public string customerCompany { get; set; }
            public string customerPostCode { get; set; }
            public string customerCity { get; set; }
            public string customerAddress { get; set; }
            public string customerTaxCode { get; set; }
            public string customerPhone { get; set; }
            public string customerMail { get; set; }
            public string customerCode { get; set; }
            public string customerType { get; set; }
            public int id { get; set; }
        }

        public class OwnProduct
        {
            public string status { get; set; }
            public string categoryDesc { get; set; }
            public string categoryName { get; set; }
            public string secondPrintAt { get; set; }
            public string productType { get; set; }
            public string productName { get; set; }
            public int productId { get; set; }
            public string groupName { get; set; }
            public string productArticalNumber { get; set; }
            public string printAt { get; set; }
            public int tableId { get; set; }
            public int signatureCount { get; set; }
            public int orderId { get; set; }
            public int categoryId { get; set; }
            public int groupId { get; set; }
            public int index { get; set; }
            public bool isLine { get; set; }
            public int editIndex { get; set; }
            public double productPrice { get; set; }
            public double discountRate { get; set; }
            public int quantity { get; set; }
            public double discount { get; set; }
            public int makedKitchen { get; set; }
            public int numCus { get; set; }
            public int border { get; set; }
            public double money { get; set; }
            public int tablePos { get; set; }
            public double tax { get; set; }
            public double taxRate { get; set; }
            public double totalDiscount { get; set; }
            public double totalMoney { get; set; }
            public double totalTax { get; set; }
            public int transferToKitchen { get; set; }
            public int allowChangeTax { get; set; }
        }

        public class OwnProductOrders
        {
            public OwnProductOrders()
            {
                listOwnProductOrders = new List<OwnProduct>();
            }
            public List<OwnProduct> listOwnProductOrders { get; set; }
        }

        public class Zdata
        {
            public ownCustomer customer { get; set; }
            public OwnProductOrders listProductOrders { get; set; }
            public string waiter { get; set; }
        }

        public class OwnOrders
        {
            public string action { get; set; }
            public string signature { get; set; }
            public string time { get; set; }
            public string user { get; set; }
            public Zdata zdata { get; set; }
        }

        // Model for JSON from Lieferando API
        public class SideDish
        {
            public int price { get; set; }
            public string name { get; set; }
            public int count { get; set; }
            public string id { get; set; }
        }

        public class Product
        {
            public Product()
            {
                sideDishes = new List<SideDish>();
            }
            public double price { get; set; }
            public string name { get; set; }
            public int count { get; set; }
            public string remark { get; set; }
            public string id { get; set; }
            public string category { get; set; }
            public List<SideDish> sideDishes { get; set; }
        }

        public class Discount
        {
            public double price { get; set; }
            public string name { get; set; }
            public int count { get; set; }
        }

        public class Customer
        {
            public string phoneNumber { get; set; }
            public string streetNumber { get; set; }
            public string city { get; set; }
            public string street { get; set; }
            public string companyName { get; set; }
            public string postalCode { get; set; }
            public string name { get; set; }
            public string extraAddressInfo { get; set; }
        }

        public class Order
        {
            public Order()
            {
                products = new List<Product>();
                discounts = new List<Discount>();
            }
            public string orderKey { get; set; }
            public object requestedDeliveryTime { get; set; } // object, because can be empty, flagged by Lieferando as "ASAP"
            public string orderType { get; set; }
            public double totalPrice { get; set; }
            public string remark { get; set; }
            public string restaurantId { get; set; }
            public string version { get; set; }
            public string platform { get; set; }
            public List<Product> products { get; set; }
            public bool isPaid { get; set; }
            public int deliveryCosts { get; set; }
            public List<Discount> discounts { get; set; }
            public string publicReference { get; set; }
            public string courier { get; set; }
            public double totalDiscount { get; set; }
            public string paymentMethod { get; set; }
            public string id { get; set; }
            public DateTime orderDate { get; set; }
            public Customer customer { get; set; }
        }

        public class LieferandoOrders
        {
            public LieferandoOrders()
            {
                orders = new List<Order>();
            }
            [JsonProperty("orders")]
            public List<Order> orders { get; set; }
        }

        //public class OrdersList
        //{
        //    [JsonProperty("orders")]
        //    public string List<Order> Orders { get; set; }
        //}

        // TOOD: JSON Model for status updates
        public class LieferandoStatusUpdates
        {
            public string id { get; set; }
            public string status { get; set; }
            public string key { get; set; }
            public string changedDeliveryTime { get; set; }
            public string text { get; set; }
        }

        public static LieferandoOrders LieferandoRequest(string restaurantId, string apikey, string username, string password) // later parameter int restaurantId
        {
            var byteArray = Encoding.ASCII.GetBytes(username + ":" + password); // "test-username-123:test-password-123" only for sandbox api
            var clientGet = new RestClient("https://sandbox-pull-posapi.takeaway.com/1.0/orders/" + restaurantId); // test id 1234567// TODO later: Replace with https://posapi.takeaway.com/1.0/orders/<RestaurantId>
            //clientGet.Timeout = -1;
            var requestGetOrd = new RestRequest(Method.GET);
            requestGetOrd.AddHeader("content-type", "application/json");
            requestGetOrd.AddHeader("Apikey", apikey); // "abc123"
            requestGetOrd.AddHeader("Authorization", "Basic " + Convert.ToBase64String(byteArray));

            //IRestResponse responseGet = clientGet.Execute(requestGetOrd); // Currently ERROR STATUS CODE 530 // uncomment for re-testing
            //if (responseGet.StatusCode != HttpStatusCode.OK) return null; // TODO case: change if response content can be null not empty {}

            string json;
            // Sorry for hardcoded path, it's just for testing purposes for now, since https://sandbox-pull-posapi.takeaway.com as of now is currently not available.
            // I contacted Lieferando-Support regarding that problem, I hope, they resolve that soon.
            // Get Request are Status Code 530 right now which does not give orders.
            using (StreamReader r = new StreamReader("../../LieferandoSandboxOrders.json")) // in DUBUG MODE ../../ because we end up in bin/Debug/ 
            {
                json = r.ReadToEnd();
            }

            var newLieferandoOrders = JsonConvert.DeserializeObject<LieferandoOrders>(json); // json // responseGet.Content // Currently ERROR STATUS CODE 530

            return newLieferandoOrders;
        }

        // Post OwnOrders to our server api
        public static IRestResponse PostOwnOrders(LieferandoOrders LieferandoOrders)
        {
            //var clientPost = new RestClient("<server-base-adresse>:13000"); 
            var clientPost = new RestClient("https://sandbox-pull-posapi.takeaway.com/1.0/orders/1234567"); // temp test adress // TODO later: Please add server adresse with Port 13000.
            var requestPostOrd = new RestRequest(Method.POST);
            IRestResponse responsePost = null;
            // TODO: filter, change parameter in function to single order that is checked if new
            // sending orders seperately for now
            var ownOrders = LieferandoOrders.ToOwnOrder();
            foreach (var ownOrder in ownOrders)
            {
                var newOwnOrder = JsonConvert.SerializeObject(ownOrder, Formatting.Indented);
                responsePost = clientPost.Execute(requestPostOrd.AddJsonBody(newOwnOrder));
            }
            return responsePost;
        }

        // Post status updates to Lieferando.
        public static bool PostStatusUpdate(LieferandoStatusUpdates newStatusUpdate)
        {
            var clientPost = new RestClient("https://posapi.takeaway.com/1.0/status");
            var requestPostOrd = new RestRequest(Method.POST);
            IRestResponse responsePost = null;
            // TODO: filter, change parameter in function to single order that is checked if new
            // sending orders seperately for now
            
            responsePost = clientPost.Execute(
                requestPostOrd.AddJsonBody(JsonConvert.SerializeObject(newStatusUpdate, Formatting.Indented)));

            return responsePost.StatusCode == HttpStatusCode.OK;
        }
    }
}
