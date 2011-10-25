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
[System.Xml.Serialization.XmlTypeAttribute(Namespace="https://services.yesmail.com")]
[System.Xml.Serialization.XmlRootAttribute("subscriber", Namespace="https://services.yesmail.com", IsNullable=false)]
public partial class subscriberBase {
    
    private int userIdField;
    
    private bool userIdFieldSpecified;
    
    private GlobalSubscriptionState subscriptionStateField;
    
    private bool subscriptionStateFieldSpecified;
    
    private bool allowResubscribeField;
    
    private subscriberBaseDivision divisionField;
    
    private attributes attributesField;
    
    private decimal schemaVersionField;
    
    private bool schemaVersionFieldSpecified;
    
    public subscriberBase() {
        this.allowResubscribeField = false;
    }
    
    /// <remarks/>
    public int userId {
        get {
            return this.userIdField;
        }
        set {
            this.userIdField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlIgnoreAttribute()]
    public bool userIdSpecified {
        get {
            return this.userIdFieldSpecified;
        }
        set {
            this.userIdFieldSpecified = value;
        }
    }
    
    /// <remarks/>
    public GlobalSubscriptionState subscriptionState {
        get {
            return this.subscriptionStateField;
        }
        set {
            this.subscriptionStateField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlIgnoreAttribute()]
    public bool subscriptionStateSpecified {
        get {
            return this.subscriptionStateFieldSpecified;
        }
        set {
            this.subscriptionStateFieldSpecified = value;
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
    public subscriberBaseDivision division {
        get {
            return this.divisionField;
        }
        set {
            this.divisionField = value;
        }
    }
    
    /// <remarks/>
    public attributes attributes {
        get {
            return this.attributesField;
        }
        set {
            this.attributesField = value;
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
    
    /// <remarks/>
    [System.Xml.Serialization.XmlIgnoreAttribute()]
    public bool schemaVersionSpecified {
        get {
            return this.schemaVersionFieldSpecified;
        }
        set {
            this.schemaVersionFieldSpecified = value;
        }
    }
}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.1")]
[System.SerializableAttribute()]
[System.Xml.Serialization.XmlTypeAttribute(Namespace="https://services.yesmail.com")]
public enum GlobalSubscriptionState {
    
    /// <remarks/>
    UNSUBSCRIBED,
    
    /// <remarks/>
    SUBSCRIBED,
    
    /// <remarks/>
    REFERRED,
    
    /// <remarks/>
    DEAD,
    
    /// <remarks/>
    REVIVE,
}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.1")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true, Namespace="https://services.yesmail.com")]
public partial class subscriberBaseDivision {
    
    private bool subscribedField;
    
    private bool subscribedFieldSpecified;
    
    private bool memberField;
    
    private bool memberFieldSpecified;
    
    private string valueField;
    
    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public bool subscribed {
        get {
            return this.subscribedField;
        }
        set {
            this.subscribedField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlIgnoreAttribute()]
    public bool subscribedSpecified {
        get {
            return this.subscribedFieldSpecified;
        }
        set {
            this.subscribedFieldSpecified = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public bool member {
        get {
            return this.memberField;
        }
        set {
            this.memberField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlIgnoreAttribute()]
    public bool memberSpecified {
        get {
            return this.memberFieldSpecified;
        }
        set {
            this.memberFieldSpecified = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlTextAttribute()]
    public string Value {
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
[System.Xml.Serialization.XmlTypeAttribute(Namespace="https://services.yesmail.com")]
public partial class keyValue {
    
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
[System.Xml.Serialization.XmlTypeAttribute(Namespace="https://services.yesmail.com")]
public partial class row {
    
    private rowIds idsField;
    
    private rowColumns columnsField;
    
    /// <remarks/>
    public rowIds ids {
        get {
            return this.idsField;
        }
        set {
            this.idsField = value;
        }
    }
    
    /// <remarks/>
    public rowColumns columns {
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
public partial class rowIds {
    
    private keyValue[] idField;
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("id")]
    public keyValue[] id {
        get {
            return this.idField;
        }
        set {
            this.idField = value;
        }
    }
}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.1")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true, Namespace="https://services.yesmail.com")]
public partial class rowColumns {
    
    private keyValue[] columnField;
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("column")]
    public keyValue[] column {
        get {
            return this.columnField;
        }
        set {
            this.columnField = value;
        }
    }
}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.1")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(Namespace="https://services.yesmail.com")]
public partial class attributes {
    
    private attributesAttribute[] attributeField;
    
    private decimal schemaVersionField;
    
    private bool schemaVersionFieldSpecified;
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("attribute")]
    public attributesAttribute[] attribute {
        get {
            return this.attributeField;
        }
        set {
            this.attributeField = value;
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
    
    /// <remarks/>
    [System.Xml.Serialization.XmlIgnoreAttribute()]
    public bool schemaVersionSpecified {
        get {
            return this.schemaVersionFieldSpecified;
        }
        set {
            this.schemaVersionFieldSpecified = value;
        }
    }
}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.1")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true, Namespace="https://services.yesmail.com")]
public partial class attributesAttribute {
    
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
[System.Xml.Serialization.XmlTypeAttribute(Namespace="https://services.yesmail.com")]
[System.Xml.Serialization.XmlRootAttribute(Namespace="https://services.yesmail.com", IsNullable=false)]
public partial class subscriberMessage {
    
    private int masterIdField;
    
    private attributes attributesField;
    
    private decimal schemaVersionField;
    
    private bool schemaVersionFieldSpecified;
    
    /// <remarks/>
    public int masterId {
        get {
            return this.masterIdField;
        }
        set {
            this.masterIdField = value;
        }
    }
    
    /// <remarks/>
    public attributes attributes {
        get {
            return this.attributesField;
        }
        set {
            this.attributesField = value;
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
    
    /// <remarks/>
    [System.Xml.Serialization.XmlIgnoreAttribute()]
    public bool schemaVersionSpecified {
        get {
            return this.schemaVersionFieldSpecified;
        }
        set {
            this.schemaVersionFieldSpecified = value;
        }
    }
}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.1")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(Namespace="https://services.yesmail.com")]
[System.Xml.Serialization.XmlRootAttribute(Namespace="https://services.yesmail.com", IsNullable=false)]
public partial class sideTable {
    
    private sideTableTable[] tableField;
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("table")]
    public sideTableTable[] table {
        get {
            return this.tableField;
        }
        set {
            this.tableField = value;
        }
    }
}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.1")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true, Namespace="https://services.yesmail.com")]
public partial class sideTableTable {
    
    private string nameField;
    
    private row[] rowsField;
    
    private decimal schemaVersionField;
    
    private bool schemaVersionFieldSpecified;
    
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
    [System.Xml.Serialization.XmlArrayItemAttribute(IsNullable=false)]
    public row[] rows {
        get {
            return this.rowsField;
        }
        set {
            this.rowsField = value;
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
    
    /// <remarks/>
    [System.Xml.Serialization.XmlIgnoreAttribute()]
    public bool schemaVersionSpecified {
        get {
            return this.schemaVersionFieldSpecified;
        }
        set {
            this.schemaVersionFieldSpecified = value;
        }
    }
}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.1")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true, Namespace="https://services.yesmail.com")]
[System.Xml.Serialization.XmlRootAttribute(Namespace="https://services.yesmail.com", IsNullable=false)]
public partial class subscribeAndSend {
    
    private subscriberBase subscriberField;
    
    private sideTableTable[] sideTableField;
    
    private subscriberMessage subscriberMessageField;
    
    private decimal schemaVersionField;
    
    private bool schemaVersionFieldSpecified;
    
    /// <remarks/>
    public subscriberBase subscriber {
        get {
            return this.subscriberField;
        }
        set {
            this.subscriberField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlArrayItemAttribute("table", IsNullable=false)]
    public sideTableTable[] sideTable {
        get {
            return this.sideTableField;
        }
        set {
            this.sideTableField = value;
        }
    }
    
    /// <remarks/>
    public subscriberMessage subscriberMessage {
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
    
    /// <remarks/>
    [System.Xml.Serialization.XmlIgnoreAttribute()]
    public bool schemaVersionSpecified {
        get {
            return this.schemaVersionFieldSpecified;
        }
        set {
            this.schemaVersionFieldSpecified = value;
        }
    }
}
