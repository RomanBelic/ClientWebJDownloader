using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Entities
{
    public class UserType : DefaultEntity
    {
        protected override object Key { get => id; }

        private int id;
        public int Id { get => id; set => id = value; }
        
        public override bool IsEmpty()
        {
            return this.id <= 0;
        }

        private string nameStr;
        public string NameStr { get => nameStr; set => nameStr = value; }
    }
}
