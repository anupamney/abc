using System;
using Application.Dal.Contract;
using Application.Entities;
using Application.Data.DataAccess;

namespace mbaspnetcore6.Repositories
{
    public class EmployeeRepository : IServiceRepository<Employee, int>
    {
        IDataAccess<Employee, int> empDataAccess;
        public EmployeeRepository(IDataAccess<Employee, int> empDataAccess)
        {
            this.empDataAccess = empDataAccess;
        }

        ResponseStatus<Employee> IServiceRepository<Employee, int>.CreateRecord(Employee entity)
        {
            ResponseStatus<Employee> response = new ResponseStatus<Employee>();
            try
            {
                response.Record = empDataAccess.Create(entity);
                response.Message = "Record is created successfully";
                response.StatusCode = 201;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return response;
        }

        ResponseStatus<Employee> IServiceRepository<Employee, int>.DeleteRecord(int id)
        {
            ResponseStatus<Employee> response = new ResponseStatus<Employee>();
            try
            {
                response.Record = empDataAccess.Delete(id);
                response.Message = "Record is delete successfully";
                response.StatusCode = 203;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return response;
        }

        ResponseStatus<Employee> IServiceRepository<Employee, int>.GetRecord(int id)
        {
            ResponseStatus<Employee> response = new ResponseStatus<Employee>();
            try
            {
                response.Record = empDataAccess.Get(id);
                response.Message = "Record is read successfully";
                response.StatusCode = 200;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return response;
        }

        ResponseStatus<Employee> IServiceRepository<Employee, int>.GetRecords()
        {
            ResponseStatus<Employee> response = new ResponseStatus<Employee>();
            try
            {
                response.Records = empDataAccess.Get();
                response.Message = "Records are read successfully";
                response.StatusCode = 200;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return response;
        }

        ResponseStatus<Employee> IServiceRepository<Employee, int>.UpdateRecord(int id, Employee entity)
        {
            ResponseStatus<Employee> response = new ResponseStatus<Employee>();
            try
            {
                response.Record = empDataAccess.Update(id, entity);
                response.Message = "Record is updated successfully";
                response.StatusCode = 204;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return response;
        }
    }
}

