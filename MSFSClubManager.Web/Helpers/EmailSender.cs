﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;
using AutoMapper.Configuration;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.Extensions.Configuration;
using IConfiguration = Microsoft.Extensions.Configuration.IConfiguration;

namespace MSFSClubManager.Web.Helpers
{
    public class EmailSender: IEmailSender
        {

        // Our private configuration variables
        private string host;
        private int port;
        private bool enableSSL;
        private string userName;
        private string password;

        private IConfiguration _configRoot;

        // Get our parameterized configuration
        public EmailSender(IConfiguration configRoot)
        {
            _configRoot = (IConfigurationRoot)configRoot;
            this.host = _configRoot.GetValue<string>("AppSettings:EmailHost");
            this.port = Convert.ToInt32(_configRoot.GetValue<string>("AppSettings:EmailPort"));
            this.enableSSL = Convert.ToBoolean(_configRoot.GetValue<string>("AppSettings:EnableSSL"));
            this.userName = _configRoot.GetValue<string>("AppSettings:EmailUserName");
            this.password = _configRoot.GetValue<string>("AppSettings:EmailPassword");
        }

        //
        // Use our configuration to send the email by using SmtpClient
        public Task SendEmailAsync(string email, string subject, string htmlMessage)
        {


            var client = new SmtpClient(host, port)
            {
                Credentials = new NetworkCredential(this.userName, this.password),
                EnableSsl = enableSSL
            };
            return client.SendMailAsync(
                new MailMessage(userName, email, subject, htmlMessage) { IsBodyHtml = true }
            );
        }
    }
}
