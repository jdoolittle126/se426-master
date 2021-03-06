//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

// 
// This source code was auto-generated by Microsoft.VSDesigner, Version 4.0.30319.42000.
// 
#pragma warning disable 1591

namespace w2_group_activity_1.PhoneWebService {
    using System;
    using System.Web.Services;
    using System.Diagnostics;
    using System.Web.Services.Protocols;
    using System.Xml.Serialization;
    using System.ComponentModel;
    
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.8.4084.0")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Web.Services.WebServiceBindingAttribute(Name="PhoneVerifySoap", Namespace="http://ws.cdyne.com/PhoneVerify/query")]
    public partial class PhoneVerify : System.Web.Services.Protocols.SoapHttpClientProtocol {
        
        private System.Threading.SendOrPostCallback CheckPhoneNumberOperationCompleted;
        
        private System.Threading.SendOrPostCallback CheckPhoneNumbersOperationCompleted;
        
        private bool useDefaultCredentialsSetExplicitly;
        
        /// <remarks/>
        public PhoneVerify() {
            this.Url = global::w2_group_activity_1.Properties.Settings.Default.w2_group_activity_1_PhoneWebService_PhoneVerify;
            if ((this.IsLocalFileSystemWebService(this.Url) == true)) {
                this.UseDefaultCredentials = true;
                this.useDefaultCredentialsSetExplicitly = false;
            }
            else {
                this.useDefaultCredentialsSetExplicitly = true;
            }
        }
        
        public new string Url {
            get {
                return base.Url;
            }
            set {
                if ((((this.IsLocalFileSystemWebService(base.Url) == true) 
                            && (this.useDefaultCredentialsSetExplicitly == false)) 
                            && (this.IsLocalFileSystemWebService(value) == false))) {
                    base.UseDefaultCredentials = false;
                }
                base.Url = value;
            }
        }
        
        public new bool UseDefaultCredentials {
            get {
                return base.UseDefaultCredentials;
            }
            set {
                base.UseDefaultCredentials = value;
                this.useDefaultCredentialsSetExplicitly = true;
            }
        }
        
        /// <remarks/>
        public event CheckPhoneNumberCompletedEventHandler CheckPhoneNumberCompleted;
        
        /// <remarks/>
        public event CheckPhoneNumbersCompletedEventHandler CheckPhoneNumbersCompleted;
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://ws.cdyne.com/PhoneVerify/query/CheckPhoneNumber", RequestNamespace="http://ws.cdyne.com/PhoneVerify/query", ResponseNamespace="http://ws.cdyne.com/PhoneVerify/query", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public PhoneReturn CheckPhoneNumber(string PhoneNumber, string LicenseKey) {
            object[] results = this.Invoke("CheckPhoneNumber", new object[] {
                        PhoneNumber,
                        LicenseKey});
            return ((PhoneReturn)(results[0]));
        }
        
        /// <remarks/>
        public void CheckPhoneNumberAsync(string PhoneNumber, string LicenseKey) {
            this.CheckPhoneNumberAsync(PhoneNumber, LicenseKey, null);
        }
        
        /// <remarks/>
        public void CheckPhoneNumberAsync(string PhoneNumber, string LicenseKey, object userState) {
            if ((this.CheckPhoneNumberOperationCompleted == null)) {
                this.CheckPhoneNumberOperationCompleted = new System.Threading.SendOrPostCallback(this.OnCheckPhoneNumberOperationCompleted);
            }
            this.InvokeAsync("CheckPhoneNumber", new object[] {
                        PhoneNumber,
                        LicenseKey}, this.CheckPhoneNumberOperationCompleted, userState);
        }
        
