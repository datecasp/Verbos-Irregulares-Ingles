using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Verbos_Irregulares_Inglés.Modelos
{
    public class VerboCell : VerbosIngles, INotifyPropertyChanged
    {
        string? _castellano;
        string? _infinitivo;
        string? _pasado;
        string? _participio;

        public VerboCell(string castellano, string infinitivo, string pasado, string participio)
        {
            this._castellano = castellano;
            this._infinitivo = infinitivo;
            this._pasado = pasado;
            this._participio = participio;
        }

        public string castellano
        {
            get { return _castellano; }
            set
            {
                _castellano = value;
                OnPropertyChanged("castellano");
            }
        }

        public string infinitivo
        {
            get { return _infinitivo; }
            set
            {
                _infinitivo = value;
                OnPropertyChanged("infinitivo");
            }
        }

        public string pasado
        {
            get { return _pasado; }
            set
            {
                _pasado = value;
                OnPropertyChanged("pasado");
            }
        }

        public string participio
        {
            get { return _participio; }
            set
            {
                _participio = value;
                OnPropertyChanged("participio");
            }
        }

        private ObservableCollection<VerboCell> _verboLista = new ObservableCollection<VerboCell>();
        public ObservableCollection<VerboCell> verboLista
        {
            get { return _verboLista; }
            set
            {
                if (_verboLista != value)
                {
                    _verboLista = value;
                    OnPropertyChanged("verboLista");
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged(string propname)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propname));
        }
    }
}
