using FinalProject.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Mail;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using MySecurityLib;
namespace FinalProject.Controllers
{
    public class UserController : ApiController
    {
        FinalProjectEntities userobj = new FinalProjectEntities();

        Email email = new Email();

        public UserController()
        {
            userobj.Configuration.ProxyCreationEnabled = false;
        }
        // GET: api/User
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }
        
        // GET: api/User/5
        public string Get(int id)
        {
            return "value";
        }


        [HttpPost]
        [Route("api/User/Registration")]
        public void registration(T_Users user)
        {
            
            user.RoleId =102;
            userobj.T_Users.Add(user);

            userobj.SaveChanges();

            email.body = "You Are Registraion Sucessfully.....!";
            email.to = user.EmailId;
            email.subject = "Registration Success";
            sendmail(email);
        }

         // POST: api/User
        public void Post1([FromBody]string value)
        {


        }

        // PUT: api/User/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/User/5
        public void Delete(int id)
        {
          
        }

        [HttpPost]
        [Route("api/User/sendmail")]
        public ResponseData sendmail([FromBody] Email e)
        {
            ResponseData rs = new ResponseData();
            string to = e.to;
            string body = e.body;
            string subject = e.subject;


            string result = "Message Sent Successfully..!!";
            string senderID = "dikshanagrale18@gmail.com";// use sender’s email id here..
            const string senderPassword = "chandrabhan"; // sender password here…
            try
            {
                SmtpClient smtp = new SmtpClient
                {
                    Host = "smtp.gmail.com", // smtp server address here…
                    Port = 587,
                    EnableSsl = true,
                    DeliveryMethod = SmtpDeliveryMethod.Network,
                    Credentials = new System.Net.NetworkCredential(senderID, senderPassword),
                    Timeout = 30000,
                };
                MailMessage message = new MailMessage(senderID, to, subject, body);
                smtp.Send(message);
            }
            catch (Exception ex)
            {
                result = "Error sending email.!!!";
                rs.Error = ex;
            }
            return rs;
        }



        [HttpPost]
        [Route("api/User/OTP")]
        public ResponseData OTP([FromBody]dynamic otpDetails)
        {
            string email = otpDetails.EmailId.ToString();


            var userlist = userobj.T_Users.ToList();
            var User = (from u in userlist
                        where u.EmailId == email
                        select u).SingleOrDefault();
            string o = otpDetails.OTP.ToString();

            var otpd = userobj.T_OTP_Details.ToList();
            var vOTP = (from v in otpd
                        where v.UserId == User.UserId && v.OTP == o
                        select v).SingleOrDefault();

            if (vOTP != null)
            {
                ResponseData RC = new ResponseData();
                RC.Status = "success";
                RC.Error = null;
                RC.Data = vOTP;
                return RC;
            }
            else
            {
                ResponseData RC = new ResponseData();
                RC.Status = "fail";
                RC.Error = null;
                RC.Data = false;
                return RC;
            }
        }




        [HttpPost]
        [Route("api/User/IsExist")]
        public ResponseData IsExist([FromBody]T_Users value)
        {
            Email e = new Email();
            var userlist = userobj.T_Users.ToList();
            var User = (from u in userlist
                        where u.EmailId == value.EmailId
                        select u).SingleOrDefault();
            if (User != null)
            {
                ResponseData RC = new ResponseData();
                string mails = GetOTP();

                T_OTP_Details otp = new T_OTP_Details();
                otp.UserId = User.UserId;
                otp.ValidTill = DateTime.Now; 
                otp.GeneratedOn = DateTime.Now;
                otp.OTP = mails;
                userobj.T_OTP_Details.Add(otp);
                userobj.SaveChanges();
                //

                e.body = "OTP is " + mails;
                e.to = User.EmailId;
                e.subject = "OTP";
                sendmail(e);

                RC.Status = "success";
                RC.Error = null;
                RC.Data = mails;
                return RC;
            }
            else
            {
                ResponseData RC = new ResponseData();
                RC.Status = "fail";
                RC.Error = null;
                RC.Data = false;
                return RC;
            }

        }


        [HttpPut]
        [Route("api/User/UpdatePassword")]
        public ResponseData updatepassword([FromBody]T_Users value)
        {

            var userlist = userobj.T_Users.ToList();
            var User = (from u in userlist
                        where u.EmailId == value.EmailId
                        select u).SingleOrDefault();

            if (User != null)
            {
                User.Password = value.Password;
                userobj.SaveChanges();
                ResponseData rc = new ResponseData();
                rc.Status = "success";
                rc.Error = null;
                rc.Data = User;
                return rc;
            }
            else
            {
                ResponseData rc = new ResponseData();
                rc.Status = "fail";
                rc.Error = null;
                rc.Data = null;
                return rc;
            }
        }
        private string GetOTP(string otpType = "1", int len = 5)
        {
            //otptype 1 = alpha numeric
            string alphabets = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            string small_alphabets = "abcdefghijklmnopqrstuvwxyz";
            string numbers = "1234567890";

            string characters = numbers;
            if (otpType == "1")
            {
                characters += alphabets + small_alphabets + numbers;
            }
            int length = 5;
            string otp = string.Empty;
            for (int i = 0; i < length; i++)
            {
                string character = string.Empty;
                do
                {
                    int index = new Random().Next(0, characters.Length);
                    character = characters.ToCharArray()[index].ToString();
                } while (otp.IndexOf(character) != -1);
                otp += character;
            }
            return otp;
        }

        //for user changepassword
        [HttpPut]
        [Route("api/User/ChangePassword")]
        public ResponseData changepassword([FromBody]dynamic value)
        {
            ResponseData rs = new ResponseData();
            var userlist = userobj.T_Users.ToList();
            var User = (from u in userlist
                        where u.EmailId == value.EmailId.ToString() && u.Password == value.Password.ToString()
                        select u).SingleOrDefault();

            if (User != null)
            {
                User.Password = value.NewPassword;
                userobj.SaveChanges();
               
                rs.Status = "Success";
                rs.Error = null;
                rs.Data = User;
                return rs;
            }
            else
            {
              
                rs.Status = "Fail";
                rs.Error = null;
                rs.Data = null;
                return rs;
            }
        }



    }


}

    

