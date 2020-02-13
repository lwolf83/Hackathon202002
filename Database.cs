using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Data.Common;
using System.Linq;
using System.Collections.Specialized;

namespace EcoConception
{
    public sealed class Database
    {
        private SqlConnection Connection { get; set; }

        public Database(SqlConnectionStringBuilder connectionBuilder)
        {
            Connection = new SqlConnection(connectionBuilder.ConnectionString);
        }

        public void OpenConnection()
        {
            try
            {
                Connection.Open();
            }
            catch (Exception exception)
            {
                if (exception is InvalidOperationException || exception is SqlException)
                {
                    Console.WriteLine("There has been an error while connecting to the database:\n", exception);
                }
            }
        }

        public void CloseConnection()
        {
            try
            {
                Connection.Close();
            }
            catch (SqlException exception)
            {
                Console.WriteLine("There has been an error while closing the connection to the database:\n", exception);
            }
        }

        public void AddProduct(Product product)
        {/*
            String sql = "INSERT INTO product (name, price, description)" +
                         "VALUES (@Name, @Price, @Description, @CategoryId);";
            IEnumerable<SqlParameter> parameters = new List<SqlParameter>
            {
                new SqlParameter("@Name", product.Name),
                new SqlParameter("@Price", product.Price),
                new SqlParameter("@Description", product.Description),
                new SqlParameter("@CategoryId", product.Category.Id)
            };
            Query(sql, parameters);*/
        }

        public void UpdateProduct(Product product)
        {/*
            String sql = "UPDATE product " +
                         "SET name=@Name, description=@Description, price=@Price" +
                         "WHERE id=@ProductId;";
            IEnumerable<SqlParameter> parameters = new List<SqlParameter>
            {
                new SqlParameter("@Name", product.Name),
                new SqlParameter("@Price", product.Price),
                new SqlParameter("@Description", product.Description),
                new SqlParameter("@ProductId", product.Id)
            };
            Query(sql, parameters);*/
        }

        public void RemoveProductById(int productId)
        {
            String sql = "DELETE FROM product WHERE id =" + productId;
            SqlCommand cmd = new SqlCommand();

            // Combinez l'objet Command avec Connection.
            cmd.Connection = Connection;
            cmd.CommandText = sql;
        }
        /*
        public IEnumerable<object> GetProductsByCategory(Category category)
        {
            String sql = "SELECT [id], [description], [name], [price], [categoryId] FROM product " +
                         "WHERE categoryId = @CategoryId";
            IEnumerable<SqlParameter> parameters = new List<SqlParameter>
            {
                new SqlParameter("@CategoryId", category.Id)
            };
            return products;
        }*/

        public Product GetProductById(int id)
        {
            String sql = "SELECT [id], [Description], [Name], [Price], [CategoryId] FROM Product WHERE id = " + id;
            SqlCommand cmd = new SqlCommand();

            // Combinez l'objet Command avec Connection.
            cmd.Connection = Connection;
            cmd.CommandText = sql;
            Product newProduct = new Product();
            using (DbDataReader reader = cmd.ExecuteReader())
            {
                if (reader.HasRows)
                {
                    reader.Read();
                    newProduct.Id = reader.GetInt32(reader.GetOrdinal("id"));
                    newProduct.Price = reader.GetDecimal(reader.GetOrdinal("Price"));
                    newProduct.CategoryId = reader.GetInt32(reader.GetOrdinal("CategoryId"));
                    newProduct.Description = reader.GetString(reader.GetOrdinal("Description"));
                    newProduct.Name = reader.GetString(reader.GetOrdinal("Name"));
                }
            }
            return newProduct;
        }

       public Product GetProductByName(String name)
        {
            String sql = "SELECT [id], [Description], [Name], [Price], [CategoryId] FROM Product WHERE Name = " + name;
            SqlCommand cmd = new SqlCommand();

            // Combinez l'objet Command avec Connection.
            cmd.Connection = Connection;
            cmd.CommandText = sql;
            Product newProduct = new Product();
            using (DbDataReader reader = cmd.ExecuteReader())
            {
                if (reader.HasRows)
                {
                    reader.Read();
                    newProduct.Id = reader.GetInt32(reader.GetOrdinal("id"));
                    newProduct.Price = reader.GetDecimal(reader.GetOrdinal("Price"));
                    newProduct.CategoryId = reader.GetInt32(reader.GetOrdinal("CategoryId"));
                    newProduct.Description = reader.GetString(reader.GetOrdinal("Description"));
                    newProduct.Name = reader.GetString(reader.GetOrdinal("Name"));
                }
            }
            return newProduct;
        }
        
       /* public IEnumerable<Product> GetAllProducts()
        {
            String sql = "SELECT [id], [description], [name], [price], [categoryId] FROM product";
            // IEnumerable<object> allProducts = 
            return allProducts.Cast<Product>();
        }*/
        
        public void AddCategory(string name, string description)
        {
            String sql = "INSERT INTO [Category] (Name, Description) VALUES ('" + name + "', '" + description + "')";
            SqlCommand cmd = new SqlCommand();

            // Combinez l'objet Command avec Connection.
            cmd.Connection = Connection;
            cmd.CommandText = sql;          
        }

        public void UpdateCategory(string name, string description)
        {
            String sql = "UPDATE [Category] SET [Name] = '" + name + "', [Description] = '" + description + "' WHERE Id = " + 1;
            SqlCommand cmd = new SqlCommand();

            // Combinez l'objet Command avec Connection.
            cmd.Connection = Connection;
            cmd.CommandText = sql;
        }
    

        public void RemoveCategoryById(int id)
        {
            String sql = "DELETE FROM [Category] WHERE Id = " + id;
            SqlCommand cmd = new SqlCommand();

            // Combinez l'objet Command avec Connection.
            cmd.Connection = Connection;
            cmd.CommandText = sql;
        }
    

       public Category GetCategoryById(int id)
        {
            String sql = "SELECT [Id], [Description], [Name] FROM Category WHERE Id = " + id;
            SqlCommand cmd = new SqlCommand();

            // Combinez l'objet Command avec Connection.
            cmd.Connection = Connection;
            cmd.CommandText = sql;
            Category newCategory = new Category();
            using (DbDataReader reader = cmd.ExecuteReader())
            {
                if (reader.HasRows)
                {
                    reader.Read();
                    newCategory.Id = reader.GetInt32(reader.GetOrdinal("Id"));
                    newCategory.Description = reader.GetString(reader.GetOrdinal("Description"));
                    newCategory.Name = reader.GetString(reader.GetOrdinal("Name"));

                }
            }

            return newCategory;
           
        }

        public Category GetCategoryByName(String name)
        {
            String sql = "SELECT [Id], [Description], [Name] FROM Category WHERE Id = " + name;
            SqlCommand cmd = new SqlCommand();

            // Combinez l'objet Command avec Connection.
            cmd.Connection = Connection;
            cmd.CommandText = sql;
            Category newCategory = new Category();
            using (DbDataReader reader = cmd.ExecuteReader())
            {
                if (reader.HasRows)
                {
                    reader.Read();
                    newCategory.Id = reader.GetInt32(reader.GetOrdinal("Id"));
                    newCategory.Description = reader.GetString(reader.GetOrdinal("Description"));
                    newCategory.Name = reader.GetString(reader.GetOrdinal("Name"));
                }
            }
            return newCategory;
        }
    }
}