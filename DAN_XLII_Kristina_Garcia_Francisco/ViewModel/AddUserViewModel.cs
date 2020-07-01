using DAN_XLII_Kristina_Garcia_Francisco.Commands;
using DAN_XLII_Kristina_Garcia_Francisco.Model;
using DAN_XLII_Kristina_Garcia_Francisco.View;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Windows;
using System.Windows.Input;

namespace DAN_XLII_Kristina_Garcia_Francisco.ViewModel
{
    class AddUserViewModel : BaseViewModel
    {
        AddUser addUser;
        Service service = new Service();

        #region Constructor
        /// <summary>
        /// Constructor with edit user window opening
        /// </summary>
        /// <param name="addUserOpen">opens the add user window</param>
        /// <param name="userEdit">gets the user info that is being edited</param>
        /// <param name="sectorEdit">gets the sector info that is being edited</param>
        public AddUserViewModel(AddUser addUserOpen, tblUser userEdit, tblSector sectorEdit)
        {
            sector = sectorEdit;
            user = userEdit;
            addUser = addUserOpen;
            LocationList = service.GetAllLocations().ToList();
            SectorList = service.GetAllSectors().ToList();
            ManagerList = service.GetAllManagers(User.UserID).ToList();
        }

        /// <summary>
        /// Constructor with Add User param
        /// </summary>
        /// <param name="addUserOpen">opens the add user window</param>
        public AddUserViewModel(AddUser addUserOpen)
        {
            user = new tblUser();
            sector = new tblSector();
            addUser = addUserOpen;
            LocationList = service.GetAllLocations().ToList();
            SectorList = service.GetAllSectors().ToList();
            ManagerList = service.GetAllManagers(User.UserID).ToList();
        }
        #endregion

        #region Property
        /// <summary>
        /// Information about the specific user
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
        /// Information about the specific manager
        /// </summary>
        private tblUser manager;
        public tblUser Manager
        {
            get
            {
                return manager;
            }
            set
            {
                manager = value;
                OnPropertyChanged("Manager");
                // Set the Manager ID that was selected to the user.
                User.MenagerID = manager.UserID;
            }
        }

        /// <summary>
        /// Cheks if its possible to execute the add and edit commands
        /// </summary>
        private bool isUpdateUser;
        public bool IsUpdateUser
        {
            get
            {
                return isUpdateUser;
            }
            set
            {
                isUpdateUser = value;
            }
        }

        /// <summary>
        /// Information about the specific location
        /// </summary>
        private tblLocation location;
        public tblLocation Location
        {
            get
            {
                return location;
            }
            set
            {
                location = value;
                OnPropertyChanged("Location");
                // Set the Location ID that was selected to the user.
                User.LocationID = location.LocationID;
            }
        }

        /// <summary>
        /// List of all locations
        /// </summary>
        private List<tblLocation> locationList;
        public List<tblLocation> LocationList
        {
            get
            {
                return locationList;
            }
            set
            {
                locationList = value;
                OnPropertyChanged("LocationList");
            }
        }

        /// <summary>
        /// Information about the specific location
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

        /// <summary>
        /// List of all locations
        /// </summary>
        private List<tblSector> sectorList;
        public List<tblSector> SectorList
        {
            get
            {
                return sectorList;
            }
            set
            {
                sectorList = value;
                OnPropertyChanged("SectorList");
            }
        }

        /// <summary>
        /// List of all managers
        /// </summary>
        private List<tblUser> managerList;
        public List<tblUser> ManagerList
        {
            get
            {
                return managerList;
            }
            set
            {
                managerList = value;
                OnPropertyChanged("ManagerList");
            }
        }
        #endregion

        #region Commands
        /// <summary>
        /// Command that tries to save the user
        /// </summary>
        private ICommand save;
        public ICommand Save
        {
            get
            {
                if (save == null)
                {
                    save = new RelayCommand(param => SaveExecute(), param => this.CanSaveExecute);
                }
                return save;
            }
        }

        /// <summary>
        /// Executes the save command
        /// </summary>
        private void SaveExecute()
        {
            try
            {
                service.AddSector(Sector);
                service.AddUser(User, Sector);
                isUpdateUser = true;
                addUser.Close();
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Exception" + ex.Message.ToString());
            }
        }

        /// <summary>
        /// Can only execute the field are filled up
        /// </summary>
        /// <returns>true if possible</returns>
        private bool CanSaveExecute
        {
            get
            {
                return User.IsValid;
            }
        }

        /// <summary>
        /// Command that tries to close the user window
        /// </summary>
        private ICommand close;
        public ICommand Close
        {
            get
            {
                if (close == null)
                {
                    close = new RelayCommand(param => CloseExecute(), param => CanCloseExecute());
                }
                return close;
            }
        }

        /// <summary>
        /// Executes the close command
        /// </summary>
        private void CloseExecute()
        {
            try
            {
                addUser.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        /// <summary>
        /// Checks if its possible to close the window
        /// </summary>
        /// <returns>true</returns>
        private bool CanCloseExecute()
        {
            return true;
        }
        #endregion
    }
}
