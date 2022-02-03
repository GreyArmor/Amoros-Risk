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
    public partial class MainGameMenu : UserControl {
        
        private Grid e_0;
        
        private Grid e_1;
        
        private Grid e_2;
        
        private Button e_3;
        
        private Button e_4;
        
        private Button e_5;
        
        private Button e_6;
        
        public MainGameMenu() {
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
            this.e_3.Content = "New game";
            Grid.SetRow(this.e_3, 0);
            // e_4 element
            this.e_4 = new Button();
            this.e_2.Children.Add(this.e_4);
            this.e_4.Name = "e_4";
            this.e_4.Content = "Multiplayer";
            Grid.SetRow(this.e_4, 1);
            // e_5 element
            this.e_5 = new Button();
            this.e_2.Children.Add(this.e_5);
            this.e_5.Name = "e_5";
            this.e_5.Content = "Highscores";
            Grid.SetRow(this.e_5, 2);
            // e_6 element
            this.e_6 = new Button();
            this.e_2.Children.Add(this.e_6);
            this.e_6.Name = "e_6";
            this.e_6.Content = "Exit";
            Grid.SetRow(this.e_6, 3);
        }
        
        private static void InitializeElementResources(UIElement elem) {
            // Resource - [System.Windows.Controls.Button] Style
            Style r_0_s = new Style(typeof(Button));
            Setter r_0_s_S_0 = new Setter(Button.MarginProperty, new Thickness(5F));
            r_0_s.Setters.Add(r_0_s_S_0);
            elem.Resources.Add(typeof(Button), r_0_s);
        }
    }
}
