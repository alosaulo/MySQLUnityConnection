using UnityEngine;

[System.Serializable]
public class DBConnection
{
    [Header("Connection Data")]
    [SerializeField]
    string Server;
    [SerializeField]
    string User;
    [SerializeField]
    string Database;
    [SerializeField]
    string Password;
    [SerializeField]
    string Port;

    public string GetConnectionString() 
    {
        string strCon = $"Server={Server}; Uid={User}; Database={Database}; Pwd={Password}; Port={Port}";
        return strCon;
    }

}
