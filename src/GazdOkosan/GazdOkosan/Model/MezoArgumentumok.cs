using System;

namespace GazdOkosan.Model
{
    public class MezoArgumentumok : EventArgs
    {
        private Int32 _lepesszam;

        public Int32 Lepesszam { get { return _lepesszam; } }

        public MezoArgumentumok(Int32 lepesszam)
        {
            _lepesszam = lepesszam;
        }

    }
}
