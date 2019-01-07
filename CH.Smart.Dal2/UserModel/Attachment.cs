using System;
using System.Collections.Generic;

namespace CH.Smart.Dal2.UserModel
{
    public partial class Attachment
    {
        public int Id { get; set; }
        public string Path { get; set; }
        public byte Type { get; set; }
        public string Data { get; set; }
        public int Owner { get; set; }
        public int RefCount { get; set; }
        public DateTime UploadTime { get; set; }
    }
}
