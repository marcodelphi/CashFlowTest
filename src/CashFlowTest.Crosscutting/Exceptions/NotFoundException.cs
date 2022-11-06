using CashFlowTest.Crosscutting.Constants;

namespace CashFlowTest.Crosscutting.Exceptions;

public sealed class NotFoundException : ErrorCodeException
{
    public NotFoundException() : this(string.Empty) { }

    public NotFoundException(string message) : base(ApplicationErrorCodesConstants.NOT_FOUND, message) { }
}
