namespace discipline.hangfire.shared.abstractions.Identifiers;

public sealed record UserId(Ulid Value)
{
    public static UserId New()
        => new (Ulid.NewUlid());

    public override string ToString()
        => Value.ToString();

    public static UserId Empty()
        => new UserId(Ulid.Empty);

    public static UserId Parse(string stringTypedId)
    {
        if (!Ulid.TryParse(stringTypedId, out var parsedId))
        {
            throw new ArgumentException($"Can not parse stronglyTypedId of type: {nameof(UserId)}");
        }

        return new UserId(parsedId);
    }
}