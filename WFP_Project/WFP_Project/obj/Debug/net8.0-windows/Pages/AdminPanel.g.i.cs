﻿#pragma checksum "..\..\..\..\Pages\AdminPanel.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "4EAD239DB3E911A072DC03EBCDB6F4FCCE890A87"
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


namespace WFP_Project.Pages {
    
    
    /// <summary>
    /// AdminPanel
    /// </summary>
    public partial class AdminPanel : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 12 "..\..\..\..\Pages\AdminPanel.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Border AdminSQLRectangleUI;
        
        #line default
        #line hidden
        
        
        #line 20 "..\..\..\..\Pages\AdminPanel.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button ButtonExecuteSQL;
        
        #line default
        #line hidden
        
        
        #line 35 "..\..\..\..\Pages\AdminPanel.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock TextBlockAdminSQL;
        
        #line default
        #line hidden
        
        
        #line 42 "..\..\..\..\Pages\AdminPanel.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox TextBoxAdminSQL;
        
        #line default
        #line hidden
        
        
        #line 91 "..\..\..\..\Pages\AdminPanel.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock TextBlockAdminDatabases;
        
        #line default
        #line hidden
        
        
        #line 98 "..\..\..\..\Pages\AdminPanel.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox ComboBoxDatabases;
        
        #line default
        #line hidden
        
        
        #line 186 "..\..\..\..\Pages\AdminPanel.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button ButtonOpenTables;
        
        #line default
        #line hidden
        
        
        #line 201 "..\..\..\..\Pages\AdminPanel.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Border TablesPanel;
        
        #line default
        #line hidden
        
        
        #line 210 "..\..\..\..\Pages\AdminPanel.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.WrapPanel tablesWrapPanel;
        
        #line default
        #line hidden
        
        
        #line 214 "..\..\..\..\Pages\AdminPanel.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid DataGridAdminSQL;
        
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
            System.Uri resourceLocater = new System.Uri("/WFP_Project;component/pages/adminpanel.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\Pages\AdminPanel.xaml"
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
            
            #line 6 "..\..\..\..\Pages\AdminPanel.xaml"
            ((WFP_Project.Pages.AdminPanel)(target)).Loaded += new System.Windows.RoutedEventHandler(this.Window_Loaded);
            
            #line default
            #line hidden
            return;
            case 2:
            this.AdminSQLRectangleUI = ((System.Windows.Controls.Border)(target));
            return;
            case 3:
            this.ButtonExecuteSQL = ((System.Windows.Controls.Button)(target));
            
            #line 26 "..\..\..\..\Pages\AdminPanel.xaml"
            this.ButtonExecuteSQL.Click += new System.Windows.RoutedEventHandler(this.ButtonExecuteSQL_Click);
            
            #line default
            #line hidden
            return;
            case 4:
            this.TextBlockAdminSQL = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 5:
            this.TextBoxAdminSQL = ((System.Windows.Controls.TextBox)(target));
            
            #line 49 "..\..\..\..\Pages\AdminPanel.xaml"
            this.TextBoxAdminSQL.GotFocus += new System.Windows.RoutedEventHandler(this.TextBoxAdminSQL_GotFocus);
            
            #line default
            #line hidden
            return;
            case 6:
            this.TextBlockAdminDatabases = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 7:
            this.ComboBoxDatabases = ((System.Windows.Controls.ComboBox)(target));
            
            #line 109 "..\..\..\..\Pages\AdminPanel.xaml"
            this.ComboBoxDatabases.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.ComboBoxDatabases_SelectionChanged);
            
            #line default
            #line hidden
            return;
            case 8:
            this.ButtonOpenTables = ((System.Windows.Controls.Button)(target));
            
            #line 192 "..\..\..\..\Pages\AdminPanel.xaml"
            this.ButtonOpenTables.Click += new System.Windows.RoutedEventHandler(this.ButtonOpenTables_Click);
            
            #line default
            #line hidden
            return;
            case 9:
            this.TablesPanel = ((System.Windows.Controls.Border)(target));
            return;
            case 10:
            this.tablesWrapPanel = ((System.Windows.Controls.WrapPanel)(target));
            return;
            case 11:
            this.DataGridAdminSQL = ((System.Windows.Controls.DataGrid)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

