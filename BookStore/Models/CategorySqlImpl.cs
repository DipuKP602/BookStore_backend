using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Configuration;
using System.Globalization;

namespace BookStore.Models
{
    public class CategorySqlImpl : ICategoryRepository
    {
        SqlConnection conn;
        SqlCommand comm;
        public CategorySqlImpl()
        {
            conn = new SqlConnection(ConfigurationManager.ConnectionStrings["myDB"].ConnectionString);
            comm = new SqlCommand();
        }
        public Category AddCategory(Category category)
        {
            throw new NotImplementedException();
        }

        public void DeleteCategory(Category category)
        {
            throw new NotImplementedException();
        }

        public void EditCategory(Category category)
        {
            throw new NotImplementedException();
        }

        public List<Category> GetCategories()
        {
            List<Category> catList = new List<Category>();
            comm.CommandText = "select * from category";
            comm.Connection = conn;
            conn.Open();
            SqlDataReader reader = comm.ExecuteReader();

            while (reader.Read())
            {
                int id = Convert.ToInt32(reader["categoryId"]);
                int status = Convert.ToInt32(reader["status"]);
                int pos = Convert.ToInt32(reader["position"]);
                string name = reader["categoryName"].ToString();
                string imageURL = reader["image"].ToString();
                string desc = reader["description"].ToString();
                //DateTime date = DateTime.ParseExact(reader["createdAt"].ToString(),"yyyy",CultureInfo.InvariantCulture);
                DateTime date = Convert.ToDateTime(reader["createdAt"].ToString());
                Category cat = new Category(id, name, desc, imageURL, status, pos, date);
                catList.Add(cat);
            }

            conn.Close();
            return catList;
        }
    }
}