namespace UB_BikeRental.Interfaces
{
    public interface IEntity<T>
    {
        T Id { get; set; }
    }
}
