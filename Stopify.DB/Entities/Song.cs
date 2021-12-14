using System;
using System.Collections.Generic;

#nullable disable

namespace Stopify.DB.Entities
{
    public partial class Song
    {
        public int Id { get; set; }
        public string SongName { get; set; }
        public int ArtistId { get; set; }

        public virtual Artist Artist { get; set; }
    }
}
