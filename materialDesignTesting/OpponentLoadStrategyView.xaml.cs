﻿using System;
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

namespace materialDesignTesting
{
    /// <summary>
    /// Interaction logic for OpponentLoadStrategyView.xaml
    /// </summary>
    public partial class OpponentLoadStrategyView : UserControl
    {
        public OpponentLoadStrategyView()
        {
            DataContext = new OpponentLoadStrategyViewModel();
            InitializeComponent();
        }
    }
}
