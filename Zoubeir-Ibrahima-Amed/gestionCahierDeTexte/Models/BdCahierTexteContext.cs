using MySql.Data.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppGestionCahierTexte.Models
{
    [DbConfigurationType(typeof(MySqlEFConfiguration))]
    public class BdCahierTexteContext:DbContext
    {

        public BdCahierTexteContext():base("connCahiertexte")
        {
        }

        public DbSet<Matiere> Matieres { get; set; }
        
        public DbSet<AnneeAcademique>  anneeAcademiques {  get; set; }

        public DbSet<Classe> Classes { get; set; }

    }
}
