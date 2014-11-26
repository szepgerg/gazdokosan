using System;
using System.Collections.Generic;
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
using System.Windows.Shapes;
using GazdOkosan.ViewModel;

namespace GazdOkosan.View
{
    /// <summary>
    /// Interaction logic for NewGameWindow.xaml
    /// </summary>
    public partial class NewGameWindow : Window
    {
        public NewGameWindow()
        {
            InitializeComponent();
        }

        /*private void Button_Click(object sender, RoutedEventArgs e)
        {
            int jatekosSzam = 0;
            String[] nevek = new String[4];
            GazdOkosanViewModel vievModel = new GazdOkosanViewModel();

            if (radioButton2.IsChecked == true)
            {
                jatekosSzam = 2;
            }
            else if (radioButton3.IsChecked == true)
            {
                jatekosSzam = 3;
            }
            else if (radioButton4.IsChecked == true)
            {
                jatekosSzam = 4;
            }

            switch(jatekosSzam)
            {
                case 2: nevek = new String[2];
                        nevek[0] = textBox1.Text;
                        nevek[1] = textBox2.Text;
                        break;
                case 3: nevek = new String[3];
                        nevek[0] = textBox1.Text;
                        nevek[1] = textBox2.Text;
                        nevek[2] = textBox2.Text;   
                        break;
                case 4: nevek = new String[4];
                        nevek[0] = textBox1.Text;
                        nevek[1] = textBox2.Text;
                        nevek[2] = textBox2.Text;
                        nevek[3] = textBox2.Text;
                        break;
            }

            vievModel.ujJatek(nevek, Int32.Parse(textBoxMoney.Text));
        }*/
    }
}
