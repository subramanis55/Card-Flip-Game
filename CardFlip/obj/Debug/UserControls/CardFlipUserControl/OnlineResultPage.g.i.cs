﻿#pragma checksum "..\..\..\..\UserControls\CardFlipUserControl\OnlineResultPage.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "3B0EF5ADE5800146CA270CE7BD389A07391BD9EBDD6E3D08EB4EFEAE93120361"
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
using CardFlip.UserControls.Common;
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
    /// OnlineResultPage
    /// </summary>
    public partial class OnlineResultPage : System.Windows.Controls.UserControl, System.Windows.Markup.IComponentConnector {
        
        
        #line 11 "..\..\..\..\UserControls\CardFlipUserControl\OnlineResultPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Grid MainGrid;
        
        #line default
        #line hidden
        
        
        #line 17 "..\..\..\..\UserControls\CardFlipUserControl\OnlineResultPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button resetBtn;
        
        #line default
        #line hidden
        
        
        #line 28 "..\..\..\..\UserControls\CardFlipUserControl\OnlineResultPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Grid container;
        
        #line default
        #line hidden
        
        
        #line 43 "..\..\..\..\UserControls\CardFlipUserControl\OnlineResultPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Border ScrollViewerContainer;
        
        #line default
        #line hidden
        
        
        #line 51 "..\..\..\..\UserControls\CardFlipUserControl\OnlineResultPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.StackPanel resultPanel;
        
        #line default
        #line hidden
        
        
        #line 57 "..\..\..\..\UserControls\CardFlipUserControl\OnlineResultPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Border ImageContainer;
        
        #line default
        #line hidden
        
        
        #line 58 "..\..\..\..\UserControls\CardFlipUserControl\OnlineResultPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal CardFlip.UserControls.Common.RoundedImage MemeImage;
        
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
            System.Uri resourceLocater = new System.Uri("/CardFlip;component/usercontrols/cardflipusercontrol/onlineresultpage.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\UserControls\CardFlipUserControl\OnlineResultPage.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal System.Delegate _CreateDelegate(System.Type delegateType, string handler) {
            return System.Delegate.CreateDelegate(delegateType, this, handler);
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
            
            #line 8 "..\..\..\..\UserControls\CardFlipUserControl\OnlineResultPage.xaml"
            ((CardFlip.UserControls.CardFlipUserControl.OnlineResultPage)(target)).SizeChanged += new System.Windows.SizeChangedEventHandler(this.resultcontrolSizeChanged);
            
            #line default
            #line hidden
            return;
            case 2:
            this.MainGrid = ((System.Windows.Controls.Grid)(target));
            return;
            case 3:
            this.resetBtn = ((System.Windows.Controls.Button)(target));
            
            #line 17 "..\..\..\..\UserControls\CardFlipUserControl\OnlineResultPage.xaml"
            this.resetBtn.Click += new System.Windows.RoutedEventHandler(this.RefreshClick);
            
            #line default
            #line hidden
            return;
            case 4:
            this.container = ((System.Windows.Controls.Grid)(target));
            return;
            case 5:
            this.ScrollViewerContainer = ((System.Windows.Controls.Border)(target));
            return;
            case 6:
            this.resultPanel = ((System.Windows.Controls.StackPanel)(target));
            return;
            case 7:
            this.ImageContainer = ((System.Windows.Controls.Border)(target));
            return;
            case 8:
            this.MemeImage = ((CardFlip.UserControls.Common.RoundedImage)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

