using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;


public partial class salaDeEspera : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if(Session["conectado"] == null)
            Response.Redirect("login.aspx");

        string connection = "Data Source=FEDE2\\SQLEXPRESS;Initial Catalog=dbChatTcp2;Integrated Security=True";
        SqlConnection conn = new SqlConnection(connection);

        string query = "SELECT IdSala, Descripcion from Sala";
        SqlCommand commandLog = new SqlCommand(query, conn);

        SqlDataAdapter adtp = new SqlDataAdapter(query, conn);

        DataTable dt = new DataTable();
        adtp.Fill(dt);

        gvSala.DataSource = dt;
        gvSala.DataBind();
    }

    protected void gvSala_RowCommand(object sender, GridViewCommandEventArgs e)
    {

        int esadm = Convert.ToInt32(Request.QueryString["adm"]);

        if (e.CommandName == "Entrar")
        {
            GridViewRow gvr = (GridViewRow)((LinkButton)e.CommandSource).NamingContainer;
            string idSala = Convert.ToString(gvr.RowIndex);
            Response.Redirect("chat.aspx?Id=" + idSala);
        }

        //eliminar sala (entra , pero no elimina!)

        if (e.CommandName == "Eliminar" && esadm == 1) //agregar label si no es administrador no puede
        {
            string connection = "Data Source=FEDE2\\SQLEXPRESS;Initial Catalog=dbChatTcp2;Integrated Security=True";
            SqlConnection conn = new SqlConnection(connection);

            conn.Open();

            string query = "DELETE IdSala,Descripcion FROM Sala WHERE IdSala=@idsala";
            SqlCommand command = new SqlCommand(query, conn);

            GridViewRow gvr = (GridViewRow)((LinkButton)e.CommandSource).NamingContainer;
            string idSala = Convert.ToString(gvr.RowIndex);
            command.Parameters.AddWithValue("@idsala", idSala);
            
            command.ExecuteNonQuery();
            conn.Close(); 
        }
    }

}