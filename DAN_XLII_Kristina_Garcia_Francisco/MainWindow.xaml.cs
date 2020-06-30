﻿using DAN_XLII_Kristina_Garcia_Francisco.ViewModel;
using System.Windows;

namespace DAN_XLII_Kristina_Garcia_Francisco
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            this.DataContext = new MainWindowViewModel(this);
        }
    }
}
