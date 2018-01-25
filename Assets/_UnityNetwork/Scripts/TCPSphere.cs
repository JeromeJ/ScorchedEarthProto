using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
#if UNITY_EDITOR
using UnityEditor;
#endif
using UnityEngine;

public class TCPSphere : DualBehaviour
{
    #region Public Members

    #endregion

    #region Public void

    #endregion

    #region System

    public static char s_separator = ' ';

    protected static Socket s;
    protected SocketAsyncEventArgs test;

    protected void Start()
    {
        s = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        s.Connect("devutopia.net", 54321);
        //s.Blocking = false;

        //test = new SocketAsyncEventArgs();
        //test.Completed += new EventHandler<SocketAsyncEventArgs>(myTest);
    }

    protected void FixedUpdate()
    {
        if (Input.GetMouseButtonDown(0))
        {
            CmdChangeSize();
            
        }   
    }

#if UNITY_EDITOR
    /// <summary>
    /// Alternative to temporarily replace asynchronous sockets
    /// </summary>
    [MenuItem("SocketServer/Receive data")]
    public static void ReceiveData()
    {
        byte[] buffer = new byte[1024];
        s.Receive(buffer);

        string str = System.Text.Encoding.UTF8.GetString(buffer);

        Debug.Log(str);

        // TrimEnd removes extraneous leading spaces
        string lastSentScale = str.TrimEnd(s_separator).Split(s_separator).Last();
        float newScale = float.Parse(lastSentScale);

        GameObject.Find("Sphere").transform.localScale = new Vector3(newScale, newScale, newScale);
    }
#endif

    //private void myTest(object sender, SocketAsyncEventArgs e)
    //{
    //    Debug.Log(e.Buffer.ToString());
    //}

    private void CmdChangeSize()
    {
        float newScale = transform.localScale.x + .1f;

        transform.localScale = new Vector3(newScale, newScale, newScale);

        s.Send(Encoding.ASCII.GetBytes(newScale.ToString() + s_separator.ToString()));
    }

    #endregion

    #region Class Methods

    #endregion

    #region Tools Debug and Utility

    #endregion

    #region Private and Protected Members

    #endregion
}
