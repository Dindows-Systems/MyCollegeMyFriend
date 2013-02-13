using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

public partial class Controls_Friend : System.Web.UI.UserControl
{
    RegistrationHelper regHelper = new RegistrationHelper();
    DataTable dt = new DataTable();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (!object.Equals(Request.QueryString["UserLoginID"], null))
            {
                GetAllFriend(Request.QueryString["UserLoginID"].ToString());
            }
        }
    }

    public void GetAllFriend(string UserLoginID)
    {
        dt = regHelper.GetMemberFriend(UserLoginID);
        if (dt.Rows.Count > 0)
        {
            FriendList.DataSource = dt;
            FriendList.DataBind();
            FriendList.Visible = true;
        }
        else
        {
            FriendList.Visible = false;
        }
    }

    public string getHREF(object sURL)
    {
        DataRowView dRView = (DataRowView)sURL;
        return ResolveUrl("~/Member/MemberProfile.aspx?UserLoginID=" + dRView["LoginId"].ToString());
    }
    public string getSRC(object imgSRC)
    {
        DataRowView dRView = (DataRowView)imgSRC;
        return ResolveUrl("~/MemberImages/" + dRView["LoginId"].ToString() + "/" + "Thumbnail" + "/" + "S" + "/" + dRView["ImageName"].ToString());
    }

}
