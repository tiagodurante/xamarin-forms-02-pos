using Xamarin.Forms;

namespace Aula2UX
{
	public partial class Aula2UXPage : ContentPage
	{

		public object Email
		{
			get;
			set;
		}

		public object Senha
		{
			get;
			set;
		}

		public Command CmdNavegar
		{
			get;
			set;
		}

		public Aula2UXPage()
		{
			Email = "tiagodurante@icloud.com";

			CmdNavegar = new Command(Navegar);

			BindingContext = this;
			InitializeComponent();
		}

		void Navegar()
		{
			Navigation.PushAsync(new MyPage());
		}
	}
}