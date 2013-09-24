using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using docsoft.entities;

/// <summary>
/// Summary description for homeUi
/// </summary>
public class homeUi : System.Web.UI.UserControl
{
    public Be BeItem { get; set; }
	public homeUi()
	{
	
	}
}
public class ViewDataUploadFilesResult
{
    public string Thumbnail_url { get; set; }
    public string Name { get; set; }
    public string Id { get; set; }
    public string Anh { get; set; }
    public int Length { get; set; }
    public string Type { get; set; }
}