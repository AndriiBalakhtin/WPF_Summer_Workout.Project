﻿#pragma checksum "..\..\..\..\Pages\Editor.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "0BB107FAEB710809B843BB307407AFB41ABDCB30"
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
using WFP_Project.Pages;


namespace WFP_Project.Pages {
    
    
    /// <summary>
    /// Editor
    /// </summary>
    public partial class Editor : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 14 "..\..\..\..\Pages\Editor.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label selectedRowLabel;
        
        #line default
        #line hidden
        
        
        #line 33 "..\..\..\..\Pages\Editor.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox forceTextBox;
        
        #line default
        #line hidden
        
        
        #line 36 "..\..\..\..\Pages\Editor.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox repeate_1stTextBox;
        
        #line default
        #line hidden
        
        
        #line 39 "..\..\..\..\Pages\Editor.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox weightTextBox;
        
        #line default
        #line hidden
        
        
        #line 42 "..\..\..\..\Pages\Editor.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox repeate_2ndTextBox;
        
        #line default
        #line hidden
        
        
        #line 45 "..\..\..\..\Pages\Editor.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox goalTextBox;
        
        #line default
        #line hidden
        
        
        #line 48 "..\..\..\..\Pages\Editor.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox repeate_3rdTextBox;
        
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
            System.Uri resourceLocater = new System.Uri("/WFP_Project;component/pages/editor.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\Pages\Editor.xaml"
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
            this.selectedRowLabel = ((System.Windows.Controls.Label)(target));
            return;
            case 2:
            this.forceTextBox = ((System.Windows.Controls.TextBox)(target));
            return;
            case 3:
            this.repeate_1stTextBox = ((System.Windows.Controls.TextBox)(target));
            return;
            case 4:
            this.weightTextBox = ((System.Windows.Controls.TextBox)(target));
            return;
            case 5:
            this.repeate_2ndTextBox = ((System.Windows.Controls.TextBox)(target));
            return;
            case 6:
            this.goalTextBox = ((System.Windows.Controls.TextBox)(target));
            return;
            case 7:
            this.repeate_3rdTextBox = ((System.Windows.Controls.TextBox)(target));
            return;
            case 8:
            
            #line 50 "..\..\..\..\Pages\Editor.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.UpdateButton_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

