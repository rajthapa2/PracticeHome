using System;

namespace Pipeline
{
    public class RangeValidationException  :Exception, IExceptionValidation
    {
        public object Value { get; set; }

        public RangeValidationException(object value) : this("Range Validation", value)
        {
            Value = value;
        }

        public RangeValidationException(string message, object value) : base(message)
        {
            Value = value;
        }
    }

    public interface IExceptionValidation
    {
        object Value { get; set; }
    }
}
