using UnityEngine;
public interface IAnimation
{    
    public void Animate(SpriteData spriteData, float normalizeTime);
    public void Animate(SpriteData spriteData);
    public int Frame();
    public float Length();
}