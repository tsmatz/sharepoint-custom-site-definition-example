﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:2.0.50727.42
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System.Xml.Serialization;

// 
// This source code was auto-generated by xsd, Version=2.0.50727.42.
// 


/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.42")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true)]
[System.Xml.Serialization.XmlRootAttribute(Namespace="http://schemas.microsoft.com/office/infopath/2003/myXSD/2006-10-17T06:59:30", IsNullable=false)]
public partial class InitForm {
    
    private string asigneeField;
    
    private string instructionsField;
    
    private System.Xml.XmlAttribute[] anyAttrField;
    
    /// <remarks/>
    public string asignee {
        get {
            return this.asigneeField;
        }
        set {
            this.asigneeField = value;
        }
    }
    
    /// <remarks/>
    public string instructions {
        get {
            return this.instructionsField;
        }
        set {
            this.instructionsField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlAnyAttributeAttribute()]
    public System.Xml.XmlAttribute[] AnyAttr {
        get {
            return this.anyAttrField;
        }
        set {
            this.anyAttrField = value;
        }
    }
}