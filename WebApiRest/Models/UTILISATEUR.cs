using System;
using System.Collections.Generic;

namespace WebApiRest.Models
{
    public partial class UTILISATEUR
    {
        public int ID_UTILISATEUR { get; set; }
        public string LOGIN { get; set; }
        public string PASSWORD { get; set; }
    }
}
