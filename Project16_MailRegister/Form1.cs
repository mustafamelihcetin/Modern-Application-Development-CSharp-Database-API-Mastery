﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MailKit.Net.Smtp;
using MimeKit;

namespace Project16_MailRegister
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        Db16Project20Entities context = new Db16Project20Entities();
        private void btnRegister_Click(object sender, EventArgs e)
        {
            Random random = new Random();
            int confirmCode = random.Next(100000, 1000000);

            TblUser user = new TblUser();
            user.Email = txtEmail.Text;
            user.Name = txtName.Text;
            user.Surname = txtSurname.Text;
            user.Password = txtPassword.Text;
            user.IsConfirm = false;
            user.ConfirmCode = confirmCode.ToString();

            context.TblUsers.Add(user);
            context.SaveChanges();

            #region MailCoding
            MimeMessage mimeMessage = new MimeMessage();

            MailboxAddress mailboxAddressFrom = new MailboxAddress("AdminRegister", "mctnprojects@gmail.com");
            mimeMessage.From.Add(mailboxAddressFrom);

            MailboxAddress mailboxAddressTo = new MailboxAddress("User", txtEmail.Text);
            mimeMessage.To.Add(mailboxAddressTo);

            var bodyBuilder = new BodyBuilder();
            bodyBuilder.TextBody = "E-posta adresinizin onay kodu: " + confirmCode;
            mimeMessage.Body = bodyBuilder.ToMessageBody();

            mimeMessage.Subject = "E-posta Onay Kodu";

            SmtpClient smtpClient = new SmtpClient();
            smtpClient.Connect("smtp.gmail.com", 587, false);
            smtpClient.Authenticate("mctnprojects@gmail.com", "key");
            smtpClient.Send(mimeMessage);
            smtpClient.Disconnect(true);

            MessageBox.Show("Mail adresinize doğrulama kodu gönderilmiştir.");
            FrmMailConfirm frmMailConfirm = new FrmMailConfirm();
            frmMailConfirm.email = txtEmail.Text;
            frmMailConfirm.Show();
            #endregion

        }
    }
}
