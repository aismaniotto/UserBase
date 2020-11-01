using System.Collections.Generic;
using System.Linq;
using UserBase.Entities;

namespace UserBase.Validators
{
    /*
     * Extract and adapated from
      * https://github.com/CrossGeeks/ValidationXFSample/blob/master/ValidationsXFSample/Helpers/Validators/ValidatableObject.cs
      * and 
      * https://xamgirl.com/validation-snippets-in-xamarin-forms/
     */

    public class ValidatableObject<T> : ObservableClass, IValidatable<T>
    {
        public List<IValidationRule<T>> Validations { get; } = new List<IValidationRule<T>>();

        private List<string>  _errors = new List<string>();
        public List<string> Errors
        {
            get { return _errors; }
            set { SetProperty(ref _errors, value); }
        }


        public bool CleanOnChange { get; set; } = true;

        T _value;
        public T Value
        {
            get => _value;
            set
            {
                _value = value;

                if (CleanOnChange)
                    IsValid = true;
            }
        }

        private bool _isValid= true;
        public bool IsValid
        {
            get { return _isValid; }
            set { SetProperty(ref _isValid, value); }
        }

        public virtual bool Validate()
        {
            Errors.Clear();

            IEnumerable<string> errors = Validations.Where(v => !v.Check(Value))
                .Select(v => v.ValidationMessage);

            Errors = errors.ToList();
            IsValid = !Errors.Any();

            return this.IsValid;
        }
        public override string ToString()
        {
            return $"{Value}";
        }
    }
    
}
