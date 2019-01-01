﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace materialDesignTesting
{
    public class MainWindowViewModel : INotifyPropertyChanged
    {
        private object currentViewModel;

        private string showMenu;
        private string showOView;
        private int viewsTogglingCounter = 0;
        public string ShowMenu
        {
            get
            {
                if (showMenu == null)
                    showMenu = "Visible";
                return showMenu; }

            set
            {
                showMenu = value; RaisePropertyChanged();
            }

        }


        public string ShowOView
        {
            get
            {
                if (showOView == null)
                    showOView = "Hidden";
                return showOView;
            }

            set
            {
                showOView = value; RaisePropertyChanged();
            }

        }


        public void ToggleMenuVisibility()
        {
            ShowMenu = (ShowMenu == "Visible" ? "Hidden" : "Visible");
            ShowOView = (ShowOView == "Visible" ? "Hidden" : "Visible");
        }

        public object CurrentViewModel
        {
            get {

                return currentViewModel;
            }
            set { currentViewModel = value; RaisePropertyChanged(); }
        }


        private static String hideMenus = "Visible";

       

        public String HideMenus
        {
            get { return hideMenus; }
            set { hideMenus = value; RaisePropertyChanged(); }
        }

        private RelayCommand<Type> navigateCommand;
        public RelayCommand<Type> NavigateCommand
        {
            get
            {
                return navigateCommand
                  ?? (navigateCommand = new RelayCommand<Type>(
                    vmType =>
                    {
                        //toggle menus visibility and then navigate
                        ShowMenu = (ShowMenu == "Visible" ? "Hidden" : "Visible");
                        ShowOView = (ShowOView == "Visible" ? "Hidden" : "Visible");

                        //Bind a 'CurrentViewModel Set' eventTo the button
                        CurrentViewModel = null;
                        CurrentViewModel = Activator.CreateInstance(vmType);
                    }));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void RaisePropertyChanged([CallerMemberName] String propertyName = "")
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }


        private void OnClick_backToWizardMenu(object sender, RoutedEventArgs e)
        {
            ShowMenu = "Visible";
            ShowOView = "Hidden";
        }


        private RelayCommand<Type> backToWizardCommand;
        public RelayCommand<Type> BackToWizardCommand
        {
            get
            {
               return backToWizardCommand
                  ?? (backToWizardCommand = new RelayCommand<Type>(
                    (Type)=>
                    {
                        ShowMenu = "Visible";
                        ShowOView = "Hidden";
                    }));
            }
        }


    }



    public class RelayCommand<T> : ICommand
    {
        #region Fields

        readonly Action<T> _execute = null;
        readonly Predicate<T> _canExecute = null;

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of <see cref="DelegateCommand{T}"/>.
        /// </summary>
        /// <param name="execute">Delegate to execute when Execute is called on the command.  This can be null to just hook up a CanExecute delegate.</param>
        /// <remarks><seealso cref="CanExecute"/> will always return true.</remarks>
        public RelayCommand(Action<T> execute)
            : this(execute, null)
        {
        }

        /// <summary>
        /// Creates a new command.
        /// </summary>
        /// <param name="execute">The execution logic.</param>
        /// <param name="canExecute">The execution status logic.</param>
        public RelayCommand(Action<T> execute, Predicate<T> canExecute)
        {
            if (execute == null)
                throw new ArgumentNullException("execute");

            _execute = execute;
            _canExecute = canExecute;
        }

        #endregion

        #region ICommand Members

        ///<summary>
        ///Defines the method that determines whether the command can execute in its current state.
        ///</summary>
        ///<param name="parameter">Data used by the command.  If the command does not require data to be passed, this object can be set to null.</param>
        ///<returns>
        ///true if this command can be executed; otherwise, false.
        ///</returns>
        public bool CanExecute(object parameter)
        {
            return _canExecute == null ? true : _canExecute((T)parameter);
        }

        ///<summary>
        ///Occurs when changes occur that affect whether or not the command should execute.
        ///</summary>
        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        ///<summary>
        ///Defines the method to be called when the command is invoked.
        ///</summary>
        ///<param name="parameter">Data used by the command. If the command does not require data to be passed, this object can be set to <see langword="null" />.</param>
        public void Execute(object parameter)
        {
            _execute((T)parameter);
        }

        #endregion
    }

}