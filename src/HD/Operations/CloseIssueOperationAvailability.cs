﻿namespace HD.Operations
{
    class CloseIssueOperationAvailability : IOperationAvailablity
    {
        public bool CanClose => false;
        public bool CanReject => false;
        public bool CanWork => true;
        public bool CanDone => false;
    }
}
