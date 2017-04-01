using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Xamarin.Forms;

namespace Aula2UX
{
	public partial class MyPage : ContentPage
	{
			
		public ObservableCollection<Pessoa> Nomes
		{
			get;
			set;
		}

		public MyPage()
		{
			BindingContext = this;

			Nomes = new ObservableCollection<Pessoa>() { new Pessoa { Nome = "Tiago" }, new Pessoa { Nome = "Felipe" } };
			InitializeComponent();
		}

		void adicionar(object sender, System.EventArgs e)
		{
			Navigation.PopAsync();
		}
		void abrirAnuncios(object sender, System.EventArgs e)
		{
			Navigation.PushAsync(new Anuncios());
		}
	}

	public class Pessoa
	{
		public string Nome
		{
			get;
			set;
		}
	}
}
