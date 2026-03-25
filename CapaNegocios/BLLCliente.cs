using CapaDatos1;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaNegocios
{
    public class BLLCliente
    {
        DALCliente dal = new DALCliente();

        public DataTable ListarClientes()
        {
            return dal.ListarClientes();
        }
        public void Insertar(string nombre, long documento, string direccion, string telefono, string email)
        {
            dal.Insertar(
                nombre,
                documento,
                direccion,
                telefono,
                email,
                DateTime.Now,     
                "admin"          
            );
        }
        public void Editar(int idCliente, string nombre, long documento, string direccion, string telefono, string email)
        {
            dal.Editar(
                idCliente,
                nombre,
                documento,
                direccion,
                telefono,
                email,
                DateTime.Now,
                "admin"
            );
        }
        public void Eliminar(int idCliente)
        {
            dal.Eliminar(idCliente);
        }
    }
}
