namespace Services.Helpers.Interfaces
{
    public interface IValidable<in T>
    {
        ServiceError Validate(T data);
    }
}