using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HairController : MonoBehaviour
{
    public int hairStyle;
    public PlayerMovement playerMovement;

    public SpriteSheet[] hairSpriteSheets;

    private void Update()
    {
        hairStyle = transform.parent.GetComponent<PlayerColorsLoader>().playerData.hairStyle;
        GetComponent<SpriteRenderer>().sprite = getSpriteFromVec(hairStyle, playerMovement.change);
    }

    private Sprite getSpriteFromVec(int hairStyle, Vector2 vec)
    {
        float xAbs = Mathf.Abs(vec.x);
        float yAbs = Mathf.Abs(vec.y);

        if (xAbs > yAbs)
        {
            if (vec.x < 0) //Left
            {
                return hairSpriteSheets[hairStyle].spriteSheet[3];
            }
            else if (vec.x > 0) //Right
            {
                return hairSpriteSheets[hairStyle].spriteSheet[1];
            }
        }
        else if (xAbs < yAbs)
        {
            if (vec.y > 0) //Up
            {
                return hairSpriteSheets[hairStyle].spriteSheet[2];
            }
            else if (vec.y < 0) //Down
            {
                return hairSpriteSheets[hairStyle].spriteSheet[0];
            }
        }
        return hairSpriteSheets[hairStyle].spriteSheet[0];
    }

    [System.Serializable]
    public class SpriteSheet
    {
        public Sprite[] spriteSheet;
    }
}

