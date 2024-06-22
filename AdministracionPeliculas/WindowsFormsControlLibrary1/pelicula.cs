using System.Drawing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsControlLibrary1
{
    internal class pelicula
    {
    }
}

public class Pelicula
{
    public string Titulo { get; set; }
    public string Descripcion { get; set; }
    public Image Poster { get; set; } // Para almacenar la imagen de la película

    // Constructor
    public Pelicula(string titulo, string descripcion, Image poster)
    {
        Titulo = titulo;
        Descripcion = descripcion;
        Poster = poster;
    }
}
