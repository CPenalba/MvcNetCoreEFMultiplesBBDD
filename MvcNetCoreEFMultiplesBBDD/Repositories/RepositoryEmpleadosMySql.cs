using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.Blazor;
using MvcNetCoreEFMultiplesBBDD.Data;
using MvcNetCoreEFMultiplesBBDD.Models;

#region
//CREATE VIEW V_EMPLEADOS AS
//SELECT 
//    EMP.EMP_NO AS IDEMPLEADO,
//    EMP.APELLIDO,
//    EMP.OFICIO,
//    EMP.SALARIO,
//    DEPT.DNOMBRE AS DEPARTAMENTO,
//    DEPT.LOC AS LOCALIDAD
//FROM EMP 
//INNER JOIN DEPT ON EMP.DEPT_NO = DEPT.DEPT_NO;

#endregion
namespace MvcNetCoreEFMultiplesBBDD.Repositories
{
    public class RepositoryEmpleadosMySql: IRepositoryEmpleados
    {
        private HospitalContext context;

        public RepositoryEmpleadosMySql(HospitalContext context)
        {
            this.context = context;
        }

        public async Task<List<EmpleadoView>> GetEmpleadosAsync()
        {
            var consulta = from empleado in this.context.EmpleadosView
                           select empleado;
            return await consulta.ToListAsync();
        }

        public async Task<EmpleadoView> FindEmpleadoAsync(int idEmpleado)
        {
            var consulta = from empleado in this.context.EmpleadosView
                           where empleado.IdEmpleado == idEmpleado
                           select empleado;
            return await consulta.FirstOrDefaultAsync();
        }
    }
}
