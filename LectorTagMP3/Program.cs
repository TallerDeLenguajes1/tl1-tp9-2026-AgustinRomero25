using System.IO;
using System.Text;
using HerramientasDeAccesoMP3;

Console.WriteLine("============================================== Lector Tag MP3 =======================================================");

string DirectorioIngresado;
string Texto;
Id3v1Tag Datos = new Id3v1Tag();

do
{
    Console.WriteLine("Ingrese directorio del archivo MP3:");
    DirectorioIngresado = Console.ReadLine();
    if(File.Exists(DirectorioIngresado))
    {
        Console.WriteLine("Archivo encontrado.");
    }
    else
    {
        Console.WriteLine("El archivo no existe.");
    }
} while (!File.Exists(DirectorioIngresado));

using (FileStream fs = new FileStream(DirectorioIngresado, FileMode.Open))
{
    if(fs.Length < 128)
    {
        Console.WriteLine("Archivo inválido.");
        return;
    }
    
    fs.Seek(fs.Length - 128, SeekOrigin.Begin);

    byte[] buffer = new byte[128];
    int leidos = fs.Read(buffer, 0, 128);
    // los bytes son binarios: para usarlos como texto, se convierten
    Texto = Encoding.UTF8.GetString(buffer, 0, leidos);
}  // el using cierra el stream y libera recursos

string tag = Texto.Substring(0,3);

if(tag == "TAG")
{
    Datos.ObtenerTitulo = Texto.Substring(3, 30);
    Datos.ObtenerArtista = Texto.Substring(33, 30);
    Datos.ObtenerAlbum = Texto.Substring(63, 30);

    string Anio = Texto.Substring(93, 4).Trim();
    Datos.ObtenerAnio = int.Parse(Anio);
    string Titulo = Datos.ObtenerTitulo;
    string Artista = Datos.ObtenerArtista;
    string Album = Datos.ObtenerAlbum;

    Console.WriteLine($"Titulo: {Titulo}\nArtista: {Artista}\nAlbum: {Album}\nAño: {Anio}");
} else
{
    Console.WriteLine("El archivo no contiene una etiqueta ID3v1.");
}