using System;
using UnityEngine;
using UnityEngine.AI;

public static class HexMetrics
{
    public static float HexRadius { get; private set; }
    public static float OuterRadius(float hexSize)
    {
        return hexSize;
    }
    public static float InnerRadius(float hexSize)
    {
        return hexSize * (Mathf.Sqrt(3) / 2);
    }

    public static Vector3[] Corners(float hexSize, HexOrientation orientation)
    {
        Vector3[] corners = new Vector3[6];
        for (int i = 0; i < 6; i++)
        {
            corners[i] = Corner(hexSize, orientation, i);
        }
        return corners;
    }

    public static Vector3 Corner(float hexSize, HexOrientation orientation, int index)
    {

        float angle = 60f * index;
        if (orientation == HexOrientation.Pointy)
        {
            angle += 30f;
        }
        Vector3 corner = new Vector3(hexSize * Mathf.Cos(angle * Mathf.Deg2Rad),
            0f,
            hexSize * Mathf.Sin(angle * Mathf.Deg2Rad)
            );
        return corner;
    }

    public static Vector3 Center(float hexSize, int x, int z, HexOrientation orientation)
    {
        Vector3 centerPosition;
        if (orientation == HexOrientation.Pointy)
        {
            centerPosition.x = (x + z * 0.5f - z / 2) * (InnerRadius(hexSize) * 2f);
            centerPosition.y = 0f;
            centerPosition.z = z * (OuterRadius(hexSize) * 1.5f);
        }
        else
        { // FlatTop: Horizontal rows, columns stagger vertically.
            centerPosition.x = x * (OuterRadius(hexSize) * 1.5f);
            centerPosition.y = 0f;
            centerPosition.z = (z + (x % 2 == 1 ? 0.5f : 0f)) * (InnerRadius(hexSize) * 2f);
        }
        return centerPosition;
    }
    
    public static Vector3 OffsetToCube(int col, int row, HexOrientation orientation)
  {
      if (orientation == HexOrientation.Pointy)
      {
          return AxialToCube(OffsetToAxialPointy(col, row));
      }
      else
      {
          return AxialToCube(OffsetToAxialFlat(col, row));
      }
  }
  public static Vector3 AxialToCube(Vector2Int axial)
  {
      float x = axial.x;
      float z = axial.y;
      float y = -x - z;
      return new Vector3(x, z, y);
  }
  public static Vector2Int OffsetToAxialFlat(int col, int row)
  {
      int q = col;
      int r = row - (col + (col & 1)) / 2;
      return new Vector2Int(q, r);
  }

  public static Vector2Int OffsetToAxialPointy(int col, int row)
  {
      int q = col - (row + (row & 1)) / 2;
      int r = row;
      return new Vector2Int(q, r);
  }
}
