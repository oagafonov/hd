namespace HD.Operations
{
    class WorkIssueOperationAvailability : IOperationAvailablity
    {
        public bool CanClose => false;
        public bool CanReject => true;
        public bool CanWork => false;
        public bool CanDone => true;
    }
}
