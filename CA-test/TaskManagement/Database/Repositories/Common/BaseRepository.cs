using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagement.Database.Models;
using TaskManagement.Database.Models.Common;

namespace TaskManagement.Database.Repositories.Common
{
    public abstract class BaseRepository<TDomain, TKey>
        where TKey : struct
        where TDomain : BaseEntity<TKey>
    {
        protected List<TDomain> _entries;

        public BaseRepository(List<TDomain> entries)
        {
            _entries = entries;
        }

        public List<TDomain> GetAll()
        {
            return _entries;
        }
        public List<TDomain> GetAll(Predicate<TDomain> expression)
        {
            List<TDomain> filteredEntries = new List<TDomain>();

            foreach (TDomain entry in _entries)
            {
                if (expression(entry))
                {
                    filteredEntries.Add(entry);
                }
            }

            return filteredEntries;
        }


        public void Insert(TDomain entry)
        {
            _entries.Add(entry);
        }
        public void InsertRange(List<TDomain> entries)
        {
            _entries.AddRange(entries);
        }

        public TDomain? GetById(TKey id)
        {
            foreach (TDomain entry in _entries)
            {
                //Upcasting
                if (entry.Id.Equals(id))
                {
                    return entry;
                }
            }

            return default;
        }
        public TDomain? GetBy(Predicate<TDomain> expression)
        {
            foreach (TDomain entry in _entries)
            {
                //Upcasting
                if (expression(entry))
                {
                    return entry;
                }
            }

            return default;
        }

        public void RemoveById(TKey id)
        {
            _entries.Remove(GetById(id)!);
        }
        public void RemoveBy(Predicate<TDomain> expression)
        {
            _entries.Remove(GetBy(expression)!);
        }
        public void Remove(TDomain entry)
        {
            _entries.Remove(entry);
        }
    }
}
