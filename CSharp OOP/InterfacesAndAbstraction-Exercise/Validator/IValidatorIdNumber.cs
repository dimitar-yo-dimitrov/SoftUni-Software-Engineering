using System;
using System.Collections.Generic;
using System.Text;

namespace Validator
{
    public interface IValidatorIdNumber
    {
        public string Id { get; }

        public bool ValidatePersonalIdNumber(string Id);
    }
}
