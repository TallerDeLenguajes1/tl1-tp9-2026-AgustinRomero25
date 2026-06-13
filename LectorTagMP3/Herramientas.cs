namespace HerramientasDeAccesoMP3
{
    public class  Id3v1Tag
    {
        private string Titulo;
        private string Artista;
        private string Album;
        private int AnioCancion;

        public string ObtenerTitulo {
            get {return Titulo;}
            set {Titulo = value;}
        }
        public string ObtenerArtista {
            get {return Artista;}
            set {Artista = value;}
        }
        public string ObtenerAlbum {
            get {return Album;}
            set {Album = value;}
        }
        public int ObtenerAnio {
            get {return AnioCancion;}
            set {AnioCancion = value;}
        }
    }
}