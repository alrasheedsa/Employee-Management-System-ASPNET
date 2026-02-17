using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Web.Configuration;
using System.Web.UI.WebControls;

namespace Mohammed11254WebApp.demo
{
    public class CRUD
    {
        public static string conStr = WebConfigurationManager.ConnectionStrings["MyDbConnection"].ConnectionString;

        public CRUD() { }

        private SqlConnection GetConnection()
        {
            return new SqlConnection(conStr);
        }

       
        public DataTable getDT(string mySql)
        {
            DataTable dt = new DataTable();
            try
            {
                using (SqlConnection con = GetConnection())
                using (SqlCommand cmd = new SqlCommand(mySql, con))
                using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                {
                    con.Open();
                    da.Fill(dt);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("⚠️ خطأ في getDT: " + ex.Message, ex);
            }
            return dt;
        }

        
        public DataTable getDTPassSqlDic(string mySql, Dictionary<string, object> myPara)
        {
            DataTable dt = new DataTable();
            try
            {
                using (SqlConnection con = GetConnection())
                using (SqlCommand cmd = new SqlCommand(mySql, con))
                {
                    foreach (var p in myPara)
                        cmd.Parameters.AddWithValue(p.Key, p.Value ?? DBNull.Value);

                    using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                    {
                        con.Open();
                        da.Fill(dt);
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("⚠️ خطأ في getDTPassSqlDic: " + ex.Message, ex);
            }
            return dt;
        }

        
        public int ExecuteNonQuery(string mySql, Dictionary<string, object> myPara = null)
        {
            int rows = 0;
            try
            {
                using (SqlConnection con = GetConnection())
                using (SqlCommand cmd = new SqlCommand(mySql, con))
                {
                    if (myPara != null)
                    {
                        foreach (var p in myPara)
                            cmd.Parameters.AddWithValue(p.Key, p.Value ?? DBNull.Value);
                    }
                    con.Open();
                    rows = cmd.ExecuteNonQuery();
                }
            }
            catch (SqlException ex)
            {
                if (ex.Number == 547)
                    throw new Exception("⚠️ لا يمكن الحذف بسبب وجود بيانات مرتبطة في جداول أخرى.", ex);
                else
                    throw new Exception($"⚠️ خطأ SQL رقم {ex.Number}: {ex.Message}", ex);
            }
            catch (Exception ex)
            {
                throw new Exception("⚠️ خطأ في ExecuteNonQuery: " + ex.Message, ex);
            }
            return rows;
        }

        
        public int InsertUpdateDelete(string mySql, Dictionary<string, object> myPara = null)
        {
            return ExecuteNonQuery(mySql, myPara);
        }

        
        public object ExecuteScalar(string mySql, Dictionary<string, object> myPara = null)
        {
            try
            {
                using (SqlConnection con = GetConnection())
                using (SqlCommand cmd = new SqlCommand(mySql, con))
                {
                    if (myPara != null)
                    {
                        foreach (var p in myPara)
                            cmd.Parameters.AddWithValue(p.Key, p.Value ?? DBNull.Value);
                    }
                    con.Open();
                    return cmd.ExecuteScalar();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("⚠️ خطأ في ExecuteScalar: " + ex.Message, ex);
            }
        }

        
        public void populateCombo(DropDownList ddl, string mySql, string valueField, string textField, Dictionary<string, object> myPara = null)
        {
            DataTable dt = (myPara == null) ? getDT(mySql) : getDTPassSqlDic(mySql, myPara);
            ddl.DataSource = dt;
            ddl.DataValueField = valueField;
            ddl.DataTextField = textField;
            ddl.DataBind();
        }

        
        public void populateGv(GridView gv, string mySql, Dictionary<string, object> myPara = null)
        {
            DataTable dt = (myPara == null) ? getDT(mySql) : getDTPassSqlDic(mySql, myPara);
            gv.DataSource = dt;
            gv.DataBind();
        }

        
        public bool AuthenticateUser(string username, string passwordHash)
        {
            try
            {
                string sql = "SELECT COUNT(*) FROM UsersAdmins WHERE username = @username AND PasswordHash = @password";
                var p = new Dictionary<string, object>
                {
                    { "@username", username },
                    { "@password", passwordHash }
                };
                object res = ExecuteScalar(sql, p);
                if (res == null || res == DBNull.Value) return false;
                return Convert.ToInt32(res) > 0;
            }
            catch (Exception ex)
            {
                throw new Exception("⚠️ خطأ في AuthenticateUser: " + ex.Message, ex);
            }
        }
    }
}
