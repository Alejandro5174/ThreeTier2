using CapaDatos1;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaNegocios
{
    public class BLLRoles
    {
        DALRoles roles = new DALRoles();

        public DataTable ListarRoles()
        {
            return roles.ListarRoles();
        }
        public void Insertar(string descripcion)
        {
            roles.Insertar(descripcion);
        }

        public void Editar(int id, string descripcion)
        {
            roles.Editar(id, descripcion);
        }

        public void Eliminar(int id)
        {
            roles.Eliminar(id);
        }
    }
}

