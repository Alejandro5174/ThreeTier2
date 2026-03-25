using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class BLLInformes
{
    DALInformes dal = new DALInformes();
    public DataTable InformeClientes(DateTime fechaInicio, DateTime fechaFin)
    {
        return dal.InformeClientes(fechaInicio, fechaFin);
    }
    public DataTable InformeFacturacion(DateTime f1, DateTime f2)
    {
        return dal.InformeFacturacion(f1, f2);
    }
    
}