﻿using System;
using System.Runtime.InteropServices;
using System.Security;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace Fasetto.Word.Core
{
    /// <summary>
    /// The View Model for a login screen
    /// </summary>
    public class LoginViewModel : BaseViewModel
    {
        #region Public Properties

        /// <summary>
        /// The email of the user
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// A flag indicating if the login command is running
        /// </summary>
        public bool LoginIsRunning { get; set; }

        #endregion

        #region Commands

        /// <summary>
        /// The command to login
        /// </summary>
        public ICommand LoginCommand { get; set; }

        /// <summary>
        /// The command to goto the login page
        /// </summary>
        public ICommand GoToLoginCommand { get; set; }

        /// <summary>
        /// The command to goto the register page
        /// </summary>
        public ICommand GoToRegisterCommand { get; set; }

        #endregion

        #region Constructor

        /// <summary>
        /// Default constructor
        /// </summary>
        public LoginViewModel()
        {
            // Create commands
            LoginCommand = new RelayParameterizedCommand(async (parameter) => await LoginAsync(parameter));
            GoToLoginCommand = new RelayCommand(async () => await GoToLoginAsync());
            GoToRegisterCommand = new RelayCommand(async () => await GoToRegisterAsync());
        }

        #endregion

        /// <summary>
        /// Attempts to log the user in
        /// </summary>
        /// <param name="parameter">The <see cref="SecureString"/> passed in from the view for the users password</param>
        /// <returns></returns>
        public async Task LoginAsync(object parameter)
        {
            await RunCommand(() => LoginIsRunning, async () =>
            {
                await Task.Delay(5000);

                var email = Email;

                // IMPORTANT: Never store unsecure password in variable like this
                var pass = (parameter as IHavePassword).SecurePassword.Unsecure();
            });
        }

        /// <summary>
        /// Takes the user to the login page
        /// </summary>
        /// <returns></returns>
        public async Task GoToLoginAsync()
        {
            // TODO: goto register page 
            IoC.Get<ApplicationViewModel>().CurrentPage = ApplicationPage.Login;

            await Task.Delay(1);
        }

        /// <summary>
        /// Takes the user to the register page
        /// </summary>
        /// <returns></returns>
        public async Task GoToRegisterAsync()
        {
            // TODO: goto register page 
            IoC.Get<ApplicationViewModel>().CurrentPage = ApplicationPage.Register;

            await Task.Delay(1);
        }
    }
}
