using System;
using System.Collections.Generic;

namespace CH.Smart.Dal2.UserModel
{
    public partial class BaseAccount
    {
        public int AccountId { get; set; }
        public string AccountPhone { get; set; }
        public string AccountName { get; set; }
        public string AccountEmail { get; set; }
        public string AccountPasswd { get; set; }
        public string AccountIcon { get; set; }
        public short? AccountType { get; set; }
        public byte Status { get; set; }
        public DateTime Upload { get; set; }
        public DateTime Update { get; set; }
        public string Salt { get; set; }
    }
}
