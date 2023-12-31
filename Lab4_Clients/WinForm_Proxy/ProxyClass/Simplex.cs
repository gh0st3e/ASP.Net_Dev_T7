﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан программой.
//     Исполняемая версия:4.0.30319.42000
//
//     Изменения в этом файле могут привести к неправильной работе и будут потеряны в случае
//     повторной генерации кода.
// </auto-generated>
//------------------------------------------------------------------------------

// 
// This source code was auto-generated by wsdl, Version=4.8.3928.0.
// 
namespace FinReportWebServiceClient.ProxyClass {
    using System;
    using System;
    using System.Web.Services;
    using System.Web.Services.Description;
    using System.Web.Services.Protocols;
    using System.Diagnostics;

    using System.Xml.Serialization;
    using System.ComponentModel;
    
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("wsdl", "4.8.3928.0")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Web.Services.WebServiceBindingAttribute(Name="SimplexSoap", Namespace="http://LDI/")]
    public partial class Simplex : System.Web.Services.Protocols.SoapHttpClientProtocol {
        
        private System.Threading.SendOrPostCallback AddOperationCompleted;
        
        private System.Threading.SendOrPostCallback AddSOperationCompleted;
        
        private System.Threading.SendOrPostCallback ConcatOperationCompleted;
        
        private System.Threading.SendOrPostCallback SumOperationCompleted;
        
        private System.Threading.SendOrPostCallback HelloWorldOperationCompleted;
        
        private System.Threading.SendOrPostCallback GetQueryPageOperationCompleted;
        
        /// <remarks/>
        public Simplex() {
            this.Url = "http://localhost:64630/Simplex.asmx";
        }
        
        /// <remarks/>
        public event AddCompletedEventHandler AddCompleted;
        
        /// <remarks/>
        public event AddSCompletedEventHandler AddSCompleted;
        
        /// <remarks/>
        public event ConcatCompletedEventHandler ConcatCompleted;
        
        /// <remarks/>
        public event SumCompletedEventHandler SumCompleted;
        
        /// <remarks/>
        public event HelloWorldCompletedEventHandler HelloWorldCompleted;
        
        /// <remarks/>
        public event GetQueryPageCompletedEventHandler GetQueryPageCompleted;
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://LDI/Add", RequestNamespace="http://LDI/", ResponseNamespace="http://LDI/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public int Add(int x, int y) {
            object[] results = this.Invoke("Add", new object[] {
                        x,
                        y});
            return ((int)(results[0]));
        }
        
        /// <remarks/>
        public System.IAsyncResult BeginAdd(int x, int y, System.AsyncCallback callback, object asyncState) {
            return this.BeginInvoke("Add", new object[] {
                        x,
                        y}, callback, asyncState);
        }
        
        /// <remarks/>
        public int EndAdd(System.IAsyncResult asyncResult) {
            object[] results = this.EndInvoke(asyncResult);
            return ((int)(results[0]));
        }
        
        /// <remarks/>
        public void AddAsync(int x, int y) {
            this.AddAsync(x, y, null);
        }
        
        /// <remarks/>
        public void AddAsync(int x, int y, object userState) {
            if ((this.AddOperationCompleted == null)) {
                this.AddOperationCompleted = new System.Threading.SendOrPostCallback(this.OnAddOperationCompleted);
            }
            this.InvokeAsync("Add", new object[] {
                        x,
                        y}, this.AddOperationCompleted, userState);
        }
        
        private void OnAddOperationCompleted(object arg) {
            if ((this.AddCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.AddCompleted(this, new AddCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://LDI/AddS", RequestNamespace="http://LDI/", ResponseNamespace="http://LDI/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public string AddS(InputData data) {
            object[] results = this.Invoke("AddS", new object[] {
                        data});
            return ((string)(results[0]));
        }
        
        /// <remarks/>
        public System.IAsyncResult BeginAddS(InputData data, System.AsyncCallback callback, object asyncState) {
            return this.BeginInvoke("AddS", new object[] {
                        data}, callback, asyncState);
        }
        
        /// <remarks/>
        public string EndAddS(System.IAsyncResult asyncResult) {
            object[] results = this.EndInvoke(asyncResult);
            return ((string)(results[0]));
        }
        
        /// <remarks/>
        public void AddSAsync(InputData data) {
            this.AddSAsync(data, null);
        }
        
        /// <remarks/>
        public void AddSAsync(InputData data, object userState) {
            if ((this.AddSOperationCompleted == null)) {
                this.AddSOperationCompleted = new System.Threading.SendOrPostCallback(this.OnAddSOperationCompleted);
            }
            this.InvokeAsync("AddS", new object[] {
                        data}, this.AddSOperationCompleted, userState);
        }
        
        private void OnAddSOperationCompleted(object arg) {
            if ((this.AddSCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.AddSCompleted(this, new AddSCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://LDI/Concat", RequestNamespace="http://LDI/", ResponseNamespace="http://LDI/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public string Concat(string s, double d) {
            object[] results = this.Invoke("Concat", new object[] {
                        s,
                        d});
            return ((string)(results[0]));
        }
        
        /// <remarks/>
        public System.IAsyncResult BeginConcat(string s, double d, System.AsyncCallback callback, object asyncState) {
            return this.BeginInvoke("Concat", new object[] {
                        s,
                        d}, callback, asyncState);
        }
        
        /// <remarks/>
        public string EndConcat(System.IAsyncResult asyncResult) {
            object[] results = this.EndInvoke(asyncResult);
            return ((string)(results[0]));
        }
        
        /// <remarks/>
        public void ConcatAsync(string s, double d) {
            this.ConcatAsync(s, d, null);
        }
        
        /// <remarks/>
        public void ConcatAsync(string s, double d, object userState) {
            if ((this.ConcatOperationCompleted == null)) {
                this.ConcatOperationCompleted = new System.Threading.SendOrPostCallback(this.OnConcatOperationCompleted);
            }
            this.InvokeAsync("Concat", new object[] {
                        s,
                        d}, this.ConcatOperationCompleted, userState);
        }
        
        private void OnConcatOperationCompleted(object arg) {
            if ((this.ConcatCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.ConcatCompleted(this, new ConcatCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://LDI/Sum", RequestNamespace="http://LDI/", ResponseNamespace="http://LDI/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public A Sum(A a1, A a2) {
            object[] results = this.Invoke("Sum", new object[] {
                        a1,
                        a2});
            return ((A)(results[0]));
        }
        
        /// <remarks/>
        public System.IAsyncResult BeginSum(A a1, A a2, System.AsyncCallback callback, object asyncState) {
            return this.BeginInvoke("Sum", new object[] {
                        a1,
                        a2}, callback, asyncState);
        }
        
        /// <remarks/>
        public A EndSum(System.IAsyncResult asyncResult) {
            object[] results = this.EndInvoke(asyncResult);
            return ((A)(results[0]));
        }
        
        /// <remarks/>
        public void SumAsync(A a1, A a2) {
            this.SumAsync(a1, a2, null);
        }
        
        /// <remarks/>
        public void SumAsync(A a1, A a2, object userState) {
            if ((this.SumOperationCompleted == null)) {
                this.SumOperationCompleted = new System.Threading.SendOrPostCallback(this.OnSumOperationCompleted);
            }
            this.InvokeAsync("Sum", new object[] {
                        a1,
                        a2}, this.SumOperationCompleted, userState);
        }
        
        private void OnSumOperationCompleted(object arg) {
            if ((this.SumCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.SumCompleted(this, new SumCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://LDI/HelloWorld", RequestNamespace="http://LDI/", ResponseNamespace="http://LDI/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public string HelloWorld() {
            object[] results = this.Invoke("HelloWorld", new object[0]);
            return ((string)(results[0]));
        }
        
        /// <remarks/>
        public System.IAsyncResult BeginHelloWorld(System.AsyncCallback callback, object asyncState) {
            return this.BeginInvoke("HelloWorld", new object[0], callback, asyncState);
        }
        
        /// <remarks/>
        public string EndHelloWorld(System.IAsyncResult asyncResult) {
            object[] results = this.EndInvoke(asyncResult);
            return ((string)(results[0]));
        }
        
        /// <remarks/>
        public void HelloWorldAsync() {
            this.HelloWorldAsync(null);
        }
        
        /// <remarks/>
        public void HelloWorldAsync(object userState) {
            if ((this.HelloWorldOperationCompleted == null)) {
                this.HelloWorldOperationCompleted = new System.Threading.SendOrPostCallback(this.OnHelloWorldOperationCompleted);
            }
            this.InvokeAsync("HelloWorld", new object[0], this.HelloWorldOperationCompleted, userState);
        }
        
        private void OnHelloWorldOperationCompleted(object arg) {
            if ((this.HelloWorldCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.HelloWorldCompleted(this, new HelloWorldCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://LDI/GetQueryPage", RequestNamespace="http://LDI/", ResponseNamespace="http://LDI/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public string GetQueryPage() {
            object[] results = this.Invoke("GetQueryPage", new object[0]);
            return ((string)(results[0]));
        }
        
        /// <remarks/>
        public System.IAsyncResult BeginGetQueryPage(System.AsyncCallback callback, object asyncState) {
            return this.BeginInvoke("GetQueryPage", new object[0], callback, asyncState);
        }
        
        /// <remarks/>
        public string EndGetQueryPage(System.IAsyncResult asyncResult) {
            object[] results = this.EndInvoke(asyncResult);
            return ((string)(results[0]));
        }
        
        /// <remarks/>
        public void GetQueryPageAsync() {
            this.GetQueryPageAsync(null);
        }
        
        /// <remarks/>
        public void GetQueryPageAsync(object userState) {
            if ((this.GetQueryPageOperationCompleted == null)) {
                this.GetQueryPageOperationCompleted = new System.Threading.SendOrPostCallback(this.OnGetQueryPageOperationCompleted);
            }
            this.InvokeAsync("GetQueryPage", new object[0], this.GetQueryPageOperationCompleted, userState);
        }
        
        private void OnGetQueryPageOperationCompleted(object arg) {
            if ((this.GetQueryPageCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.GetQueryPageCompleted(this, new GetQueryPageCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        public new void CancelAsync(object userState) {
            base.CancelAsync(userState);
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("wsdl", "4.8.3928.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://LDI/")]
    public partial class InputData {
        
        private int xField;
        
        private int yField;
        
        /// <remarks/>
        public int x {
            get {
                return this.xField;
            }
            set {
                this.xField = value;
            }
        }
        
        /// <remarks/>
        public int y {
            get {
                return this.yField;
            }
            set {
                this.yField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("wsdl", "4.8.3928.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://LDI/")]
    public partial class A {
        
        private string sField;
        
        private int kField;
        
        private float fField;
        
        /// <remarks/>
        public string s {
            get {
                return this.sField;
            }
            set {
                this.sField = value;
            }
        }
        
        /// <remarks/>
        public int k {
            get {
                return this.kField;
            }
            set {
                this.kField = value;
            }
        }
        
        /// <remarks/>
        public float f {
            get {
                return this.fField;
            }
            set {
                this.fField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("wsdl", "4.8.3928.0")]
    public delegate void AddCompletedEventHandler(object sender, AddCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("wsdl", "4.8.3928.0")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class AddCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal AddCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public int Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((int)(this.results[0]));
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("wsdl", "4.8.3928.0")]
    public delegate void AddSCompletedEventHandler(object sender, AddSCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("wsdl", "4.8.3928.0")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class AddSCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal AddSCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public string Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((string)(this.results[0]));
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("wsdl", "4.8.3928.0")]
    public delegate void ConcatCompletedEventHandler(object sender, ConcatCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("wsdl", "4.8.3928.0")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class ConcatCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal ConcatCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public string Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((string)(this.results[0]));
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("wsdl", "4.8.3928.0")]
    public delegate void SumCompletedEventHandler(object sender, SumCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("wsdl", "4.8.3928.0")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class SumCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal SumCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public A Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((A)(this.results[0]));
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("wsdl", "4.8.3928.0")]
    public delegate void HelloWorldCompletedEventHandler(object sender, HelloWorldCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("wsdl", "4.8.3928.0")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class HelloWorldCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal HelloWorldCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public string Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((string)(this.results[0]));
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("wsdl", "4.8.3928.0")]
    public delegate void GetQueryPageCompletedEventHandler(object sender, GetQueryPageCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("wsdl", "4.8.3928.0")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class GetQueryPageCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal GetQueryPageCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public string Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((string)(this.results[0]));
            }
        }
    }
}
