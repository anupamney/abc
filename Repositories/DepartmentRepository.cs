using System;

namespace mbaspnetcore6.Repositories
{
    /// <summary>
    /// A Department Repository class that will be having a Business Logic
    /// for Performing Operations for Department
    /// This will be registered in Dependency Container
    /// This will be Injected with Data Access layer for Department
    /// </summary>
    public class DepartmentRepository : IServiceRepository<Department, int>
    {
        // Define a Dependency
        IDataAccess<Department, int> deptDataAccess;

        /// <summary>
        /// Inject the Dependency 
        /// </summary>
        public DepartmentRepository(IDataAccess<Department,int> dataAccess)
        {
            deptDataAccess = dataAccess;
        }

        public ResponseStatus<Department> CreateRecord(Department entity)
        {
            ResponseStatus<Department> response = new ResponseStatus<Department>();
            try
            {
                response.Record = deptDataAccess.Create(entity);
                response.Message = "Record is created successfully";
                response.StatusCode = 201;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return response;
        }

        public ResponseStatus<Department> DeleteRecord(int id)
        {
            ResponseStatus<Department> response = new ResponseStatus<Department>();
            try
            {
                response.Record = deptDataAccess.Delete(id);
                response.Message = "Record is delete successfully";
                response.StatusCode = 203;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return response;
        }

        public ResponseStatus<Department> GetRecord(int id)
        {
            ResponseStatus<Department> response = new ResponseStatus<Department>();
            try
            {
                response.Record = deptDataAccess.Get(id);
                response.Message = "Record is read successfully";
                response.StatusCode = 200;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return response;
        }

        public ResponseStatus<Department> GetRecords()
        {
            ResponseStatus<Department> response = new ResponseStatus<Department>();
            try
            {
                response.Records = deptDataAccess.Get();
                response.Message = "Records are read successfully";
                response.StatusCode = 200;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return response;
        }

        public ResponseStatus<Department> UpdateRecord(int id, Department entity)
        {
            ResponseStatus<Department> response = new ResponseStatus<Department>();
            try
            {
                response.Record = deptDataAccess.Update(id, entity);
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

