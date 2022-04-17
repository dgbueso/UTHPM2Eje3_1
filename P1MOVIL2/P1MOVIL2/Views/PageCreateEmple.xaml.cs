﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using P1MOVIL2.Models;



using Xamarin.Forms;
using Xamarin.Forms.Xaml;


namespace P1MOVIL2.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PageCreateEmple : ContentPage
    {
        public PageCreateEmple()
        {
            InitializeComponent();
        }

        private async void btnagregar_Clicked(object sender, EventArgs e)
        {
            var emple = new Empleados
            {
                nombre = Nombre.Text,
                apellidos = Apellidos.Text,
                edad = Convert.ToInt32(Edad.Text),
                ocupacion = Ocupacion.Text,
                direccion = direccion.Text
            };
            var resultado = await App.BaseDatos.EmpleadoGuardar(emple);
            if (resultado != 0)
               await DisplayAlert("Aviso", "Empleado Guardado Satisfactoriamente", "OK");
            else
                await DisplayAlert("Aviso", "Error al Guardar", "OK");
            await Navigation.PopAsync();
        }

        private async void btnborrar_Clicked(object sender, EventArgs e)
        {
            var emple = await App.BaseDatos.GetEmpleadosByIdAsync(Convert.ToInt32(codigo.Text));
            if (emple != null)
            {
                await App.BaseDatos.EmpleadoBorrar(emple);
                await DisplayAlert("Aviso", "Eliminado Correctamente", "OK");
                await Navigation.PopAsync();
            }
        }
        public async void llenardatos()
        {
            var empleList = await App.BaseDatos.GetEmpleados();
            
        }
        private async void btnactualizar_Clicked(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(codigo.Text))
            {
                Empleados emple = new Empleados()
                {
                    codigo=Convert.ToInt32(codigo.Text),
                    nombre = Nombre.Text,
                    apellidos = Apellidos.Text,
                    edad = Convert.ToInt32(Edad.Text),
                    ocupacion = Ocupacion.Text,
                    direccion = direccion.Text
                };
                await App.BaseDatos.EmpleadoGuardar(emple);
                await DisplayAlert("Aviso", "Actualizado Correctamente", "OK");
                await Navigation.PopAsync();
            }
        }
    }
}