using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace w5_midterm_part_2
{
    
    [ServiceContract]
    public interface INeitStoreOrdersService
    {

        [OperationContract]
        int ReturnDoubleOrderId(int orderId);

        [OperationContract]
        Order GetOrder(int orderId);
    }


    public class Order
    {
        [DataMember]
        public int OrderId { get; set; }
        [DataMember]
        public string ShopperAddress { get; set; }
        [DataMember] 
        public string ShopperName { get; set; }
        [DataMember]
        public OrderItem[] Items { get; set; }
    }

    [DataContract]
    public class OrderItem
    {
        [DataMember] 
        public OrderItemOptions Options { get; set; }
        [DataMember] 
        public string Name { get; set; }
        [DataMember] 
        public double Cost { get; set; }
        [DataMember]
        public string Sku { get; set; }
    }

    [DataContract]
    public class OrderItemOptions
    {
        [DataMember]
        public string Color { get; set; }
        [DataMember]
        public string Size { get; set; }
    }

}
