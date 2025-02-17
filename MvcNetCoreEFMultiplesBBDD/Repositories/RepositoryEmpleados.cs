using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.Blazor;
using MvcNetCoreEFMultiplesBBDD.Data;
using MvcNetCoreEFMultiplesBBDD.Models;

#region
//SQL SERVER
//CREATE VIEW V_EMPLEADOS
//AS
//SELECT EMP_NO AS IDEMPLEADO, EMP.APELLIDO, EMP.OFICIO, EMP.SALARIO,
//DEPT.DNOMBRE AS DEPARTAMENTO, DEPT.LOC AS LOCALIDAD
//FROM EMP INNER JOIN DEPT
//ON EMP.DEPT_NO = DEPT.DEPT_NO
//GO

//ORACLE
//CREATE OR REPLACE VIEW V_EMPLEADOS
//AS
//SELECT EMP.EMP_NO AS IDEMPLEADO, EMP.APELLIDO, EMP.OFICIO, EMP.SALARIO,
//DEPT.DNOMBRE AS DEPARTAMENTO, DEPT.LOC AS LOCALIDAD
//FROM EMP INNER JOIN DEPT
//ON EMP.DEPT_NO=DEPT.DEPT_NO;

//SQL SERVER
//CREATE PROCEDURE SP_ALL_VEMPLEADOS
//AS
//SELECT * FROM V_EMPLEADOS
//GO

//ORACLE
//CREATE OR REPLACE PROCEDURE SP_ALL_VEMPLEADOS
//(p_cursor_empleados out sys_refcursor)
//AS
//BEGIN
//  OPEN p_cursor_empleados for
//  SELECT * FROM V_EMPLEADOS;
//END;
#endregion

namespace MvcNetCoreEFMultiplesBBDD.Repositories
{
    public class RepositoryEmpleados: IRepositoryEmpleados
    {
        private HospitalContext context;

        public RepositoryEmpleados(HospitalContext context)
        {
            this.context = context;
        }

        public async Task<List<EmpleadoView>> GetEmpleadosAsync()
        {
            //var consulta = from datos in this.context.EmpleadosView select datos;
            //return await consulta.ToListAsync();
            string sql = "SP_ALL_VEMPLEADOS";
            var consulta = this.context.EmpleadosView.FromSqlRaw(sql);
            return await consulta.ToListAsync();
        }

        public async Task<EmpleadoView> FindEmpleadoAsync(int idEmpleado)
        {
            var consulta = from datos in this.context.EmpleadosView where datos.IdEmpleado == idEmpleado select datos;
            return await consulta.FirstOrDefaultAsync();
        }
    }
}
