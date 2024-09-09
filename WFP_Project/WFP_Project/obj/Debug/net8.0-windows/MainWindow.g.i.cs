﻿#pragma checksum "..\..\..\MainWindow.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "EF3A914ED9AF8071F5F4EFD7840752412DCE838B"
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
        
        
        #line 25 "..\..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ContentControl MainContentControl;
        
        #line default
        #line hidden
        
        
        #line 30 "..\..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.StackPanel StackPanelRadioButtonsMainWindow;
        
        #line default
        #line hidden
        
        
        #line 43 "..\..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.RadioButton RadioButton_Admin;
        
        #line default
        #line hidden
        
        
        #line 185 "..\..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.RadioButton RadioButton_Home;
        
        #line default
        #line hidden
        
        
        #line 317 "..\..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.RadioButton RadioButton_Session;
        
        #line default
        #line hidden
        
        
        #line 444 "..\..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.RadioButton RadioButton_Controls;
        
        #line default
        #line hidden
        
        
        #line 564 "..\..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.RadioButton RadioButton_Archive;
        
        #line default
        #line hidden
        
        
        #line 688 "..\..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.RadioButton RadioButton_Settings;
        
        #line default
        #line hidden
        
        
        #line 810 "..\..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Border BlockUserControl;
        
        #line default
        #line hidden
        
        
        #line 825 "..\..\..\MainWindow.xaml"
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
            this.MainContentControl = ((System.Windows.Controls.ContentControl)(target));
            return;
            case 3:
            this.StackPanelRadioButtonsMainWindow = ((System.Windows.Controls.StackPanel)(target));
            return;
            case 4:
            this.RadioButton_Admin = ((System.Windows.Controls.RadioButton)(target));
            
            #line 50 "..\..\..\MainWindow.xaml"
            this.RadioButton_Admin.Click += new System.Windows.RoutedEventHandler(this.RadioButton_AdminChecked);
            
            #line default
            #line hidden
            return;
            case 5:
            this.RadioButton_Home = ((System.Windows.Controls.RadioButton)(target));
            
            #line 191 "..\..\..\MainWindow.xaml"
            this.RadioButton_Home.Click += new System.Windows.RoutedEventHandler(this.RadioButton_HomeChecked);
            
            #line default
            #line hidden
            return;
            case 6:
            this.RadioButton_Session = ((System.Windows.Controls.RadioButton)(target));
            
            #line 325 "..\..\..\MainWindow.xaml"
            this.RadioButton_Session.Click += new System.Windows.RoutedEventHandler(this.RadioButton_SessionChecked);
            
            #line default
            #line hidden
            return;
            case 7:
            this.RadioButton_Controls = ((System.Windows.Controls.RadioButton)(target));
            
            #line 451 "..\..\..\MainWindow.xaml"
            this.RadioButton_Controls.Click += new System.Windows.RoutedEventHandler(this.RadioButton_ControlsChecked);
            
            #line default
            #line hidden
            return;
            case 8:
            this.RadioButton_Archive = ((System.Windows.Controls.RadioButton)(target));
            
            #line 571 "..\..\..\MainWindow.xaml"
            this.RadioButton_Archive.Click += new System.Windows.RoutedEventHandler(this.RadioButton_ArchiveChecked);
            
            #line default
            #line hidden
            return;
            case 9:
            this.RadioButton_Settings = ((System.Windows.Controls.RadioButton)(target));
            
            #line 695 "..\..\..\MainWindow.xaml"
            this.RadioButton_Settings.Click += new System.Windows.RoutedEventHandler(this.RadioButton_SettingsChecked);
            
            #line default
            #line hidden
            return;
            case 10:
            this.BlockUserControl = ((System.Windows.Controls.Border)(target));
            return;
            case 11:
            this.LockIcon = ((MaterialDesignThemes.Wpf.PackIcon)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

