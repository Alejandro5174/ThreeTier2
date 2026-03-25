using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static CapaDatos1.DALconexion;

public class DALInformes
{
    Conexion conexion = new Conexion();
    public DataTable InformeClientes(DateTime fechaInicio, DateTime fechaFin)
    {
        SqlDataAdapter da = new SqlDataAdapter(
        "SELECT * FROM TBLCLIENTES", conexion.cn);

        DataTable dt = new DataTable();
        da.Fill(dt);

        return dt;
    }
    public DataTable InformeFacturacion(DateTime f1, DateTime f2)
    {
        SqlDataAdapter da = new SqlDataAdapter(
        @"SELECT 
        f.IdFactura,
        f.DtmFecha,
        c.StrNombre,
        f.NumValorTotal
      FROM TBLFACTURA f
      INNER JOIN TBLCLIENTES c ON f.IdCliente = c.IdCliente
      WHERE CONVERT(date, f.DtmFecha) BETWEEN @f1 AND @f2",
        conexion.cn);

        da.SelectCommand.Parameters.AddWithValue("@f1", f1.Date);
        da.SelectCommand.Parameters.AddWithValue("@f2", f2.Date);

        DataTable dt = new DataTable();
        da.Fill(dt);

        return dt;
    }
    public void Eliminar(int idFactura)
    {
        conexion.cn.Open();

        SqlCommand cmd = new SqlCommand(
            "DELETE FROM TBLFACTURA WHERE IdFactura=@id",
            conexion.cn);

        cmd.Parameters.AddWithValue("@id", idFactura);

        cmd.ExecuteNonQuery();
        conexion.cn.Close();
    }
}
