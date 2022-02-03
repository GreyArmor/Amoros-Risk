// -----------------------------------------------------------
//  
//  This file was generated, please do not modify.
//  
// -----------------------------------------------------------
namespace EmptyKeys.UserInterface.Generated {
    using System;
    using System.CodeDom.Compiler;
    using System.Collections.ObjectModel;
    using EmptyKeys.UserInterface;
    using EmptyKeys.UserInterface.Charts;
    using EmptyKeys.UserInterface.Data;
    using EmptyKeys.UserInterface.Controls;
    using EmptyKeys.UserInterface.Controls.Primitives;
    using EmptyKeys.UserInterface.Input;
    using EmptyKeys.UserInterface.Interactions.Core;
    using EmptyKeys.UserInterface.Interactivity;
    using EmptyKeys.UserInterface.Media;
    using EmptyKeys.UserInterface.Media.Effects;
    using EmptyKeys.UserInterface.Media.Animation;
    using EmptyKeys.UserInterface.Media.Imaging;
    using EmptyKeys.UserInterface.Shapes;
    using EmptyKeys.UserInterface.Renderers;
    using EmptyKeys.UserInterface.Themes;
    
    
    [GeneratedCodeAttribute("Empty Keys UI Generator", "3.2.0.0")]
    public partial class WindowRoot : UIRoot {
        
        private Grid e_0;
        
        private Grid e_1;
        
        private Grid e_2;
        
        private Button e_3;
        
        private Button e_4;
        
        private Button e_5;
        
        private Button e_6;
        
        public WindowRoot() : 
                base() {
            this.Initialize();
        }
        
        public WindowRoot(int width, int height) : 
                base(width, height) {
            this.Initialize();
        }
        
        private void Initialize() {
            Style style = RootStyle.CreateRootStyle();
            style.TargetType = this.GetType();
            this.Style = style;
            this.InitializeComponent();
        }
        
