﻿#pragma checksum "..\..\..\..\..\Views\Windows\Main.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "77DED9BD8A15DA578678AAF43C40B7BFF3974043"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using Employees.Commands;
using Employees.ViewModels;
using Employees.Views;
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


namespace Employees {
    
    
    /// <summary>
    /// Main
    /// </summary>
    public partial class Main : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 58 "..\..\..\..\..\Views\Windows\Main.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button exit;
        
        #line default
        #line hidden
        
        
        #line 66 "..\..\..\..\..\Views\Windows\Main.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Grid GridMenu;
        
        #line default
        #line hidden
        
        
        #line 70 "..\..\..\..\..\Views\Windows\Main.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button Settings;
        
        #line default
        #line hidden
        
        
        #line 74 "..\..\..\..\..\Views\Windows\Main.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button LogOut;
        
        #line default
        #line hidden
        
        
        #line 79 "..\..\..\..\..\Views\Windows\Main.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button Profile;
        
        #line default
        #line hidden
        
        
        #line 85 "..\..\..\..\..\Views\Windows\Main.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button ButtonShowMenu;
        
        #line default
        #line hidden
        
        
        #line 91 "..\..\..\..\..\Views\Windows\Main.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button ButtonHideMenu;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "5.0.3.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/Employees;component/views/windows/main.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\..\Views\Windows\Main.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "5.0.3.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            
            #line 10 "..\..\..\..\..\Views\Windows\Main.xaml"
            ((Employees.Main)(target)).MouseLeftButtonDown += new System.Windows.Input.MouseButtonEventHandler(this.DraggableWindow);
            
            #line default
            #line hidden
            return;
            case 2:
            this.exit = ((System.Windows.Controls.Button)(target));
            return;
            case 3:
            this.GridMenu = ((System.Windows.Controls.Grid)(target));
            return;
            case 4:
            this.Settings = ((System.Windows.Controls.Button)(target));
            return;
            case 5:
            this.LogOut = ((System.Windows.Controls.Button)(target));
            return;
            case 6:
            this.Profile = ((System.Windows.Controls.Button)(target));
            return;
            case 7:
            this.ButtonShowMenu = ((System.Windows.Controls.Button)(target));
            
            #line 87 "..\..\..\..\..\Views\Windows\Main.xaml"
            this.ButtonShowMenu.Click += new System.Windows.RoutedEventHandler(this.ButtonShowMenu_Click);
            
            #line default
            #line hidden
            return;
            case 8:
            this.ButtonHideMenu = ((System.Windows.Controls.Button)(target));
            
            #line 93 "..\..\..\..\..\Views\Windows\Main.xaml"
            this.ButtonHideMenu.Click += new System.Windows.RoutedEventHandler(this.ButtonHideMenu_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

