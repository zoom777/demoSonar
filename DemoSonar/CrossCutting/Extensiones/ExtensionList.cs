using System.Collections.Generic;
using System.Data;
using System.ComponentModel;

namespace CrossCutting
{
    public static class ExtensionList
    {
        /// <summary>
        /// Convierte una Lista Genérica en un DataTable
        /// </summary>
        /// <typeparam name="T">Clase de la lista</typeparam>
        /// <param name="data">Lista Genérica a convertir</param>
        /// <returns></returns>
        public static DataTable ToDataTable<T>(this IList<T> data, string nameTable = "")
        {
            PropertyDescriptorCollection props = TypeDescriptor.GetProperties(typeof(T));

            DataTable table = new DataTable(nameTable);
            for (int i = 0; i < props.Count; i++)
            {
                PropertyDescriptor prop = props[i];
                table.Columns.Add(prop.Name, prop.PropertyType);
            }

            object[] values = new object[props.Count];
            foreach (T item in data)
            {
                for (int i = 0; i < values.Length; i++)
                {
                    values[i] = props[i].GetValue(item);
                }
                table.Rows.Add(values);
            }

            return table;

        }

    }
}
