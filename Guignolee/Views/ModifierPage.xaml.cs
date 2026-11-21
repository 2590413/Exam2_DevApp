
using Guignolee.Models;
using Guignolee.ViewModels;
using Guignolee.ViewModels.Pages;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Navigation;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace Guignolee.Views
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class ModifierPage : Page
    {
        public ModifierViewModel ViewModel { get; private set;}
        public ModifierPage()
        {
            
            ViewModel = new ModifierViewModel(new DonViewModel(new Don()));
            InitializeComponent();
           
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            if (e.Parameter is DonViewModel DonSelectionne)
            {
                DonViewModel copie = new DonViewModel(new Don
                {
                    Id = DonSelectionne.Id,
                    Donateur = DonSelectionne.Donateur,
                    Contenu = DonSelectionne.Contenu,
                    Quantite = DonSelectionne.Quantite,
                    EstPerissable = DonSelectionne.EstPerissable,
                    EstRemis = DonSelectionne.EstRemis
                });

                ViewModel.DonEdit = copie;
            }
            
        }


        private void btnEnregistrer_Click(object sender, RoutedEventArgs e)
        {
            if (ViewModel.DonEdit.EstValide)
            {
                Frame.Navigate(typeof(RegistrePage), ViewModel.DonEdit);
            }
        }

        private void btnAnnuler_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(RegistrePage));
        }
    }
}

