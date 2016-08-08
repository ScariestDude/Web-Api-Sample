using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using WebApp.Attributes;
using WebApp.Models;
using WebApp.Repositories.Contracts;
using WebApp.Utilities;

namespace WebApp.Repositories.Implementation
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private List<Employee> employees;
        private string connectionString;
        private ValueTypesConverter typesConverter;


        public EmployeeRepository()
        {
            connectionString = ConfigurationManager.ConnectionStrings["MyConnection"].ConnectionString;
            typesConverter = new ValueTypesConverter();

        }

        public void Delete(int id)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("DeleteEmployee", connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@Id", SqlDbType.Int).Value = id;
                    connection.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public Employee Get(int id)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("GetEmployee", connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@Id", SqlDbType.Int).Value = id;
                    connection.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        PropertyInfo[] propertyInfoArray = typeof(Employee).GetProperties();
                        Employee employee = new Employee(); ; 

                        if (reader.Read())
                        {
                            foreach (var prop in propertyInfoArray)
                            {
                                string columnName = ((ColumnNameAttribute)prop.GetCustomAttribute(typeof(ColumnNameAttribute))).Name;

                                prop.SetValue(employee, (reader[columnName] == DBNull.Value) ? string.Empty : reader[columnName]);
                            }
                        }
                        reader.Close();

                        return employee;
                    }
                }
            }
        }

        public IEnumerable<Employee> GetAll()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("GetAllEmployees", connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    connection.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        PropertyInfo[] propertyInfoArray = typeof(Employee).GetProperties();
                        List<Employee> employees = new List<Employee>();
                        Employee employee;

                        while (reader.Read())
                        {
                            employee = new Employee();

                            foreach (var prop in propertyInfoArray)
                            {
                                string columnName = ((ColumnNameAttribute)prop.GetCustomAttribute(typeof(ColumnNameAttribute))).Name;

                                prop.SetValue(employee, (reader[columnName] == DBNull.Value) ? null : reader[columnName]);
                            }

                            employees.Add(employee);
                        }
                        reader.Close();

                        return employees;
                    }
                }
            }
        }

        public void Save(Employee employee)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("CreateEmployee", connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    
                    connection.Open();

                    var propertyInfoArray = typeof(Employee).GetProperties().Where(
                        prop => Attribute.IsDefined(prop, typeof(SpParameterAttribute)));

                    foreach (var prop in propertyInfoArray)
                    {
                        var parameterName = ((SpParameterAttribute)prop.GetCustomAttribute(typeof(SpParameterAttribute))).Name;

                        cmd.Parameters.Add(parameterName, typesConverter.GetSQLType(prop.PropertyType)).Value = prop.GetValue(employee);
                    }
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void Update(Employee employee)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("UpdateEmployee", connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    connection.Open();

                    cmd.Parameters.Add("@Id", SqlDbType.Int).Value = employee.Id;

                    var propertyInfoArray = typeof(Employee).GetProperties().Where(
                        prop => Attribute.IsDefined(prop, typeof(SpParameterAttribute)));

                    foreach (var prop in propertyInfoArray)
                    {
                        var parameterName = ((SpParameterAttribute)prop.GetCustomAttribute(typeof(SpParameterAttribute))).Name;

                        cmd.Parameters.Add(parameterName, typesConverter.GetSQLType(prop.PropertyType)).Value = prop.GetValue(employee);
                    }
                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}