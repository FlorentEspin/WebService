using System;
using System.Collections.Generic;

namespace WebApiRest.Models
{
    public partial class JEU
    {
        public JEU()
        {
            this.GENREs = new List<GENRE>();
            this.EDITEURs = new List<EDITEUR>();
        }

        public int ID_JEU { get; set; }
        public int ID_NORME { get; set; }
        public string NOM_JEU { get; set; }
        public System.DateTime DATE_DE_SORTIE { get; set; }
        public string DESCRIPTIF { get; set; }
        public string IMAGE { get; set; }
        public virtual NORME NORME { get; set; }
        public virtual ICollection<GENRE> GENREs { get; set; }
        public virtual ICollection<EDITEUR> EDITEURs { get; set; }
    }
}
