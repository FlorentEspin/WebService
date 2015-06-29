using System;
using System.Collections.Generic;
using Newtonsoft.Json;
namespace WebApiRest.Models
{
    public partial class NORME
    {
        public NORME()
        {
            this.JEUs = new List<JEU>();
        }

        public int ID_NORME { get; set; }
        public string DESCRIPTION { get; set; }
        [JsonIgnore]
        public virtual ICollection<JEU> JEUs { get; set; }
    }
}
