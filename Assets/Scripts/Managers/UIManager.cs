using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
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

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public Usuario GetDadosNovoUsuario() 
    { 
        Usuario novoUsuario = new Usuario();

        novoUsuario.NOME = "";
        novoUsuario.LOGIN = "";
        novoUsuario.IDADE = "";
        novoUsuario.SEXO = "";
        novoUsuario.SENHA = "";

        return novoUsuario;
    }

    public void MostrarNotificacao(string text) 
    { 
        
    }

}
