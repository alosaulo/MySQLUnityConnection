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
    public GameObject panelLogin;

    [Header("Painel Usuário Logado")]
    public GameObject panelLogado;
    public Text txtUsuario;
    public Text score;

    [Header("Painel Cadastro Score")]
    public InputField inputScore;

    [Header("Painel Mostrar Scores")]
    public Text txtMostrarScores;

    public Usuario usuarioLogado;

    // Start is called before the first frame update
    void Start()
    {

    }

    public void MostrarUsuarios() {
        txtMostrarUsuario.text = ListarUsuarios();
    }

    public void MostarScores() {
        txtMostrarScores.text = ListarScores();
    }

    public void MostrarScoresUsuario() {
        score.text = ListarScores(usuarioLogado.id);
    }

    public void CadastraUsuario() {
        string login = inputLoginCadastro.text;
        string senha = inputSenhaCadastro.text;
        InserirUsuario(login, senha);
    }

    public void InserirScore() {
        int pontos = int.Parse(inputScore.text);
        int userId = usuarioLogado.id;

        string strCon = $"Server={Server}; Uid={User}; Database={Database}; Pwd={Password}; Port={Port}";
        MySqlConnection con = new MySqlConnection(strCon);
        try
        {
            txtMsgServidor.text = "Conectando no banco.";
            con.Open();
            string sql = $"INSERT INTO SCORE(PONTOS, USUARIOID) VALUES ('{pontos}','{userId}')";
            MySqlCommand cmd = new MySqlCommand(sql, con);
            txtMsgServidor.text = "Realizando query.";
            cmd.ExecuteNonQuery();

        }
        catch (System.Exception ex)
        {
            txtMsgServidor.text = ex.Message;
        }
        con.Close();
        txtMsgServidor.text = "Tudo ok";
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

    private string ListarScores() {
        string resultado = "";
        string strCon = $"Server={Server}; Uid={User}; Database={Database}; Pwd={Password}; Port={Port}";
        MySqlConnection con = new MySqlConnection(strCon);
        try
        {
            txtMsgServidor.text = "Conectando no banco.";

            con.Open();

            string sql = "SELECT u.LOGIN, s.PONTOS from usuario u, score s where u.id = s.USUARIOID order by s.PONTOS DESC";

            MySqlCommand cmd = new MySqlCommand(sql, con);
            MySqlDataReader rdr = cmd.ExecuteReader();

            resultado += "LOGIN -- SCORE \n";

            while (rdr.Read())
            {
                resultado += (rdr[0] + " -- " + rdr[1] + "\n");
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

    private string ListarScores(int idUsuario) {
        string resultado = "";
        string strCon = $"Server={Server}; Uid={User}; Database={Database}; Pwd={Password}; Port={Port}";
        MySqlConnection con = new MySqlConnection(strCon);
        try
        {
            txtMsgServidor.text = "Conectando no banco.";

            con.Open();

            string sql = $"SELECT u.LOGIN, s.PONTOS from usuario u, score s where u.id = {idUsuario} && s.USUARIOID = {idUsuario} order by s.PONTOS DESC";

            MySqlCommand cmd = new MySqlCommand(sql, con);
            MySqlDataReader rdr = cmd.ExecuteReader();

            resultado += "LOGIN -- SCORE \n";

            while (rdr.Read())
            {
                resultado += (rdr[0] + " -- " + rdr[1] + "\n");
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
            panelLogado.SetActive(true);
            panelLogin.SetActive(false);
            txtUsuario.text = usuarioLogado.NOME;
            MostrarScoresUsuario();
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
                usuarioLogado.id = (int)rdr[0];
                usuarioLogado.NOME = rdr[1].ToString();
                usuarioLogado.SENHA = rdr[2].ToString();
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
