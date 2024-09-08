﻿#pragma checksum "..\..\..\..\UserControls\ConfirmEmail.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "90A88CC24470CE5B7759E4B82163360F2F15A714"
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


namespace WFP_Project.UserControls {
    
    
    /// <summary>
    /// ConfirmEmail
    /// </summary>
    public partial class ConfirmEmail : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 16 "..\..\..\..\UserControls\ConfirmEmail.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.RadioButton RadioButtonReturnBackToSignUp;
        
        #line default
        #line hidden
        
        
        #line 105 "..\..\..\..\UserControls\ConfirmEmail.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Border ConfirmEmailRectangleUI;
        
        #line default
        #line hidden
        
        
        #line 128 "..\..\..\..\UserControls\ConfirmEmail.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock TextBlockCheckEmail;
        
        #line default
        #line hidden
        
        
        #line 135 "..\..\..\..\UserControls\ConfirmEmail.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox TextBoxConfirmationCode;
        
        #line default
        #line hidden
        
        
        #line 186 "..\..\..\..\UserControls\ConfirmEmail.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Border ButtonSendAgainEmailRectangleUI;
        
        #line default
        #line hidden
        
        
        #line 195 "..\..\..\..\UserControls\ConfirmEmail.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button ButtonSendAgainEmail;
        
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
            System.Uri resourceLocater = new System.Uri("/WFP_Project;component/usercontrols/confirmemail.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\UserControls\ConfirmEmail.xaml"
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
            
            #line 10 "..\..\..\..\UserControls\ConfirmEmail.xaml"
            ((WFP_Project.UserControls.ConfirmEmail)(target)).Loaded += new System.Windows.RoutedEventHandler(this.Window_Loaded);
            
            #line default
            #line hidden
            return;
            case 2:
            this.RadioButtonReturnBackToSignUp = ((System.Windows.Controls.RadioButton)(target));
            
            #line 22 "..\..\..\..\UserControls\ConfirmEmail.xaml"
            this.RadioButtonReturnBackToSignUp.Checked += new System.Windows.RoutedEventHandler(this.RadioButtonReturnBackToSignUp_Checked);
            
            #line default
            #line hidden
            return;
            case 3:
            this.ConfirmEmailRectangleUI = ((System.Windows.Controls.Border)(target));
            return;
            case 4:
            
            #line 119 "..\..\..\..\UserControls\ConfirmEmail.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.ButtonConfirmEmail_Click);
            
            #line default
            #line hidden
            return;
            case 5:
            this.TextBlockCheckEmail = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 6:
            this.TextBoxConfirmationCode = ((System.Windows.Controls.TextBox)(target));
            
            #line 149 "..\..\..\..\UserControls\ConfirmEmail.xaml"
            this.TextBoxConfirmationCode.GotFocus += new System.Windows.RoutedEventHandler(this.TextBoxConfirmationCode_GotFocus);
            
            #line default
            #line hidden
            return;
            case 7:
            this.ButtonSendAgainEmailRectangleUI = ((System.Windows.Controls.Border)(target));
            return;
            case 8:
            this.ButtonSendAgainEmail = ((System.Windows.Controls.Button)(target));
            
            #line 201 "..\..\..\..\UserControls\ConfirmEmail.xaml"
            this.ButtonSendAgainEmail.Click += new System.Windows.RoutedEventHandler(this.ButtonSendAgainEmail_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

