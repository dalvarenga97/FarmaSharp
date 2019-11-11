using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace FarmaSharp
{
    /// <summary>
    /// Lógica de interacción para w_Medicamento.xaml
    /// </summary>
    public partial class w_Medicamento : Window
    {

        FarmaciaEntities datos;

        public w_Medicamento()
        {
            InitializeComponent();
            datos = new FarmaciaEntities();
        }


        void CargarGrilla()
        {
            dgMedicamento.ItemsSource = datos.Medicamento.ToList();
        }
        private void dgMedicamento_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (dgMedicamento.SelectedItem != null)
            {
                Medicamento m = (Medicamento)dgMedicamento.SelectedItem;

                txtId.Text = m.Id.ToString();
                txtNombre.Text = m.NombreMedicamento;
                txtDescripcion.Text = m.DescripcionMedicamento;
                txtObservacion.Text = m.ObservacionMedicamento;

                if (rdbPastillas.IsChecked == true)
                {
                    //rdbPastillas.IsChecked = m.tipomedicamento.Valu 
                }

            }
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            CargarGrilla();
        }

        private void btnGuardar_Click(object sender, RoutedEventArgs e)
        {
            Medicamento m = new Medicamento();
            m.NombreMedicamento = txtNombre.Text;
            m.DescripcionMedicamento = txtDescripcion.Text;
            m.ObservacionMedicamento = txtObservacion.Text;
            if (rdbPastillas.IsChecked == true)
                m.tipomedicamento = rdbPastillas.Content.ToString();
            else if (rdbJarabe.IsChecked == true)
                m.tipomedicamento = rdbJarabe.Content.ToString();
            else if (rdbInyectable.IsChecked == true)
                m.tipomedicamento = rdbInyectable.Content.ToString();

            datos.Medicamento.Add(m);
            datos.SaveChanges();
            CargarGrilla();
        }

        private void ModificacionDeMaterial(object sender, RoutedEventArgs e)
        {

        }

        private void BtnLimpiar_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnEliminar_Click(object sender, RoutedEventArgs e)
        {
            if (dgMedicamento.SelectedItem != null)
            {
                Medicamento m = (Medicamento)dgMedicamento.SelectedItem;
                datos.Medicamento.Remove(m);
                datos.SaveChanges();
                CargarGrilla();
            }
            else
            {

                MessageBox.Show("Debe Seleccionar Un Medicamento");

            }
        }
    }
}
