using DAN_XLII_Kristina_Garcia_Francisco.Commands;
using DAN_XLII_Kristina_Garcia_Francisco.Helper;
using DAN_XLII_Kristina_Garcia_Francisco.Model;
using DAN_XLII_Kristina_Garcia_Francisco.View;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Threading;
using System.Windows;
using System.Windows.Input;

namespace DAN_XLII_Kristina_Garcia_Francisco.ViewModel
{
    class MainWindowViewModel : BaseViewModel
    {
        MainWindow main;
        Service service = new Service();
        private readonly BackgroundWorker bgWorker = new BackgroundWorker();

        #region Constructor
        /// <summary>
        /// Constructor with Main Window param
        /// </summary>
        /// <param name="mainOpen">opens the main window</param>
        public MainWindowViewModel(MainWindow mainOpen)
        {
            main = mainOpen;
            UserList = service.GetAllUsers().ToList();
            service.GetAllLocations().ToList();

            bgWorker.DoWork += WorkerOnDoWorkDelete;
        }
        #endregion

        #region Property
        /// <summary>
        /// List of all Users
        /// </summary>
        private List<tblUser> userList;
        public List<tblUser> UserList
        {
            get
            {
                return userList;
            }
            set
            {
                userList = value;
                OnPropertyChanged("UsersList");
            }
        }


        /// <summary>
        /// Specific User info
        /// </summary>
        private tblUser user;
        public tblUser User
        {
            get
            {
                return user;
            }
            set
            {
                user = value;
                OnPropertyChanged("User");
            }
        }


        /// <summary>
        /// Specific Sector info
        /// </summary>
        private tblSector sector;
        public tblSector Sector
        {
            get
            {
                return sector;
            }
            set
            {
                sector = value;
                OnPropertyChanged("Sector");
            }
        }
        #endregion

        #region Commands
        /// <summary>
        /// Command that tries to delete the user, their identification card and recorded evidences
        /// </summary>
        private ICommand deleteUser;
        public ICommand DeleteUser
        {
            get
            {
                if (deleteUser == null)
                {
                    deleteUser = new RelayCommand(param => DeleteUserExecute(), param => CanDeleteUserExecute());
                }
                return deleteUser;
            }
        }

        /// <summary>
        /// Executes the delete command
        /// </summary>
        public void DeleteUserExecute()
        {
            // Checks if the user really wants to delete the selected Identification Card info
            var result = MessageBox.Show("Are you sure you want to delete the user?", "Confirmation", MessageBoxButton.YesNo, MessageBoxImage.Question);

            if (result == MessageBoxResult.Yes)
            {
                try
                {
                    if (User != null)
                    {
                        if (!bgWorker.IsBusy)
                        {
                            // This method will start the execution asynchronously in the background
                            bgWorker.RunWorkerAsync();
                        }

                        int userID = User.UserID;
                        service.DeleteUser(userID);
                        UserList = service.GetAllUsers().ToList();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }
            else
            {
                return;
            }
        }

        /// <summary>
        /// Can only execute this command if the User list has the users data
        /// </summary>
        /// <returns>true if possible</returns>
        public bool CanDeleteUserExecute()
        {
            if (UserList == null)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        /// <summary>
        /// Command that tries to open the edit user window
        /// </summary>
        private ICommand editUser;
        public ICommand EditUser
        {
            get
            {
                if (editUser == null)
                {
                    editUser = new RelayCommand(param => EditUserExecute(), param => CanEditUserExecute());
                }
                return editUser;
            }
        }

        /// <summary>
        /// Executes the edit command
        /// </summary>
        public void EditUserExecute()
        {
            try
            {
                if (User != null)
                {
                    AddUser addUser = new AddUser(User, Sector);
                    addUser.ShowDialog();

                    if ((addUser.DataContext as AddUserViewModel).IsUpdateUser == true)
                    {
                        UserList = service.GetAllUsers().ToList();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        /// <summary>
        /// Can only execute this command if the User list has the users data
        /// </summary>
        /// <returns>true if possible</returns>
        public bool CanEditUserExecute()
        {
            if (UserList == null)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        /// <summary>
        /// Command that tries to add a new user
        /// </summary>
        private ICommand addUser;
        public ICommand AddUser
        {
            get
            {
                if (addUser == null)
                {
                    addUser = new RelayCommand(param => AddUserExecute(), param => CanAddUserExecute());
                }
                return addUser;
            }
        }

        /// <summary>
        /// Executes the add user command
        /// </summary>
        private void AddUserExecute()
        {
            try
            {
                AddUser addUser = new AddUser();
                addUser.ShowDialog();
                if ((addUser.DataContext as AddUserViewModel).IsUpdateUser == true)
                {
                    UserList = service.GetAllUsers().ToList();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        /// <summary>
        /// Checks if its possible to add the new User
        /// </summary>
        /// <returns>true</returns>
        private bool CanAddUserExecute()
        {
            return true;
        }
        #endregion

        /// <summary>
        /// Writes the message to the log file.
        /// </summary>
        /// <param name="sender">object sender</param>
        /// <param name="e">DoWorkEventArgs e</param>
        public void WorkerOnDoWorkDelete(object sender, DoWorkEventArgs e)
        {
            LogMessage log = new LogMessage();
            string message = log.Message("Deleted", User.FirstName, User.LastName);

            log.LogFile(message);
        }
    }
}
