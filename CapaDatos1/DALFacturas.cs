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
    public class DALFacturas
    {
        Conexion conexion = new Conexion();

        public DataTable ListarFacturas()
        {
            SqlDataAdapter da = new SqlDataAdapter(
             @"SELECT 
             f.IdFactura,
             f.DtmFecha,
             c.StrNombre AS Cliente,
             e.StrNombre AS Empleado,
             f.NumValorTotal,
             f.IdEstado
             FROM TBLFACTURA f
             INNER JOIN TBLCLIENTES c ON f.IdCliente = c.IdCliente
             INNER JOIN TBLEMPLEADO e ON f.IdEmpleado = e.IdEmpleado",
             conexion.cn);
            DataTable dt = new DataTable();
            da.Fill(dt);

            return dt;
        }
        public DataTable CargarClientes()
        {
            SqlDataAdapter da = new SqlDataAdapter(
            "SELECT IdCliente, StrNombre FROM TBLCLIENTES", conexion.cn);

            DataTable dt = new DataTable();
            da.Fill(dt);

            return dt;
        }
        public DataTable CargarEmpleados()
        {
            SqlDataAdapter da = new SqlDataAdapter(
            "SELECT IdEmpleado, StrNombre FROM TBLEMPLEADO", conexion.cn);

            DataTable dt = new DataTable();
            da.Fill(dt);

            return dt;
        }
        public DataTable CargarEstados()
        {
            SqlDataAdapter da = new SqlDataAdapter(
            "SELECT IdEstadoFactura, StrDescripcion FROM TBLESTADO_FACTURA", conexion.cn);

            DataTable dt = new DataTable();
            da.Fill(dt);

            return dt;
        }
        public void GuardarFactura(int IdCliente, int IdEmpleado, int IdEstado, double descuento, double impuesto, double total, DataTable detalle)
        {
            conexion.cn.Open();
            SqlTransaction tran = conexion.cn.BeginTransaction();

            try
            {
                SqlCommand cmdFactura = new SqlCommand(
                @"INSERT INTO TBLFACTURA 
                (DtmFecha, IdCliente, IdEmpleado, IdEstado, NumDescuento, NumImpuesto, NumValorTotal)
                VALUES (GETDATE(), @cliente, @empleado, @estado, @desc, @imp, @total);
                SELECT SCOPE_IDENTITY();",
                conexion.cn, tran);

                cmdFactura.Parameters.AddWithValue("@cliente", IdCliente);
                cmdFactura.Parameters.AddWithValue("@empleado", IdEmpleado);
                cmdFactura.Parameters.AddWithValue("@estado", IdEstado);
                cmdFactura.Parameters.AddWithValue("@desc", descuento);
                cmdFactura.Parameters.AddWithValue("@imp", impuesto);
                cmdFactura.Parameters.AddWithValue("@total", total);

                int idFactura = Convert.ToInt32(cmdFactura.ExecuteScalar());

            
                foreach (DataRow row in detalle.Rows)
                {
                    SqlCommand cmdDetalle = new SqlCommand(
                    @"INSERT INTO TBLDETALLE_FACTURA 
                    (IdFactura, IdProducto, NumCantidad, NumPrecio)
                    VALUES (@factura, @producto, @cantidad, @precio)",
                    conexion.cn, tran);

                    cmdDetalle.Parameters.AddWithValue("@factura", idFactura); 
                    cmdDetalle.Parameters.AddWithValue("@producto", row["IdProducto"]);
                    cmdDetalle.Parameters.AddWithValue("@cantidad", row["Cantidad"]);
                    cmdDetalle.Parameters.AddWithValue("@precio", row["Precio"]);
                  

                    cmdDetalle.ExecuteNonQuery();
                }

                tran.Commit();
            }
            catch
            {
                tran.Rollback();
                throw;
            }
            finally
            {
                conexion.cn.Close();
            }
        }
        public void EditarFactura(int IdFactura, int IdCliente, int IdEmpleado, int IdEstado, double total)
        {
            conexion.cn.Open();

            SqlCommand cmd = new SqlCommand(
            @"UPDATE TBLFACTURA SET
            IdCliente=@cliente,
            IdEmpleado=@empleado,
            IdEstado=@estado,
            NumValorTotal=@total
            WHERE IdFactura=@id",
            conexion.cn);

            cmd.Parameters.AddWithValue("@id", IdFactura);
            cmd.Parameters.AddWithValue("@cliente", IdCliente);
            cmd.Parameters.AddWithValue("@empleado", IdEmpleado);
            cmd.Parameters.AddWithValue("@estado", IdEstado);
            cmd.Parameters.AddWithValue("@total", total);

            cmd.ExecuteNonQuery();
            conexion.cn.Close();
        }
        public void Eliminar(int IdFactura)
        {
            conexion.cn.Open();

            SqlCommand cmd = new SqlCommand(
            "DELETE FROM TBLFACTURA WHERE IdFactura=@id",
            conexion.cn);

            cmd.Parameters.AddWithValue("@id", IdFactura);

            cmd.ExecuteNonQuery();
            conexion.cn.Close();
        }
    }
}
