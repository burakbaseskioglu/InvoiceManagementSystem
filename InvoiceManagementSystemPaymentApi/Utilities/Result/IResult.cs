namespace InvoiceManagementSystemPaymentApi.Utilities.Result
{
    public interface IResult
    {
        bool Success { get; }
        string Message { get; }
    }
}
