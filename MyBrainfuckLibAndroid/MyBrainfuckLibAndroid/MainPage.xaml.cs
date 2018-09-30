using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace MyBrainfuckLibAndroid
{
	public partial class MainPage : ContentPage
	{
		public MainPage()
		{
			InitializeComponent();
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            txtResult.Text = MyBrainfuckLib.MyBrainfuck.ExecuteBrainfuckCode(txtSource.Text);
        }
    }
}
