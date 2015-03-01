using Pipeline;
using Risk.Api._Api.Personal;

namespace Risk.Api.Domain
{
    public interface IRiskStore
    {
        void Save(Risk risk);
        void Update(ICommand command);
    }
}
