using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDatos1;

namespace CapaNegocios
{
    public class BLLSeguridad
    {
        DALSeguridad seguridad = new DALSeguridad();

        public bool ValidarUsuario(string usuario, string clave)
        {
            return seguridad.ValidarUsuario(usuario, clave);
        }
        public void Insertar(int idEmpleado, string usuario, string clave)
        {
            seguridad.Insertar(idEmpleado, usuario, clave);
        }
        public DataTable ListarUsuarios()
        {
            return seguridad.ListarUsuarios();
        }
        public void Eliminar(int id)
        {
            seguridad.Eliminar(id);
        }
        public void Editar(int id, int idEmpleado, string usuario, string clave)
        {
            seguridad.Editar(id, idEmpleado, usuario, clave);
        }
    }
}
