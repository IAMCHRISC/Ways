﻿#pragma checksum "..\..\..\OrientationQuestionWindow.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "1FC207DAEEFDFE16D38898ED11FB463F326D96D3"
//------------------------------------------------------------------------------
// <auto-generated>
//     Ce code a été généré par un outil.
//     Version du runtime :4.0.30319.42000
//
//     Les modifications apportées à ce fichier peuvent provoquer un comportement incorrect et seront perdues si
//     le code est régénéré.
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
using ways;


namespace ways {
    
    
    /// <summary>
    /// OrientationQuestionWindow
    /// </summary>
    public partial class OrientationQuestionWindow : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 18 "..\..\..\OrientationQuestionWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label numberOfQuestionsLabel;
        
        #line default
        #line hidden
        
        
        #line 20 "..\..\..\OrientationQuestionWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label resultsListLabel;
        
        #line default
        #line hidden
        
        
        #line 24 "..\..\..\OrientationQuestionWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label countLabel;
        
        #line default
        #line hidden
        
        
        #line 25 "..\..\..\OrientationQuestionWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock questionTitleLabel;
        
        #line default
        #line hidden
        
        
        #line 26 "..\..\..\OrientationQuestionWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.StackPanel answersStackPanel;
        
        #line default
        #line hidden
        
        
        #line 27 "..\..\..\OrientationQuestionWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label invalidAnswerLabel;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.8.1.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/ways;component/orientationquestionwindow.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\OrientationQuestionWindow.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.8.1.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            this.numberOfQuestionsLabel = ((System.Windows.Controls.Label)(target));
            return;
            case 2:
            this.resultsListLabel = ((System.Windows.Controls.Label)(target));
            return;
            case 3:
            this.countLabel = ((System.Windows.Controls.Label)(target));
            return;
            case 4:
            this.questionTitleLabel = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 5:
            this.answersStackPanel = ((System.Windows.Controls.StackPanel)(target));
            return;
            case 6:
            this.invalidAnswerLabel = ((System.Windows.Controls.Label)(target));
            return;
            case 7:
            
            #line 28 "..\..\..\OrientationQuestionWindow.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.ValidateAnswer);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

