using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace WebApiRest.Models
{
    public partial class GENRE
    {
        public GENRE()
        {
            this.JEUs = new List<JEU>();
        }

        public int ID_GENRE { get; set; }
        public string NOM_GENRE { get; set; }
        [JsonIgnore]
        public virtual ICollection<JEU> JEUs { get; set; }
    }
}
