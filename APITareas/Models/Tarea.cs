﻿namespace APITareas.Models
{
    public class Tarea
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public string Prioridad { get; set; }
        public int IdEstado { get; set; }
    }
}
