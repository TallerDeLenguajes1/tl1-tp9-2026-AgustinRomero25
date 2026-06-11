using System.IO;
using System.Runtime.Serialization.Formatters;

Console.WriteLine("--------------------------------- Sistema de Solicitud de Datos -----------------------------------");
string DirectorioIngresado;

do
{
    Console.WriteLine("Ingrese el directorio a analizar: ");
    DirectorioIngresado = Console.ReadLine();
    if(!Directory.Exists(DirectorioIngresado))
    {
        Console.WriteLine("Error. Ingrese un directorio valido.");
    } else
    {
        string[] Carpetas = Directory.GetDirectories(DirectorioIngresado);
        string[] Archivos = Directory.GetFiles(DirectorioIngresado);

        for(int i = 0; i < Carpetas.Length; i++)
        {
            DirectoryInfo Carpeta = new DirectoryInfo(Carpetas[i]);
            Console.WriteLine(Carpeta.Name);
        }
        
        StreamWriter Reporte = new StreamWriter("reporte_archivos.csv");
        Reporte.WriteLine("Nombre  |  Kb  |  Fecha Modificacion");

        for(int j = 0; j < Archivos.Length; j++)
        {
            FileInfo Archivo = new FileInfo(Archivos[j]);
            double Kbytes = (double)Archivo.Length / 1024;
            if (Archivo.Name != "reporte_archivos.csv")
            {
                Console.WriteLine($"{Archivo.Name} - {Kbytes:F2} Kb.");
                Reporte.WriteLine($"{Archivo.Name}  |  {Kbytes:F2} Kb  |  {Archivo.LastWriteTime}");
            }
        }
        Reporte.Close();
    }
} while (!Directory.Exists(DirectorioIngresado));
