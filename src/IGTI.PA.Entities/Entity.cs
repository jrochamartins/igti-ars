using System;

namespace IGTI.PA.Entities
{
    public abstract class Entity
    {
        private string _id;

        public string Id
        {
            get
            {
                if (string.IsNullOrWhiteSpace(_id))
                    _id = Guid.NewGuid().ToString();
                return _id;
            }
            set => _id = value;
        }
    }
}