        private void OnCheckPhoneNumberOperationCompleted(object arg) {
            if ((this.CheckPhoneNumberCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.CheckPhoneNumberCompleted(this, new CheckPhoneNumberCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://ws.cdyne.com/PhoneVerify/query/CheckPhoneNumbers", RequestNamespace="http://ws.cdyne.com/PhoneVerify/query", ResponseNamespace="http://ws.cdyne.com/PhoneVerify/query", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        [return: System.Xml.Serialization.XmlArrayItemAttribute(IsNullable=false)]
        public PhoneReturn[] CheckPhoneNumbers(string[] PhoneNumbers, string LicenseKey) {
            object[] results = this.Invoke("CheckPhoneNumbers", new object[] {
                        PhoneNumbers,
                        LicenseKey});
            return ((PhoneReturn[])(results[0]));
        }
        
        /// <remarks/>
        public void CheckPhoneNumbersAsync(string[] PhoneNumbers, string LicenseKey) {
            this.CheckPhoneNumbersAsync(PhoneNumbers, LicenseKey, null);
        }
        
        /// <remarks/>
        public void CheckPhoneNumbersAsync(string[] PhoneNumbers, string LicenseKey, object userState) {
            if ((this.CheckPhoneNumbersOperationCompleted == null)) {
                this.CheckPhoneNumbersOperationCompleted = new System.Threading.SendOrPostCallback(this.OnCheckPhoneNumbersOperationCompleted);
            }
            this.InvokeAsync("CheckPhoneNumbers", new object[] {
                        PhoneNumbers,
                        LicenseKey}, this.CheckPhoneNumbersOperationCompleted, userState);
        }
        
        private void OnCheckPhoneNumbersOperationCompleted(object arg) {
            if ((this.CheckPhoneNumbersCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.CheckPhoneNumbersCompleted(this, new CheckPhoneNumbersCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        public new void CancelAsync(object userState) {
            base.CancelAsync(userState);
        }
        
        private bool IsLocalFileSystemWebService(string url) {
            if (((url == null) 
                        || (url == string.Empty))) {
                return false;
            }
            System.Uri wsUri = new System.Uri(url);
            if (((wsUri.Port >= 1024) 
                        && (string.Compare(wsUri.Host, "localHost", System.StringComparison.OrdinalIgnoreCase) == 0))) {
                return true;
            }
            return false;
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.8.4084.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://ws.cdyne.com/PhoneVerify/query")]
    public partial class PhoneReturn {
        
        private string companyField;
        
        private bool validField;
        
        private string useField;
        
        private string stateField;
        
        private string switchField;
        
        private string rcField;
        
        private string oCNField;
        
        private string originalNumberField;
        
        private string cleanNumberField;
        
        private string switchNameField;
        
        private string switchTypeField;
        
        private string countryField;
        
        private string cLLIField;
        
        private string prefixTypeField;
        
        private string lATAField;
        
        private string smsField;
        
        private string emailField;
        
        private string assignDateField;
        
        private string telecomCityField;
        
        private string telecomCountyField;
        
        private string telecomStateField;
        
        private string telecomZipField;
        
        private string timeZoneField;
        
        private string latField;
        
        private string longField;
        
        private bool wirelessField;
        
        private string lRNField;
        
        /// <remarks/>
        public string Company {
            get {
                return this.companyField;
            }
            set {
                this.companyField = value;
            }
        }
        
        /// <remarks/>
        public bool Valid {
            get {
                return this.validField;
            }
            set {
                this.validField = value;
            }
        }
        
        /// <remarks/>
        public string Use {
            get {
                return this.useField;
            }
            set {
                this.useField = value;
            }
        }
        
        /// <remarks/>
        public string State {
            get {
                return this.stateField;
            }
            set {
                this.stateField = value;
            }
        }
        
        /// <remarks/>
        public string Switch {
            get {
                return this.switchField;
            }
            set {
                this.switchField = value;
            }
        }
        
        /// <remarks/>
        public string RC {
            get {
                return this.rcField;
            }
            set {
                this.rcField = value;
            }
        }
        
        /// <remarks/>
        public string OCN {
            get {
                return this.oCNField;
            }
            set {
                this.oCNField = value;
            }
        }
        
        /// <remarks/>
        public string OriginalNumber {
            get {
                return this.originalNumberField;
            }
            set {
                this.originalNumberField = value;
            }
        }
        
        /// <remarks/>
        public string CleanNumber {
            get {
                return this.cleanNumberField;
            }
            set {
                this.cleanNumberField = value;
            }
        }
        
        /// <remarks/>
        public string SwitchName {
            get {
                return this.switchNameField;
            }
            set {
                this.switchNameField = value;
            }
        }
        
        /// <remarks/>
        public string SwitchType {
            get {
                return this.switchTypeField;
            }
            set {
                this.switchTypeField = value;
            }
        }
        
        /// <remarks/>
        public string Country {
            get {
                return this.countryField;
            }
            set {
                this.countryField = value;
            }
        }
        
        /// <remarks/>
        public string CLLI {
            get {
                return this.cLLIField;
            }
            set {
                this.cLLIField = value;
            }
        }
        
        /// <remarks/>
        public string PrefixType {
            get {
                return this.prefixTypeField;
            }
            set {
                this.prefixTypeField = value;
            }
        }
        
        /// <remarks/>
        public string LATA {
            get {
                return this.lATAField;
            }
            set {
                this.lATAField = value;
            }
        }
        
        /// <remarks/>
        public string sms {
            get {
                return this.smsField;
            }
            set {
                this.smsField = value;
            }
        }
        
        /// <remarks/>
        public string Email {
            get {
                return this.emailField;
            }
            set {
                this.emailField = value;
            }
        }
        
        /// <remarks/>
        public string AssignDate {
            get {
                return this.assignDateField;
            }
            set {
                this.assignDateField = value;
            }
        }
        
        /// <remarks/>
        public string TelecomCity {
            get {
                return this.telecomCityField;
            }
            set {
                this.telecomCityField = value;
            }
        }
        
        /// <remarks/>
        public string TelecomCounty {
            get {
                return this.telecomCountyField;
            }
            set {
                this.telecomCountyField = value;
            }
        }
        
        /// <remarks/>
        public string TelecomState {
            get {
                return this.telecomStateField;
            }
            set {
                this.telecomStateField = value;
            }
        }
        
        /// <remarks/>
        public string TelecomZip {
            get {
                return this.telecomZipField;
            }
            set {
                this.telecomZipField = value;
            }
        }
        
        /// <remarks/>
        public string TimeZone {
            get {
                return this.timeZoneField;
            }
            set {
                this.timeZoneField = value;
            }
        }
        
        /// <remarks/>
        public string Lat {
            get {
                return this.latField;
            }
            set {
                this.latField = value;
            }
        }
        
        /// <remarks/>
        public string Long {
            get {
                return this.longField;
            }
            set {
                this.longField = value;
            }
        }
        
        /// <remarks/>
        public bool Wireless {
            get {
                return this.wirelessField;
            }
            set {
                this.wirelessField = value;
            }
        }
        
        /// <remarks/>
        public string LRN {
            get {
                return this.lRNField;
            }
            set {
                this.lRNField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.8.4084.0")]
    public delegate void CheckPhoneNumberCompletedEventHandler(object sender, CheckPhoneNumberCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.8.4084.0")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class CheckPhoneNumberCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal CheckPhoneNumberCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public PhoneReturn Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((PhoneReturn)(this.results[0]));
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.8.4084.0")]
    public delegate void CheckPhoneNumbersCompletedEventHandler(object sender, CheckPhoneNumbersCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.8.4084.0")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class CheckPhoneNumbersCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal CheckPhoneNumbersCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public PhoneReturn[] Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((PhoneReturn[])(this.results[0]));
            }
        }
    }
}

#pragma warning restore 1591