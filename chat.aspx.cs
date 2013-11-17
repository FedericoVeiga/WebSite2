using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;

public partial class chat : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["conectado"] == null)
            Response.Redirect("login.aspx");
        
        
        string id = Request.QueryString["Id"];

        string query = "SELECT IdMensaje, Login, FechaHora,IdSala Texto FROM Mensaje WHERE IdSala=@idSala";
        string connection = "Data Source=FEDE2\\SQLEXPRESS;Initial Catalog=dbChatTcp2;Integrated Security=True";

        SqlConnection conn = new SqlConnection(connection);
        conn.Open();
        SqlCommand command = new SqlCommand(query, conn);

        
        command.Parameters.AddWithValue("@IdSala", id);
        SqlDataAdapter adtp = new SqlDataAdapter(command);
        DataTable dtMensajes = new DataTable();

        adtp.Fill(dtMensajes);
        
        lvMensajes.DataSource = dtMensajes;
        lvMensajes.DataBind();
    }

    protected void btnEnviar_Click(object sender, EventArgs e)
    {
        
        string connection = "Data Source=FEDE2\\SQLEXPRESS;Initial Catalog=dbChatTcp2;Integrated Security=True";
        SqlConnection conn = new SqlConnection(connection);

        conn.Open();
        string query = "INSERT INTO Mensaje (Login, IdSala, FechaHora, Texto) Values (@login, @id, @fecha, @texto)";
        SqlCommand commandLog = new SqlCommand(query, conn);
        commandLog.Parameters.AddWithValue("@login", ((usuario)Session["conectado"]).login);
        commandLog.Parameters.AddWithValue("@id", Request.QueryString["Id"]);
        commandLog.Parameters.AddWithValue("@fecha", DateTime.Now);
        commandLog.Parameters.AddWithValue("@texto", txtMensaje.Text);

        commandLog.ExecuteNonQuery();

    }
}

