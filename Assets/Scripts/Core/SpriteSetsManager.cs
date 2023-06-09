using System;
using UnityEngine;

[CreateAssetMenu(fileName = "SpriteSetsManager", menuName = "mgmxengine/SpriteSetsManager", order = 0)]
[Serializable]
public class SpriteSetsManager : ScriptableObject
{
    public SpriteDataSet BeamDown;
    public SpriteDataSet Idle;
    public SpriteDataSet Crouch;
    public SpriteDataSet Run;
    public SpriteDataSet Dash;
    public SpriteDataSet Jump;
    public SpriteDataSet Fall;
    public SpriteDataSet Land;
    public SpriteDataSet WallSlide;
    public SpriteDataSet WallJump;
    public SpriteDataSet ClimbLadder;
    public SpriteDataSet ClimbLadderUp;
    public SpriteDataSet ClimbLadderDown;
}