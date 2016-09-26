﻿#pragma checksum "..\..\..\Windows\LoginWindow.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "469A1F17D69F85B53B81E9BBB40F6C3D"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using MahApps.Metro.Controls;
using SmartArchive;
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


namespace SmartArchive.Windows {
    
    
    /// <summary>
    /// LoginWindow
    /// </summary>
    public partial class LoginWindow : MahApps.Metro.Controls.MetroWindow, System.Windows.Markup.IComponentConnector {
        
        
        #line 14 "..\..\..\Windows\LoginWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Grid MainGrid;
        
        #line default
        #line hidden
        
        
        #line 29 "..\..\..\Windows\LoginWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Image Logo;
        
        #line default
        #line hidden
        
        
        #line 30 "..\..\..\Windows\LoginWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label Title;
        
        #line default
        #line hidden
        
        
        #line 34 "..\..\..\Windows\LoginWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox UsernameInput;
        
        #line default
        #line hidden
        
        
        #line 39 "..\..\..\Windows\LoginWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.PasswordBox PasswordInput;
        
        #line default
        #line hidden
        
        
        #line 43 "..\..\..\Windows\LoginWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.CheckBox RememberCheckBox;
        
        #line default
        #line hidden
        
        
        #line 45 "..\..\..\Windows\LoginWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button LoginBtn;
        
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
            System.Uri resourceLocater = new System.Uri("/SmartArchive;component/windows/loginwindow.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\Windows\LoginWindow.xaml"
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
            this.MainGrid = ((System.Windows.Controls.Grid)(target));
            return;
            case 2:
            this.Logo = ((System.Windows.Controls.Image)(target));
            return;
            case 3:
            this.Title = ((System.Windows.Controls.Label)(target));
            return;
            case 4:
            this.UsernameInput = ((System.Windows.Controls.TextBox)(target));
            
            #line 35 "..\..\..\Windows\LoginWindow.xaml"
            this.UsernameInput.GotFocus += new System.Windows.RoutedEventHandler(this.UsernameInput_OnGotFocus);
            
            #line default
            #line hidden
            
            #line 35 "..\..\..\Windows\LoginWindow.xaml"
            this.UsernameInput.LostFocus += new System.Windows.RoutedEventHandler(this.UsernameInput_OnLostFocus);
            
            #line default
            #line hidden
            return;
            case 5:
            this.PasswordInput = ((System.Windows.Controls.PasswordBox)(target));
            
            #line 40 "..\..\..\Windows\LoginWindow.xaml"
            this.PasswordInput.GotFocus += new System.Windows.RoutedEventHandler(this.PasswordInput_OnGotFocus);
            
            #line default
            #line hidden
            
            #line 40 "..\..\..\Windows\LoginWindow.xaml"
            this.PasswordInput.LostFocus += new System.Windows.RoutedEventHandler(this.PasswordInput_OnLostFocus);
            
            #line default
            #line hidden
            return;
            case 6:
            this.RememberCheckBox = ((System.Windows.Controls.CheckBox)(target));
            return;
            case 7:
            this.LoginBtn = ((System.Windows.Controls.Button)(target));
            
            #line 45 "..\..\..\Windows\LoginWindow.xaml"
            this.LoginBtn.Click += new System.Windows.RoutedEventHandler(this.LoginButton_OnClick);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

