﻿#pragma checksum "..\..\..\MainWindow.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "11CB65E145CD58A132E97842679A126B65AC74E4"
//------------------------------------------------------------------------------
// <auto-generated>
//     Ce code a été généré par un outil.
//     Version du runtime :4.0.30319.42000
//
//     Les modifications apportées à ce fichier peuvent provoquer un comportement incorrect et seront perdues si
//     le code est régénéré.
// </auto-generated>
//------------------------------------------------------------------------------

using SAE01;
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


namespace SAE01 {
    
    
    /// <summary>
    /// MainWindow
    /// </summary>
    public partial class MainWindow : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 22 "..\..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid dgConcess;
        
        #line default
        #line hidden
        
        
        #line 65 "..\..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Image logo_voiture;
        
        #line default
        #line hidden
        
        
        #line 82 "..\..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtBoxTriPrenom;
        
        #line default
        #line hidden
        
        
        #line 109 "..\..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button buttonSupprimerSelection;
        
        #line default
        #line hidden
        
        
        #line 119 "..\..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DatePicker dateDebutTri;
        
        #line default
        #line hidden
        
        
        #line 128 "..\..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DatePicker dateFinTri;
        
        #line default
        #line hidden
        
        
        #line 137 "..\..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button buttonEditEmprunt;
        
        #line default
        #line hidden
        
        
        #line 147 "..\..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button buttonSupprEmprunt;
        
        #line default
        #line hidden
        
        
        #line 157 "..\..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button buttonAddEmpunt;
        
        #line default
        #line hidden
        
        
        #line 167 "..\..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button buttonRefresh;
        
        #line default
        #line hidden
        
        
        #line 174 "..\..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Image imageRefresh;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "5.0.16.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/SAE01;component/mainwindow.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\MainWindow.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "5.0.16.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            this.dgConcess = ((System.Windows.Controls.DataGrid)(target));
            return;
            case 2:
            this.logo_voiture = ((System.Windows.Controls.Image)(target));
            return;
            case 3:
            this.txtBoxTriPrenom = ((System.Windows.Controls.TextBox)(target));
            
            #line 90 "..\..\..\MainWindow.xaml"
            this.txtBoxTriPrenom.KeyUp += new System.Windows.Input.KeyEventHandler(this.txtBoxTriPrenom_KeyUp);
            
            #line default
            #line hidden
            return;
            case 4:
            this.buttonSupprimerSelection = ((System.Windows.Controls.Button)(target));
            
            #line 116 "..\..\..\MainWindow.xaml"
            this.buttonSupprimerSelection.Click += new System.Windows.RoutedEventHandler(this.buttonSupprimerSelection_Click);
            
            #line default
            #line hidden
            return;
            case 5:
            this.dateDebutTri = ((System.Windows.Controls.DatePicker)(target));
            
            #line 126 "..\..\..\MainWindow.xaml"
            this.dateDebutTri.LostFocus += new System.Windows.RoutedEventHandler(this.dateDebutTri_LostFocus);
            
            #line default
            #line hidden
            return;
            case 6:
            this.dateFinTri = ((System.Windows.Controls.DatePicker)(target));
            
            #line 135 "..\..\..\MainWindow.xaml"
            this.dateFinTri.LostFocus += new System.Windows.RoutedEventHandler(this.dateFinTri_LostFocus);
            
            #line default
            #line hidden
            return;
            case 7:
            this.buttonEditEmprunt = ((System.Windows.Controls.Button)(target));
            
            #line 144 "..\..\..\MainWindow.xaml"
            this.buttonEditEmprunt.Click += new System.Windows.RoutedEventHandler(this.buttonEditEmprunt_Click);
            
            #line default
            #line hidden
            return;
            case 8:
            this.buttonSupprEmprunt = ((System.Windows.Controls.Button)(target));
            
            #line 154 "..\..\..\MainWindow.xaml"
            this.buttonSupprEmprunt.Click += new System.Windows.RoutedEventHandler(this.buttonSupprEmprunt_Click);
            
            #line default
            #line hidden
            return;
            case 9:
            this.buttonAddEmpunt = ((System.Windows.Controls.Button)(target));
            
            #line 164 "..\..\..\MainWindow.xaml"
            this.buttonAddEmpunt.Click += new System.Windows.RoutedEventHandler(this.buttonAddEmpunt_Click);
            
            #line default
            #line hidden
            return;
            case 10:
            this.buttonRefresh = ((System.Windows.Controls.Button)(target));
            
            #line 173 "..\..\..\MainWindow.xaml"
            this.buttonRefresh.Click += new System.Windows.RoutedEventHandler(this.buttonRefresh_Click);
            
            #line default
            #line hidden
            return;
            case 11:
            this.imageRefresh = ((System.Windows.Controls.Image)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

