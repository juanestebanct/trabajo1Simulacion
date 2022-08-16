using UnityEngine;

[System.Serializable]
public struct MyVector
{
    public float x;
    public float y;

    public MyVector(float x, float y)
    {
        this.x = x;
        this.y = y;
    }

    public MyVector Sum(MyVector other)
    {
        return new MyVector(
            x + other.x,
            y + other.y
        );
    }
    public MyVector sub(MyVector other)
    {
        return new MyVector(
            x - other.x,
            y - other.y
        );
    }
    public MyVector Scale(float other)
    {
        return new MyVector(
            x * other,
            y * other
        );
    }
    public static MyVector operator +(MyVector a, MyVector b)
    {
        return a.Sum(b);
    }
    public static MyVector operator -(MyVector a, MyVector b)
    {
        return a.sub(b);
    }
    public static MyVector operator *(MyVector a, float b)
    {
        return a.Scale(b);
    }
    public static MyVector operator *(float b, MyVector a)
    {
        return a.Scale(b);
    }
    public void Draw(Color color)
    {
        Debug.DrawLine(
            new Vector3(0, 0, 0),
            new Vector3(x, y, 0),
            color,
            0
        );
    }
    public static implicit operator Vector3(MyVector a)
    {
        return new Vector3(a.x,a.y,0);
    }
    public static implicit operator MyVector(Vector3 a)
    {
        return new MyVector(a.x,a.y);
    }
    public MyVector Lerp(MyVector b ,float c)
    {
        return (this + (this - b) * c);
            
    }
    public void Draw(MyVector origin,Color color)
    {
        Debug.DrawLine(
            new Vector3(origin.x,origin.y,0),
            new Vector3(x+origin.x, y+origin.y, 0),
            color,
            0
        );
    }
}
