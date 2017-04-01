using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Xamarin.Forms;

namespace Aula2UX
{
	public partial class Detalhes : ContentPage, INotifyPropertyChanged
	{
		public Anuncio Anuncio {
			get;
			set;
		}

		public Detalhes(Anuncio anuncio)
		{
			Anuncio = anuncio;
			BindingContext = this;
			InitializeComponent();
		}

		protected override void OnAppearing()
		{
			base.OnAppearing();
			CarregarDados();
		}

		async Task CarregarDados()
		{
			var url = "https://classidiario.odiario.com/api/anuncio/"+Anuncio.Id;
			var web = new HttpClient();
			var json = await web.GetStringAsync(url);

			Anuncio = JsonConvert.DeserializeObject<Anuncio>(json);

			OnPropertyChanged("Anuncio");
		}

		//exibir todos os dados do anuncio usando a url https://classidiario.odiario.com/api/anuncio/1183935
		// se possivel usar carousel photos
		//entregar em 15 dias no email leandro@lanceloti.com.br

		public event PropertyChangedEventHandler PropertyChanged;

		protected virtual void OnPropertyChanged(string propertyName)
		{
			if (PropertyChanged != null)
			{
				PropertyChanged(this,
					new PropertyChangedEventArgs(propertyName));
			}
		}

	}
}
