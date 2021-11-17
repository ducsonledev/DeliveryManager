using System.Collections.Generic;
using static BackgroundLieferandoApiAsyncRequests.LieferandoApiRequester;
// TODO: import app settings to fill out rest of the missing properties

namespace BackgroundLieferandoApiAsyncRequests
{
    public static class OrdersExtension
    {
        // Extension method for converting Lieferando's json string format for their orders
        // to a format for our server.
        public static List<OwnOrders> ToOwnOrder(this LieferandoOrders lieferandoOrders)
        {
            List<OwnOrders> listOfOwnOrders = new List<OwnOrders>();
            foreach (var order in lieferandoOrders.orders)
            {
                var listOfproducts = new OwnProductOrders();
                int productIdx = 1;
                foreach (var product in order.products)
                {
                    // ids cannot be null
                    int.TryParse(product.id, out int LieferandoProductId);
                    int.TryParse(order.id, out int LieferandoOrderId);
                    var newProduct = new OwnProduct
                    {
                        status = "INPROGRESS", // what are other status in our API? TODO: status updates to Lieferando API?
                        categoryDesc = product.category,
                        categoryName = product.category,
                        secondPrintAt = Properties.Settings.Default.secondPrintAt, // TODO: depending on category 
                        productType = "PRODUCT", // always "PRODUCT"
                        productName = product.name,
                        productId = LieferandoProductId,
                        groupName = "Küche", // always "Küche"
                        productArticalNumber = product.id, // same as product id
                        printAt = Properties.Settings.Default.PrintAt, // TODO: from config depending on category 
                        tableId = 0, // always 0
                        signatureCount = 0, // always 0
                        orderId = LieferandoOrderId, //0//int.Parse(order.id),
                        categoryId = Properties.Settings.Default.CategoryId, // TODO: from config depending on category
                        groupId = 1, // always 1
                        index = productIdx++, // incremental from 1 to n, suffix +1 after each order
                        isLine = false, // always false
                        editIndex = 0, // always 0
                        productPrice = product.price,
                        discountRate = 0.0, // always 0.0 until we have some
                        quantity = product.count,
                        discount = 0.0, // always 0.0 until we have some
                        makedKitchen = 0, // always 0
                        numCus = 1, // always 1
                        border = 0, // always 0
                        money = product.price,
                        tablePos = 0, // always 0
                        tax = Properties.Settings.Default.Tax, // TODO: from config depending on product id
                                                               // if product id in database == product.id
                        taxRate = Properties.Settings.Default.TaxRate, // TODO: from config file depend of product id
                        totalDiscount = 0.0, // always 0.0 until we have some
                        totalMoney = product.price,
                        totalTax = product.count * Properties.Settings.Default.Tax, // =quantity*tax (tax, TODO: from config depending on product id)
                                                                                    // if product id in database == product.id 
                        transferToKitchen = 0, // always 0
                        allowChangeTax = Properties.Settings.Default.AllowChangeTax, // TODO: from config file depend of product id
                        // missing information provided by Lieferando API that is not used in our API:
                        // - (not mandatory) sideDishes (and its id), remark
                    };
                    listOfproducts.listOwnProductOrders.Add(newProduct);
                }

                var newOrder = new OwnOrders
                {
                    action = "automaticOrder", // not provided
                    signature = order.orderKey,
                    time = "26/10/2021 21:15:40", // TODO: convert time format
                    user = "1",
                    zdata = new Zdata
                    {
                        customer = new ownCustomer
                        {
                            customerName = order.customer.name,
                            customerCompany = order.customer.companyName,
                            customerPhone = order.customer.phoneNumber,
                            customerCode = order.customer.postalCode,
                            customerCity = order.customer.city,
                            customerAddress = order.customer.street,
                            customerMail = "tungnm.ptit@gmail.com", // not provided
                            customerType = "ECONOMIC", // not provided
                            id = 1
                            // missing information provided by Lieferando API that is not used in our API:
                            // - (not mandatory) extraAddressInfo
                        },
                        listProductOrders = listOfproducts,
                        waiter = "1" // not provided
                    },
                    // missing information provided by Lieferando API that is not used in for our API:
                    // - (not mandatory) remark
                };
                listOfOwnOrders.Add(newOrder);
            }


            return listOfOwnOrders;
        }
    }
}
