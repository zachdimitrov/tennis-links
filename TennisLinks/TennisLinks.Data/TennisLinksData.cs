using System;
using System.Collections.Generic;
using TennisLinks.Data.Interfaces;
using TennisLinks.Data.Repositories;
using TennisLinks.Models;

namespace TennisLinks.Data
{
    public class TennisLinksData : ITennisLinksData
    {
        private ITennisLinksDbContext context;

        private IDictionary<Type, object> dict;

        public TennisLinksData(ITennisLinksDbContext context)
        {
            this.context = context;
        }

        public IRepository<Message> Messages
        {
            get
            {
                return this.GetRepository<Message>();
            }
        }

        public IUserRepository Users
        {
            get
            {
                return (IUserRepository)this.GetRepository<User>();
            }
        }

        private IRepository<T> GetRepository<T>()
            where T : class
        {
            var type = typeof(T);

            if (!dict.ContainsKey(type))
            {
                var repositoryType = typeof(EfRepository<T>);

                if (type.IsAssignableFrom(typeof(User)))
                {
                    repositoryType = typeof(IUserRepository);
                }

                var instance = Activator.CreateInstance(repositoryType, this.context);

                dict.Add(type, instance);
            }

            return (IRepository<T>)dict[type];
        }
    }
}
