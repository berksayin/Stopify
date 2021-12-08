using System;
using System.Collections.Generic;

#nullable disable

namespace Stopify.DB.Entities
{
    public partial class User
    {
        //Database model.

        public int Id { get; set; }
        public int UserType { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }
    }
}
