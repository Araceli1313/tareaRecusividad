using System;
using System.IO;

class Program
{
    static void Main()
    {
        string ruta = @"C:\Carpeta"; 
        string extension = ".txt"; 

        int totalElementos = ContarArchivosYCarpetas(ruta);
        Console.WriteLine($"Número total de archivos y carpetas: {totalElementos}");

        Console.WriteLine($"\nArchivos con extensión {extension} encontrados:");
        BuscarArchivosPorExtension(ruta, extension);
    }

    static int ContarArchivosYCarpetas(string ruta)
    {
        int contador = 0;
        try
        {
            string[] archivos = Directory.GetFiles(ruta);
            contador += archivos.Length;

            string[] carpetas = Directory.GetDirectories(ruta);
            contador += carpetas.Length;

            foreach (string carpeta in carpetas)
            {
                contador += ContarArchivosYCarpetas(carpeta);
            }
        }
        catch (UnauthorizedAccessException)
        {
            Console.WriteLine($"Acceso denegado a la carpeta: {ruta}");
        }
        return contador;
    }

    static void BuscarArchivosPorExtension(string ruta, string extension)
    {
        try
        {
            string[] archivos = Directory.GetFiles(ruta, $"*{extension}");
            foreach (string archivo in archivos)
            {
                Console.WriteLine(archivo);
            }

            string[] carpetas = Directory.GetDirectories(ruta);
            foreach (string carpeta in carpetas)
            {
                BuscarArchivosPorExtension(carpeta, extension);
            }
        }
        catch (UnauthorizedAccessException)
        {
            Console.WriteLine($"Acceso denegado a la carpeta: {ruta}");
        }
    }
}