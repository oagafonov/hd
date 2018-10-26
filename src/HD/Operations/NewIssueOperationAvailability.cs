namespace HD.Operations
{
    class NewIssueOperationAvailability : IOperationAvailablity
    {
        public bool CanClose => false;
        public bool CanReject => true;
        public bool CanWork => true;
        public bool CanDone => false;
    }
}
