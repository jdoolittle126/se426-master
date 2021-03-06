//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace part3.FootballWebService {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(Namespace="", ConfigurationName="FootballWebService.FootballServiceSoap")]
    public interface FootballServiceSoap {
        
        [System.ServiceModel.OperationContractAttribute(Action="/GetFootballTeam", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        part3.FootballWebService.FootballTeam GetFootballTeam();
        
        [System.ServiceModel.OperationContractAttribute(Action="/GetFootballTeam", ReplyAction="*")]
        System.Threading.Tasks.Task<part3.FootballWebService.FootballTeam> GetFootballTeamAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="/HelloWorld", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        string HelloWorld();
        
        [System.ServiceModel.OperationContractAttribute(Action="/HelloWorld", ReplyAction="*")]
        System.Threading.Tasks.Task<string> HelloWorldAsync();
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.8.4084.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class FootballTeam : object, System.ComponentModel.INotifyPropertyChanged {
        
        private string teamNameField;
        
        private string divisionField;
        
        private Player[] rosterField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=0)]
        public string TeamName {
            get {
                return this.teamNameField;
            }
            set {
                this.teamNameField = value;
                this.RaisePropertyChanged("TeamName");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=1)]
        public string Division {
            get {
                return this.divisionField;
            }
            set {
                this.divisionField = value;
                this.RaisePropertyChanged("Division");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlArrayAttribute(Order=2)]
        [System.Xml.Serialization.XmlArrayItemAttribute(IsNullable=false)]
        public Player[] roster {
            get {
                return this.rosterField;
            }
            set {
                this.rosterField = value;
                this.RaisePropertyChanged("roster");
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
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.8.4084.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class Player : object, System.ComponentModel.INotifyPropertyChanged {
        
        private string nameField;
        
        private string weightField;
        
        private string positionField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=0)]
        public string name {
            get {
                return this.nameField;
            }
            set {
                this.nameField = value;
                this.RaisePropertyChanged("name");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=1)]
        public string weight {
            get {
                return this.weightField;
            }
            set {
                this.weightField = value;
                this.RaisePropertyChanged("weight");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=2)]
        public string position {
            get {
                return this.positionField;
            }
            set {
                this.positionField = value;
                this.RaisePropertyChanged("position");
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
    public interface FootballServiceSoapChannel : part3.FootballWebService.FootballServiceSoap, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class FootballServiceSoapClient : System.ServiceModel.ClientBase<part3.FootballWebService.FootballServiceSoap>, part3.FootballWebService.FootballServiceSoap {
        
        public FootballServiceSoapClient() {
        }
        
        public FootballServiceSoapClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public FootballServiceSoapClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public FootballServiceSoapClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public FootballServiceSoapClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public part3.FootballWebService.FootballTeam GetFootballTeam() {
            return base.Channel.GetFootballTeam();
        }
        
        public System.Threading.Tasks.Task<part3.FootballWebService.FootballTeam> GetFootballTeamAsync() {
            return base.Channel.GetFootballTeamAsync();
        }
        
        public string HelloWorld() {
            return base.Channel.HelloWorld();
        }
        
        public System.Threading.Tasks.Task<string> HelloWorldAsync() {
            return base.Channel.HelloWorldAsync();
        }
    }
}
