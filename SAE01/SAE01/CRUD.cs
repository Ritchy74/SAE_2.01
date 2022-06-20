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
