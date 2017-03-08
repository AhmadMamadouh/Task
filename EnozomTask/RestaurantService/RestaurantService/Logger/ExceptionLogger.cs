using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace RestaurantService.Logger
{
    public class ExceptionLogger
    {

        public string RecordExceptionlog(Exception ex)
        {


            string _strGUID = new Guid().ToString();
            string filePath = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Error.txt");


            using (StreamWriter writer = new StreamWriter(filePath, true))
            {
                writer.WriteLine("GUID : " + _strGUID + "<br/>" + Environment.NewLine + "Message :" + ex.Message + "<br/>" + Environment.NewLine + "StackTrace :" + ex.StackTrace +
                   "" + Environment.NewLine + "Date :" + DateTime.Now.ToString());
                writer.WriteLine(Environment.NewLine + "-----------------------------------------------------------------------------" + Environment.NewLine);
            }

            return _strGUID;
        }
    }
}