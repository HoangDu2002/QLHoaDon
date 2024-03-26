using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace project_OOP_demo
{
    class account
    {
        private string tentaikhoan;

        public string Tentaikhoan 
        { 
          get => tentaikhoan; 
          set => tentaikhoan = value; 
        }
      

        private string matkhau;
        public string Matkhau
        {
            get => matkhau;
            set => matkhau = value;
        }
        public account(string tentaikhoan, string matkhau)
        {
            this.Tentaikhoan = tentaikhoan;
            this.Matkhau = matkhau;
        }
    
    
    }
}
