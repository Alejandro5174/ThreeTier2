using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static CapaDatos1.DALconexion;

namespace CapaDatos1
{
    public class DALSeguridad
    {
        Conexion conexion = new Conexion();

        public bool ValidarUsuario(string usuario, string clave)
        {
            conexion.cn.Open();

            SqlCommand cmd = new SqlCommand(
                "SELECT COUNT(*) FROM TBLSEGURIDAD WHERE StrUsuario=@usuario AND StrClave=@clave",
                conexion.cn);

            cmd.Parameters.AddWithValue("@usuario", usuario);
            cmd.Parameters.AddWithValue("@clave", clave);

            int count = (int)cmd.ExecuteScalar();

            conexion.cn.Close();

            return count > 0;
        }
        public void Insertar(int idEmpleado, string usuario, string clave)
        {
            conexion.cn.Open();

            SqlCommand cmd = new SqlCommand(
            "INSERT INTO TBLSEGURIDAD (IdEmpleado, StrUsuario, StrClave) VALUES (@emp,@user,@clave)",
            conexion.cn);

            cmd.Parameters.AddWithValue("@emp", idEmpleado);
            cmd.Parameters.AddWithValue("@user", usuario);
            cmd.Parameters.AddWithValue("@clave", clave);

            cmd.ExecuteNonQuery();
            conexion.cn.Close();
        }
        public DataTable ListarUsuarios()
        {
            SqlDataAdapter da = new SqlDataAdapter(
            "SELECT s.IdSeguridad, e.StrNombre, s.StrUsuario, s.StrClave " +
            "FROM TBLSEGURIDAD s " +
            "INNER JOIN TBLEMPLEADO e ON s.IdEmpleado = e.IdEmpleado",
            conexion.cn);

            DataTable dt = new DataTable();
            da.Fill(dt);

            return dt;
        }
        public void Eliminar(int id)
        {
            conexion.cn.Open();

            SqlCommand cmd = new SqlCommand(
                "DELETE FROM TBLSEGURIDAD WHERE IdSeguridad=@id",
                conexion.cn);

            cmd.Parameters.AddWithValue("@id", id);

            cmd.ExecuteNonQuery();

            conexion.cn.Close();
        }
        public void Editar(int id, int idEmpleado, string usuario, string clave)
        {
            conexion.cn.Open();

            SqlCommand cmd = new SqlCommand(
                "UPDATE TBLSEGURIDAD SET IdEmpleado=@idEmpleado, StrUsuario=@usuario, StrClave=@clave WHERE IdSeguridad=@id",
                conexion.cn);

            cmd.Parameters.AddWithValue("@id", id);
            cmd.Parameters.AddWithValue("@idEmpleado", idEmpleado);
            cmd.Parameters.AddWithValue("@usuario", usuario);
            cmd.Parameters.AddWithValue("@clave", clave);

            cmd.ExecuteNonQuery();

            conexion.cn.Close();
        }
    }
}
