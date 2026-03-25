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
    public class DALCliente
    {
        Conexion conexion = new Conexion();
        public DataTable ListarClientes()
        {
            SqlDataAdapter da = new SqlDataAdapter(
            "SELECT * FROM TBLCLIENTES", conexion.cn);

            DataTable dt = new DataTable();
            da.Fill(dt);

            return dt;
        }
        public void Insertar(string nombre, long documento, string direccion, string telefono, string email, DateTime fechaModifica, string usuario)
        {
            conexion.cn.Open();

            SqlCommand cmd = new SqlCommand(
            "INSERT INTO TBLCLIENTES (StrNombre, NumDocumento, StrDireccion, StrTelefono, StrEmail, DtmFechaModifica, StrUsuarioModifica) " +
            "VALUES (@nombre,@documento,@direccion,@telefono,@email,@fecha,@usuario)",
            conexion.cn);

            cmd.Parameters.AddWithValue("@nombre", nombre);
            cmd.Parameters.AddWithValue("@documento", documento);
            cmd.Parameters.AddWithValue("@direccion", direccion);
            cmd.Parameters.AddWithValue("@telefono", telefono);
            cmd.Parameters.AddWithValue("@email", email);
            cmd.Parameters.AddWithValue("@fecha", fechaModifica);
            cmd.Parameters.AddWithValue("@usuario", usuario);

            cmd.ExecuteNonQuery();
            conexion.cn.Close();
        }
        public void Editar(int idCliente, string nombre, long documento, string direccion, string telefono, string email, DateTime fechaModifica, string usuario)
        {
            conexion.cn.Open();

            SqlCommand cmd = new SqlCommand(
            "UPDATE TBLCLIENTES SET " +
            "StrNombre=@nombre, " +
            "NumDocumento=@documento, " +
            "StrDireccion=@direccion, " +
            "StrTelefono=@telefono, " +
            "StrEmail=@email, " +
            "DtmFechaModifica=@fecha, " +
            "StrUsuarioModifica=@usuario " +
            "WHERE IdCliente=@id",
            conexion.cn);

            cmd.Parameters.AddWithValue("@id", idCliente);
            cmd.Parameters.AddWithValue("@nombre", nombre);
            cmd.Parameters.AddWithValue("@documento", documento);
            cmd.Parameters.AddWithValue("@direccion", direccion);
            cmd.Parameters.AddWithValue("@telefono", telefono);
            cmd.Parameters.AddWithValue("@email", email);
            cmd.Parameters.AddWithValue("@fecha", fechaModifica);
            cmd.Parameters.AddWithValue("@usuario", usuario);

            cmd.ExecuteNonQuery();
            conexion.cn.Close();
        }
        public void Eliminar(int idCliente)
        {
            conexion.cn.Open();

            SqlCommand cmd = new SqlCommand(
            "DELETE FROM TBLCLIENTES WHERE IdCliente=@id",
            conexion.cn);

            cmd.Parameters.AddWithValue("@id", idCliente);

            cmd.ExecuteNonQuery();
            conexion.cn.Close();
        }
    }
}
