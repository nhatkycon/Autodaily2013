using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using linh.core.dal;
using System.IO;
using linh.core;
using docsoft;
using System.Linq;
public partial class lib_aspx_sql : BasedPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Security.IsAuthenticated() || Security.Username != "bo_adm")
        {
            //rendertext("403 - UnAuthorize; login to access");
        }
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        if (FileUpload1.HasFile)
        {
            //FileUpload1.PostedFile.SaveAs();
            StreamReader rd=new StreamReader(FileUpload1.PostedFile.InputStream);
            string[] commands = rd.ReadToEnd().Split(new string[] { "GO\r\n", "GO ", "GO\t" }, StringSplitOptions.RemoveEmptyEntries);
            Literal1.Text = "";
            foreach (string l in commands)
            {
                try
                {
                    SqlHelper.ExecuteNonQuery(con(), System.Data.CommandType.Text, l);
                }
                catch (Exception ex)
                {
                    Literal1.Text = ex.Message + "<br/>" + l;
                }
            } 
        }
        else
        {
            string[] commands = TextBox1.Text.Split(new string[] { "GO\r\n", "GO ", "GO\t" }, StringSplitOptions.RemoveEmptyEntries);
            Literal1.Text = "";
            foreach (string l in commands)
            {
                try
                {
                    SqlHelper.ExecuteNonQuery(con(), System.Data.CommandType.Text, l);
                }
                catch (Exception ex)
                {
                    Literal1.Text = ex.Message + "<br/>" + l;
                }
            } 
        }
    }
    protected void Button2_Click(object sender, EventArgs e)
    {
        grd.DataSource = SqlHelper.ExecuteDataset(con(), System.Data.CommandType.Text, TextBox1.Text);
        grd.DataBind();
    }
    protected void Button4_Click(object sender, EventArgs e)
    {
        StreamReader rd = new StreamReader(FileUpload1.PostedFile.InputStream);
        TextBox1.Text = rd.ReadToEnd();
    }
    public static SqlConnection con()
    {
        SqlConnection _con = new SqlConnection(@"Data Source=210.245.86.53;Initial Catalog=milanspa_vn_db;Persist Security Info=True;User ID=milanspa_vn_usr;Password=aB123$567;Pooling=False;Connect Timeout=3000;");
        return _con;
    }
    protected void Button3_Cdlick(object sender, EventArgs e)
    {
        string[] commands = TextBox1.Text.Split(new string[] { "GO\r\n", "GO ", "GO\t" }, StringSplitOptions.RemoveEmptyEntries);
        Literal1.Text = "";
        foreach (string l in commands)
        {
            try
            {
                Literal1.Text = SqlHelper.ExecuteScalar(con(), System.Data.CommandType.Text, l).ToString();
            }
            catch (Exception ex)
            {
                Literal1.Text = ex.Message + "<br/>" + l;
            }
        }
    }
}