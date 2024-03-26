using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace project_OOP_demo
{
    public class accountlist
    {
        private static accountlist instance;
        public static accountlist Instance 
        {   get
            {
                if (instance == null)
                    instance = new accountlist();
                return instance;
            }

            set => instance = value; }

        List<account> listtaikhoan;

        internal List<account> Listtaikhoan 
        { 
            get => listtaikhoan; 
            set => listtaikhoan = value; 
        }
        

        accountlist()
        {
            listtaikhoan = new List<account>();
            listtaikhoan.Add(new account("admin", "123123"));
            
        }
    }
}
