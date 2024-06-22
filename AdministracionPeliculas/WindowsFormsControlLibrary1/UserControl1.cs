using InitializeComponent
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace AdministracionPeliculas
{
    public partial class Form1 : Form
    {
        private List<Pelicula> peliculas = new List<Pelicula>();

        public Form1()
        {
            InitializeComponent();
            // Evento Load del formulario
            this.Load += Form1_Load;
            // Eventos de los botones
            btnCargarImagen.Click += BtnCargarImagen_Click;
            btnAgregar.Click += BtnAgregar_Click;
            btnActualizar.Click += BtnActualizar_Click;
            btnEliminar.Click += BtnEliminar_Click;
            lstPeliculas.SelectedIndexChanged += LstPeliculas_SelectedIndexChanged;
        }

        // Cargar películas al cargar el formulario
        private void Form1_Load(object sender, EventArgs e)
        {
            CargarPeliculas();
        }

        // Método para cargar la lista de películas en el ListBox
        private void CargarPeliculas()
        {
            lstPeliculas.Items.Clear();
            foreach (Pelicula pelicula in peliculas)
            {
                lstPeliculas.Items.Add(pelicula.Titulo);
            }
        }

        // Evento al seleccionar una película en el ListBox
        private void LstPeliculas_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstPeliculas.SelectedIndex != -1)
            {
                Pelicula peliculaSeleccionada = peliculas[lstPeliculas.SelectedIndex];
                txtTitulo.Text = peliculaSeleccionada.Titulo;
                txtDescripcion.Text = peliculaSeleccionada.Descripcion;
                pbImagen.Image = peliculaSeleccionada.Poster;
            }
        }

        // Evento para cargar una imagen desde el disco
        private void BtnCargarImagen_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Archivos de imagen|*.jpg;*.jpeg;*.png;*.bmp";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                pbImagen.Image = new Bitmap(openFileDialog.FileName);
            }
        }

        // Evento para agregar una nueva película
        private void BtnAgregar_Click(object sender, EventArgs e)
        {
            string titulo = txtTitulo.Text;
            string descripcion = txtDescripcion.Text;
            Image imagen = (pbImagen.Image != null) ? new Bitmap(pbImagen.Image) : null;

            Pelicula nuevaPelicula = new Pelicula(titulo, descripcion, imagen);
            peliculas.Add(nuevaPelicula);
            CargarPeliculas();
            LimpiarCampos();
        }

        // Evento para actualizar una película existente
        private void BtnActualizar_Click(object sender, EventArgs e)
        {
            if (lstPeliculas.SelectedIndex != -1)
            {
                string titulo = txtTitulo.Text;
                string descripcion = txtDescripcion.Text;
                Image imagen = (pbImagen.Image != null) ? new Bitmap(pbImagen.Image) : null;

                Pelicula peliculaSeleccionada = peliculas[lstPeliculas.SelectedIndex];
                peliculaSeleccionada.Titulo = titulo;
                peliculaSeleccionada.Descripcion = descripcion;
                peliculaSeleccionada.Poster = imagen;

                CargarPeliculas();
                LimpiarCampos();
            }
        }

        // Evento para eliminar una película
        private void BtnEliminar_Click(object sender, EventArgs e)
        {
            if (lstPeliculas.SelectedIndex != -1)
            {
                peliculas.RemoveAt(lstPeliculas.SelectedIndex);
                CargarPeliculas();
                LimpiarCampos();
            }
        }

        // Método para limpiar los campos del formulario
        private void LimpiarCampos()
        {
            txtTitulo.Text = "";
            txtDescripcion.Text = "";
            pbImagen.Image = null;
            lstPeliculas.ClearSelected();
        }
    }
}
