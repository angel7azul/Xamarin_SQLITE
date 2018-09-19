using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace XamarinSQLITE.Clases
{
    class Tarea
    {
        [PrimaryKey,AutoIncrement, Column("ID")]
        public int Id { get; set; }
        [MaxLength(150)]
        public string Nombre { get; set; }
        public DateTime Fecha { get; set; }
        public TimeSpan Hora { get; set; }
        public bool Completada { get; set; }
    }
}
