namespace HD.Operations
{
    public interface IOperationAvailablity
    {
        bool CanClose { get; }
        bool CanReject { get; }
        bool CanWork { get; }
        bool CanDone { get; }
    }
}