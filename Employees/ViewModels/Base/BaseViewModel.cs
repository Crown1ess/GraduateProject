using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;

namespace Employees.ViewModels.Base
{
    internal abstract class BaseViewModel : INotifyPropertyChanged, IDisposable
    {
        #region INotifyPropertyChanged
        /// <summary>
        /// Уведомления
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;
        public virtual void OnPropertyChanged([CallerMemberName]string property = null)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(property));
        }
        #endregion

        #region Dispose
        /// <summary>
        /// запуск сборщика
        /// </summary>
        private bool disposed;
        protected virtual void Dispose(bool Disposing)
        {
            if (!Disposing || disposed) return;
            disposed = true;
        }
        public void Dispose()
        {
            Dispose(true);
        }
        #endregion
    }
}
