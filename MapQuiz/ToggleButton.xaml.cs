using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace MapQuiz
{
    /// <summary>
    /// ToggleButton.xaml の相互作用ロジック
    /// </summary>
    public partial class ToggleButton : UserControl
    {
        public ToggleButton()
        {
            InitializeComponent();
            //button.Click += new RoutedEventHandler(button_Click);
            Text = "";
            IsActive = false;
        }

        //void button_Click(object sender, RoutedEventArgs e)
        //{
        //    IsActive = !IsActive;
        //}

        private string _text;
        public string Text
        {
            get { return _text; }
            set
            {
                _text = value;
                TextBlock.Text = _text;
            }
        }

        private bool _isActive;
        public bool IsActive
        {
            get { return _isActive; }
            set
            {
                _isActive = value;
                if (_isActive)
                {
                    ForeRect.Fill = new SolidColorBrush(Colors.LightPink);
                }
                else
                {
                    ForeRect.Fill = new SolidColorBrush(Colors.LightGray);
                }
            }
        }

    }
}
