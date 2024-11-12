using System;

namespace CrossCutting
{
    public static class ExtensionDatetime
    {
        public static object GetDbValue(this DateTime? pFecha)
        {
            object oFecha;
            if (pFecha.HasValue)
            {
                oFecha = pFecha.Value;
            }
            else
            {
                oFecha = DBNull.Value;
            }

            return oFecha;
        }
    }
}
