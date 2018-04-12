<%@ Application Language="C#" %>

<script runat="server">

    void Application_Start(object sender, EventArgs e) 
    {
        if (Application["ATLINEUSERS"] == null)
        {
            Hashtable hs = new Hashtable();
            Application["ATLINEUSERS"] = hs;
        }

    }
    
    void Application_End(object sender, EventArgs e) 
    {
        Application.Clear();
    }
        
    void Application_Error(object sender, EventArgs e) 
    { 
        // 在出现未处理的错误时运行的代码

    }

    void Session_Start(object sender, EventArgs e) 
    {
        
    }

    void Session_End(object sender, EventArgs e) 
    {
            if (Application["ATLINEUSERS"] != null)
            {
                Hashtable hs = (Hashtable)Application["ATLINEUSERS"];
                string id = Session.SessionID;
                string key = "";
                foreach (DictionaryEntry de in hs)
                {
                    if (de.Value.ToString() == id)
                    {
                        key = de.Key.ToString();
                        break;
                    }
                }
                hs.Remove(key);
            }
            Session.Abandon();
    }
       
</script>
