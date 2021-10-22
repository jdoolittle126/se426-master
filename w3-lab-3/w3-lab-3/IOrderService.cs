using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace w3_lab_3
{
    
    [ServiceContract]
    public interface IOrderService
    {

        [OperationContract]
        int GetNumberOfOrders();

        [OperationContract]
        double GetTotalCostForAnOrder(int orderId);

        [OperationContract]
        List<OrderItem> GetItemListForOrder(int orderId);

        [OperationContract]
        int HowManyOrderedForAPartNo(string partNo);

        [OperationContract]
        OrderAddress GetBillingAddressForAnOrder(int orderId);
    }


    [DataContract]
    public class OrderAddress
    {
        [DataMember] 
        public string Name { get; set; }
        [DataMember] 
        public string Address { get; set; }
        [DataMember] 
        public string City { get; set; }
        [DataMember] 
        public string State { get; set; }
        [DataMember] 
        public string Zip { get; set; }
    }

    [DataContract]
    public class CustomerOptions
    {
        [DataMember] 
        public string Size { get; set; }
        [DataMember] 
        public string Color { get; set; }
    }

    [DataContract]
    public class OrderItem
    {
        [DataMember] 
        public string PartNo { get; set; }
        [DataMember] 
        public string Description { get; set; }
        [DataMember] 
        public double UnitPrice { get; set; }
        [DataMember] 
        public int Quantity { get; set; }
        [DataMember] 
        public double TotalCost { get; set; }
        [DataMember] 
        public CustomerOptions Options { get; set; }
    }

}
