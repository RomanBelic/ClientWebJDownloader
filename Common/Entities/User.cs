using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Entities
{
    public class User : DefaultEntity
    {
        protected override object Key { get => id; }

        private int id;
        public int Id { get => id; set => id = value; }

        private string nom;
        public string Nom { get => nom; set => nom = value; }
        
        private string prenom;
        public string Prenom { get => prenom; set => prenom = value; }
      
        private int idType;
        public int IdType { get => idType; set => idType = value; }
      
        private string pass;
        public string Pass { get => pass; set => pass = value; }
        
        private string login;
        public string Login { get => login; set => login = value; }

        private DateTime dateRegister;
        public DateTime DateRegister { get => dateRegister; set => dateRegister = value; }

        public string DateRegisterStr
        {
            get => (dateRegister > DateTime.MinValue) ? dateRegister.ToString("dd/MM/yyyy") : String.Empty;
        }
       
        public override bool IsEmpty()
        {
            return this.id <= 0;
        }

        public User()
        {
            this.userType = new UserType();
        }

        private UserType userType;
        public UserType UserType { get => userType; set => userType = value; }

    }
}
