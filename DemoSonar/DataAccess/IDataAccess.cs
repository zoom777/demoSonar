using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public interface IDataAccess<TEntity> : IDisposable
    {

        ///// <summary>
        ///// Obtiene todas la entidades del tipo TEntity para este repositorio
        ///// </summary>
        ///// <returns>IQueryable de los elementos seleccionados</returns>
        //IQueryable<TEntity> Listar();

        /// <summary>
        /// Obtiene todas la entidades del tipo TEntity para este repositorio
        /// </summary>
        /// <param name="pEntidad">elemento del tipo TEntity para contiene los filtros de busqueda</param>
        /// <returns>IQueryable de los elementos seleccionados</returns>
        IQueryable<TEntity> Listar(TEntity pEntidad);

        /// <summary>
        /// Obtiene un elemento por su Id
        /// </summary>
        /// <param name="pId">Identificador de la entidad</param>
        /// <returns>elemento del tipo TEntity seleccionado</returns>
        TEntity Obtener(int pId);

        /// <summary>
        /// Agrega un elemento del tipo TEntity al repositorio
        /// </summary>
        /// <param name="pEntidad">elemento del tipo TEntity para agregar al repositorio</param>
        void Insertar(TEntity pEntidad);

        /// <summary>
        /// Actualiza un elemento del tipo TEntity en el repositorio
        /// </summary>
        /// <param name="pEntidad">elemento del tipo TEntity para actualizar al repositorio</param>
        void Actualizar(TEntity pEntidad);

        /// <summary>
        /// Elimina un elemento del tipo TEntity en el repositorio
        /// </summary>
        /// <param name="pId">id de elemento a eliminar</param>
        void Eliminar(int pId);

        /// <summary>
        /// Guarda los cambios en el repositorio
        /// </summary>
        /// <returns>cantidad de elementos que fueron afectados</returns>
        int Guardar();

        /// <summary>
        /// Valida si la entidad existe en el repositorio
        /// </summary>
        /// <param name="pEntity">entida que contiene los argumentos para la validacion</param>
        /// <returns>valor binario indicando si existe o no</returns>
        bool ValidarExiste(TEntity pEntity);

        ///// <summary>
        ///// Realiza  el listado basado en un filtro, un ordenamiento y en bloques, funcion para la paginacion.
        ///// </summary>
        ///// <param name="filtro">clase que contiene los datos para filtrar el resultado</param>
        ///// <param name="sortExpression">campo por que se realizara el ordenamiento</param>
        ///// <param name="startRowIndex">fila inicial del bloque de registros que se obtendra</param>
        ///// <param name="maximumRows">numero de filas del bloque de registros que se obtendra</param>
        ///// <returns>listado de resultados filtrados y paginados</returns>
        //IList Listar(TEntity filtro, string sortExpression,
        //                          int startRowIndex, int maximumRows);

        ///// <summary>
        ///// Realiza el conteo total de los registros segun el filtro, funcion para la paginacion.
        ///// </summary>
        ///// <param name="filtro">clase que contiene los datos para filtrar el resultado</param>
        ///// <returns>cantidad total de registros segun el filtro.</returns>
        //int TotalFilter(TEntity filtro);
    }
}
