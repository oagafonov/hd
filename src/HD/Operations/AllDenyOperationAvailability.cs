namespace HD.Operations
{
    class AllDenyOperationAvailability : IOperationAvailablity
    {
        public bool CanClose => false;
        public bool CanReject => false;
        public bool CanWork => false;
        public bool CanDone => false;
    }
}
