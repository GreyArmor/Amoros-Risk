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
        
        private Grid e_3;
        
        private Image image;
        
        private Grid e_4;
        
        private Image e_5;
        
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
            Grid.SetRow(this.e_2, 1);
            // e_3 element
            this.e_3 = new Grid();
            this.e_2.Children.Add(this.e_3);
            this.e_3.Name = "e_3";
            Grid.SetRow(this.e_3, 0);
            // image element
            this.image = new Image();
            this.e_3.Children.Add(this.image);
            this.image.Name = "image";
            this.image.Margin = new Thickness(5F, 5F, 5F, 5F);
            this.image.HorizontalAlignment = HorizontalAlignment.Center;
            BitmapImage image_bm = new BitmapImage();
            image_bm.TextureAsset = "Images\\\\PlayButtonRisk";
            this.image.Source = image_bm;
            this.image.Stretch = Stretch.Fill;
            Grid.SetRow(this.image, 0);
            this.image.SetResourceReference(Image.StyleProperty, "gridImageStyle");
            // e_4 element
            this.e_4 = new Grid();
            this.e_2.Children.Add(this.e_4);
            this.e_4.Name = "e_4";
            Grid.SetRow(this.e_4, 1);
            // e_5 element
            this.e_5 = new Image();
            this.e_4.Children.Add(this.e_5);
            this.e_5.Name = "e_5";
            this.e_5.Margin = new Thickness(5F, 5F, 5F, 5F);
            this.e_5.HorizontalAlignment = HorizontalAlignment.Center;
            BitmapImage e_5_bm = new BitmapImage();
            e_5_bm.TextureAsset = "Images\\\\CreditButtonRisk";
            this.e_5.Source = e_5_bm;
            this.e_5.Stretch = Stretch.Fill;
            Grid.SetRow(this.e_5, 1);
            this.e_5.SetResourceReference(Image.StyleProperty, "gridImageStyle");
            ImageManager.Instance.AddImage("Images\\\\PlayButtonRisk");
            ImageManager.Instance.AddImage("Images\\\\CreditButtonRisk");
        }
        
        private static void InitializeElementResources(UIElement elem) {
            // Resource - [gridImageStyle] Style
            Style r_0_s = new Style(typeof(Image));
            Setter r_0_s_S_0 = new Setter(Image.WidthProperty, float.NaN);
            r_0_s.Setters.Add(r_0_s_S_0);
            Setter r_0_s_S_1 = new Setter(Image.MarginProperty, new Thickness(0F, 1F, 0F, 1F));
            r_0_s.Setters.Add(r_0_s_S_1);
            EventTrigger r_0_s_ET_0 = new EventTrigger(Image.MouseEnterEvent);
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
            Storyboard.SetTargetProperty(r_0_s_ET_0_AC_0_SB_TL_0, Image.MarginProperty);
            r_0_s_ET_0_AC_0_SB.Children.Add(r_0_s_ET_0_AC_0_SB_TL_0);
            EventTrigger r_0_s_ET_1 = new EventTrigger(Image.MouseLeaveEvent);
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
            Storyboard.SetTargetProperty(r_0_s_ET_1_AC_0_SB_TL_0, Image.MarginProperty);
            r_0_s_ET_1_AC_0_SB.Children.Add(r_0_s_ET_1_AC_0_SB_TL_0);
            FloatAnimation r_0_s_ET_1_AC_0_SB_TL_1 = new FloatAnimation();
            r_0_s_ET_1_AC_0_SB_TL_1.Name = "r_0_s_ET_1_AC_0_SB_TL_1";
            r_0_s_ET_1_AC_0_SB_TL_1.Duration = new Duration(new TimeSpan(0, 0, 0, 0, 500));
            r_0_s_ET_1_AC_0_SB_TL_1.To = 200F;
            SineEase r_0_s_ET_1_AC_0_SB_TL_1_EA = new SineEase();
            r_0_s_ET_1_AC_0_SB_TL_1.EasingFunction = r_0_s_ET_1_AC_0_SB_TL_1_EA;
            Storyboard.SetTargetProperty(r_0_s_ET_1_AC_0_SB_TL_1, Image.WidthProperty);
            r_0_s_ET_1_AC_0_SB.Children.Add(r_0_s_ET_1_AC_0_SB_TL_1);
            elem.Resources.Add("gridImageStyle", r_0_s);
        }
    }
}
