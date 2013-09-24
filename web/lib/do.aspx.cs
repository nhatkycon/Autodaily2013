using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using linh.core.dal;
using System.IO;
using linh.core;
using docsoft;
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
           string[] commands = TextBox1.Text.Split(new string[] { "GO\r\n", "GO ", "GO\t" }, StringSplitOptions.RemoveEmptyEntries);
           Literal1.Text = "";
            foreach (string l in commands)
            {
                try
                {
                    SqlHelper.ExecuteNonQuery(DAL.con(), System.Data.CommandType.Text, l);
                }
                catch (Exception ex)
                {
                    Literal1.Text = ex.Message +"<br/>" + l;
                }
            }
        
    }
    protected void Button2_Click(object sender, EventArgs e)
    {
        grd.DataSource = SqlHelper.ExecuteDataset(DAL.con(), System.Data.CommandType.Text, TextBox1.Text);
        grd.DataBind();
    }
    protected void Button4_Click(object sender, EventArgs e)
    {
        StreamReader rd = new StreamReader(FileUpload1.PostedFile.InputStream);
        TextBox1.Text = rd.ReadToEnd();
    }
    protected void Button3_Cdlick(object sender, EventArgs e)
    {
        string[] commands = TextBox1.Text.Split(new string[] { "GO\r\n", "GO ", "GO\t" }, StringSplitOptions.RemoveEmptyEntries);
        Literal1.Text = "";
        foreach (string l in commands)
        {
            try
            {
                Literal1.Text = SqlHelper.ExecuteScalar(DAL.con(), System.Data.CommandType.Text, l).ToString();
            }
            catch (Exception ex)
            {
                Literal1.Text = ex.Message + "<br/>" + l;
            }
        }
    }
}