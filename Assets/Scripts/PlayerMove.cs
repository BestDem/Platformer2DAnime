using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public static PlayerMove singltoneMove {get; private set;}
    [SerializeField] private PlayerController2D playerController;
    [SerializeField] private DataStorage data;
    private float speed;
    public float Speed() => speed;

    private void Awake()
    {
        singltoneMove = this;
        speed = data.SpeedWalk;
    }

    private void Update()
    {
        if(speed != data.SpeedRun && speed != data.SpeedWalk) return;

        if(Input.GetKey(KeyCode.LeftControl))
            speed = data.SpeedRun;
        else
            speed = data.SpeedWalk;
    }

    public void ChangeSpeed(float speedN)
    {
        speed = speedN;
    }
    public void ChangeSpeedOnTime(float speed, float time)
    {
        StartCoroutine(Change(time));
    }

    IEnumerator Change(float time)
    {
        yield return new WaitForSecondsRealtime(time);
        ChangeSpeed(data.SpeedWalk);
    }
}
