using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Xamarin.Forms;

namespace Aula2UX
{
	public partial class Anuncios : ContentPage
	{
		public ObservableCollection<Anuncio> dados { get; set; }

		public Anuncios()
		{
			//jamais coloque codigo pesado aqui
			dados = new ObservableCollection<Anuncio>();
			BindingContext = this;
			InitializeComponent();
		}

		protected override void OnAppearing()
		{
			base.OnAppearing();
			CarregarDados();
		}

		void Handle_ItemSelected(object sender, Xamarin.Forms.SelectedItemChangedEventArgs e)
		{
			if (e.SelectedItem == null) return;
			var anuncio = (Anuncio)e.SelectedItem;

			Navigation.PushAsync(new Detalhes(anuncio));
			((ListView)sender).SelectedItem = null;
		}

		//void CarregarDados()
		//{
		//	var url = "https://classidiario.odiario.com/api/busca";
		//	var web = new HttpClient();
		//	var json = web.GetStringAsync(url);

		//	var anuncios = JsonConvert.DeserializeObject<List<Anuncio>>(json.Result);
		//	foreach (var anuncio in anuncios)
		//	{
		//		dados.Add(anuncio);
		//	}
		//}

		//async void CarregarDados()
		//{
		//	var url = "https://classidiario.odiario.com/api/busca";
		//	var web = new HttpClient();
		//	var json = await web.GetStringAsync(url);

		//	var anuncios = JsonConvert.DeserializeObject<List<Anuncio>>(json);
		//	foreach (var anuncio in anuncios)
		//	{void abrirAnuncios(object sender, System.EventArgs e)
		//		dados.Add(anuncio);
		//	}
		//}

		async Task CarregarDados()
		{
			var url = "https://classidiario.odiario.com/api/busca";
			var web = new HttpClient();
			var json = await web.GetStringAsync(url);

			var anuncios = JsonConvert.DeserializeObject<List<Anuncio>>(json);
			foreach (var anuncio in anuncios)
			{
				dados.Add(anuncio);
			}
		}

	}
}
