using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static CapaDatos1.DALconexion;

namespace CapaDatos1
{
    public class DALProductos
    {
        Conexion conexion = new Conexion();

        public DataTable ListarProductos()
        {
            SqlDataAdapter da = new SqlDataAdapter(
            "SELECT IdProducto, StrNombre, StrCodigo, NumPrecioCompra, NumPrecioVenta, NumStock FROM TBLPRODUCTO",
            conexion.cn);

            DataTable dt = new DataTable();
            da.Fill(dt);

            return dt;
        }

        public void Insertar(string nombre, string codigo, float precioCompra, float precioVenta, int categoria, string detalle, string foto, int stock)
        {
            conexion.cn.Open();

            SqlCommand cmd = new SqlCommand(
            "INSERT INTO TBLPRODUCTO (StrNombre,StrCodigo,NumPrecioCompra,NumPrecioVenta,IdCategoria,StrDetalle,strFoto,NumStock) " +
            "VALUES (@nombre,@codigo,@compra,@venta,@categoria,@detalle,@foto,@stock)",
            conexion.cn);

            cmd.Parameters.AddWithValue("@nombre", nombre);
            cmd.Parameters.AddWithValue("@codigo", codigo);
            cmd.Parameters.AddWithValue("@compra", precioCompra);
            cmd.Parameters.AddWithValue("@venta", precioVenta);
            cmd.Parameters.AddWithValue("@categoria", categoria);
            cmd.Parameters.AddWithValue("@detalle", detalle);
            cmd.Parameters.AddWithValue("@foto", foto);
            cmd.Parameters.AddWithValue("@stock", stock);

            cmd.ExecuteNonQuery();
            conexion.cn.Close();
        }

        public void Editar(int id, string nombre, string codigo, float precioCompra, float precioVenta, int categoria, string detalle, string foto, int stock)
        {
            conexion.cn.Open();

            SqlCommand cmd = new SqlCommand(
            "UPDATE TBLPRODUCTO SET StrNombre=@nombre,StrCodigo=@codigo,NumPrecioCompra=@compra,NumPrecioVenta=@venta," +
            "IdCategoria=@categoria,StrDetalle=@detalle,strFoto=@foto,NumStock=@stock WHERE IdProducto=@id",
            conexion.cn);

            cmd.Parameters.AddWithValue("@id", id);
            cmd.Parameters.AddWithValue("@nombre", nombre);
            cmd.Parameters.AddWithValue("@codigo", codigo);
            cmd.Parameters.AddWithValue("@compra", precioCompra);
            cmd.Parameters.AddWithValue("@venta", precioVenta);
            cmd.Parameters.AddWithValue("@categoria", categoria);
            cmd.Parameters.AddWithValue("@detalle", detalle);
            cmd.Parameters.AddWithValue("@foto", foto);
            cmd.Parameters.AddWithValue("@stock", stock);

            cmd.ExecuteNonQuery();
            conexion.cn.Close();
        }

        public void Eliminar(int id)
        {
            conexion.cn.Open();

            SqlCommand cmd = new SqlCommand(
            "DELETE FROM TBLPRODUCTO WHERE IdProducto=@id",
            conexion.cn);

            cmd.Parameters.AddWithValue("@id", id);

            cmd.ExecuteNonQuery();
            conexion.cn.Close();
        }
    }
}
