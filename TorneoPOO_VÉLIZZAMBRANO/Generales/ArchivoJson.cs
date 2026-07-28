using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.Json;

namespace TorneoPOO_VÉLIZZAMBRANO.Generales
{
    public static class ArchivoJson
    {
        private static readonly JsonSerializerOptions opciones = new JsonSerializerOptions
        {
            WriteIndented = true,
            PropertyNameCaseInsensitive = true
        };

        public static List<T> Cargar<T>(string rutaArchivo)
        {
            if (!File.Exists(rutaArchivo))
            {
                return new List<T>();
            }
            string contenido = File.ReadAllText(rutaArchivo);
            return JsonSerializer.Deserialize<List<T>>(contenido, opciones) ?? new List<T>();
        }

        public static void Guardar<T>(string rutaArchivo, List<T> lista)
        {
            // Extraer la ruta del directorio (ej: "Datos")
            string carpeta = Path.GetDirectoryName(rutaArchivo);

            // Si la carpeta no está vacía y no existe en el disco, se crea automáticamente
            if (!string.IsNullOrEmpty(carpeta) && !Directory.Exists(carpeta))
            {
                Directory.CreateDirectory(carpeta);
            }

            string contenido = JsonSerializer.Serialize(lista, opciones);
            File.WriteAllText(rutaArchivo, contenido);
        }
    }
}