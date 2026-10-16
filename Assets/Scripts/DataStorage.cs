using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "MoveData", menuName ="move")]
public class DataStorage : ScriptableObject
{
    [SerializeField] private int speedCraw;
    public int SpeedCraw => speedCraw;
    [SerializeField] private int speedRun;
    public int SpeedRun => speedRun;
    [SerializeField] private int speedWalk;
    public int SpeedWalk => speedWalk;
    [SerializeField] private int jump;
    public int Jump => jump;
    [SerializeField] private int jumpWater;
    public int JumpWater => jumpWater;
    
}
