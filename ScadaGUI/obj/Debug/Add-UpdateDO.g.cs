﻿#pragma checksum "..\..\Add-UpdateDO.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "DF2A2F6F19705FDCEF9FA7C87E1FCC6A4BE6052AFF9A8DDA7DD262F35C62F30D"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using ScadaGUI;
using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Effects;
using System.Windows.Media.Imaging;
using System.Windows.Media.Media3D;
using System.Windows.Media.TextFormatting;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Shell;


namespace ScadaGUI {
    
    
    /// <summary>
    /// Add_UpdateDO
    /// </summary>
    public partial class Add_UpdateDO : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 8 "..\..\Add-UpdateDO.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal ScadaGUI.Add_UpdateDO doo;
        
        #line default
        #line hidden
        
        
        #line 23 "..\..\Add-UpdateDO.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button AddAI;
        
        #line default
        #line hidden
        
        
        #line 26 "..\..\Add-UpdateDO.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox idTxt;
        
        #line default
        #line hidden
        
        
        #line 29 "..\..\Add-UpdateDO.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox desTxt;
        
        #line default
        #line hidden
        
        
        #line 32 "..\..\Add-UpdateDO.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox adresCombo;
        
        #line default
        #line hidden
        
        
        #line 35 "..\..\Add-UpdateDO.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox stTxt;
        
        #line default
        #line hidden
        
        
        #line 37 "..\..\Add-UpdateDO.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button Cancel;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/ScadaGUI;component/add-updatedo.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\Add-UpdateDO.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            this.doo = ((ScadaGUI.Add_UpdateDO)(target));
            return;
            case 2:
            this.AddAI = ((System.Windows.Controls.Button)(target));
            
            #line 23 "..\..\Add-UpdateDO.xaml"
            this.AddAI.Click += new System.Windows.RoutedEventHandler(this.OK_Click);
            
            #line default
            #line hidden
            return;
            case 3:
            this.idTxt = ((System.Windows.Controls.TextBox)(target));
            return;
            case 4:
            this.desTxt = ((System.Windows.Controls.TextBox)(target));
            return;
            case 5:
            this.adresCombo = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 6:
            this.stTxt = ((System.Windows.Controls.TextBox)(target));
            return;
            case 7:
            this.Cancel = ((System.Windows.Controls.Button)(target));
            
            #line 37 "..\..\Add-UpdateDO.xaml"
            this.Cancel.Click += new System.Windows.RoutedEventHandler(this.Cancel_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}
