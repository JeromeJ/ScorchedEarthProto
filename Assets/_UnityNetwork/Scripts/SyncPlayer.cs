using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.Networking;

public class SyncPlayer : NetworkBehaviour
{
    #region Public Members

    [SyncVar(hook = "OnChangeName")]
    public string _name;

    [SerializeField]
    private SyncSphere m_syncedSphere;

    #endregion

    #region Public void

    public static void blabbla()
    {

    }

    public void SetNameTo(string name)
    {
        //// CAUTION, it seems you can permanently edit your prefabs :) oups :<

        Selection.objects = new GameObject[] { this.gameObject };
        this.transform.localScale = Vector3.forward;

        Debug.Log(this.gameObject.scene, this.gameObject);

        CmdChangeName(name);
    }

    public void OnChangeName(string name)
    {
        this.name = name;
    }

    [Command] public void CmdChangeName(string name)
    {
        Debug.Log("Server change name:" + name);
        _name = name;

        // If done here instead of the hook = only on the server
        // gameObject.name = name;
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
