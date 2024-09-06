﻿#pragma checksum "..\..\..\..\UserControls\FirstStep.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "6DF460C1B39C28D6D977455DA01A1773AF46CBC9"
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


namespace WFP_Project.Windows {
    
    
    /// <summary>
    /// FirstStep
    /// </summary>
    public partial class FirstStep : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 16 "..\..\..\..\UserControls\FirstStep.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ContentControl FirstStepContent;
        
        #line default
        #line hidden
        
        
        #line 20 "..\..\..\..\UserControls\FirstStep.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Border FirstStepRectangleUI;
        
        #line default
        #line hidden
        
        
        #line 29 "..\..\..\..\UserControls\FirstStep.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock TextBlockWelcome;
        
        #line default
        #line hidden
        
        
        #line 50 "..\..\..\..\UserControls\FirstStep.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.RadioButton RadioButtonLogin;
        
        #line default
        #line hidden
        
        
        #line 144 "..\..\..\..\UserControls\FirstStep.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.RadioButton RadioButtonSignUp;
        
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
            System.Uri resourceLocater = new System.Uri("/WFP_Project;component/usercontrols/firststep.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\UserControls\FirstStep.xaml"
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
            
            #line 10 "..\..\..\..\UserControls\FirstStep.xaml"
            ((WFP_Project.Windows.FirstStep)(target)).Loaded += new System.Windows.RoutedEventHandler(this.Window_Loaded);
            
            #line default
            #line hidden
            return;
            case 2:
            this.FirstStepContent = ((System.Windows.Controls.ContentControl)(target));
            return;
            case 3:
            this.FirstStepRectangleUI = ((System.Windows.Controls.Border)(target));
            return;
            case 4:
            this.TextBlockWelcome = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 5:
            this.RadioButtonLogin = ((System.Windows.Controls.RadioButton)(target));
            
            #line 56 "..\..\..\..\UserControls\FirstStep.xaml"
            this.RadioButtonLogin.Checked += new System.Windows.RoutedEventHandler(this.RadioButtonLogin_Checked);
            
            #line default
            #line hidden
            return;
            case 6:
            this.RadioButtonSignUp = ((System.Windows.Controls.RadioButton)(target));
            
            #line 150 "..\..\..\..\UserControls\FirstStep.xaml"
            this.RadioButtonSignUp.Checked += new System.Windows.RoutedEventHandler(this.RadioButtonSignUp_Checked);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}
