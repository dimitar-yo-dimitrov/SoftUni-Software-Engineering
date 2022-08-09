
namespace Validator
{
    public interface IEgnValidator
    {
        public string Egn { get; }

        public bool ValidateEgn(string Egn);
    }
}
