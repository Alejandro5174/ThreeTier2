using CapaDatos1;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaNegocios
{
    public class BLLFacturas
    {
        DALFacturas dal = new DALFacturas();

        public DataTable ListarFacturas()
        {
            return dal.ListarFacturas();
        }
        public DataTable CargarClientes()
        {
            return dal.CargarClientes();
        }
        public DataTable CargarEmpleados()
        {
            return dal.CargarEmpleados();
        }
        public DataTable CargarEstados()
        {
            return dal.CargarEstados();
        }
        public void GuardarFactura(int IdCliente, int IdEmpleado, int IdEstado, double descuento, double impuesto, double total, DataTable detalle)
        {
            dal.GuardarFactura(IdCliente, IdEmpleado, IdEstado, descuento, impuesto, total, detalle);
        }
        public void EditarFactura(int IdFactura, int IdCliente, int IdEmpleado, int IdEstado, double total)
        {
            dal.EditarFactura(IdFactura, IdCliente, IdEmpleado, IdEstado, total);
        }
        public void Eliminar(int IdFactura)
        {
            dal.Eliminar(IdFactura);
        }

    }
}
