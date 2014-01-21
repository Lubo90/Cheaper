using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for UsersModel
/// </summary>
public class UserModel
{
	public UserModel()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    public string UserName { get; set; }
    public string Passwd { get; set; }
    public bool StatsEnabled { get; set; }
    public bool ShowEmail { get; set; }
    public bool ShowPhone { get; set; }
    public bool ShowBirthDate { get; set; }
    public string GaduGadu { get; set; }
    public string Phone { get; set; }
    public byte[] DisplayPic { get; set; }
}