using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDatos1;

namespace CapaNegocios
{
    public class BLLEmpleados
    {
        DALEmpleado empleados = new DALEmpleado();

        public void Insertar(string nombre, long documento, string direccion, string telefono, string email, int rol, DateTime ingreso, DateTime retiro)
        {
            empleados.Insertar(nombre, documento, direccion, telefono, email, rol, ingreso, retiro);
        }

        public void Editar(
            int idEmpleado,
            string nombre,
            string documento,
            string direccion,
            string telefono,
            string email,
            int rol,
            DateTime ingreso,
            DateTime retiro)
        {
            empleados.Editar(idEmpleado, nombre, documento, direccion, telefono, email, rol, ingreso, retiro);
        }

        public DataTable ListarEmpleados()
        {
            return empleados.ListarEmpleados();
        }

        public void Eliminar(int id)
        {
            empleados.Eliminar(id);
        }
    }
}

