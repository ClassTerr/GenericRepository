namespace GenericRepository.Common.Common;

public class ValueAccessor<T>
{
    private readonly Func<T> _accessor;

    public ValueAccessor(Func<T> accessor)
    {
        _accessor = accessor ?? throw new ArgumentNullException(nameof(accessor));
    }

    public T Value => _accessor();
}
