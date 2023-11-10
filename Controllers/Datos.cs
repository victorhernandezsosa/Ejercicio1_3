using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ejercicio1_3.Models;
using SQLite;

namespace Ejercicio1_3.Controllers
{
    public class Datos
    {
        readonly SQLiteAsyncConnection dbase;

        public Datos(String dbpath)
        {
            dbase = new SQLiteAsyncConnection(dbpath);

            //Crearemos las tablas de la base de datos 
            dbase.CreateTableAsync<Personas>(); //Creado la tabla de Empleado
        }

        public Task<int> PersonSave(Personas person)
        {
            if (person.Id != 0)
            {
                return dbase.UpdateAsync(person); // Update
            }
            else
            {
                return dbase.InsertAsync(person); ;// Insert
            }
        }

        // Read
        public Task<List<Personas>> obtenerPersonlist()
        {
            return dbase.Table<Personas>().ToListAsync();
        }

        // Read V2
        public Task<Personas> obtenerPerson(int pid)
        {
            return dbase.Table<Personas>()
                .Where(i => i.Id == pid)
                .FirstOrDefaultAsync();
        }

        // Delete
        public Task<int> PersonDelete(Personas emple)
        {
            return dbase.DeleteAsync(emple);
        }

    }
}
