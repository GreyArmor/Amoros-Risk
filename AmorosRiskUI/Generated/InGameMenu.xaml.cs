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
    
    
    [GeneratedCodeAttribute("Empty Keys UI Generator", "3.3.0.0")]
    public partial class InGameMenu : UserControl {
        
        private Grid e_0;
        
        private Grid e_1;
        
        private Grid e_2;
        
        private Button e_3;
        
        public InGameMenu() {
            Style style = UserControlStyle.CreateUserControlStyle();
            style.TargetType = this.GetType();
            this.Style = style;
            this.InitializeComponent();
        }
        
        private void InitializeComponent() {
            InitializeElementResources(this);
            // e_0 element
            this.e_0 = new Grid();
            this.Content = this.e_0;
            this.e_0.Name = "e_0";
            // e_1 element
            this.e_1 = new Grid();
            this.e_0.Children.Add(this.e_1);
            this.e_1.Name = "e_1";
            RowDefinition row_e_1_0 = new RowDefinition();
            row_e_1_0.Height = new GridLength(9F, GridUnitType.Star);
            this.e_1.RowDefinitions.Add(row_e_1_0);
            RowDefinition row_e_1_1 = new RowDefinition();
            this.e_1.RowDefinitions.Add(row_e_1_1);
            Grid.SetColumn(this.e_1, 1);
            // e_2 element
            this.e_2 = new Grid();
            this.e_1.Children.Add(this.e_2);
            this.e_2.Name = "e_2";
            ColumnDefinition col_e_2_0 = new ColumnDefinition();
            this.e_2.ColumnDefinitions.Add(col_e_2_0);
            ColumnDefinition col_e_2_1 = new ColumnDefinition();
            this.e_2.ColumnDefinitions.Add(col_e_2_1);
            ColumnDefinition col_e_2_2 = new ColumnDefinition();
            this.e_2.ColumnDefinitions.Add(col_e_2_2);
            ColumnDefinition col_e_2_3 = new ColumnDefinition();
            this.e_2.ColumnDefinitions.Add(col_e_2_3);
            Grid.SetRow(this.e_2, 1);
            // e_3 element
            this.e_3 = new Button();
            this.e_2.Children.Add(this.e_3);
            this.e_3.Name = "e_3";
            this.e_3.Content = "Back";
            Grid.SetRow(this.e_3, 0);
            Binding binding_e_3_Command = new Binding("BackCommand");
            this.e_3.SetBinding(Button.CommandProperty, binding_e_3_Command);
        }
        
        private static void InitializeElementResources(UIElement elem) {
            // Resource - [gridImageStyle] Style
            Style r_0_s = new Style(typeof(ImageButton));
            Setter r_0_s_S_0 = new Setter(ImageButton.WidthProperty, float.NaN);
            r_0_s.Setters.Add(r_0_s_S_0);
            Setter r_0_s_S_1 = new Setter(ImageButton.MarginProperty, new Thickness(0F, 1F, 0F, 1F));
            r_0_s.Setters.Add(r_0_s_S_1);
            EventTrigger r_0_s_ET_0 = new EventTrigger(ImageButton.MouseEnterEvent);
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
            Storyboard.SetTargetProperty(r_0_s_ET_0_AC_0_SB_TL_0, ImageButton.MarginProperty);
            r_0_s_ET_0_AC_0_SB.Children.Add(r_0_s_ET_0_AC_0_SB_TL_0);
            EventTrigger r_0_s_ET_1 = new EventTrigger(ImageButton.MouseLeaveEvent);
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
            Storyboard.SetTargetProperty(r_0_s_ET_1_AC_0_SB_TL_0, ImageButton.MarginProperty);
            r_0_s_ET_1_AC_0_SB.Children.Add(r_0_s_ET_1_AC_0_SB_TL_0);
            FloatAnimation r_0_s_ET_1_AC_0_SB_TL_1 = new FloatAnimation();
            r_0_s_ET_1_AC_0_SB_TL_1.Name = "r_0_s_ET_1_AC_0_SB_TL_1";
            r_0_s_ET_1_AC_0_SB_TL_1.Duration = new Duration(new TimeSpan(0, 0, 0, 0, 500));
            r_0_s_ET_1_AC_0_SB_TL_1.To = 200F;
            SineEase r_0_s_ET_1_AC_0_SB_TL_1_EA = new SineEase();
            r_0_s_ET_1_AC_0_SB_TL_1.EasingFunction = r_0_s_ET_1_AC_0_SB_TL_1_EA;
            Storyboard.SetTargetProperty(r_0_s_ET_1_AC_0_SB_TL_1, ImageButton.WidthProperty);
            r_0_s_ET_1_AC_0_SB.Children.Add(r_0_s_ET_1_AC_0_SB_TL_1);
            elem.Resources.Add("gridImageStyle", r_0_s);
        }
    }
}
