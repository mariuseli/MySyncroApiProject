using System;
using System.Collections.Generic;
using System.Text;

namespace MySyncroAPI.Domain
{
    public class MySyncSession : EntityBase
    {
        public string SessionName { get; set; }
        public int SessionItemsCount { get; set; }
        public ICollection<MyContact> SyncedContactList { get; set; }
    }
}
