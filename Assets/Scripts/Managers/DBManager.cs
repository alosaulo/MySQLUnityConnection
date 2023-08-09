using MySql.Data.MySqlClient;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class DBManager : MonoBehaviour
{
    public DBConnection dbConn;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public bool Login()
    {
        return false;
    }

    public void InsertUsuario(Usuario usuario) 
    {
        string strCon = dbConn.GetConnectionString();
        using (MySqlConnection conn = new MySqlConnection(strCon)) 
        {
            Debug.Log("Conectando no banco...");
            try
            {
                string sql = 
                    $"INSERT INTO USUARIO(NOME,IDADE,SEXO,LOGIN, SENHA) " +
                    $"VALUES ('{usuario.NOME}','{usuario.IDADE}','{usuario.SEXO}','{usuario.LOGIN}','{usuario.SENHA}')";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                Debug.Log("Realizando inserção...");
                cmd.ExecuteNonQuery();
            }
            catch (System.Exception ex)
            {
                Debug.LogError(ex.Message);
            }
            Debug.Log("Tudo ok!");
        }
    }

}
