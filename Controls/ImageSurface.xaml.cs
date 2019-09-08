using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Quaker.Controls
{
    /// <summary>
    /// Interaction logic for ImageSurface.xaml
    /// </summary>
    public partial class ImageSurface : UserControl
    {
        public static readonly DependencyProperty PictureProperty =
         DependencyProperty.Register("Picture", typeof(String), typeof(ImageSurface));

        public static readonly DependencyProperty OutputTextProperty =
         DependencyProperty.Register("OutputText", typeof(String), typeof(ImageSurface));

        public static readonly DependencyProperty InputTextProperty =
         DependencyProperty.Register("InputText", typeof(String), typeof(ImageSurface));

        public String Picture
        {
            get { return (String)this.GetValue(PictureProperty); }
            set { this.SetValue(PictureProperty, value); OnPropertyChanged("Picture"); }
        }
        public String OutputText
        {
            get { return (String)this.GetValue(OutputTextProperty); }
            set { this.SetValue(OutputTextProperty, value); OnPropertyChanged("OutputText"); }
        }
        public String InputText
        {
            get { return (String)this.GetValue(InputTextProperty); }
            set { this.SetValue(InputTextProperty, value); OnPropertyChanged("InputText"); }
        }
        public ImageSurface()
        {
            InitializeComponent();
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string name)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(name));
            }
        }
    }
}
