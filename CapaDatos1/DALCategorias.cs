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
    public class DALCategorias
    {
        Conexion conexion = new Conexion();

        public DataTable ListarCategorias()
        {
            SqlDataAdapter da = new SqlDataAdapter(
            "SELECT IdCategoria, StrDescripcion FROM TBLCATEGORIA_PROD",
            conexion.cn);

            DataTable dt = new DataTable();
            da.Fill(dt);

            return dt;
        }
        public void Insertar(string descripcion)
        {
            conexion.cn.Open();

            SqlCommand cmd = new SqlCommand(
            "INSERT INTO TBLCATEGORIA_PROD (StrDescripcion) VALUES (@descripcion)",
            conexion.cn);

            cmd.Parameters.AddWithValue("@descripcion", descripcion);

            cmd.ExecuteNonQuery();
            conexion.cn.Close();
        }
        public void Editar(int id, string descripcion)
        {
            conexion.cn.Open();

            SqlCommand cmd = new SqlCommand(
            "UPDATE TBLCATEGORIA_PROD SET StrDescripcion=@descripcion WHERE IdCategoria=@id",
            conexion.cn);

            cmd.Parameters.AddWithValue("@id", id);
            cmd.Parameters.AddWithValue("@descripcion", descripcion);

            cmd.ExecuteNonQuery();
            conexion.cn.Close();
        }
        public void Eliminar(int id)
        {
            conexion.cn.Open();

            SqlCommand cmd = new SqlCommand(
            "DELETE FROM TBLCATEGORIA_PROD WHERE IdCategoria=@id",
            conexion.cn);

            cmd.Parameters.AddWithValue("@id", id);

            cmd.ExecuteNonQuery();
            conexion.cn.Close();
        }

    }
}
