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
    public class DALEmpleado
    {
        Conexion conexion = new Conexion();

        public DataTable ListarEmpleados()
        {
            SqlDataAdapter da = new SqlDataAdapter(
            "SELECT * FROM TBLEMPLEADO", conexion.cn);

            DataTable dt = new DataTable();
            da.Fill(dt);

            return dt;
        }
        public void Insertar(string nombre, long documento, string direccion, string telefono, string email, int rol, DateTime ingreso, DateTime retiro)
        {
            conexion.cn.Open();

            SqlCommand cmd = new SqlCommand(
            "INSERT INTO TBLEMPLEADO (strNombre, NumDocumento, StrDireccion, StrTelefono, StrEmail, IdRolEmpleado, DtmIngreso, DtmRetiro) " +
            "VALUES (@nombre,@documento,@direccion,@telefono,@email,@rol,@ingreso,@retiro)",
            conexion.cn);

            cmd.Parameters.AddWithValue("@nombre", nombre);
            cmd.Parameters.AddWithValue("@documento", documento);
            cmd.Parameters.AddWithValue("@direccion", direccion);
            cmd.Parameters.AddWithValue("@telefono", telefono);
            cmd.Parameters.AddWithValue("@email", email);
            cmd.Parameters.AddWithValue("@rol", rol);
            cmd.Parameters.AddWithValue("@ingreso", ingreso);
            cmd.Parameters.AddWithValue("@retiro", retiro);

            cmd.ExecuteNonQuery();
            conexion.cn.Close();
        }
        public void Editar(int idEmpleado,string nombre,string documento,string direccion,string telefono,string email,int rol,DateTime ingreso,DateTime retiro)
        {
            conexion.cn.Open();

            SqlCommand cmd = new SqlCommand(
            "UPDATE TBLEMPLEADO SET " +
            "strNombre=@nombre, " +
            "NumDocumento=@documento, " +
            "StrDireccion=@direccion, " +
            "StrTelefono=@telefono, " +
            "StrEmail=@email, " +
            "IdRolEmpleado=@rol, " +
            "DtmIngreso=@ingreso, " +
            "DtmRetiro=@retiro " +
            "WHERE IdEmpleado=@id", conexion.cn);

            cmd.Parameters.AddWithValue("@id", idEmpleado);
            cmd.Parameters.AddWithValue("@nombre", nombre);
            cmd.Parameters.AddWithValue("@documento", documento);
            cmd.Parameters.AddWithValue("@direccion", direccion);
            cmd.Parameters.AddWithValue("@telefono", telefono);
            cmd.Parameters.AddWithValue("@email", email);
            cmd.Parameters.AddWithValue("@rol", rol);
            cmd.Parameters.AddWithValue("@ingreso", ingreso);
            cmd.Parameters.AddWithValue("@retiro", retiro);

            cmd.ExecuteNonQuery();
            conexion.cn.Close();
        }
        public void Eliminar(int idEmpleado)
        {
            conexion.cn.Open();

            SqlCommand cmd = new SqlCommand(
            "DELETE FROM TBLEMPLEADO WHERE IdEmpleado=@id",
            conexion.cn);

            cmd.Parameters.AddWithValue("@id", idEmpleado);

            cmd.ExecuteNonQuery();
            conexion.cn.Close();
        }
    }
}

