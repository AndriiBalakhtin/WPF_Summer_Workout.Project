﻿#pragma checksum "..\..\..\..\Windows\EditTrainingWindow .xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "7CAC43666163285615282ABA6E760F70BFE341FB"
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
using WFP_Project.Windows;


namespace WFP_Project.Windows {
    
    
    /// <summary>
    /// EditTrainingWindow
    /// </summary>
    public partial class EditTrainingWindow : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 12 "..\..\..\..\Windows\EditTrainingWindow .xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox TrainingNameTextBox;
        
        #line default
        #line hidden
        
        
        #line 15 "..\..\..\..\Windows\EditTrainingWindow .xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox AthleteNameTextBox;
        
        #line default
        #line hidden
        
        
        #line 18 "..\..\..\..\Windows\EditTrainingWindow .xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox CoachNameTextBox;
        
        #line default
        #line hidden
        
        
        #line 21 "..\..\..\..\Windows\EditTrainingWindow .xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListView ExercisesListView;
        
        #line default
        #line hidden
        
        
        #line 32 "..\..\..\..\Windows\EditTrainingWindow .xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox ExerciseNameTextBox;
        
        #line default
        #line hidden
        
        
        #line 35 "..\..\..\..\Windows\EditTrainingWindow .xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox RepsTextBox;
        
        #line default
        #line hidden
        
        
        #line 38 "..\..\..\..\Windows\EditTrainingWindow .xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox SetsTextBox;
        
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
            System.Uri resourceLocater = new System.Uri("/WFP_Project;component/windows/edittrainingwindow%20.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\Windows\EditTrainingWindow .xaml"
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
            this.TrainingNameTextBox = ((System.Windows.Controls.TextBox)(target));
            return;
            case 2:
            this.AthleteNameTextBox = ((System.Windows.Controls.TextBox)(target));
            return;
            case 3:
            this.CoachNameTextBox = ((System.Windows.Controls.TextBox)(target));
            return;
            case 4:
            this.ExercisesListView = ((System.Windows.Controls.ListView)(target));
            return;
            case 5:
            this.ExerciseNameTextBox = ((System.Windows.Controls.TextBox)(target));
            return;
            case 6:
            this.RepsTextBox = ((System.Windows.Controls.TextBox)(target));
            return;
            case 7:
            this.SetsTextBox = ((System.Windows.Controls.TextBox)(target));
            return;
            case 8:
            
            #line 40 "..\..\..\..\Windows\EditTrainingWindow .xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.AddExerciseButton_Click);
            
            #line default
            #line hidden
            return;
            case 9:
            
            #line 43 "..\..\..\..\Windows\EditTrainingWindow .xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.SaveButton_Click);
            
            #line default
            #line hidden
            return;
            case 10:
            
            #line 44 "..\..\..\..\Windows\EditTrainingWindow .xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.CancelButton_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

