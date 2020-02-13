using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
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
        {
            String sql = "INSERT INTO product (name, price, description)" +
                         "VALUES (@Name, @Price, @Description, @CategoryId);";
            IEnumerable<SqlParameter> parameters = new List<SqlParameter>
            {
                new SqlParameter("@Name", product.Name),
                new SqlParameter("@Price", product.Price),
                new SqlParameter("@Description", product.Description),
                new SqlParameter("@CategoryId", product.Category.Id)
            };
            Query(sql, parameters);
        }

        public void UpdateProduct(Product product)
        {
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
            Query(sql, parameters);
        }

        public void RemoveProductById(int productId)
        {
            String sql = "DELETE FROM product WHERE id=@ProductId";
            IEnumerable<SqlParameter> parameters = new List<SqlParameter>
            {
                new SqlParameter("@ProductId", productId)
            };
            Query(sql, parameters);
        }

        public IEnumerable<Product> GetProductsByCategory(Category category)
        {
            String sql = "SELECT [id], [description], [name], [price], [categoryId] FROM product " +
                         "WHERE categoryId = @CategoryId";
            IEnumerable<SqlParameter> parameters = new List<SqlParameter>
            {
                new SqlParameter("@CategoryId", category.Id)
            };
            IEnumerable<Product> products = Query<Product>(sql, parameters);
            return products;
        }

        public Product GetProductById(int id)
        {
            String sql = "SELECT [id], [description], [name], [price], [categoryId] FROM product WHERE id = @Id";
            IEnumerable<SqlParameter> parameters = new List<SqlParameter>
            {
                new SqlParameter("@Id", id)
            };
            Product concernedProduct = QueryOne<Product>(sql, parameters);
            return concernedProduct;
        }

        public Product GetProductByName(String name)
        {
            String sql = "SELECT [id], [description], [name], [price], [categoryId] FROM product WHERE name = @Name";
            IEnumerable<SqlParameter> parameters = new List<SqlParameter>
            {
                new SqlParameter("@Name", name)
            };
            Product concernedProduct = QueryOne<Product>(sql, parameters);
            return concernedProduct;
        }

        public IEnumerable<Product> GetAllProducts()
        {
            String sql = "SELECT [id], [description], [name], [price], [categoryId] FROM product";
            IEnumerable<Product> allProducts = Query<Product>(sql);
            return allProducts;
        }

        public void AddCategory(Category category)
        {
            throw new NotImplementedException("Not yet implemented. You should implement it.");
        }

        public void UpdateCategory(Category category)
        {
            throw new NotImplementedException("Not yet implemented. You should implement it.");
        }

        public void RemoveCategoryById(int categoryId)
        {
            throw new NotImplementedException("Not yet implemented. You should implement it.");
        }

        public Category GetCategoryById(int id)
        {
            throw new NotImplementedException("Not yet implemented. You should implement it.");
        }

        public Category GetCategoryByName(String name)
        {
            throw new NotImplementedException("Not yet implemented. You should implement it.");
        }

        // Récupère UN seul résultat (le premier)
        public T QueryOne<T>(String query, IEnumerable<SqlParameter> manyParameters=null)
        {
            IEnumerable<T> entities = Query<T>(query, manyParameters);
            T concernedEntity = entities.FirstOrDefault();
            return concernedEntity;
        }

        public IEnumerable<T> Query<T>(String query, IEnumerable<SqlParameter> manyParameters = null)
        {
            SqlDataReader reader = Query(query, manyParameters);

            while (reader.HasRows && reader.Read())
            {
                yield return (T)reader[0];
            }
        }

        public SqlDataReader Query(String query, IEnumerable<SqlParameter> manyParameters=null)
        {
            SqlDataReader reader;
            using (SqlCommand command = new SqlCommand(query, Connection))
            {
                foreach (SqlParameter parameter in manyParameters)
                {
                    command.Parameters.Add(parameter);
                }
                reader = command.ExecuteReader();
            }
            return reader;
        }
    }
}