using System;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Xml.Serialization;

namespace CrossCutting
{
    public static class ExtensionGeneric
    {
        /// <summary>
        /// Permite una clonación en profundidad de origen
        /// </summary>
        /// <param name="origen">Objeto serializable</param>
        /// <exception cref="ArgumentExcepcion">
        /// Se produce cuando el objeto no es serializable.
        /// </exception>
        /// <remarks>Extraido de 
        /// http://es.debugmodeon.com/articulo/clonar-objetos-de-estructura-compleja
        /// http://geeks.ms/blogs/jvelasco/archive/2011/01/23/c-implementar-la-interface-icloneable.aspx
        /// </remarks>
        public static T Copia<T>(T origen)
        {
            // Verificamos que sea serializable antes de hacer la copia            
            if (!typeof(T).IsSerializable)
                throw new ArgumentException("La clase " + typeof(T).ToString() + " no es serializable");
            
            // En caso de ser nulo el objeto, se devuelve tal cual
            if (Object.ReferenceEquals(origen, null))
                return default(T);
            
            //Creamos un stream en memoria            
            IFormatter formatter = new BinaryFormatter();
            Stream stream = new MemoryStream();
            using (stream)
            {
                try
                {
                    formatter.Serialize(stream, origen);
                    stream.Seek(0, SeekOrigin.Begin);
                    //Deserializamos la porcón de memoria en el nuevo objeto                
                    return (T)formatter.Deserialize(stream);
                }
                catch (SerializationException ex)
                { throw new ArgumentException(ex.Message, ex); }
                catch { throw; }
            }
        }

        public static string SerializeToFile(this object dataToSerialize)
        {
            if (dataToSerialize == null) return null;

            using (var stringwriter = new StringWriter())
            {
                var serializer = new XmlSerializer(dataToSerialize.GetType());
                serializer.Serialize(stringwriter, dataToSerialize);
                var fileName = ToFile(stringwriter.ToString(), string.Format("{0}.xml", Guid.NewGuid()));
                return fileName;
            }
        }

        public static string ToFile(string content, string file)
        {
            var pathType = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, file.Substring(file.IndexOf('.') + 1));
            if (!Directory.Exists(pathType)) Directory.CreateDirectory(pathType);
            var path = Path.Combine(pathType, file);
            if (File.Exists(path))
            {
                File.AppendAllText(path, string.Format("{0}{1}", content, Environment.NewLine));
            }
            else
                File.WriteAllText(path, content);

            return path;
        }
    }
}
