using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Text;

namespace BackgroundLieferandoApiAsyncRequests
{
    public class LieferandoApiRequester
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
        public class newCustomer
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
            public List<OwnProduct> listOwnProductOrders { get; set; }
        }

        public class Zdata
        {
            public newCustomer customer { get; set; }
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
            public string orderKey { get; set; }
            public object requestedDeliveryTime { get; set; }
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
            public List<Order> orders { get; set; }
        }

        //public class OrdersList
        //{
        //    [JsonProperty("orders")]
        //    public string List<Order> Orders { get; set; }
        //}

        public static List<OwnOrders> LieferandoRequest (string username, string password) // later parameter int restaurantId
        {
            var byteArray = Encoding.ASCII.GetBytes(username + ":" + password); // test-username-123:test-password-123 only for sandbox api
            var clientGet = new RestClient("https://sandbox-pull-posapi.takeaway.com/1.0/orders/1234567"); // TODO later: Replace with https://posapi.takeaway.com/1.0/orders/<RestaurantId>
            //clientGet.Timeout = -1;
            var requestGetOrd = new RestRequest(Method.GET);
            requestGetOrd.AddHeader("content-type", "application/json");
            requestGetOrd.AddHeader("Apikey", "abc123");
            requestGetOrd.AddHeader("Authorization", "Basic " + Convert.ToBase64String(byteArray));

            //var clientPost = new RestClient("<server-base-adresse>:13000"); 
            //var clientPost = new RestClient("https://sandbox-pull-posapi.takeaway.com/1.0/orders/1234567"); // TODO later: Please add server adresse with Port 13000.
            //var requestPostOrd = new RestRequest(Method.POST);
         
            IRestResponse responseGet = clientGet.Execute(requestGetOrd);

            var newLieferandoOrders = JsonConvert.DeserializeObject<LieferandoOrders>(responseGet.Content);
            var ownOrders = newLieferandoOrders.ToOwnOrder();

            // sending orders seperately for now
            //foreach (var ownOrder in ownOrders)
            //{
            //    var newOwnOrder = JsonConvert.SerializeObject(ownOrder, Formatting.Indented);
            //    IRestResponse responsePost = clientPost.Execute(requestPostOrd.AddJsonBody(newOwnOrder));
            //    Console.WriteLine(responsePost.Content);
            //}

            return ownOrders;
        }

        //static void Main(string[] args)
        //{
            
        //}
    }
}
