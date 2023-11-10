using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;

namespace Ejercicio1_3.Models
{
    public class Personas
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string Nombres { get; set; }
        public string Apellidos {  get; set; }
        public int Edad {  get; set; }
        public string Correo {  get; set; }
        public string Direccion {  get; set; }
    }
}
