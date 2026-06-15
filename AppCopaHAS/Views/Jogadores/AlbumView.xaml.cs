using AppCopaHAS.ViewModels;

namespace AppCopaHAS.Views.Jogadores;

public partial class AlbumView : ContentPage
{
	AlbumViewModel viewModel;
	public AlbumView()
	{
		InitializeComponent();

		viewModel = new AlbumViewModel();
		BindingContext = viewModel;
		Title = "Álbum";
	}
}