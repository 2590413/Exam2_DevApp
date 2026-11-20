using Guignolee.Models;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Guignolee.ViewModels
{
    public class DonViewModel : ValidableViewModel
    {
        private readonly Don _don;

        public DonViewModel(Don don)
        {
            _don = don;
            _errors.Add("Donateur", new ObservableCollection<ValidationResult>());
            _errors.Add("Contenu", new ObservableCollection<ValidationResult>());
            _errors.Add("Quantite", new ObservableCollection<ValidationResult>());

            Validate(Donateur, nameof(Donateur));
            Validate(Contenu, nameof(Contenu));
            Validate(Quantite, nameof(Quantite));

        }

        public int Id => _don.Id;

        [Required(ErrorMessage = "Le champ est requis")]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "De 2 à 50 caractères.")]
        [RegularExpression(@"^[\p{L}\d ]+$", ErrorMessage = "Lettres, chiffres et espaces seulement.")]
        public string Donateur
        {
            get { return _don.Donateur; }
            set
            {
                if (_don.Contenu != value && Validate(value))
                {
                    _don.Donateur = value;
                    RaisePropertyChanged();
                }
            }
        }

        [Required(ErrorMessage = "Le champ est requis")]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "De 2 à 50 caractères.")]
        [RegularExpression(@"^[\p{L}\d ]+$", ErrorMessage = "Lettres, chiffres et espaces seulement.")]
        [DeniedValues(["Nourriture", "Divers", "Denrées"], ErrorMessage = "Précisez votre contenu.")]
        public string Contenu
        {
            get { return _don.Contenu; }
            set
            {
                if (_don.Contenu != value && Validate(value))
                {
                    _don.Contenu = value;
                    RaisePropertyChanged();
                }
         
            }
        }

        [Range(1, 100, ErrorMessage = "La quantité doit être entre 1 et 100")]
        [Required(ErrorMessage = "Le champ est requis")]
        public int Quantite
        {
            get { return _don.Quantite; }
            set
            {
                if (Quantite != value && Validate(value))
                {
                    _don.Quantite = value;
                    RaisePropertyChanged();
                }
            }
        }


        public bool EstPerissable
        {
            get { return _don.EstPerissable; }
            set
            {
                if (_don.EstPerissable != value)
                {
                    _don.EstPerissable = value;
                    RaisePropertyChanged();
                }
            }
        }

        public bool EstRemis
        {
            get { return _don.EstRemis; }
            set
            {
                if (_don.EstRemis != value)
                {
                    _don.EstRemis = value;
                    RaisePropertyChanged();
                }
            }
        }

        public DateTime DateReception => _don.DateReception;

        public string Details
        {
            get
            {   
                if (_don.EstPerissable)
                {
                    return $"{_don.Quantite} article(s) - {_don.Donateur} - reçu le {_don.DateReception:dd-MM-yyyy} (Périssable)";
                }
                else
                {
                    return $"{_don.Quantite} article(s) - {_don.Donateur} - reçu le {_don.DateReception:dd-MM-yyyy}";
                }
            }
        }
    }
}
