using UnityEngine;
using System.Collections;

public class Terrain : MonoBehaviour
{
    Texture2D texture;

	// Use this for initialization
	void Start()
    {
        texture = gameObject.GetComponent<SpriteRenderer>().sprite.texture;
        HighlightEdges();
	}

    void HighlightEdges()
    {
        for (int x = 0; x < texture.width; x++)
        {
            for (int y = 0; y < texture.height; y++)
            {
                if (PixelIsSolid(x, y) == true && PixelTouchingAir(x, y))
                {
                    texture.SetPixel(x, y, Color.black);
                }
            }
        }
        texture.Apply();
    }

    bool PixelTouchingAir(int x, int y)
    {
        if (PixelIsSolid(x - 1, y) == false)
            return true;
        if (PixelIsSolid(x + 1, y) == false)
            return true;
        if (PixelIsSolid(x, y - 1) == false)
            return true;
        if (PixelIsSolid(x, y + 1) == false)
            return true;
        if (PixelIsSolid(x - 1, y - 1) == false)
            return true;
        if (PixelIsSolid(x - 1, y + 1) == false)
            return true;
        if (PixelIsSolid(x + 1, y - 1) == false)
            return true;
        if (PixelIsSolid(x + 1, y + 1) == false)
            return true;

        return false;
    }

    bool? PixelIsSolid(int x, int y)
    {
        if (x < 0 || x >= texture.width || y < 0 || y >= texture.height)
            return null;

        return texture.GetPixel(x, y).a > 0.5f;
    }
	
	// Update is called once per frame
	void Update()
    {
	
	}

    void OnMouseDown()
    {

    }
}
