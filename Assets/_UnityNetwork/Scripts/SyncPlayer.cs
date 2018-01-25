using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class SyncPlayer : NetworkBehaviour
{
    #region Public Members

    [SyncVar]
    // [SyncVar(hook = "OnChangeName")]
    public string _name;

    #endregion

    #region Public void

    public void SetNameTo(string name)
    {
        CmdChangeName(name);
    }

    //public void OnChangeName(string name)
    //{
    //    this.name = name;
    //}


    [Command]
    public void CmdChangeName(string name)
    {

        Debug.Log("Server change name:" + name);
        _name = name;

        // Instead of the hook
        gameObject.name = name;
    }

    #endregion

    #region System

    protected void Awake()
    {
        
    }

    private void Update()
    {
        
    }

    #endregion

    #region Class Methods

    #endregion

    #region Tools Debug and Utility

    #endregion

    #region Private and Protected Members

    #endregion
}
