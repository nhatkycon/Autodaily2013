using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
namespace linh.core
{
    #region BaseEntity
    [Serializable]
    public abstract class BaseEntityCollection<T> : List<T> where T : BaseEntity, new()
    {

    }
    [Serializable]
    public abstract class BaseEntity
    {
        public abstract BaseEntity getFromReader(IDataReader rd);
    }

    #endregion

    #region BaseObject
    public interface BaseObject
    {
        void del(string id);
        BaseObject get(string id);
    }
    public class BaseObjectEntity : BaseObject
    {

        public virtual void del(string id)
        {
        }

        public virtual BaseObject get(string id)
        {
            return null;
        }
    }

    #endregion
}
