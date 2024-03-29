﻿namespace SpaceStation.Repositories.Contracts
{
    using System.Collections.Generic;

    public interface IRepository<T>
    {
        IReadOnlyCollection<T> Models { get; }

        void Add(T planet);

        bool Remove(T model);

        T FindByName(string name);
    }
}
