﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace w3_lab_3_client.ServiceReference1 {
    using System.Runtime.Serialization;
    using System;
    
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="Order", Namespace="http://schemas.datacontract.org/2004/07/w5_midterm_part_2")]
    [System.SerializableAttribute()]
    public partial class Order : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private w3_lab_3_client.ServiceReference1.OrderItem[] ItemsField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int OrderIdField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string ShopperAddressField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string ShopperNameField;
        
        [global::System.ComponentModel.BrowsableAttribute(false)]
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData {
            get {
                return this.extensionDataField;
            }
            set {
                this.extensionDataField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public w3_lab_3_client.ServiceReference1.OrderItem[] Items {
            get {
                return this.ItemsField;
            }
            set {
                if ((object.ReferenceEquals(this.ItemsField, value) != true)) {
                    this.ItemsField = value;
                    this.RaisePropertyChanged("Items");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int OrderId {
            get {
                return this.OrderIdField;
            }
            set {
                if ((this.OrderIdField.Equals(value) != true)) {
                    this.OrderIdField = value;
                    this.RaisePropertyChanged("OrderId");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string ShopperAddress {
            get {
                return this.ShopperAddressField;
            }
            set {
                if ((object.ReferenceEquals(this.ShopperAddressField, value) != true)) {
                    this.ShopperAddressField = value;
                    this.RaisePropertyChanged("ShopperAddress");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string ShopperName {
            get {
                return this.ShopperNameField;
            }
            set {
                if ((object.ReferenceEquals(this.ShopperNameField, value) != true)) {
                    this.ShopperNameField = value;
                    this.RaisePropertyChanged("ShopperName");
                }
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="OrderItem", Namespace="http://schemas.datacontract.org/2004/07/w5_midterm_part_2")]
    [System.SerializableAttribute()]
    public partial class OrderItem : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private double CostField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string NameField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private w3_lab_3_client.ServiceReference1.OrderItemOptions OptionsField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string SkuField;
        
        [global::System.ComponentModel.BrowsableAttribute(false)]
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData {
            get {
                return this.extensionDataField;
            }
            set {
                this.extensionDataField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public double Cost {
            get {
                return this.CostField;
            }
            set {
                if ((this.CostField.Equals(value) != true)) {
                    this.CostField = value;
                    this.RaisePropertyChanged("Cost");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Name {
            get {
                return this.NameField;
            }
            set {
                if ((object.ReferenceEquals(this.NameField, value) != true)) {
                    this.NameField = value;
                    this.RaisePropertyChanged("Name");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public w3_lab_3_client.ServiceReference1.OrderItemOptions Options {
            get {
                return this.OptionsField;
            }
            set {
                if ((object.ReferenceEquals(this.OptionsField, value) != true)) {
                    this.OptionsField = value;
                    this.RaisePropertyChanged("Options");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Sku {
            get {
                return this.SkuField;
            }
            set {
                if ((object.ReferenceEquals(this.SkuField, value) != true)) {
                    this.SkuField = value;
                    this.RaisePropertyChanged("Sku");
                }
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="OrderItemOptions", Namespace="http://schemas.datacontract.org/2004/07/w5_midterm_part_2")]
    [System.SerializableAttribute()]
    public partial class OrderItemOptions : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string ColorField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string SizeField;
        
        [global::System.ComponentModel.BrowsableAttribute(false)]
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData {
            get {
                return this.extensionDataField;
            }
            set {
                this.extensionDataField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Color {
            get {
                return this.ColorField;
            }
            set {
                if ((object.ReferenceEquals(this.ColorField, value) != true)) {
                    this.ColorField = value;
                    this.RaisePropertyChanged("Color");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Size {
            get {
                return this.SizeField;
            }
            set {
                if ((object.ReferenceEquals(this.SizeField, value) != true)) {
                    this.SizeField = value;
                    this.RaisePropertyChanged("Size");
                }
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="ServiceReference1.INeitStoreOrdersService")]
    public interface INeitStoreOrdersService {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/INeitStoreOrdersService/ReturnDoubleOrderId", ReplyAction="http://tempuri.org/INeitStoreOrdersService/ReturnDoubleOrderIdResponse")]
        int ReturnDoubleOrderId(int orderId);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/INeitStoreOrdersService/ReturnDoubleOrderId", ReplyAction="http://tempuri.org/INeitStoreOrdersService/ReturnDoubleOrderIdResponse")]
        System.Threading.Tasks.Task<int> ReturnDoubleOrderIdAsync(int orderId);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/INeitStoreOrdersService/GetOrder", ReplyAction="http://tempuri.org/INeitStoreOrdersService/GetOrderResponse")]
        w3_lab_3_client.ServiceReference1.Order GetOrder(int orderId);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/INeitStoreOrdersService/GetOrder", ReplyAction="http://tempuri.org/INeitStoreOrdersService/GetOrderResponse")]
        System.Threading.Tasks.Task<w3_lab_3_client.ServiceReference1.Order> GetOrderAsync(int orderId);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface INeitStoreOrdersServiceChannel : w3_lab_3_client.ServiceReference1.INeitStoreOrdersService, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class NeitStoreOrdersServiceClient : System.ServiceModel.ClientBase<w3_lab_3_client.ServiceReference1.INeitStoreOrdersService>, w3_lab_3_client.ServiceReference1.INeitStoreOrdersService {
        
        public NeitStoreOrdersServiceClient() {
        }
        
        public NeitStoreOrdersServiceClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public NeitStoreOrdersServiceClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public NeitStoreOrdersServiceClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public NeitStoreOrdersServiceClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public int ReturnDoubleOrderId(int orderId) {
            return base.Channel.ReturnDoubleOrderId(orderId);
        }
        
        public System.Threading.Tasks.Task<int> ReturnDoubleOrderIdAsync(int orderId) {
            return base.Channel.ReturnDoubleOrderIdAsync(orderId);
        }
        
        public w3_lab_3_client.ServiceReference1.Order GetOrder(int orderId) {
            return base.Channel.GetOrder(orderId);
        }
        
        public System.Threading.Tasks.Task<w3_lab_3_client.ServiceReference1.Order> GetOrderAsync(int orderId) {
            return base.Channel.GetOrderAsync(orderId);
        }
    }
}
