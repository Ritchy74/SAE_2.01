/**
 * @file CRUD.cs
 * Interface CRUD (Create, Read, Update, Delete)
 * @author Guyon Remy
 * @author Collombet Nathan
 * @author Corvaisier-Palluy Leo
 * @date Juin 2022
 * @version 1.0
 */
using System;
using System.Collections.Generic;
using System.Text;

namespace SAE01
{
    public interface CRUD<T>
    {
        void Create();
        void Read();
        void Update();
        void Delete();
        List<T> FindAll();
        List<T> FindBySelection(string criteres);
    }
}
