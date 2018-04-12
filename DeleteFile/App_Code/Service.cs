using System;
using System.Web;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.IO;
using System.Configuration;

[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
public class Service : System.Web.Services.WebService
{
    public Service () {

        //如果使用设计的组件，请取消注释以下行 
        //InitializeComponent(); 
    }

    [WebMethod]
    public string DeleteTraFile(string fileName,string docID) 
    {
        try
        {
            string filePath = ConfigurationManager.AppSettings["HISPAHT"];
            string docFile = "";
            if (!string.IsNullOrEmpty(filePath))
                docFile = filePath + docID + ".xml";
            if (File.Exists(fileName))
            {
                File.Delete(fileName);
            }
            if (File.Exists(docFile))
                File.Delete(docFile);
            return "OK";
        }
        catch(Exception ex)
        {
            return ex.Message;
        }
    }
    
}
