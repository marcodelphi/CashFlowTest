using CashFlowTest.Crosscutting.Constants;

namespace CashFlowTest.Crosscutting.Exceptions;

public sealed class ReferenceEntityNotFoundException : ErrorCodeException
{
    public ReferenceEntityNotFoundException() : this(string.Empty) { }

    public ReferenceEntityNotFoundException(string message) : base(ApplicationErrorCodesConstants.REFERENCE_ENTITY_NOT_FOUND, message) { }
}
