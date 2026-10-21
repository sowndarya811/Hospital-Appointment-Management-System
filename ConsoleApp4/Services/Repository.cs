using System;
using System.Collections.Generic;
using System.Text;

namespace Hospital_Appointment_Management_System.Services
{
    public class Repository<T>:IRepository<T>
    {
        private readonly List<T> _items;
        private readonly Func<T,string>_idSelector;

        public Repository(Func<T,string>idSelector)
        {
            _items=new List<T>();
            _idSelector=idSelector;
        }
        public void Add(T item)
        {
            _items.Add(item);
        }
        public List<T>GetAll()
        {
            return _items.ToList();
        }
        public T?GetById(string id)
        {
            return _items.FirstOrDefault(
                item =>_idSelector(item)
                    .Equals(id,StringComparison.OrdinalIgnoreCase));
        }

        public void Update(T item)
        {
            string id=_idSelector(item);
            T?existingItem=GetById(id);
            if(existingItem==null)
            {
                return;
            }
            int index=_items.IndexOf(existingItem);

            _items[index]=item;
        }
        public void Delete(string id)
        {
            T?item=GetById(id);

            if(item!=null)
            {
                _items.Remove(item);
            }
        }
    }
}