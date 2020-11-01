using System;
using Xamarin.Forms;

namespace UserBase.Presentation.Behaviors
{
    public class EntryLineValidationBehavior : BehaviorBase<Entry>
    {
        public static readonly BindableProperty IsValidProperty =
            BindableProperty.Create(
                nameof(IsValid),
                typeof(bool),
                typeof(EntryLineValidationBehavior),
                true,
                BindingMode.Default,
                null,
                (bindable, oldValue, newValue) => OnIsValidChanged(bindable, newValue));

        public bool IsValid
        {
            get
            {
                return (bool)GetValue(IsValidProperty);
            }
            set
            {
                SetValue(IsValidProperty, value);
            }
        }

        private static void OnIsValidChanged(BindableObject bindable, object newValue)
        {
            if (bindable is EntryLineValidationBehavior IsValidBehavior &&
                 newValue is bool IsValid)
            {
                IsValidBehavior.AssociatedObject.PlaceholderColor = IsValid ? Color.Default : Color.Red;
            }
        }
    }
}
