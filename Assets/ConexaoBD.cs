using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MySql.Data.MySqlClient;
using UnityEngine.UI;

public class ConexaoBD : MonoBehaviour
{
    [Header("Dados Conexão")]
    public string Server;
    public string User;
    public string Database;
    public string Password;
    public string Port;

    [Header("Mensagem Servidor")]
    public Text txtMsgServidor;

    [Header("Painel Cadastro Usuário")]
    public InputField inputLoginCadastro;
    public InputField inputSenhaCadastro;

    [Header("Painel Mostrar Usuários")]
    public Text txtMostrarUsuario;

    [Header("Painel Logar Usuário")]
    public InputField inputLoginUsuario;
    public InputField inputLoginSenhaUsuario;

    // Start is called before the first frame update
    void Start()
    {

    }

    public void MostrarUsuarios() {
        txtMostrarUsuario.text = ListarUsuarios();
    }

    public void CadastraUsuario() {
        string login = inputLoginCadastro.text;
        string senha = inputSenhaCadastro.text;
        InserirUsuario(login, senha);
    }

    private void InserirUsuario(string login, string senha) 
    {
        string strCon = $"Server={Server}; Uid={User}; Database={Database}; Pwd={Password}; Port={Port}";
        MySqlConnection con = new MySqlConnection(strCon);
        try
        {
            txtMsgServidor.text = "Conectando no banco.";
            con.Open();
            string sql = $"INSERT INTO USUARIO(LOGIN, SENHA) VALUES ('{login}','{senha}')";
            MySqlCommand cmd = new MySqlCommand(sql, con);
            txtMsgServidor.text = "Fazendo consulta.";
            cmd.ExecuteNonQuery();

        }
        catch (System.Exception ex)
        {
            txtMsgServidor.text =  ex.Message;
        }
        con.Close();
        txtMsgServidor.text = "Tudo ok";
    }

    private string ListarUsuarios()
    {
        string resultado = "";
        string strCon = $"Server={Server}; Uid={User}; Database={Database}; Pwd={Password}; Port={Port}";
        MySqlConnection con = new MySqlConnection(strCon);
        try
        {
            txtMsgServidor.text = "Conectando no banco.";
            
            con.Open();
            
            string sql = $"SELECT * FROM USUARIO";
            
            MySqlCommand cmd = new MySqlCommand(sql, con);
            MySqlDataReader rdr = cmd.ExecuteReader();

            while (rdr.Read())
            {
                resultado += (rdr[0] + " -- " + rdr[1] +" -- " + rdr[2]+"\n");
            }

            rdr.Close();
        }
        catch (System.Exception ex)
        {
            txtMsgServidor.text = ex.Message;
        }
        con.Close();
        txtMsgServidor.text = "Tudo ok";
        return resultado;
    }

    public void Logar() {
        string login = inputLoginUsuario.text;
        string senha = inputLoginSenhaUsuario.text;
        bool conexao = ConexaoLogin(login, senha);
        if (conexao == true)
        {
            txtMsgServidor.text = "Usuário logado";
        }
    }

    private bool ConexaoLogin(string login, string senha) {
        string resultado = "";
        string strCon = $"Server={Server}; Uid={User}; Database={Database}; Pwd={Password}; Port={Port}";
        MySqlConnection con = new MySqlConnection(strCon);
        try
        {
            txtMsgServidor.text = "Conectando no banco.";

            con.Open();

            string sql = $"SELECT * FROM USUARIO WHERE LOGIN='{login}' and senha='{senha}'";

            MySqlCommand cmd = new MySqlCommand(sql, con);
            MySqlDataReader rdr = cmd.ExecuteReader();

            int rowcount = 0;

            while (rdr.Read())
            {
                rowcount++;
            }

            if (rowcount > 0) {
                rdr.Close();
                con.Close();
                txtMsgServidor.text = "Usuário encontrado";
                return true;
            }
            else { 
                rdr.Close();
                con.Close();
                txtMsgServidor.text = "Usuário não encontrado.";
                return false;
            }
            
        }
        catch (System.Exception ex)
        {
            txtMsgServidor.text = ex.Message;
            return false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
