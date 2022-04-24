using ArbanZones.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Web;
using System.Web.Script.Serialization;

namespace ArbanZones.CommonMethod
{
    public class Services
    {
        string MyUserId, MyPassword, MySenderId, MyRoute, SmsType, applicationID, senderId, message;
        public Services()
        {
            //
            // TODO: Add constructor logic here
            //
            MySenderId = "SenderId";
            MyUserId = "SenderUserId";
            MyPassword = "SenderPassword";
            SmsType = "Trans";
            MyRoute = "15";
            /// Push notification Server Id
            applicationID = "AAAATBzXzgY:APA91bF4FRFm82CYsKrAJ8O3ClmvRP4NBASkA_zNCE2tLVr4NVQrGUturdD0PUvOP3YQmQ9Kkri5fPXtyXwcHmjLt_0u9v3Jr45fchHdyf0OAWpQJC4K3u5EFc2NZUbI2Eij3IcvfvKo";
            senderId = "326901419526";
        }
        public bool SendMySMS(string MobNo, string Message)
        {
            try
            {
                string APIUrl = "http://pro.hrcs.in/api/mt/SendSMS?user=" + MyUserId + "&password=" + MyPassword + "&senderid=" + MySenderId + "&channel=" + SmsType + "&DCS=0&flashsms=0&number=91" + MobNo + "&text=" + Message + "&route=" + MyRoute;
                WebClient wc = new WebClient();
                string result = wc.DownloadString(APIUrl);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public string PushNotification(string Message, string Tittle, string Token)
        {
            try
            {
                WebRequest tRequest = WebRequest.Create("https://fcm.googleapis.com/fcm/send");
                tRequest.Method = "post";
                tRequest.ContentType = "application/json";
                var data = new
                {
                    to = Token,
                    notification = new
                    {
                        body = Message,
                        title = Tittle,
                        icon = "https://www.drravibhaskar.com/wp-content/uploads/sites/4/2017/04/cropped-logo-85x85.png",
                        sound = "default"
                    }
                };
                var serializer = new JavaScriptSerializer();
                var json = serializer.Serialize(data);
                Byte[] byteArray = Encoding.UTF8.GetBytes(json);
                tRequest.Headers.Add(string.Format("Authorization: key={0}", applicationID));
                tRequest.Headers.Add(string.Format("Sender: id={0}", senderId));
                tRequest.ContentLength = byteArray.Length;
                using (Stream dataStream = tRequest.GetRequestStream())
                {
                    dataStream.Write(byteArray, 0, byteArray.Length);
                    using (WebResponse tResponse = tRequest.GetResponse())
                    {
                        using (Stream dataStreamResponse = tResponse.GetResponseStream())
                        {
                            using (StreamReader tReader = new StreamReader(dataStreamResponse))
                            {
                                String sResponseFromServer = tReader.ReadToEnd();

                                //message = sResponseFromServer;
                                message = "True";

                            }
                        }
                    }
                }

            }
            catch (Exception ex)
            {
                message = "Opps! PushNotification Not Respond";
            }
            return message;
        }
        public string PushNotification(string Message, string Tittle, string Token, List<UserDetails> userDetails)
        {
            try
            {


                WebRequest tRequest = WebRequest.Create("https://fcm.googleapis.com/fcm/send");
                tRequest.Method = "post";
                tRequest.ContentType = "application/json";
                foreach (var item in userDetails)
                {
                    if (item.DeviceToken != "-" && item.DeviceToken != null && item.DeviceToken != "")
                    {
                        var data = new
                        {
                            to = item.DeviceToken,
                            notification = new
                            {
                                body = Message,
                                title = Tittle,
                                icon = "https://www.drravibhaskar.com/wp-content/uploads/sites/4/2017/04/cropped-logo-85x85.png",
                                sound = "default"
                            }
                        };
                        var serializer = new JavaScriptSerializer();
                        var json = serializer.Serialize(data);
                        Byte[] byteArray = Encoding.UTF8.GetBytes(json);
                        tRequest.Headers.Add(string.Format("Authorization: key={0}", applicationID));
                        tRequest.Headers.Add(string.Format("Sender: id={0}", senderId));
                        tRequest.ContentLength = byteArray.Length;
                        using (Stream dataStream = tRequest.GetRequestStream())
                        {
                            dataStream.Write(byteArray, 0, byteArray.Length);
                            using (WebResponse tResponse = tRequest.GetResponse())
                            {
                                using (Stream dataStreamResponse = tResponse.GetResponseStream())
                                {
                                    using (StreamReader tReader = new StreamReader(dataStreamResponse))
                                    {
                                        String sResponseFromServer = tReader.ReadToEnd();

                                        //message = sResponseFromServer;
                                        message = "True";

                                    }
                                }
                            }
                        }
                    }

                }
            }
            catch (Exception ex)
            {
                message = "Opps! PushNotification Not Respond";
            }
            return message;
        }
    }
}