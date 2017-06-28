using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Entities
{
    public class Link : DefaultEntity
    {
        protected override object Key { get => id; }

        private int id;
        public int Id { get => id; set => id = value; }

        private string url;
        public string Url { get => url; set => url = value; }
       
        int idUser;
        public int IdUser { get => idUser; set => idUser = value; }

        private DateTime dateCreated;
        public DateTime DateCreated { get => dateCreated; set => dateCreated = value; }

        private string name;
        public string Name { get => name; set => name = value; }

        public string DateCreatedStr
        {
            get => (dateCreated > DateTime.MinValue) ? dateCreated.ToString("dd/MM/yyyy") : String.Empty;
        }

        public override bool IsEmpty()
        {
            return this.id <= 0;
        }
    }
}
