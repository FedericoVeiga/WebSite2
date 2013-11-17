using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for usuario
/// </summary>
public class usuario
{
    private string pvpassword;
    private string pvlogin;
    private DateTime pvacceso;
    private bool pvadministrador;

    public string login
    {
        get
        {
            return pvlogin;
        }
        set
        {
            pvlogin = value;
        }
    }

    public string password
    {
        get
        {
            return pvpassword;
        }
        set
        {
            pvpassword = value;
        }
    }

    public DateTime acceso
    {
        get
        {
            return pvacceso;
        }
        set
        {
            pvacceso = value;
        }
    }

    public bool administrador
    {
        get
        {
            return pvadministrador;
        }
        set
        {
            pvadministrador = value;
        }
    } 
	
}

