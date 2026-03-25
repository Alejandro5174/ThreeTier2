using CapaDatos1;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaNegocios
{
    public class BLLCategorias
    {

        DALCategorias categorias = new DALCategorias();

        public DataTable ListarCategorias()
        {
            return categorias.ListarCategorias();
        }
        public void Insertar(string descripcion)
        {
            categorias.Insertar(descripcion);
        }

        public void Editar(int id, string descripcion)
        {
            categorias.Editar(id, descripcion);
        }

        public void Eliminar(int id)
        {
            categorias.Eliminar(id);
        }
    }
}
