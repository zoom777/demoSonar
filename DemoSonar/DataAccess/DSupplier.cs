using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity;

namespace DataAccess
{
    internal class DSupplier : IDataAccess<supplier>
    {
        public DSupplier()
        {
            
        }
        public void Actualizar(supplier pEntidad)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public void Eliminar(int pId)
        {
            throw new NotImplementedException();
        }

        public int Guardar()
        {
            throw new NotImplementedException();
        }

        public void Insertar(supplier pEntidad)
        {
            throw new NotImplementedException();
        }

        public IQueryable<supplier> Listar(supplier pEntidad)
        {
            throw new NotImplementedException();
        }

        public supplier Obtener(int pId)
        {
            throw new NotImplementedException();
        }

        public bool ValidarExiste(supplier pEntity)
        {
            throw new NotImplementedException();
        }
    }
}
