using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EditorOnlyInput : MonoBehaviour {

    public float playerSpeed = 3.0f;
    public Player player;

    private Vector3 mouseLastPos;

    // Use this for initialization
    private void Awake()
    {
        mouseLastPos = Input.mousePosition;
        player = Player.Instance;
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 front = player.transform.forward;
        front.y = 0;
        front.Normalize();

        Vector3 right = player.transform.right;
        right.y = 0;
        right.Normalize();

        if (Input.GetKey(KeyCode.W))
        {
            player.transform.position += front * playerSpeed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.S))
        {
            player.transform.position -= front * playerSpeed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.D))
        {
            player.transform.position += right * playerSpeed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.A))
        {
            player.transform.position -= right * playerSpeed * Time.deltaTime;
        }

        {//Mouse movement
            Vector3 mouseDeltaPos = Input.mousePosition - mouseLastPos;
            //player.transform.Rotate(new Vector3(-mouseDeltaPos.y, 0, 0));
            player.transform.Rotate(new Vector3(0, mouseDeltaPos.x, 0));
            mouseLastPos = Input.mousePosition;
        }
        
        if (Input.GetKey(KeyCode.Space))
        {
            player.transform.position += Vector3.up * playerSpeed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.LeftControl))
        {
            player.transform.position -= Vector3.up * playerSpeed * Time.deltaTime;
        }

        if (Input.GetKeyDown(KeyCode.N))
        {
            EventManager.Instance.PlayNextEvent();
        }
    }
}
