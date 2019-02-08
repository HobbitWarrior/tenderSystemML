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
    /// Interaction logic for LoadingView.xaml
    /// </summary>
    public partial class LoadingView : UserControl
    {
        public LoadingView()
        {
            InitializeComponent();
            //MainWindow.Snackbar.MessageQueue.Enqueue("Done :)");
            externalProcessRunner epr = new externalProcessRunner();
            //validate and save the results in the view mediator
            if ((ViewsMediator.gameResults = epr.runCmd()) == null)
                MainWindow.Snackbar.MessageQueue.Enqueue("Something went wrong, the external script runner 'externalProccessRunner' did not return results array.");
            else
                MainWindow.Snackbar.MessageQueue.Enqueue("Done :) Click Next to prceed to results.");
            //if the calculation is done change the transition between the wizard windows button controller.
            System.Console.WriteLine("finished reading from the pipe, loading graphs");
            ViewsMediator.isDoneCalcualtingQ = true;
        }
    }
}
