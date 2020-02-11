using LogitechAudioVisualizer.Helpers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq.Expressions;
using System.Runtime.CompilerServices;
using System.Windows.Threading;

namespace LogitechAudioVisualizer.ViewModels
{
    public abstract class ObservableObjectBase : INotifyPropertyChanged, INotifyPropertyChanging
    {
        protected readonly Dictionary<string, object> _valueByPropertyName;

        protected ObservableObjectBase()
        {
            _valueByPropertyName = new Dictionary<string, object>(StringComparer.Ordinal);
        }

        protected T Get<T>(Expression<Func<T>> property, T defaultValue = default(T))
        {
            return GetCore(GetPropertyName(property), defaultValue);
        }

        protected T Get<T>([CallerMemberName] string propertyName = null, T defaultValue = default(T))
        {
            return GetCore(propertyName, defaultValue);
        }

        protected bool Set<T>(Expression<Func<T>> property, T value, bool forceUpdate = false, IEqualityComparer<T> equalityComparer = null)
        {
            string propertyName = GetPropertyName(property);

            return SetCore(value, propertyName, forceUpdate, equalityComparer);
        }

        protected bool Set(Expression<Func<string>> property, string value, bool forceUpdate = false, IEqualityComparer<string> equalityComparer = null)
        {
            string propertyName = GetPropertyName(property);

            // For strings, use a case-sensitive ordinal comparer by default.
            return SetCore(value, propertyName, forceUpdate, equalityComparer ?? StringComparer.Ordinal);
        }

        protected bool Set<T>(T value, [CallerMemberName] string propertyName = null, bool forceUpdate = false, IEqualityComparer<T> equalityComparer = null)
        {
            return SetCore(value, propertyName, forceUpdate, equalityComparer);
        }

        protected bool Set(string value, [CallerMemberName] string propertyName = null, bool forceUpdate = false, IEqualityComparer<string> equalityComparer = null)
        {
            // For strings, use a case-sensitive ordinal comparer by default.
            return SetCore(value, propertyName, forceUpdate, equalityComparer ?? StringComparer.Ordinal);
        }

        protected static string GetPropertyName<T>(Expression<Func<T>> expression)
        {
            if (expression == null)
                throw new ArgumentNullException(nameof(expression));

            switch (expression.Body)
            {
                case MemberExpression memberExpression:
                    return memberExpression.Member.Name;
                case UnaryExpression unaryExpression when unaryExpression.Operand is MemberExpression memberExpression:
                    return memberExpression.Member.Name;
                default:
                    throw new ArgumentException("Cannot find the property name from the specified expression.", nameof(expression));
            }
        }

        private T GetCore<T>(string propertyName, T defaultValue = default(T))
        {
            if (propertyName == null)
                throw new ArgumentNullException(nameof(propertyName));

            if (_valueByPropertyName.TryGetValue(propertyName, out object value))
                return (T)value;

            _valueByPropertyName.Add(propertyName, defaultValue);
            return defaultValue;
        }

        protected virtual bool SetCore<T>(T value, string propertyName, bool forceUpdate, IEqualityComparer<T> equalityComparer = null)
        {
            if (propertyName == null)
                throw new ArgumentNullException(nameof(propertyName));

            if (!forceUpdate)
            {
                var oldValue = GetCore<T>(propertyName);
                if (equalityComparer == null)
                {
                    if (Equals(oldValue, value))
                        return false;
                }
                else if (equalityComparer.Equals(oldValue, value))
                    return false;
            }

            OnPropertyChanging(propertyName);

            _valueByPropertyName[propertyName] = value;

            OnPropertyChanged(propertyName);

            return true;
        }

        #region INotifyPropertyChanged

        [field: NonSerialized]
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChangedEventHandler propertyChanged = PropertyChanged;
            if (propertyChanged == null)
                return;

            DispatcherHelper.BeginInvokeIfRequired(
                () => propertyChanged.Invoke(this, new PropertyChangedEventArgs(propertyName)),
                DispatcherPriority.DataBind
            );
        }

        #endregion

        #region INotifyPropertyChanging

        public event PropertyChangingEventHandler PropertyChanging;

        protected virtual void OnPropertyChanging(string propertyName)
        {
            PropertyChangingEventHandler propertyChanging = PropertyChanging;
            if (propertyChanging == null)
                return;

            DispatcherHelper.BeginInvokeIfRequired(
                () => propertyChanging.Invoke(this, new PropertyChangingEventArgs(propertyName)),
                DispatcherPriority.DataBind
            );
        }

        #endregion
    }
}
