﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.34014
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ConsoleServiceClient.Service {
    using System.Runtime.Serialization;
    using System;
    
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="CompositeType", Namespace="http://schemas.datacontract.org/2004/07/WcfService")]
    [System.SerializableAttribute()]
    public partial class CompositeType : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private bool BoolValueField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string StringValueField;
        
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
        public bool BoolValue {
            get {
                return this.BoolValueField;
            }
            set {
                if ((this.BoolValueField.Equals(value) != true)) {
                    this.BoolValueField = value;
                    this.RaisePropertyChanged("BoolValue");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string StringValue {
            get {
                return this.StringValueField;
            }
            set {
                if ((object.ReferenceEquals(this.StringValueField, value) != true)) {
                    this.StringValueField = value;
                    this.RaisePropertyChanged("StringValue");
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
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="Service.IService", CallbackContract=typeof(ConsoleServiceClient.Service.IServiceCallback))]
    public interface IService {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService/GetData", ReplyAction="http://tempuri.org/IService/GetDataResponse")]
        string GetData(int value);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService/GetData", ReplyAction="http://tempuri.org/IService/GetDataResponse")]
        System.Threading.Tasks.Task<string> GetDataAsync(int value);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService/GetDataUsingDataContract", ReplyAction="http://tempuri.org/IService/GetDataUsingDataContractResponse")]
        ConsoleServiceClient.Service.CompositeType GetDataUsingDataContract(ConsoleServiceClient.Service.CompositeType composite);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService/GetDataUsingDataContract", ReplyAction="http://tempuri.org/IService/GetDataUsingDataContractResponse")]
        System.Threading.Tasks.Task<ConsoleServiceClient.Service.CompositeType> GetDataUsingDataContractAsync(ConsoleServiceClient.Service.CompositeType composite);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService/GetEnumerableOfInt", ReplyAction="http://tempuri.org/IService/GetEnumerableOfIntResponse")]
        int[] GetEnumerableOfInt();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService/GetEnumerableOfInt", ReplyAction="http://tempuri.org/IService/GetEnumerableOfIntResponse")]
        System.Threading.Tasks.Task<int[]> GetEnumerableOfIntAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService/GetQueryableOfInt", ReplyAction="http://tempuri.org/IService/GetQueryableOfIntResponse")]
        int[] GetQueryableOfInt();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService/GetQueryableOfInt", ReplyAction="http://tempuri.org/IService/GetQueryableOfIntResponse")]
        System.Threading.Tasks.Task<int[]> GetQueryableOfIntAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService/GetCallbackOfInt", ReplyAction="http://tempuri.org/IService/GetCallbackOfIntResponse")]
        void GetCallbackOfInt();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService/GetCallbackOfInt", ReplyAction="http://tempuri.org/IService/GetCallbackOfIntResponse")]
        System.Threading.Tasks.Task GetCallbackOfIntAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService/Connect", ReplyAction="http://tempuri.org/IService/ConnectResponse")]
        void Connect();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService/Connect", ReplyAction="http://tempuri.org/IService/ConnectResponse")]
        System.Threading.Tasks.Task ConnectAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService/GetValue", ReplyAction="http://tempuri.org/IService/GetValueResponse")]
        long GetValue(long key);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService/GetValue", ReplyAction="http://tempuri.org/IService/GetValueResponse")]
        System.Threading.Tasks.Task<long> GetValueAsync(long key);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService/SaveValue", ReplyAction="http://tempuri.org/IService/SaveValueResponse")]
        void SaveValue(long key, long value);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService/SaveValue", ReplyAction="http://tempuri.org/IService/SaveValueResponse")]
        System.Threading.Tasks.Task SaveValueAsync(long key, long value);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IServiceCallback {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService/OnCallback", ReplyAction="http://tempuri.org/IService/OnCallbackResponse")]
        void OnCallback();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService/SendInt", ReplyAction="http://tempuri.org/IService/SendIntResponse")]
        void SendInt(long i);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService/ChangedRecord", ReplyAction="http://tempuri.org/IService/ChangedRecordResponse")]
        void ChangedRecord(long key, long value);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IServiceChannel : ConsoleServiceClient.Service.IService, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class ServiceClient : System.ServiceModel.DuplexClientBase<ConsoleServiceClient.Service.IService>, ConsoleServiceClient.Service.IService {
        
        public ServiceClient(System.ServiceModel.InstanceContext callbackInstance) : 
                base(callbackInstance) {
        }
        
        public ServiceClient(System.ServiceModel.InstanceContext callbackInstance, string endpointConfigurationName) : 
                base(callbackInstance, endpointConfigurationName) {
        }
        
        public ServiceClient(System.ServiceModel.InstanceContext callbackInstance, string endpointConfigurationName, string remoteAddress) : 
                base(callbackInstance, endpointConfigurationName, remoteAddress) {
        }
        
        public ServiceClient(System.ServiceModel.InstanceContext callbackInstance, string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(callbackInstance, endpointConfigurationName, remoteAddress) {
        }
        
        public ServiceClient(System.ServiceModel.InstanceContext callbackInstance, System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(callbackInstance, binding, remoteAddress) {
        }
        
        public string GetData(int value) {
            return base.Channel.GetData(value);
        }
        
        public System.Threading.Tasks.Task<string> GetDataAsync(int value) {
            return base.Channel.GetDataAsync(value);
        }
        
        public ConsoleServiceClient.Service.CompositeType GetDataUsingDataContract(ConsoleServiceClient.Service.CompositeType composite) {
            return base.Channel.GetDataUsingDataContract(composite);
        }
        
        public System.Threading.Tasks.Task<ConsoleServiceClient.Service.CompositeType> GetDataUsingDataContractAsync(ConsoleServiceClient.Service.CompositeType composite) {
            return base.Channel.GetDataUsingDataContractAsync(composite);
        }
        
        public int[] GetEnumerableOfInt() {
            return base.Channel.GetEnumerableOfInt();
        }
        
        public System.Threading.Tasks.Task<int[]> GetEnumerableOfIntAsync() {
            return base.Channel.GetEnumerableOfIntAsync();
        }
        
        public int[] GetQueryableOfInt() {
            return base.Channel.GetQueryableOfInt();
        }
        
        public System.Threading.Tasks.Task<int[]> GetQueryableOfIntAsync() {
            return base.Channel.GetQueryableOfIntAsync();
        }
        
        public void GetCallbackOfInt() {
            base.Channel.GetCallbackOfInt();
        }
        
        public System.Threading.Tasks.Task GetCallbackOfIntAsync() {
            return base.Channel.GetCallbackOfIntAsync();
        }
        
        public void Connect() {
            base.Channel.Connect();
        }
        
        public System.Threading.Tasks.Task ConnectAsync() {
            return base.Channel.ConnectAsync();
        }
        
        public long GetValue(long key) {
            return base.Channel.GetValue(key);
        }
        
        public System.Threading.Tasks.Task<long> GetValueAsync(long key) {
            return base.Channel.GetValueAsync(key);
        }
        
        public void SaveValue(long key, long value) {
            base.Channel.SaveValue(key, value);
        }
        
        public System.Threading.Tasks.Task SaveValueAsync(long key, long value) {
            return base.Channel.SaveValueAsync(key, value);
        }
    }
}