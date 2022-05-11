﻿using System;
using System.Collections.Generic;
using System.Text;

namespace DataLayer
{
    interface IDB<T, K>
    {
     void Create(T item);

    T Read(K key, bool noTracking = false, bool useNavigationProperties = false);

    IEnumerable<T> ReadAll(bool useNavigationProperties = false);


    void Update(T item, bool useNavigationProperties = false);

    void Delete(K key);

}
}
