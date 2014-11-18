using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EstacionamentoCSHARP
{
    class Estacionamento_PM
    {
        string _PLACA;
        public string PLACA
        {
            get
            {
                return _PLACA;
            }
            set
            {
                _PLACA = value;
            }
        }

        DateTime _DATA_ENTRADA;
        public DateTime DATA_ENTRADA
        {
            get
            {
                return _DATA_ENTRADA;
            }
            set
            {
                _DATA_ENTRADA = value;
            }
        }

        Nullable<DateTime> _DATA_SAIDA;
        public Nullable<DateTime> DATA_SAIDA
        {
            get
            {
                return _DATA_SAIDA;
            }
            set
            {
                _DATA_SAIDA = value;
            }
        
        }

        Nullable<decimal> _VALOR;
        public Nullable<decimal> VALOR 
        {
            get 
            {
                return _VALOR;
            }
            set 
            {
                _VALOR = value;
            }
        }

    }
}
