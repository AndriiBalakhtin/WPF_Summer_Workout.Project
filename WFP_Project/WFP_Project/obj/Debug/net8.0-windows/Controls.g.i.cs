﻿#pragma checksum "..\..\..\Controls.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "FFAA443D1563A0C0A15B4FC6EABC50ADCE1630AE"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Controls.Ribbon;
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


namespace WFP_Project {
    
    
    /// <summary>
    /// ControlWindow
    /// </summary>
    public partial class ControlWindow : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 7 "..\..\..\Controls.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button insertButton;
        
        #line default
        #line hidden
        
        
        #line 8 "..\..\..\Controls.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox forceTextBox;
        
        #line default
        #line hidden
        
        
        #line 9 "..\..\..\Controls.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox repeate_1stTextBox;
        
        #line default
        #line hidden
        
        
        #line 10 "..\..\..\Controls.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox weightTextBox;
        
        #line default
        #line hidden
        
        
        #line 11 "..\..\..\Controls.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox repeate_2ndTextBox;
        
        #line default
        #line hidden
        
        
        #line 12 "..\..\..\Controls.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox goalTextBox;
        
        #line default
        #line hidden
        
        
        #line 13 "..\..\..\Controls.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox repeate_3rdTextBox;
        
        #line default
        #line hidden
        
        
        #line 14 "..\..\..\Controls.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid databaseDataGrid;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "8.0.4.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/WFP_Project;component/controls.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\Controls.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "8.0.4.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            
            #line 5 "..\..\..\Controls.xaml"
            ((WFP_Project.ControlWindow)(target)).Loaded += new System.Windows.RoutedEventHandler(this.Window_Loaded);
            
            #line default
            #line hidden
            return;
            case 2:
            this.insertButton = ((System.Windows.Controls.Button)(target));
            
            #line 7 "..\..\..\Controls.xaml"
            this.insertButton.Click += new System.Windows.RoutedEventHandler(this.InsertButton_Click);
            
            #line default
            #line hidden
            return;
            case 3:
            this.forceTextBox = ((System.Windows.Controls.TextBox)(target));
            return;
            case 4:
            this.repeate_1stTextBox = ((System.Windows.Controls.TextBox)(target));
            
            #line 9 "..\..\..\Controls.xaml"
            this.repeate_1stTextBox.PreviewKeyDown += new System.Windows.Input.KeyEventHandler(this.NumbersOnlyTextboxes);
            
            #line default
            #line hidden
            return;
            case 5:
            this.weightTextBox = ((System.Windows.Controls.TextBox)(target));
            return;
            case 6:
            this.repeate_2ndTextBox = ((System.Windows.Controls.TextBox)(target));
            
            #line 11 "..\..\..\Controls.xaml"
            this.repeate_2ndTextBox.PreviewKeyDown += new System.Windows.Input.KeyEventHandler(this.NumbersOnlyTextboxes);
            
            #line default
            #line hidden
            return;
            case 7:
            this.goalTextBox = ((System.Windows.Controls.TextBox)(target));
            return;
            case 8:
            this.repeate_3rdTextBox = ((System.Windows.Controls.TextBox)(target));
            
            #line 13 "..\..\..\Controls.xaml"
            this.repeate_3rdTextBox.PreviewKeyDown += new System.Windows.Input.KeyEventHandler(this.NumbersOnlyTextboxes);
            
            #line default
            #line hidden
            return;
            case 9:
            this.databaseDataGrid = ((System.Windows.Controls.DataGrid)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

