using DAN_XLII_Kristina_Garcia_Francisco.Helper;
using DAN_XLII_Kristina_Garcia_Francisco.Model;
using DAN_XLII_Kristina_Garcia_Francisco.ViewModel;
using System;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Input;

namespace DAN_XLII_Kristina_Garcia_Francisco.View
{
    /// <summary>
    /// Interaction logic for AddUser.xaml
    /// </summary>
    public partial class AddUser : Window
    {
        /// <summary>
        /// Window constructor for editing users
        /// </summary>
        /// <param name="userEdit">user that is bing edited</param>
        /// <param name="sectorEdit">csector that is being edited</param>
        public AddUser(tblUser userEdit, tblSector sectorEdit)
        {
            InitializeComponent();
            this.DataContext = new AddUserViewModel(this, userEdit, sectorEdit);
        }

        /// <summary>
        /// Window constructor for creating users
        /// </summary>
        public AddUser()
        {
            InitializeComponent();
            this.DataContext = new AddUserViewModel(this);
        }

        /// <summary>
        /// User can only imput numbers
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void NumberValidationTextBox(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }

        /// <summary>
        /// Calcualtes the birth date and places it in the textbox
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TextBox_TextChanged(object sender, EventArgs e)
        {
            InputCalculator iv = new InputCalculator();
            string text = "";
            if (txtJMBG.Text.Length >= 7)
            {
                text = iv.CountDateOfBirth(txtJMBG.Text).ToString("dd.MM.yyy.");
            }
            else
            {
                text = "";
            }

            txtDateOfBirth.Text = text;
        }
    }
}
