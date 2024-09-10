﻿#pragma checksum "..\..\..\MainWindow.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "CB1E1F135162AC73F93A2C11D8851BA73E6D2DA1"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using MaterialDesignThemes.Wpf;
using MaterialDesignThemes.Wpf.Converters;
using MaterialDesignThemes.Wpf.Transitions;
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
    /// MainWindow
    /// </summary>
    public partial class MainWindow : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 18 "..\..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.RowDefinition RowDefinitionRadioButtons;
        
        #line default
        #line hidden
        
        
        #line 27 "..\..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ContentControl MainContentControl;
        
        #line default
        #line hidden
        
        
        #line 33 "..\..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.StackPanel StackPanelRadioButtonsMainWindow;
        
        #line default
        #line hidden
        
        
        #line 46 "..\..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.RadioButton RadioButton_Admin;
        
        #line default
        #line hidden
        
        
        #line 188 "..\..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.RadioButton RadioButton_Home;
        
        #line default
        #line hidden
        
        
        #line 320 "..\..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.RadioButton RadioButton_Session;
        
        #line default
        #line hidden
        
        
        #line 447 "..\..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.RadioButton RadioButton_Controls;
        
        #line default
        #line hidden
        
        
        #line 567 "..\..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.RadioButton RadioButton_Archive;
        
        #line default
        #line hidden
        
        
        #line 691 "..\..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.RadioButton RadioButton_Settings;
        
        #line default
        #line hidden
        
        
        #line 813 "..\..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Border BlockUserControl;
        
        #line default
        #line hidden
        
        
        #line 828 "..\..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal MaterialDesignThemes.Wpf.PackIcon LockIcon;
        
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
            System.Uri resourceLocater = new System.Uri("/WFP_Project;component/mainwindow.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\MainWindow.xaml"
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
            
            #line 9 "..\..\..\MainWindow.xaml"
            ((WFP_Project.MainWindow)(target)).Loaded += new System.Windows.RoutedEventHandler(this.Window_Loaded);
            
            #line default
            #line hidden
            return;
            case 2:
            this.RowDefinitionRadioButtons = ((System.Windows.Controls.RowDefinition)(target));
            return;
            case 3:
            this.MainContentControl = ((System.Windows.Controls.ContentControl)(target));
            return;
            case 4:
            this.StackPanelRadioButtonsMainWindow = ((System.Windows.Controls.StackPanel)(target));
            return;
            case 5:
            this.RadioButton_Admin = ((System.Windows.Controls.RadioButton)(target));
            
            #line 53 "..\..\..\MainWindow.xaml"
            this.RadioButton_Admin.Click += new System.Windows.RoutedEventHandler(this.RadioButton_AdminChecked);
            
            #line default
            #line hidden
            return;
            case 6:
            this.RadioButton_Home = ((System.Windows.Controls.RadioButton)(target));
            
            #line 194 "..\..\..\MainWindow.xaml"
            this.RadioButton_Home.Click += new System.Windows.RoutedEventHandler(this.RadioButton_HomeChecked);
            
            #line default
            #line hidden
            return;
            case 7:
            this.RadioButton_Session = ((System.Windows.Controls.RadioButton)(target));
            
            #line 328 "..\..\..\MainWindow.xaml"
            this.RadioButton_Session.Click += new System.Windows.RoutedEventHandler(this.RadioButton_SessionChecked);
            
            #line default
            #line hidden
            return;
            case 8:
            this.RadioButton_Controls = ((System.Windows.Controls.RadioButton)(target));
            
            #line 454 "..\..\..\MainWindow.xaml"
            this.RadioButton_Controls.Click += new System.Windows.RoutedEventHandler(this.RadioButton_ControlsChecked);
            
            #line default
            #line hidden
            return;
            case 9:
            this.RadioButton_Archive = ((System.Windows.Controls.RadioButton)(target));
            
            #line 574 "..\..\..\MainWindow.xaml"
            this.RadioButton_Archive.Click += new System.Windows.RoutedEventHandler(this.RadioButton_ArchiveChecked);
            
            #line default
            #line hidden
            return;
            case 10:
            this.RadioButton_Settings = ((System.Windows.Controls.RadioButton)(target));
            
            #line 698 "..\..\..\MainWindow.xaml"
            this.RadioButton_Settings.Click += new System.Windows.RoutedEventHandler(this.RadioButton_SettingsChecked);
            
            #line default
            #line hidden
            return;
            case 11:
            this.BlockUserControl = ((System.Windows.Controls.Border)(target));
            return;
            case 12:
            this.LockIcon = ((MaterialDesignThemes.Wpf.PackIcon)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

