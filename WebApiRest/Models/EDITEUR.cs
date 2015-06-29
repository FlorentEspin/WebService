using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace WebApiRest.Models
{
    public partial class EDITEUR
    {
        public EDITEUR()
        {
            this.JEUs = new List<JEU>();
        }

        public int ID_EDITEUR { get; set; }
        public string NOM_EDITEUR { get; set; }
        [JsonIgnore]
        public virtual ICollection<JEU> JEUs { get; set; }
    }
}
