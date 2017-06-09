using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Entities
{
    public abstract class DefaultEntity {

        protected abstract object Key { get; }

        public override bool Equals(object obj)
        {
            return obj is DefaultEntity && ((DefaultEntity)obj).Key.Equals(Key);
        }

        public override int GetHashCode()
        {
            return new { Key }.GetHashCode();
        }

        public virtual bool IsEmpty()
        {
            return true;
        }
    }
}
