using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Terrain : MonoBehaviour
{
    SpriteRenderer spriteRenderer;
    Texture2D texture;
    Vector2 textureDimensions;

	// Use this for initialization
	void Start()
    {
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        texture = Instantiate(spriteRenderer.sprite.texture) as Texture2D;
        spriteRenderer.sprite = Sprite.Create(texture, spriteRenderer.sprite.rect, new Vector2(0.5f, 0.5f), spriteRenderer.sprite.pixelsPerUnit);
        
        textureDimensions = new Vector2(texture.width, texture.height);
        HighlightEdges();
	}

    void HighlightEdges()
    {
        for (int x = 0; x < texture.width; x++)
        {
            for (int y = 0; y < texture.height; y++)
            {
                if (PixelOnMap(x,y) && PixelIsSolid(x, y))
                {
                    var airPixels = GetNearbyAirPixels(x, y);
                    if (airPixels.Count > 0)
                    {
                        texture.SetPixel(x, y, Color.black);
                        Color halfTransparent = Color.black;
                        halfTransparent.a = 0.25f;
                        foreach (var pixel in airPixels)
                        {
                            texture.SetPixel(pixel.x, pixel.y, halfTransparent);
                        }
                    }
                    if (PixelIsGround(x, y))
                    {
                        texture.SetPixel(x, y, Color.red);
                    }
                }
            }
        }
        texture.Apply();
    }

    static List<IntVector2> nearbyOffsets = new List<IntVector2>()
    {
            new IntVector2(-1, 0),
            new IntVector2(1, 0),
            new IntVector2(0, -1),
            new IntVector2(0, 1),
    };

    List<IntVector2> GetNearbyAirPixels(int x, int y)
    {
        List<IntVector2> airPixels = new List<IntVector2>();

        foreach (var offset in nearbyOffsets)
        {
            var pixel = new IntVector2(x + offset.x, y + offset.y);
            if (PixelOnMap(x, y) && !PixelIsSolid(pixel.x, pixel.y))
            {
                airPixels.Add(pixel);
            }
        }

        return airPixels;
    }

    bool PixelIsGround(int x, int y)
    {
        return PixelOnMap(x, y + 1) && !PixelIsSolid(x, y + 1);
    }

    bool PixelIsSolid(int x, int y)
    {
        return GetPixelTransparency(x, y) > 0.5f;
    }

    bool PixelOnMap(int x, int y)
    {
        return (x > 0 || x <= texture.width) && (y > 0 || y <= texture.height);
    }

    int GetGroundBelow(int x, int y)
    {
        for (int y0 = y; y0 > 0; y0--)
        {
            if (PixelIsSolid(x, y0))
            {
                return y0;
            }
        }
        return -1;
    }


    float GetPixelTransparency(int x, int y)
    {
        return texture.GetPixel(x, y).a;
    }
	
	// Update is called once per frame
	void Update()
    {

	}

    void HighlightClickedGround()
    {
        RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
        if (!hit)
            return;

        IntVector2 localPosition = new IntVector2((Vector2)transform.InverseTransformPoint(hit.point) + textureDimensions/2);
        var groundY = GetGroundBelow((int)localPosition.x, localPosition.y);

        if (groundY > -1)
        {
            texture.SetPixel(localPosition.x, groundY, Color.green);
            texture.Apply();
        }
    }

    void OnMouseDrag()
    {
        HighlightClickedGround();
    }
}
