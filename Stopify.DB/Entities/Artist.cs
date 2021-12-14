using System;
using System.Collections.Generic;

#nullable disable

namespace Stopify.DB.Entities
{
    public partial class Artist
    {
        public Artist()
        {
            Song = new HashSet<Song>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }

        public virtual ICollection<Song> Song { get; set; }
    }
}
