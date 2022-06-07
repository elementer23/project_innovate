using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterSprite 
{
    public Sprite frontSprite { get; }
    public Sprite sideSprite { get; }

    public CharacterSprite(Sprite frontSprite, Sprite sideSprite)
    {
        this.frontSprite = frontSprite;
        this.sideSprite = sideSprite;
    }


}
