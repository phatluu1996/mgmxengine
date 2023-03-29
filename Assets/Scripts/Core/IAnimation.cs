using UnityEngine;
public interface IAnimation
{    
    public void Animate(SpriteData spriteData, SpriteDataSet spriteDataSet, float normalizeTime);
    public void Animate(SpriteData spriteData, SpriteDataSet spriteDataSet);
    public int Frame();
    public float Length();
}