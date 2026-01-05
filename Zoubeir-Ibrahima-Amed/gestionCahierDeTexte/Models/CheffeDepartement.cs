using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppGestionCahierTexte.Models
{
    /// <summary>
    /// Classe représentant un chef de département dans le système
    /// Hérite de la classe Utilisateur
    /// Le chef de département a les permissions d'administrateur (accès complet à tous les modules)
    /// </summary>
    public class CheffeDepartement : Utilisateur
    {
    }
}
