using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using testWordGenerator.Models;
using testWordGenerator.Services;
using testWordGenerator.Utils;
using testWordGenerator.ViewModels;

namespace testWordGenerator
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            DataContext = new ApplicationViewModel();
        }
    }
}
