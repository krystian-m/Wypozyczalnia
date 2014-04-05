﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Wypozyczalnia.Model;

namespace Wypozyczalnia.View
{
    public partial class ClientForm : BaseForm
    {
        public ClientForm()
        {
            InitializeComponent();
        }

        public ClientForm(Client client)
        {
            InitializeComponent();
            textBox1.Text = "" + client.Id;
            textBox2.Text = client.Name;
            textBox3.Text = client.Surname;
            textBox4.Text = client.IdNumber;
        }

        public string TextBox3
        {
            get { return textBox3.Text; }
            set { textBox3.Text = value; }
        }

        public string TextBox4
        {
            get { return textBox4.Text; }
            set { textBox4.Text = value; }
        }

        private void ActionCancel(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void ActionCorfirm(object sender, EventArgs e)
        {
            controller.Confirm();
        }
    }
}

