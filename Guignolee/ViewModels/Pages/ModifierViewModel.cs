using System;

namespace Guignolee.ViewModels.Pages
{
    public class ModifierViewModel : ValidableViewModel
    {
        private DonViewModel _donEdit;
        public DonViewModel DonEdit
        {
            get { return _donEdit; }
            set
            {
                if (_donEdit != value)
                {
                    _donEdit = value;
                    RaisePropertyChanged();
                }
            }
        }

        public ModifierViewModel(DonViewModel donViewModel)
        {
            DonEdit = donViewModel;
        }
    }
}