        private void InitializeComponent() {
            this.Background = new SolidColorBrush(new ColorW(100, 149, 237, 255));
            InitializeElementResources(this);
            // e_0 element
            this.e_0 = new Grid();
            this.Content = this.e_0;
            this.e_0.Name = "e_0";
            ColumnDefinition col_e_0_0 = new ColumnDefinition();
            this.e_0.ColumnDefinitions.Add(col_e_0_0);
            ColumnDefinition col_e_0_1 = new ColumnDefinition();
            this.e_0.ColumnDefinitions.Add(col_e_0_1);
            ColumnDefinition col_e_0_2 = new ColumnDefinition();
            this.e_0.ColumnDefinitions.Add(col_e_0_2);
            // e_1 element
            this.e_1 = new Grid();
            this.e_0.Children.Add(this.e_1);
            this.e_1.Name = "e_1";
            RowDefinition row_e_1_0 = new RowDefinition();
            this.e_1.RowDefinitions.Add(row_e_1_0);
            RowDefinition row_e_1_1 = new RowDefinition();
            row_e_1_1.Height = new GridLength(4F, GridUnitType.Star);
            this.e_1.RowDefinitions.Add(row_e_1_1);
            RowDefinition row_e_1_2 = new RowDefinition();
            this.e_1.RowDefinitions.Add(row_e_1_2);
            Grid.SetColumn(this.e_1, 1);
            // e_2 element
            this.e_2 = new Grid();
            this.e_1.Children.Add(this.e_2);
            this.e_2.Name = "e_2";
            RowDefinition row_e_2_0 = new RowDefinition();
            this.e_2.RowDefinitions.Add(row_e_2_0);
            RowDefinition row_e_2_1 = new RowDefinition();
            this.e_2.RowDefinitions.Add(row_e_2_1);
            RowDefinition row_e_2_2 = new RowDefinition();
            this.e_2.RowDefinitions.Add(row_e_2_2);
            RowDefinition row_e_2_3 = new RowDefinition();
            this.e_2.RowDefinitions.Add(row_e_2_3);
            Grid.SetRow(this.e_2, 1);
            // e_3 element
            this.e_3 = new Button();
            this.e_2.Children.Add(this.e_3);
            this.e_3.Name = "e_3";
#warning Style BasedOn is supported only in Dictionary.
            Style e_3_s = new Style(typeof(Button));
            Setter e_3_s_S_0 = new Setter(Button.MarginProperty, new Thickness(5F));
            e_3_s.Setters.Add(e_3_s_S_0);
            Setter e_3_s_S_1 = new Setter(Button.SnapsToDevicePixelsProperty, false);
            e_3_s.Setters.Add(e_3_s_S_1);
            EventTrigger e_3_s_ET_0 = new EventTrigger(Button.MouseEnterEvent);
            e_3_s.Triggers.Add(e_3_s_ET_0);
            BeginStoryboard e_3_s_ET_0_AC_0 = new BeginStoryboard();
            e_3_s_ET_0_AC_0.Name = "e_3_s_ET_0_AC_0";
            e_3_s_ET_0.AddAction(e_3_s_ET_0_AC_0);
            Storyboard e_3_s_ET_0_AC_0_SB = new Storyboard();
            e_3_s_ET_0_AC_0.Storyboard = e_3_s_ET_0_AC_0_SB;
            e_3_s_ET_0_AC_0_SB.Name = "e_3_s_ET_0_AC_0_SB";
            ThicknessAnimation e_3_s_ET_0_AC_0_SB_TL_0 = new ThicknessAnimation();
            e_3_s_ET_0_AC_0_SB_TL_0.Name = "e_3_s_ET_0_AC_0_SB_TL_0";
            e_3_s_ET_0_AC_0_SB_TL_0.Duration = new Duration(new TimeSpan(0, 0, 0, 0, 500));
            e_3_s_ET_0_AC_0_SB_TL_0.From = new Thickness(0F, 1F, 0F, 1F);
            e_3_s_ET_0_AC_0_SB_TL_0.To = new Thickness(0F, 5F, 0F, 5F);
            SineEase e_3_s_ET_0_AC_0_SB_TL_0_EA = new SineEase();
            e_3_s_ET_0_AC_0_SB_TL_0.EasingFunction = e_3_s_ET_0_AC_0_SB_TL_0_EA;
            Storyboard.SetTargetProperty(e_3_s_ET_0_AC_0_SB_TL_0, Button.MarginProperty);
            e_3_s_ET_0_AC_0_SB.Children.Add(e_3_s_ET_0_AC_0_SB_TL_0);
            FloatAnimation e_3_s_ET_0_AC_0_SB_TL_1 = new FloatAnimation();
            e_3_s_ET_0_AC_0_SB_TL_1.Name = "e_3_s_ET_0_AC_0_SB_TL_1";
            e_3_s_ET_0_AC_0_SB_TL_1.Duration = new Duration(new TimeSpan(0, 0, 0, 0, 500));
            e_3_s_ET_0_AC_0_SB_TL_1.To = 220F;
            SineEase e_3_s_ET_0_AC_0_SB_TL_1_EA = new SineEase();
            e_3_s_ET_0_AC_0_SB_TL_1.EasingFunction = e_3_s_ET_0_AC_0_SB_TL_1_EA;
            Storyboard.SetTargetProperty(e_3_s_ET_0_AC_0_SB_TL_1, Button.WidthProperty);
            e_3_s_ET_0_AC_0_SB.Children.Add(e_3_s_ET_0_AC_0_SB_TL_1);
            EventTrigger e_3_s_ET_1 = new EventTrigger(Button.MouseLeaveEvent);
            e_3_s.Triggers.Add(e_3_s_ET_1);
            BeginStoryboard e_3_s_ET_1_AC_0 = new BeginStoryboard();
            e_3_s_ET_1_AC_0.Name = "e_3_s_ET_1_AC_0";
            e_3_s_ET_1.AddAction(e_3_s_ET_1_AC_0);
            Storyboard e_3_s_ET_1_AC_0_SB = new Storyboard();
            e_3_s_ET_1_AC_0.Storyboard = e_3_s_ET_1_AC_0_SB;
            e_3_s_ET_1_AC_0_SB.Name = "e_3_s_ET_1_AC_0_SB";
            ThicknessAnimation e_3_s_ET_1_AC_0_SB_TL_0 = new ThicknessAnimation();
            e_3_s_ET_1_AC_0_SB_TL_0.Name = "e_3_s_ET_1_AC_0_SB_TL_0";
            e_3_s_ET_1_AC_0_SB_TL_0.Duration = new Duration(new TimeSpan(0, 0, 0, 0, 500));
            e_3_s_ET_1_AC_0_SB_TL_0.From = new Thickness(0F, 5F, 0F, 5F);
            e_3_s_ET_1_AC_0_SB_TL_0.To = new Thickness(0F, 1F, 0F, 1F);
            SineEase e_3_s_ET_1_AC_0_SB_TL_0_EA = new SineEase();
            e_3_s_ET_1_AC_0_SB_TL_0.EasingFunction = e_3_s_ET_1_AC_0_SB_TL_0_EA;
            Storyboard.SetTargetProperty(e_3_s_ET_1_AC_0_SB_TL_0, Button.MarginProperty);
            e_3_s_ET_1_AC_0_SB.Children.Add(e_3_s_ET_1_AC_0_SB_TL_0);
            FloatAnimation e_3_s_ET_1_AC_0_SB_TL_1 = new FloatAnimation();
            e_3_s_ET_1_AC_0_SB_TL_1.Name = "e_3_s_ET_1_AC_0_SB_TL_1";
            e_3_s_ET_1_AC_0_SB_TL_1.Duration = new Duration(new TimeSpan(0, 0, 0, 0, 500));
            e_3_s_ET_1_AC_0_SB_TL_1.To = 200F;
            SineEase e_3_s_ET_1_AC_0_SB_TL_1_EA = new SineEase();
            e_3_s_ET_1_AC_0_SB_TL_1.EasingFunction = e_3_s_ET_1_AC_0_SB_TL_1_EA;
            Storyboard.SetTargetProperty(e_3_s_ET_1_AC_0_SB_TL_1, Button.WidthProperty);
            e_3_s_ET_1_AC_0_SB.Children.Add(e_3_s_ET_1_AC_0_SB_TL_1);
            this.e_3.Style = e_3_s;
            this.e_3.Content = "New game";
            Grid.SetRow(this.e_3, 0);
            // e_4 element
            this.e_4 = new Button();
            this.e_2.Children.Add(this.e_4);
            this.e_4.Name = "e_4";
#warning Style BasedOn is supported only in Dictionary.
            Style e_4_s = new Style(typeof(Button));
            Setter e_4_s_S_0 = new Setter(Button.MarginProperty, new Thickness(5F));
            e_4_s.Setters.Add(e_4_s_S_0);
            Setter e_4_s_S_1 = new Setter(Button.SnapsToDevicePixelsProperty, false);
            e_4_s.Setters.Add(e_4_s_S_1);
            EventTrigger e_4_s_ET_0 = new EventTrigger(Button.MouseEnterEvent);
            e_4_s.Triggers.Add(e_4_s_ET_0);
            BeginStoryboard e_4_s_ET_0_AC_0 = new BeginStoryboard();
            e_4_s_ET_0_AC_0.Name = "e_4_s_ET_0_AC_0";
            e_4_s_ET_0.AddAction(e_4_s_ET_0_AC_0);
            Storyboard e_4_s_ET_0_AC_0_SB = new Storyboard();
            e_4_s_ET_0_AC_0.Storyboard = e_4_s_ET_0_AC_0_SB;
            e_4_s_ET_0_AC_0_SB.Name = "e_4_s_ET_0_AC_0_SB";
            ThicknessAnimation e_4_s_ET_0_AC_0_SB_TL_0 = new ThicknessAnimation();
            e_4_s_ET_0_AC_0_SB_TL_0.Name = "e_4_s_ET_0_AC_0_SB_TL_0";
            e_4_s_ET_0_AC_0_SB_TL_0.Duration = new Duration(new TimeSpan(0, 0, 0, 0, 500));
            e_4_s_ET_0_AC_0_SB_TL_0.From = new Thickness(0F, 1F, 0F, 1F);
            e_4_s_ET_0_AC_0_SB_TL_0.To = new Thickness(0F, 5F, 0F, 5F);
            SineEase e_4_s_ET_0_AC_0_SB_TL_0_EA = new SineEase();
            e_4_s_ET_0_AC_0_SB_TL_0.EasingFunction = e_4_s_ET_0_AC_0_SB_TL_0_EA;
            Storyboard.SetTargetProperty(e_4_s_ET_0_AC_0_SB_TL_0, Button.MarginProperty);
            e_4_s_ET_0_AC_0_SB.Children.Add(e_4_s_ET_0_AC_0_SB_TL_0);
            FloatAnimation e_4_s_ET_0_AC_0_SB_TL_1 = new FloatAnimation();
            e_4_s_ET_0_AC_0_SB_TL_1.Name = "e_4_s_ET_0_AC_0_SB_TL_1";
            e_4_s_ET_0_AC_0_SB_TL_1.Duration = new Duration(new TimeSpan(0, 0, 0, 0, 500));
            e_4_s_ET_0_AC_0_SB_TL_1.To = 220F;
            SineEase e_4_s_ET_0_AC_0_SB_TL_1_EA = new SineEase();
            e_4_s_ET_0_AC_0_SB_TL_1.EasingFunction = e_4_s_ET_0_AC_0_SB_TL_1_EA;
            Storyboard.SetTargetProperty(e_4_s_ET_0_AC_0_SB_TL_1, Button.WidthProperty);
            e_4_s_ET_0_AC_0_SB.Children.Add(e_4_s_ET_0_AC_0_SB_TL_1);
            EventTrigger e_4_s_ET_1 = new EventTrigger(Button.MouseLeaveEvent);
            e_4_s.Triggers.Add(e_4_s_ET_1);
            BeginStoryboard e_4_s_ET_1_AC_0 = new BeginStoryboard();
            e_4_s_ET_1_AC_0.Name = "e_4_s_ET_1_AC_0";
            e_4_s_ET_1.AddAction(e_4_s_ET_1_AC_0);
            Storyboard e_4_s_ET_1_AC_0_SB = new Storyboard();
            e_4_s_ET_1_AC_0.Storyboard = e_4_s_ET_1_AC_0_SB;
            e_4_s_ET_1_AC_0_SB.Name = "e_4_s_ET_1_AC_0_SB";
            ThicknessAnimation e_4_s_ET_1_AC_0_SB_TL_0 = new ThicknessAnimation();
            e_4_s_ET_1_AC_0_SB_TL_0.Name = "e_4_s_ET_1_AC_0_SB_TL_0";
            e_4_s_ET_1_AC_0_SB_TL_0.Duration = new Duration(new TimeSpan(0, 0, 0, 0, 500));
            e_4_s_ET_1_AC_0_SB_TL_0.From = new Thickness(0F, 5F, 0F, 5F);
            e_4_s_ET_1_AC_0_SB_TL_0.To = new Thickness(0F, 1F, 0F, 1F);
            SineEase e_4_s_ET_1_AC_0_SB_TL_0_EA = new SineEase();
            e_4_s_ET_1_AC_0_SB_TL_0.EasingFunction = e_4_s_ET_1_AC_0_SB_TL_0_EA;
            Storyboard.SetTargetProperty(e_4_s_ET_1_AC_0_SB_TL_0, Button.MarginProperty);
            e_4_s_ET_1_AC_0_SB.Children.Add(e_4_s_ET_1_AC_0_SB_TL_0);
            FloatAnimation e_4_s_ET_1_AC_0_SB_TL_1 = new FloatAnimation();
            e_4_s_ET_1_AC_0_SB_TL_1.Name = "e_4_s_ET_1_AC_0_SB_TL_1";
            e_4_s_ET_1_AC_0_SB_TL_1.Duration = new Duration(new TimeSpan(0, 0, 0, 0, 500));
            e_4_s_ET_1_AC_0_SB_TL_1.To = 200F;
            SineEase e_4_s_ET_1_AC_0_SB_TL_1_EA = new SineEase();
            e_4_s_ET_1_AC_0_SB_TL_1.EasingFunction = e_4_s_ET_1_AC_0_SB_TL_1_EA;
            Storyboard.SetTargetProperty(e_4_s_ET_1_AC_0_SB_TL_1, Button.WidthProperty);
            e_4_s_ET_1_AC_0_SB.Children.Add(e_4_s_ET_1_AC_0_SB_TL_1);
            this.e_4.Style = e_4_s;
            this.e_4.Content = "Multiplayer";
            Grid.SetRow(this.e_4, 1);
            // e_5 element
            this.e_5 = new Button();
            this.e_2.Children.Add(this.e_5);
            this.e_5.Name = "e_5";
#warning Style BasedOn is supported only in Dictionary.
            Style e_5_s = new Style(typeof(Button));
            Setter e_5_s_S_0 = new Setter(Button.MarginProperty, new Thickness(5F));
            e_5_s.Setters.Add(e_5_s_S_0);
            Setter e_5_s_S_1 = new Setter(Button.SnapsToDevicePixelsProperty, false);
            e_5_s.Setters.Add(e_5_s_S_1);
            EventTrigger e_5_s_ET_0 = new EventTrigger(Button.MouseEnterEvent);
            e_5_s.Triggers.Add(e_5_s_ET_0);
            BeginStoryboard e_5_s_ET_0_AC_0 = new BeginStoryboard();
            e_5_s_ET_0_AC_0.Name = "e_5_s_ET_0_AC_0";
            e_5_s_ET_0.AddAction(e_5_s_ET_0_AC_0);
            Storyboard e_5_s_ET_0_AC_0_SB = new Storyboard();
            e_5_s_ET_0_AC_0.Storyboard = e_5_s_ET_0_AC_0_SB;
            e_5_s_ET_0_AC_0_SB.Name = "e_5_s_ET_0_AC_0_SB";
            ThicknessAnimation e_5_s_ET_0_AC_0_SB_TL_0 = new ThicknessAnimation();
            e_5_s_ET_0_AC_0_SB_TL_0.Name = "e_5_s_ET_0_AC_0_SB_TL_0";
            e_5_s_ET_0_AC_0_SB_TL_0.Duration = new Duration(new TimeSpan(0, 0, 0, 0, 500));
            e_5_s_ET_0_AC_0_SB_TL_0.From = new Thickness(0F, 1F, 0F, 1F);
            e_5_s_ET_0_AC_0_SB_TL_0.To = new Thickness(0F, 5F, 0F, 5F);
            SineEase e_5_s_ET_0_AC_0_SB_TL_0_EA = new SineEase();
            e_5_s_ET_0_AC_0_SB_TL_0.EasingFunction = e_5_s_ET_0_AC_0_SB_TL_0_EA;
            Storyboard.SetTargetProperty(e_5_s_ET_0_AC_0_SB_TL_0, Button.MarginProperty);
            e_5_s_ET_0_AC_0_SB.Children.Add(e_5_s_ET_0_AC_0_SB_TL_0);
            FloatAnimation e_5_s_ET_0_AC_0_SB_TL_1 = new FloatAnimation();
            e_5_s_ET_0_AC_0_SB_TL_1.Name = "e_5_s_ET_0_AC_0_SB_TL_1";
            e_5_s_ET_0_AC_0_SB_TL_1.Duration = new Duration(new TimeSpan(0, 0, 0, 0, 500));
            e_5_s_ET_0_AC_0_SB_TL_1.To = 220F;
            SineEase e_5_s_ET_0_AC_0_SB_TL_1_EA = new SineEase();
            e_5_s_ET_0_AC_0_SB_TL_1.EasingFunction = e_5_s_ET_0_AC_0_SB_TL_1_EA;
            Storyboard.SetTargetProperty(e_5_s_ET_0_AC_0_SB_TL_1, Button.WidthProperty);
            e_5_s_ET_0_AC_0_SB.Children.Add(e_5_s_ET_0_AC_0_SB_TL_1);
            EventTrigger e_5_s_ET_1 = new EventTrigger(Button.MouseLeaveEvent);
            e_5_s.Triggers.Add(e_5_s_ET_1);
            BeginStoryboard e_5_s_ET_1_AC_0 = new BeginStoryboard();
            e_5_s_ET_1_AC_0.Name = "e_5_s_ET_1_AC_0";
            e_5_s_ET_1.AddAction(e_5_s_ET_1_AC_0);
            Storyboard e_5_s_ET_1_AC_0_SB = new Storyboard();
            e_5_s_ET_1_AC_0.Storyboard = e_5_s_ET_1_AC_0_SB;
            e_5_s_ET_1_AC_0_SB.Name = "e_5_s_ET_1_AC_0_SB";
            ThicknessAnimation e_5_s_ET_1_AC_0_SB_TL_0 = new ThicknessAnimation();
            e_5_s_ET_1_AC_0_SB_TL_0.Name = "e_5_s_ET_1_AC_0_SB_TL_0";
            e_5_s_ET_1_AC_0_SB_TL_0.Duration = new Duration(new TimeSpan(0, 0, 0, 0, 500));
            e_5_s_ET_1_AC_0_SB_TL_0.From = new Thickness(0F, 5F, 0F, 5F);
            e_5_s_ET_1_AC_0_SB_TL_0.To = new Thickness(0F, 1F, 0F, 1F);
            SineEase e_5_s_ET_1_AC_0_SB_TL_0_EA = new SineEase();
            e_5_s_ET_1_AC_0_SB_TL_0.EasingFunction = e_5_s_ET_1_AC_0_SB_TL_0_EA;
            Storyboard.SetTargetProperty(e_5_s_ET_1_AC_0_SB_TL_0, Button.MarginProperty);
            e_5_s_ET_1_AC_0_SB.Children.Add(e_5_s_ET_1_AC_0_SB_TL_0);
            FloatAnimation e_5_s_ET_1_AC_0_SB_TL_1 = new FloatAnimation();
            e_5_s_ET_1_AC_0_SB_TL_1.Name = "e_5_s_ET_1_AC_0_SB_TL_1";
            e_5_s_ET_1_AC_0_SB_TL_1.Duration = new Duration(new TimeSpan(0, 0, 0, 0, 500));
            e_5_s_ET_1_AC_0_SB_TL_1.To = 200F;
            SineEase e_5_s_ET_1_AC_0_SB_TL_1_EA = new SineEase();
            e_5_s_ET_1_AC_0_SB_TL_1.EasingFunction = e_5_s_ET_1_AC_0_SB_TL_1_EA;
            Storyboard.SetTargetProperty(e_5_s_ET_1_AC_0_SB_TL_1, Button.WidthProperty);
            e_5_s_ET_1_AC_0_SB.Children.Add(e_5_s_ET_1_AC_0_SB_TL_1);
            this.e_5.Style = e_5_s;
            this.e_5.Content = "Highscores";
            Grid.SetRow(this.e_5, 2);
            // e_6 element
            this.e_6 = new Button();
            this.e_2.Children.Add(this.e_6);
            this.e_6.Name = "e_6";
#warning Style BasedOn is supported only in Dictionary.
            Style e_6_s = new Style(typeof(Button));
            Setter e_6_s_S_0 = new Setter(Button.MarginProperty, new Thickness(5F));
            e_6_s.Setters.Add(e_6_s_S_0);
            Setter e_6_s_S_1 = new Setter(Button.SnapsToDevicePixelsProperty, false);
            e_6_s.Setters.Add(e_6_s_S_1);
            EventTrigger e_6_s_ET_0 = new EventTrigger(Button.MouseEnterEvent);
            e_6_s.Triggers.Add(e_6_s_ET_0);
            BeginStoryboard e_6_s_ET_0_AC_0 = new BeginStoryboard();
            e_6_s_ET_0_AC_0.Name = "e_6_s_ET_0_AC_0";
            e_6_s_ET_0.AddAction(e_6_s_ET_0_AC_0);
            Storyboard e_6_s_ET_0_AC_0_SB = new Storyboard();
            e_6_s_ET_0_AC_0.Storyboard = e_6_s_ET_0_AC_0_SB;
            e_6_s_ET_0_AC_0_SB.Name = "e_6_s_ET_0_AC_0_SB";
            ThicknessAnimation e_6_s_ET_0_AC_0_SB_TL_0 = new ThicknessAnimation();
            e_6_s_ET_0_AC_0_SB_TL_0.Name = "e_6_s_ET_0_AC_0_SB_TL_0";
            e_6_s_ET_0_AC_0_SB_TL_0.Duration = new Duration(new TimeSpan(0, 0, 0, 0, 500));
            e_6_s_ET_0_AC_0_SB_TL_0.From = new Thickness(0F, 1F, 0F, 1F);
            e_6_s_ET_0_AC_0_SB_TL_0.To = new Thickness(0F, 5F, 0F, 5F);
            SineEase e_6_s_ET_0_AC_0_SB_TL_0_EA = new SineEase();
            e_6_s_ET_0_AC_0_SB_TL_0.EasingFunction = e_6_s_ET_0_AC_0_SB_TL_0_EA;
            Storyboard.SetTargetProperty(e_6_s_ET_0_AC_0_SB_TL_0, Button.MarginProperty);
            e_6_s_ET_0_AC_0_SB.Children.Add(e_6_s_ET_0_AC_0_SB_TL_0);
            FloatAnimation e_6_s_ET_0_AC_0_SB_TL_1 = new FloatAnimation();
            e_6_s_ET_0_AC_0_SB_TL_1.Name = "e_6_s_ET_0_AC_0_SB_TL_1";
            e_6_s_ET_0_AC_0_SB_TL_1.Duration = new Duration(new TimeSpan(0, 0, 0, 0, 500));
            e_6_s_ET_0_AC_0_SB_TL_1.To = 220F;
            SineEase e_6_s_ET_0_AC_0_SB_TL_1_EA = new SineEase();
            e_6_s_ET_0_AC_0_SB_TL_1.EasingFunction = e_6_s_ET_0_AC_0_SB_TL_1_EA;
            Storyboard.SetTargetProperty(e_6_s_ET_0_AC_0_SB_TL_1, Button.WidthProperty);
            e_6_s_ET_0_AC_0_SB.Children.Add(e_6_s_ET_0_AC_0_SB_TL_1);
            EventTrigger e_6_s_ET_1 = new EventTrigger(Button.MouseLeaveEvent);
            e_6_s.Triggers.Add(e_6_s_ET_1);
            BeginStoryboard e_6_s_ET_1_AC_0 = new BeginStoryboard();
            e_6_s_ET_1_AC_0.Name = "e_6_s_ET_1_AC_0";
            e_6_s_ET_1.AddAction(e_6_s_ET_1_AC_0);
            Storyboard e_6_s_ET_1_AC_0_SB = new Storyboard();
            e_6_s_ET_1_AC_0.Storyboard = e_6_s_ET_1_AC_0_SB;
            e_6_s_ET_1_AC_0_SB.Name = "e_6_s_ET_1_AC_0_SB";
            ThicknessAnimation e_6_s_ET_1_AC_0_SB_TL_0 = new ThicknessAnimation();
            e_6_s_ET_1_AC_0_SB_TL_0.Name = "e_6_s_ET_1_AC_0_SB_TL_0";
            e_6_s_ET_1_AC_0_SB_TL_0.Duration = new Duration(new TimeSpan(0, 0, 0, 0, 500));
            e_6_s_ET_1_AC_0_SB_TL_0.From = new Thickness(0F, 5F, 0F, 5F);
            e_6_s_ET_1_AC_0_SB_TL_0.To = new Thickness(0F, 1F, 0F, 1F);
            SineEase e_6_s_ET_1_AC_0_SB_TL_0_EA = new SineEase();
            e_6_s_ET_1_AC_0_SB_TL_0.EasingFunction = e_6_s_ET_1_AC_0_SB_TL_0_EA;
            Storyboard.SetTargetProperty(e_6_s_ET_1_AC_0_SB_TL_0, Button.MarginProperty);
            e_6_s_ET_1_AC_0_SB.Children.Add(e_6_s_ET_1_AC_0_SB_TL_0);
            FloatAnimation e_6_s_ET_1_AC_0_SB_TL_1 = new FloatAnimation();
            e_6_s_ET_1_AC_0_SB_TL_1.Name = "e_6_s_ET_1_AC_0_SB_TL_1";
            e_6_s_ET_1_AC_0_SB_TL_1.Duration = new Duration(new TimeSpan(0, 0, 0, 0, 500));
            e_6_s_ET_1_AC_0_SB_TL_1.To = 200F;
            SineEase e_6_s_ET_1_AC_0_SB_TL_1_EA = new SineEase();
            e_6_s_ET_1_AC_0_SB_TL_1.EasingFunction = e_6_s_ET_1_AC_0_SB_TL_1_EA;
            Storyboard.SetTargetProperty(e_6_s_ET_1_AC_0_SB_TL_1, Button.WidthProperty);
            e_6_s_ET_1_AC_0_SB.Children.Add(e_6_s_ET_1_AC_0_SB_TL_1);
            this.e_6.Style = e_6_s;
            this.e_6.Content = "Exit";
            Grid.SetRow(this.e_6, 3);
        }
        
