using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public DBManager dbManager;
    public UIManager uiManager;

    // Start is called before the first frame update
    void Start()
    {
        if(dbManager == null)
            dbManager = GetComponent<DBManager>();
        if(uiManager == null)
            uiManager = GetComponent<UIManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void CadastrarNovoUsuario() 
    {
        Usuario novoUsuario = uiManager.GetDadosNovoUsuario();
        dbManager.InsertUsuario(novoUsuario);
    }

}
