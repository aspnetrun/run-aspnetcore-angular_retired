namespace AspnetRunAngular.Core.Entities.Base
{
    public interface IEntityWithTypedId<TId>
    {
        TId Id { get; }
    }
}
