﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.239
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System.Xml.Serialization;

// 
// This source code was auto-generated by xsd, Version=4.0.30319.1.
// 


/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.1")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true, Namespace="https://services.yesmail.com")]
[System.Xml.Serialization.XmlRootAttribute(Namespace="https://services.yesmail.com", IsNullable=false)]
public partial class subscribeAndSend {
    
    private subscribeAndSendSubscriber subscriberField;
    
    private subscribeAndSendTable[] sideTableField;
    
    private subscribeAndSendSubscriberMessage subscriberMessageField;
    
    private decimal schemaVersionField;
    
    /// <remarks/>
    public subscribeAndSendSubscriber subscriber {
        get {
            return this.subscriberField;
        }
        set {
            this.subscriberField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlArrayItemAttribute("table", IsNullable=false)]
    public subscribeAndSendTable[] sideTable {
        get {
            return this.sideTableField;
        }
        set {
            this.sideTableField = value;
        }
    }
    
    /// <remarks/>
    public subscribeAndSendSubscriberMessage subscriberMessage {
        get {
            return this.subscriberMessageField;
        }
        set {
            this.subscriberMessageField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public decimal schemaVersion {
        get {
            return this.schemaVersionField;
        }
        set {
            this.schemaVersionField = value;
        }
    }
}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.1")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true, Namespace="https://services.yesmail.com")]
public partial class subscribeAndSendSubscriber {
    
    private string subscriptionStateField;
    
    private bool allowResubscribeField;
    
    private string divisionField;
    
    private subscribeAndSendSubscriberAttribute[] attributesField;
    
    /// <remarks/>
    public string subscriptionState {
        get {
            return this.subscriptionStateField;
        }
        set {
            this.subscriptionStateField = value;
        }
    }
    
    /// <remarks/>
    public bool allowResubscribe {
        get {
            return this.allowResubscribeField;
        }
        set {
            this.allowResubscribeField = value;
        }
    }
    
    /// <remarks/>
    public string division {
        get {
            return this.divisionField;
        }
        set {
            this.divisionField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlArrayItemAttribute("attribute", IsNullable=false)]
    public subscribeAndSendSubscriberAttribute[] attributes {
        get {
            return this.attributesField;
        }
        set {
            this.attributesField = value;
        }
    }
}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.1")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true, Namespace="https://services.yesmail.com")]
public partial class subscribeAndSendSubscriberAttribute {
    
    private string nameField;
    
    private string valueField;
    
    /// <remarks/>
    public string name {
        get {
            return this.nameField;
        }
        set {
            this.nameField = value;
        }
    }
    
    /// <remarks/>
    public string value {
        get {
            return this.valueField;
        }
        set {
            this.valueField = value;
        }
    }
}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.1")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true, Namespace="https://services.yesmail.com")]
public partial class subscribeAndSendTable {
    
    private string nameField;
    
    private subscribeAndSendTableRows rowsField;
    
    /// <remarks/>
    public string name {
        get {
            return this.nameField;
        }
        set {
            this.nameField = value;
        }
    }
    
    /// <remarks/>
    public subscribeAndSendTableRows rows {
        get {
            return this.rowsField;
        }
        set {
            this.rowsField = value;
        }
    }
}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.1")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true, Namespace="https://services.yesmail.com")]
public partial class subscribeAndSendTableRows {
    
    private subscribeAndSendTableRowsRow rowField;
    
    /// <remarks/>
    public subscribeAndSendTableRowsRow row {
        get {
            return this.rowField;
        }
        set {
            this.rowField = value;
        }
    }
}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.1")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true, Namespace="https://services.yesmail.com")]
public partial class subscribeAndSendTableRowsRow {
    
    private subscribeAndSendTableRowsRowColumn[] columnsField;
    
    /// <remarks/>
    [System.Xml.Serialization.XmlArrayItemAttribute("column", IsNullable=false)]
    public subscribeAndSendTableRowsRowColumn[] columns {
        get {
            return this.columnsField;
        }
        set {
            this.columnsField = value;
        }
    }
}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.1")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true, Namespace="https://services.yesmail.com")]
public partial class subscribeAndSendTableRowsRowColumn {
    
    private string nameField;
    
    private string valueField;
    
    /// <remarks/>
    public string name {
        get {
            return this.nameField;
        }
        set {
            this.nameField = value;
        }
    }
    
    /// <remarks/>
    public string value {
        get {
            return this.valueField;
        }
        set {
            this.valueField = value;
        }
    }
}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.1")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true, Namespace="https://services.yesmail.com")]
public partial class subscribeAndSendSubscriberMessage {
    
    private uint masterIdField;
    
    /// <remarks/>
    public uint masterId {
        get {
            return this.masterIdField;
        }
        set {
            this.masterIdField = value;
        }
    }
}
