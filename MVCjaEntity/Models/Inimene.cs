using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace MVCjaEntity.Models
{
    public class Inimene
    {
        [DisplayName("Inimese isikukood")]
        public int Nr { get; set; }
        public string Nimi { get; set; }
        [DisplayName("vanus või Age kuidas tahad")]
        public int Vanus { get; set; }
    }
}