using BeerBuddy.Models;

namespace BeerBuddy.Factory
{
    public interface IFactory<T> where T : BaseEntity
    {}
}