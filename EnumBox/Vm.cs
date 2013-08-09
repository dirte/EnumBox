using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using EnumBox.Annotations;

namespace EnumBox
{
    class Vm :INotifyPropertyChanged
    {
        public Vm()
        {
            PaymentFrequencyList = EnumVm.CreateList();
        }
        public List<EnumVm> PaymentFrequencyList { get; private set; }

        private EnumVm _paymentFrequency;
        public EnumVm PaymentFrequency
        {
            get { return _paymentFrequency; }
            set
            {
                if (Equals(value, _paymentFrequency)) return;
                _paymentFrequency = value;
                OnPropertyChanged();
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
