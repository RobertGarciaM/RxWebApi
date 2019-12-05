using System;
using System.Collections.Generic;
using System.Text;

namespace DataApi.Helpers
{
    public static class MySettingsDb
    {
        static string netTestConecction;

        /// <summary>
        ///This method change the value of connection string of the application.
        ///If the value is different of null this return an exception
        /// </summary>
        /// <param name="Connection"></param>
        public static void SetNetTestConecction(string Connection)
        {
            if (netTestConecction == null) { netTestConecction = Connection; return; }
            throw new System.ArgumentException("No is possible change the value of connection string");
        }

        /// <summary>
        /// This method Get  the value of string connection
        /// </summary>
        /// <returns>connection string </returns>
        public static string GetNetTestConecction() { return netTestConecction; }
    }
}
