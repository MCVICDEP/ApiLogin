using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace apilogin.modelo
{
    public class Usuario
    {
        public int idusuario { get; set; }
        public string dni_usuario { get; set; }
        public string nombres_usuario { get; set; }
        public string correo { get; set; }
        public string password { get; set; }
        public string celular { get; set; }
        public int rol_usuario { get; set; }
        public DateTime fecha_creacion { get; set; }
        public string region { get; set; }
        public int flag { get; set; }
    }
}
