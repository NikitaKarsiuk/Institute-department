﻿#pragma checksum "..\..\..\..\Windows\SubjectTypeOfReportList.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "0B654797A03B746441867D884569F9BDE391DAC4"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using Institute_Department.Converters;
using Institute_Department.Windows;
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


namespace Institute_Department.Windows {
    
    
    /// <summary>
    /// SubjectTypeOfReportList
    /// </summary>
    public partial class SubjectTypeOfReportList : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 16 "..\..\..\..\Windows\SubjectTypeOfReportList.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid subjectTypeOfReportDataGrid;
        
        #line default
        #line hidden
        
        
        #line 22 "..\..\..\..\Windows\SubjectTypeOfReportList.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button SubjectTypeOfReportAddButton;
        
        #line default
        #line hidden
        
        
        #line 23 "..\..\..\..\Windows\SubjectTypeOfReportList.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button SubjectTypeOfReportDeleteButton;
        
        #line default
        #line hidden
        
        
        #line 24 "..\..\..\..\Windows\SubjectTypeOfReportList.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button SubjectTypeOfReportChangeButton;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "7.0.11.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/Institute Department;component/windows/subjecttypeofreportlist.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\Windows\SubjectTypeOfReportList.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "7.0.11.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            this.subjectTypeOfReportDataGrid = ((System.Windows.Controls.DataGrid)(target));
            return;
            case 2:
            this.SubjectTypeOfReportAddButton = ((System.Windows.Controls.Button)(target));
            
            #line 22 "..\..\..\..\Windows\SubjectTypeOfReportList.xaml"
            this.SubjectTypeOfReportAddButton.Click += new System.Windows.RoutedEventHandler(this.SubjectTypeOfReportAddButton_Click);
            
            #line default
            #line hidden
            return;
            case 3:
            this.SubjectTypeOfReportDeleteButton = ((System.Windows.Controls.Button)(target));
            
            #line 23 "..\..\..\..\Windows\SubjectTypeOfReportList.xaml"
            this.SubjectTypeOfReportDeleteButton.Click += new System.Windows.RoutedEventHandler(this.SubjectTypeOfReportDeleteButton_Click);
            
            #line default
            #line hidden
            return;
            case 4:
            this.SubjectTypeOfReportChangeButton = ((System.Windows.Controls.Button)(target));
            
            #line 24 "..\..\..\..\Windows\SubjectTypeOfReportList.xaml"
            this.SubjectTypeOfReportChangeButton.Click += new System.Windows.RoutedEventHandler(this.SubjectTypeOfReportChangeButton_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

