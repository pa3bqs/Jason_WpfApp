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
using System.Windows.Navigation;
using System.Windows.Shapes;
using Json_ClassLibrary;
using Newtonsoft.Json;


namespace Jason_WpfApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    /// 
    


    public partial class MainWindow : Window
    {
        Roll_info roll;

        public MainWindow()
        {
            InitializeComponent();
            roll = new Roll_info();
        }

        private void test_button_Click(object sender, RoutedEventArgs e)
        {
            roll.Batch_info = "my test";
            Measurment meas = new Measurment()
            {
                Deactivation_field_strength = 1.2F,
                Dect_status = 1,
                Frequency = 8200,
                Q_factor = 80.5F,
                Volume = 1.2F
            };
            roll.Meas.Add(meas);
            roll.Meas.Add(new Measurment()
            {
                Deactivation_field_strength = 1.2F,
                Dect_status = 1,
                Frequency = 8250,
                Q_factor = 81.5F,
                Volume = 1.28F
            });
            text_box.Text = JsonConvert.SerializeObject(roll , Formatting.Indented) ;
            using (System.IO.StreamWriter file = new System.IO.StreamWriter(@"Write_txt.json", false))
            {
                file.WriteLine(text_box.Text);
            } ;
        }

        private void fill_button_Click(object sender, RoutedEventArgs e)
        {
            using (System.IO.StreamReader file = new System.IO.StreamReader(@"Write_txt.json", false))
            {
               text_box.Text = file.ReadToEnd();
            };
            roll  = JsonConvert.DeserializeObject<Roll_info>(text_box.Text  );
            freq_box.Text = roll.Meas[0].Frequency.ToString();
            batch_box.Text = roll.Batch_info;
        }

        private void encrypt_texbox_Click(object sender, RoutedEventArgs e)
        {
            encrypted_text.Text = Encryption_helper.Encrypt(text_box.Text);
        }

        private void decrypt_textbox_Click(object sender, RoutedEventArgs e)
        {
            decrypted_text.Text = Encryption_helper.Decrypt(encrypted_text.Text);
        }
    }
}
