﻿#pragma checksum "..\..\..\PL\MainPage.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "7E63708D286DE3BC4983F1014CD0659B486A97F1"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using Ask.PL;
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


namespace Ask.PL {
    
    
    /// <summary>
    /// MainPage
    /// </summary>
    public partial class MainPage : System.Windows.Controls.Page, System.Windows.Markup.IComponentConnector {
        
        
        #line 13 "..\..\..\PL\MainPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button NextBtn;
        
        #line default
        #line hidden
        
        
        #line 17 "..\..\..\PL\MainPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label QuestionNumberLabel;
        
        #line default
        #line hidden
        
        
        #line 20 "..\..\..\PL\MainPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label QuestionTextLabel;
        
        #line default
        #line hidden
        
        
        #line 27 "..\..\..\PL\MainPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button ConfirmBtn;
        
        #line default
        #line hidden
        
        
        #line 31 "..\..\..\PL\MainPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button ShowBtn;
        
        #line default
        #line hidden
        
        
        #line 38 "..\..\..\PL\MainPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox UserAnswerTxt;
        
        #line default
        #line hidden
        
        
        #line 42 "..\..\..\PL\MainPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label CorrectAnswerLabel;
        
        #line default
        #line hidden
        
        
        #line 50 "..\..\..\PL\MainPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label CorrectLabel;
        
        #line default
        #line hidden
        
        
        #line 55 "..\..\..\PL\MainPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label WrongLabel;
        
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
            System.Uri resourceLocater = new System.Uri("/Ask;component/pl/mainpage.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\PL\MainPage.xaml"
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
            this.NextBtn = ((System.Windows.Controls.Button)(target));
            
            #line 13 "..\..\..\PL\MainPage.xaml"
            this.NextBtn.Click += new System.Windows.RoutedEventHandler(this.NextBtn_Click);
            
            #line default
            #line hidden
            return;
            case 2:
            this.QuestionNumberLabel = ((System.Windows.Controls.Label)(target));
            return;
            case 3:
            this.QuestionTextLabel = ((System.Windows.Controls.Label)(target));
            return;
            case 4:
            this.ConfirmBtn = ((System.Windows.Controls.Button)(target));
            
            #line 27 "..\..\..\PL\MainPage.xaml"
            this.ConfirmBtn.Click += new System.Windows.RoutedEventHandler(this.ConfirmBtn_Click);
            
            #line default
            #line hidden
            return;
            case 5:
            this.ShowBtn = ((System.Windows.Controls.Button)(target));
            
            #line 31 "..\..\..\PL\MainPage.xaml"
            this.ShowBtn.Click += new System.Windows.RoutedEventHandler(this.ShowBtn_Click);
            
            #line default
            #line hidden
            return;
            case 6:
            this.UserAnswerTxt = ((System.Windows.Controls.TextBox)(target));
            return;
            case 7:
            this.CorrectAnswerLabel = ((System.Windows.Controls.Label)(target));
            return;
            case 8:
            this.CorrectLabel = ((System.Windows.Controls.Label)(target));
            return;
            case 9:
            this.WrongLabel = ((System.Windows.Controls.Label)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

