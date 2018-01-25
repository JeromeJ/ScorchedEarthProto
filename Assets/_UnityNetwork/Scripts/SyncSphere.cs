using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Networking;

public class SyncSphere : NetworkBehaviour
{
    #region Public Members

    [SyncVar] public float Size = 1;

    public UnityEvent OnClick = new UnityEvent();

    #endregion

    #region Public void

    #endregion

    #region System

    protected void Awake()
    {
        m_transform = transform;
    }

    protected void FixedUpdate()
    {
        if (Input.GetMouseButtonDown(0))
        {
            //Size += .1f;
            OnClick.Invoke();
            CmdChangeSize(Size + .1f);
        }
            
    }

    [Command]
    public void CmdChangeSize(float _size)
    {
        Size = _size;
        m_transform.localScale *= _size;
    }

    #endregion

    #region Class Methods

    #endregion

    #region Tools Debug and Utility

    #endregion

    #region Private and Protected Members

    private Transform m_transform;

    #endregion
}
