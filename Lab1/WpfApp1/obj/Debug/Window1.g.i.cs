﻿#pragma checksum "..\..\Window1.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "38CA5129542693502D376B7B4CCF859A86442B884B5B142B79EF1812A1EB09C6"
//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан программой.
//     Исполняемая версия:4.0.30319.42000
//
//     Изменения в этом файле могут привести к неправильной работе и будут потеряны в случае
//     повторной генерации кода.
// </auto-generated>
//------------------------------------------------------------------------------

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
using WpfApp1;


namespace WpfApp1 {
    
    
    /// <summary>
    /// Window1
    /// </summary>
    public partial class Window1 : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 1 "..\..\Window1.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal WpfApp1.Window1 First;
        
        #line default
        #line hidden
        
        
        #line 11 "..\..\Window1.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button GoToMain;
        
        #line default
        #line hidden
        
        
        #line 12 "..\..\Window1.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox TB1;
        
        #line default
        #line hidden
        
        
        #line 14 "..\..\Window1.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button Add;
        
        #line default
        #line hidden
        
        
        #line 15 "..\..\Window1.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox TB2;
        
        #line default
        #line hidden
        
        
        #line 17 "..\..\Window1.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button Delete;
        
        #line default
        #line hidden
        
        
        #line 18 "..\..\Window1.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button Read;
        
        #line default
        #line hidden
        
        
        #line 19 "..\..\Window1.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label Info;
        
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
            System.Uri resourceLocater = new System.Uri("/WpfApp1;component/window1.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\Window1.xaml"
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
            this.First = ((WpfApp1.Window1)(target));
            return;
            case 2:
            this.GoToMain = ((System.Windows.Controls.Button)(target));
            
            #line 11 "..\..\Window1.xaml"
            this.GoToMain.Click += new System.Windows.RoutedEventHandler(this.GoToMain_Click);
            
            #line default
            #line hidden
            return;
            case 3:
            this.TB1 = ((System.Windows.Controls.TextBox)(target));
            return;
            case 4:
            this.Add = ((System.Windows.Controls.Button)(target));
            
            #line 14 "..\..\Window1.xaml"
            this.Add.Click += new System.Windows.RoutedEventHandler(this.Add_Click);
            
            #line default
            #line hidden
            return;
            case 5:
            this.TB2 = ((System.Windows.Controls.TextBox)(target));
            return;
            case 6:
            this.Delete = ((System.Windows.Controls.Button)(target));
            
            #line 17 "..\..\Window1.xaml"
            this.Delete.Click += new System.Windows.RoutedEventHandler(this.Delete_Click);
            
            #line default
            #line hidden
            return;
            case 7:
            this.Read = ((System.Windows.Controls.Button)(target));
            
            #line 18 "..\..\Window1.xaml"
            this.Read.Click += new System.Windows.RoutedEventHandler(this.Read_Click_1);
            
            #line default
            #line hidden
            return;
            case 8:
            this.Info = ((System.Windows.Controls.Label)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

