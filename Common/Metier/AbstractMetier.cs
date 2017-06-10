using Common.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.Entities;
using System.Data.Common;
using System.ComponentModel;

namespace Common.Metier
{
    [DataObject(true)]
    public abstract class AbstractMetier<T> where T : DefaultEntity, new ()
    {
        protected delegate string QueryInjector (Dictionary<string,object> sqlParams);

        private AbstractDAO<T> dao;
        protected AbstractDAO<T> Dao { get => dao; set => dao = value; }
        
        private QueryInjector insertGenerator;
        protected QueryInjector InsertGenerator { get => insertGenerator; set => insertGenerator = value; }

        private QueryInjector updateGenerator;
        protected QueryInjector UpdateGenerator { get => updateGenerator; set => updateGenerator = value; }

        public AbstractMetier()
        {
            this.insertGenerator = (Dictionary<string, object> sqlParams) => String.Empty;
            this.updateGenerator = (Dictionary<string, object> sqlParams) => String.Empty;
        }

        protected AbstractMetier(AbstractDAO<T> daoInstance) : this()
        {
            this.dao = daoInstance;
        }

    }
}
