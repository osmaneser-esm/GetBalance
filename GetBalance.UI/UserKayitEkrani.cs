﻿using GetBalance.DAL.Repositories;
using GetBalance.DATA;
using GetBalance.DATA.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GetBalance.UI
{
    public partial class UserKayitEkrani : Form
    {
        GenericRepository<User> userRepo;
        GenericRepository<UserDetail> userDetailRepo;
        public UserKayitEkrani()
        {
            InitializeComponent();
        }

        private void UserKayitEkrani_Load(object sender, EventArgs e)
        {
            userRepo = new GenericRepository<User>();
            userDetailRepo = new GenericRepository<UserDetail>();
            //TODO: Aktiviteler comboBox a eklenecek.
            var ActivityLevelList = Enum.GetValues(typeof(ActivityLevel));

            foreach (var item in ActivityLevelList)
            {
                cmbActivityLevel.Items.Add(item);
            }




        }

        private void btnAdd_Click(object sender, EventArgs e)
        {


            AddUser();

        }

        private void AddUser()
        {
            List<User> usersList = userRepo.GetAll();

            string firstname = txtName.Text;
            string lastname = txtName.Text;
            string email = txtEmail.Text;
            string password = txtPassword.Text;
            Gender gender = radioBtnMan.Checked ? Gender.Male : Gender.Female;
            double height = Convert.ToDouble(txtHeight.Text);
            double weight = Convert.ToDouble(txtWeight.Text);
            DateTime bday = dtpBirthdate.Value.Date;
            ActivityLevel activityLevel = (ActivityLevel)cmbActivityLevel.SelectedItem;

            User user = new User()
            {
                Email = email,
                Password = password,
                new UserDetail() { FirstName = firstname, LastName = lastname, Height = height, CurrentWeight = weight, BirthDate = bday, ActivityLevel = activityLevel, Gender = gender }

            };

        }
    }
}
