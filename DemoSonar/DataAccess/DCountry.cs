using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    internal class DCountry : IDataAccess<Country>
    {
        public DCountry()
        {
            
        }
        public void Actualizar(Country pEntidad)
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

        public void Insertar(Country pEntidad)
        {
            throw new NotImplementedException();
        }

        public IQueryable<Country> Listar(Country pEntidad)
        {
            throw new NotImplementedException();
        }

        public Country Obtener(int pId)
        {
            throw new NotImplementedException();
        }

        public bool ValidarExiste(Country pEntity)
        {
            throw new NotImplementedException();
        }
    }
}
