using System.Collections.Generic;
using static BackgroundLieferandoApiAsyncRequests.LieferandoApiRequester;

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
                foreach (var product in order.products)
                {
                    var newProduct = new OwnProduct
                    {
                        status = "INPROGRESS", // what are other status?
                        categoryDesc = product.category,
                        categoryName = product.category,
                        secondPrintAt = "EPSON TM-T82 Receipt", // not provided from Lieferando API
                        productType = "PRODUCT", // not provided
                        productName = product.name,
                        productId = 1, //int.Parse(product.id),
                        groupName = "Küche", // not provided
                        productArticalNumber = "1", // not provided
                        printAt = "PRINTKITCHEN", // not provided
                        tableId = 0, // not provided
                        signatureCount = -1, // not provided
                        orderId = 0, //Int32.Parse(order.id),
                        categoryId = 2, // not provided
                        groupId = 1, // not provided
                        index = 0, // not provided
                        isLine = false, // not provided
                        editIndex = 0, // not provided
                        productPrice = product.price,
                        discountRate = 0.0, // only from order.discounts but in an array
                        quantity = product.count,
                        discount = 0.0, // only from order.discounts but in an array
                        makedKitchen = 0, // not provided
                        numCus = 1, // not provided
                        border = 0, // not provided, what is it for?
                        money = product.price,
                        tablePos = 0, // not provided, delivery?
                        tax = 0.23, // not provided
                        taxRate = 0.07, // standard delivery tax
                        totalDiscount = 0.0, // only from as an array from order.discounts which is in fact
                                             // totalDiscount but for full order not just one product
                        totalMoney = product.price, // why so many different price tags?
                        totalTax = 0.23, // not provided
                        transferToKitchen = 0, // not provided
                        allowChangeTax = 1 // not provided
                        // missing information provided by Lieferando API that is not used in for our API:
                        // - (not mandatory) sideDishes (and its id), remark
                    };
                    listOfproducts.listOwnProductOrders = new List<OwnProduct>();
                    listOfproducts.listOwnProductOrders.Add(newProduct);
                }

                var newOrder = new OwnOrders
                {
                    action = "automaticOrder", // not provided
                    signature = order.orderKey,
                    time = "26/10/2021 21:15:40",
                    user = "1",
                    zdata = new Zdata
                    {
                        customer = new newCustomer
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
                            // missing information provided by Lieferando API that is not used in for our API:
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
