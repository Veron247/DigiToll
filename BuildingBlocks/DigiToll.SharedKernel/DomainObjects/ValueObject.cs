namespace DigiToll.SharedKernel.DomainObjects;

public abstract class ValueObject
{
    public override bool Equals(object obj)
    {
        if (obj is not ValueObject other || other.GetType() != this.GetType())
            return false;

        return EqualsCore(other);
    }

    protected abstract bool EqualsCore(ValueObject other);

    public override int GetHashCode()
    {
        return GetHashCodeCore();
    }

    protected abstract int GetHashCodeCore();
}