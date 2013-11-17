using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;


public partial class login : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["conectado"]!=null)
        {
            Response.Redirect("SalaDeEspera.aspx");
        }


    }
    protected void btnLog_Click(object sender, EventArgs e)
    {
        int esadm = 0;

        string connection = "Data Source=FEDE2\\SQLEXPRESS;Initial Catalog=dbChatTcp2;Integrated Security=True";
        SqlConnection conn = new SqlConnection(connection);

        conn.Open();

        string querryLog = "SELECT Login, Password, UltimoAcceso, Administrador from Usuario WHERE Login=@login and Password=@pass";
        SqlCommand commandLog = new SqlCommand(querryLog, conn);

        commandLog.Parameters.AddWithValue ("@login", txtUsuario.Text);
        commandLog.Parameters.AddWithValue("@pass",txtContraseña.Text);

        SqlDataReader reader = commandLog.ExecuteReader(); 

        if (reader.HasRows)
        {
            usuario userlogin= new usuario();
            //userlogin.login = reader.GetString(0);
            reader.Read();
            userlogin.login = reader["Login"].ToString();
            userlogin.password = reader["Password"].ToString();
            userlogin.administrador = (bool)(reader["Administrador"]);

            userlogin.acceso = DateTime.Now;

            conn.Close();

            conn.Open();
            querryLog = "UPDATE Usuario Set UltimoAcceso = @UltimoAcceso Where Login = @login and Password= @pass";
            commandLog =  new SqlCommand(querryLog, conn);
            commandLog.Parameters.AddWithValue("@login", txtUsuario.Text);
            commandLog.Parameters.AddWithValue("@pass", txtContraseña.Text);
            commandLog.Parameters.AddWithValue("@UltimoAcceso",userlogin.acceso);
            commandLog.ExecuteNonQuery();

            Session["conectado"]= userlogin;
            if (userlogin.administrador == true)//si es administrador esadm = 1 y se lo paso a s.d.e
            {
                esadm = 1;
                Response.Redirect("SalaDeEspera.aspx?adm=" + esadm);
            }else
            Response.Redirect("SalaDeEspera.aspx?adm=" + esadm);
        }//else
            //agregar cartel usuario incorrecto,vuelva a ingresar


    }
}