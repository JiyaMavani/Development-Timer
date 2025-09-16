using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevelopmentTimer.DAL.Enums
{
    public enum Role
    {
        Admin,
        Developer
    }
    public enum Status
    {
        Active,
        InProgress,
        Completed,
        Pending,
        Approved,
        Rejected,
        NotStarted,
        OnHold,
        PendingExtension
    }
}