﻿#pragma checksum "..\..\..\..\UserControls\CardFlipUserControl\GamePage.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "6FDEEBAE961D0C82D827260631001F382CA24F39BC513A4065F5A5194E56A09E"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using CardFlip.UserControls.CardFlipUserControl;
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


namespace CardFlip.UserControls.CardFlipUserControl {
    
    
    /// <summary>
    /// GamePage
    /// </summary>
    public partial class GamePage : System.Windows.Controls.UserControl, System.Windows.Markup.IComponentConnector {
        
        
        #line 16 "..\..\..\..\UserControls\CardFlipUserControl\GamePage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.StackPanel timeLabelContainer;
        
        #line default
        #line hidden
        
        
        #line 19 "..\..\..\..\UserControls\CardFlipUserControl\GamePage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label timeLabel;
        
        #line default
        #line hidden
        
        
        #line 23 "..\..\..\..\UserControls\CardFlipUserControl\GamePage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Grid maincontainer;
        
        #line default
        #line hidden
        
        
        #line 24 "..\..\..\..\UserControls\CardFlipUserControl\GamePage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label StartTimeLabel;
        
        #line default
        #line hidden
        
        
        #line 27 "..\..\..\..\UserControls\CardFlipUserControl\GamePage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Border gamegridContainer;
        
        #line default
        #line hidden
        
        
        #line 28 "..\..\..\..\UserControls\CardFlipUserControl\GamePage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Grid gameGrid;
        
        #line default
        #line hidden
        
        
        #line 37 "..\..\..\..\UserControls\CardFlipUserControl\GamePage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button resetBtn;
        
        #line default
        #line hidden
        
        
        #line 39 "..\..\..\..\UserControls\CardFlipUserControl\GamePage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button Start;
        
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
            System.Uri resourceLocater = new System.Uri("/CardFlip;component/usercontrols/cardflipusercontrol/gamepage.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\UserControls\CardFlipUserControl\GamePage.xaml"
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
            this.timeLabelContainer = ((System.Windows.Controls.StackPanel)(target));
            return;
            case 2:
            this.timeLabel = ((System.Windows.Controls.Label)(target));
            return;
            case 3:
            this.maincontainer = ((System.Windows.Controls.Grid)(target));
            return;
            case 4:
            this.StartTimeLabel = ((System.Windows.Controls.Label)(target));
            return;
            case 5:
            this.gamegridContainer = ((System.Windows.Controls.Border)(target));
            return;
            case 6:
            this.gameGrid = ((System.Windows.Controls.Grid)(target));
            return;
            case 7:
            this.resetBtn = ((System.Windows.Controls.Button)(target));
            
            #line 37 "..\..\..\..\UserControls\CardFlipUserControl\GamePage.xaml"
            this.resetBtn.Click += new System.Windows.RoutedEventHandler(this.RestartClick);
            
            #line default
            #line hidden
            return;
            case 8:
            this.Start = ((System.Windows.Controls.Button)(target));
            
            #line 39 "..\..\..\..\UserControls\CardFlipUserControl\GamePage.xaml"
            this.Start.Click += new System.Windows.RoutedEventHandler(this.StartClick);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

