﻿using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using WISLEY.BLL.Collab;

namespace WISLEY.DAL.Collab
{
    public class PostDAO
    {
        public int Insert(Post post)
        {
            string DBConnect = ConfigurationManager.ConnectionStrings["ConnStr"].ConnectionString;
            SqlConnection myConn = new SqlConnection(DBConnect);

            string sqlStmt = "INSERT INTO Post (userId, groupId, title, content, datecreated)" +
                             "VALUES (@paraUserID, @paraGroupID, @paraTitle, @paraContent, @paraDatecreate)";

            int result = 0;    // Execute NonQuery return an integer value
            SqlCommand sqlCmd = new SqlCommand(sqlStmt, myConn);

            sqlCmd.Parameters.AddWithValue("@paraUserID", post.userId);
            sqlCmd.Parameters.AddWithValue("@paraGroupID", post.groupId);
            sqlCmd.Parameters.AddWithValue("@paraTitle", post.title);
            sqlCmd.Parameters.AddWithValue("@paraContent", post.content);
            sqlCmd.Parameters.AddWithValue("@paraDatecreate", post.datecreated);

            myConn.Open();
            result = sqlCmd.ExecuteNonQuery();

            myConn.Close();

            return result;
        }

        public List<Post> SelectAll()
        {
            string DBConnect = ConfigurationManager.ConnectionStrings["ConnStr"].ConnectionString;
            SqlConnection myConn = new SqlConnection(DBConnect);

            string sqlstmt = "Select * from Post";
            SqlDataAdapter da = new SqlDataAdapter(sqlstmt, myConn);

            DataSet ds = new DataSet();
            da.Fill(ds);
            int rec_cnt = ds.Tables[0].Rows.Count;

            Post obj = null;
            List<Post> postlist = new List<Post>();
            if (rec_cnt > 0)
            {
                for (int i = 0; i < rec_cnt; i++)
                {
                    DataRow row = ds.Tables[0].Rows[i];
                    string userId = row["userId"].ToString();
                    string title = row["title"].ToString();
                    string content = row["content"].ToString();
                    string group = row["groupId"].ToString();
                    obj = new Post(title, content, userId, group);
                    postlist.Add(obj);
                }
            }

            return postlist;
        }

        public List<string> SelectIDs()
        {
            string DBConnect = ConfigurationManager.ConnectionStrings["ConnStr"].ConnectionString;
            SqlConnection myConn = new SqlConnection(DBConnect);

            string sqlstmt = "Select Id from Post";
            SqlDataAdapter da = new SqlDataAdapter(sqlstmt, myConn);

            DataSet ds = new DataSet();
            da.Fill(ds);
            int rec_cnt = ds.Tables[0].Rows.Count;

            List<string> IDList = new List<string>();
            if (rec_cnt > 0)
            {
                for (int i = 0; i < rec_cnt; i++)
                {
                    DataRow row = ds.Tables[0].Rows[i];
                    string id = row["Id"].ToString();
                    IDList.Add(id);
                }
            }

            return IDList;
        }

        public int UpdatePost(string userId, string title, string content, DateTime datecreate)
        {
            string DBConnect = ConfigurationManager.ConnectionStrings["ConnStr"].ConnectionString;
            SqlConnection myConn = new SqlConnection(DBConnect);

            string sqlStmt = "UPDATE Post " +
                "SET title = @paraTitle, content = @paraContent, datecreated = @paraDatecreate " +
                "WHERE userId = @paraUserID";

            int result = 0;    // Execute NonQuery return an integer value
            SqlCommand sqlCmd = new SqlCommand(sqlStmt, myConn);

            sqlCmd.Parameters.AddWithValue("@paraUserID", userId);
            sqlCmd.Parameters.AddWithValue("@paraTitle", title);
            sqlCmd.Parameters.AddWithValue("@paraContent", content);
            sqlCmd.Parameters.AddWithValue("@paraDatecreate", datecreate);

            myConn.Open();
            result = sqlCmd.ExecuteNonQuery();

            myConn.Close();

            return result;

        }
    }
}