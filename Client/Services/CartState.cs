using System;

namespace UmotaWebApp.Client.Services
{
    public class CartState
    {
        private int _sepetUrunSayisi;

        public int SepetUrunSayisi
        {
            get => _sepetUrunSayisi;
            set
            {
                if (_sepetUrunSayisi != value)
                {
                    _sepetUrunSayisi = value;
                    NotifyStateChanged();
                }
            }
        }

        public event Action OnChange;

        private void NotifyStateChanged() => OnChange?.Invoke();
    }
}