        private static void InitializeElementResources(UIElement elem) {
            // Resource - [buttonAnimStyle] Style
            var r_0_s_bo = elem.Resources[typeof(Button)];
            Style r_0_s = new Style(typeof(Button), r_0_s_bo as Style);
            Setter r_0_s_S_0 = new Setter(Button.MarginProperty, new Thickness(5F));
            r_0_s.Setters.Add(r_0_s_S_0);
            Setter r_0_s_S_1 = new Setter(Button.SnapsToDevicePixelsProperty, false);
            r_0_s.Setters.Add(r_0_s_S_1);
            EventTrigger r_0_s_ET_0 = new EventTrigger(Button.MouseEnterEvent);
            r_0_s.Triggers.Add(r_0_s_ET_0);
            BeginStoryboard r_0_s_ET_0_AC_0 = new BeginStoryboard();
            r_0_s_ET_0_AC_0.Name = "r_0_s_ET_0_AC_0";
            r_0_s_ET_0.AddAction(r_0_s_ET_0_AC_0);
            Storyboard r_0_s_ET_0_AC_0_SB = new Storyboard();
            r_0_s_ET_0_AC_0.Storyboard = r_0_s_ET_0_AC_0_SB;
            r_0_s_ET_0_AC_0_SB.Name = "r_0_s_ET_0_AC_0_SB";
            ThicknessAnimation r_0_s_ET_0_AC_0_SB_TL_0 = new ThicknessAnimation();
            r_0_s_ET_0_AC_0_SB_TL_0.Name = "r_0_s_ET_0_AC_0_SB_TL_0";
            r_0_s_ET_0_AC_0_SB_TL_0.Duration = new Duration(new TimeSpan(0, 0, 0, 0, 500));
            r_0_s_ET_0_AC_0_SB_TL_0.From = new Thickness(0F, 1F, 0F, 1F);
            r_0_s_ET_0_AC_0_SB_TL_0.To = new Thickness(0F, 5F, 0F, 5F);
            SineEase r_0_s_ET_0_AC_0_SB_TL_0_EA = new SineEase();
            r_0_s_ET_0_AC_0_SB_TL_0.EasingFunction = r_0_s_ET_0_AC_0_SB_TL_0_EA;
            Storyboard.SetTargetProperty(r_0_s_ET_0_AC_0_SB_TL_0, Button.MarginProperty);
            r_0_s_ET_0_AC_0_SB.Children.Add(r_0_s_ET_0_AC_0_SB_TL_0);
            FloatAnimation r_0_s_ET_0_AC_0_SB_TL_1 = new FloatAnimation();
            r_0_s_ET_0_AC_0_SB_TL_1.Name = "r_0_s_ET_0_AC_0_SB_TL_1";
            r_0_s_ET_0_AC_0_SB_TL_1.Duration = new Duration(new TimeSpan(0, 0, 0, 0, 500));
            r_0_s_ET_0_AC_0_SB_TL_1.To = 220F;
            SineEase r_0_s_ET_0_AC_0_SB_TL_1_EA = new SineEase();
            r_0_s_ET_0_AC_0_SB_TL_1.EasingFunction = r_0_s_ET_0_AC_0_SB_TL_1_EA;
            Storyboard.SetTargetProperty(r_0_s_ET_0_AC_0_SB_TL_1, Button.WidthProperty);
            r_0_s_ET_0_AC_0_SB.Children.Add(r_0_s_ET_0_AC_0_SB_TL_1);
            EventTrigger r_0_s_ET_1 = new EventTrigger(Button.MouseLeaveEvent);
            r_0_s.Triggers.Add(r_0_s_ET_1);
            BeginStoryboard r_0_s_ET_1_AC_0 = new BeginStoryboard();
            r_0_s_ET_1_AC_0.Name = "r_0_s_ET_1_AC_0";
            r_0_s_ET_1.AddAction(r_0_s_ET_1_AC_0);
            Storyboard r_0_s_ET_1_AC_0_SB = new Storyboard();
            r_0_s_ET_1_AC_0.Storyboard = r_0_s_ET_1_AC_0_SB;
            r_0_s_ET_1_AC_0_SB.Name = "r_0_s_ET_1_AC_0_SB";
            ThicknessAnimation r_0_s_ET_1_AC_0_SB_TL_0 = new ThicknessAnimation();
            r_0_s_ET_1_AC_0_SB_TL_0.Name = "r_0_s_ET_1_AC_0_SB_TL_0";
            r_0_s_ET_1_AC_0_SB_TL_0.Duration = new Duration(new TimeSpan(0, 0, 0, 0, 500));
            r_0_s_ET_1_AC_0_SB_TL_0.From = new Thickness(0F, 5F, 0F, 5F);
            r_0_s_ET_1_AC_0_SB_TL_0.To = new Thickness(0F, 1F, 0F, 1F);
            SineEase r_0_s_ET_1_AC_0_SB_TL_0_EA = new SineEase();
            r_0_s_ET_1_AC_0_SB_TL_0.EasingFunction = r_0_s_ET_1_AC_0_SB_TL_0_EA;
            Storyboard.SetTargetProperty(r_0_s_ET_1_AC_0_SB_TL_0, Button.MarginProperty);
            r_0_s_ET_1_AC_0_SB.Children.Add(r_0_s_ET_1_AC_0_SB_TL_0);
            FloatAnimation r_0_s_ET_1_AC_0_SB_TL_1 = new FloatAnimation();
            r_0_s_ET_1_AC_0_SB_TL_1.Name = "r_0_s_ET_1_AC_0_SB_TL_1";
            r_0_s_ET_1_AC_0_SB_TL_1.Duration = new Duration(new TimeSpan(0, 0, 0, 0, 500));
            r_0_s_ET_1_AC_0_SB_TL_1.To = 200F;
            SineEase r_0_s_ET_1_AC_0_SB_TL_1_EA = new SineEase();
            r_0_s_ET_1_AC_0_SB_TL_1.EasingFunction = r_0_s_ET_1_AC_0_SB_TL_1_EA;
            Storyboard.SetTargetProperty(r_0_s_ET_1_AC_0_SB_TL_1, Button.WidthProperty);
            r_0_s_ET_1_AC_0_SB.Children.Add(r_0_s_ET_1_AC_0_SB_TL_1);
            elem.Resources.Add("buttonAnimStyle", r_0_s);
            // Resource - [buttonStyle] Style
            var r_1_s_bo = elem.Resources[typeof(Button)];
            Style r_1_s = new Style(typeof(Button), r_1_s_bo as Style);
            Setter r_1_s_S_0 = new Setter(Button.ForegroundProperty, new SolidColorBrush(new ColorW(255, 255, 255, 255)));
            r_1_s.Setters.Add(r_1_s_S_0);
            Setter r_1_s_S_1 = new Setter(Button.BackgroundProperty, new SolidColorBrush(new ColorW(255, 140, 0, 255)));
            r_1_s.Setters.Add(r_1_s_S_1);
            Setter r_1_s_S_2 = new Setter(Button.MarginProperty, new Thickness(5F));
            r_1_s.Setters.Add(r_1_s_S_2);
            elem.Resources.Add("buttonStyle", r_1_s);
        }
    }
}
