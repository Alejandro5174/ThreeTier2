using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static CapaDatos1.DALconexion;
using CapaDatos1;

namespace CapaNegocios
{
    public class BLLProductos
    {
        DALProductos productos = new DALProductos();

        public DataTable ListarProductos()
        {
            return productos.ListarProductos();
        }
        public void Insertar(string nombre, string codigo, float precioCompra, float precioVenta,
                            int categoria, string detalle, string foto, int stock)
        {
            productos.Insertar(nombre, codigo, precioCompra, precioVenta,
                               categoria, detalle, foto, stock);
        }

        public void Editar(int id, string nombre, string codigo, float precioCompra, float precioVenta,
                           int categoria, string detalle, string foto, int stock)
        {
            productos.Editar(id, nombre, codigo, precioCompra, precioVenta,
                             categoria, detalle, foto, stock);
        }
        public void Eliminar(int id)
        {
            productos.Eliminar(id);
        }
    }
}
