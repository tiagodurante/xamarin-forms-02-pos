using System;
using System.ComponentModel;

namespace Aula2UX
{
	public class Anuncio : INotifyPropertyChanged
	{
		public string Imagem { get; set; }
		public int Id { get; set; }
		public string Titulo { get; set; }
		public string Valor { get; set; }
		public string Src => "https://classidiario.odiario.com/content/media/imagem/" + Imagem;

		private string _texto;
		public string Texto
		{
			get
			{
				return _texto;
			}
			set
			{
				_texto = value;
				OnPropertyChanged("Texto");
			}
		}

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
