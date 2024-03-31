﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HolisticMath
{
    static public Coords GetNormal(Coords vector)
    {
        float length = Distance(new Coords(0, 0, 0), vector);
        vector.x /= length;
        vector.y /= length;
        vector.z /= length;

        return vector;
    }

    static public float Distance(Coords point1, Coords point2)
    {
        float diffSquared = Square(point1.x - point2.x) +
                            Square(point1.y - point2.y) +
                            Square(point1.z - point2.z);
        float squareRoot = Mathf.Sqrt(diffSquared);
        return squareRoot;

    }

    static public Coords Lerp(Coords A, Coords B, float t)
    {
        t = Mathf.Clamp(t, 0, 1);
        Coords v = new Coords(B.x - A.x, B.y - A.y, B.z - A.z);
        float xt = A.x + v.x * t;
        float yt = A.y + v.y * t;
        float zt = A.z + v.z * t;

        return new Coords(xt, yt, zt);
    }

    static public float Square(float value)
    {
        return value * value;
    }

    static public float Dot(Coords vector1, Coords vector2)
    {
        return (vector1.x * vector2.x + vector1.y * vector2.y + vector1.z * vector2.z);
    }

    static public float Angle(Coords vector1, Coords vector2)
    {
        float dotDivide = Dot(vector1, vector2) /
                    (Distance(new Coords(0, 0, 0), vector1) * Distance(new Coords(0, 0, 0), vector2));
        return Mathf.Acos(dotDivide); //radians.  For degrees * 180/Mathf.PI;
    }

    static public Coords LookAt2D(Coords forwardVector, Coords position, Coords focusPoint)
    {
        Coords direction = new Coords(focusPoint.x - position.x, focusPoint.y - position.y, position.z);
        float angle = HolisticMath.Angle(forwardVector, direction);
        bool clockwise = false;
        if (HolisticMath.Cross(forwardVector, direction).z < 0)
            clockwise = true;

        Coords newDir = HolisticMath.Rotate(forwardVector, angle, clockwise);
        return newDir;
    }

    static public Coords Rotate(Coords vector, float angle, bool clockwise) //in radians
    {
        if (clockwise)
        {
            angle = 2 * Mathf.PI - angle;
        }

        float xVal = vector.x * Mathf.Cos(angle) - vector.y * Mathf.Sin(angle);
        float yVal = vector.x * Mathf.Sin(angle) + vector.y * Mathf.Cos(angle);
        return new Coords(xVal, yVal, 0);
    }

    static public Coords Translate(Coords position, Coords facing, Coords vector)
    {
        if (HolisticMath.Distance(new Coords(0, 0, 0), vector) <= 0) return position;
        float angle = HolisticMath.Angle(vector, facing);
        float worldAngle = HolisticMath.Angle(vector, new Coords(0, 1, 0));
        bool clockwise = false;
        if (HolisticMath.Cross(vector, facing).z < 0)
            clockwise = true;

        vector = HolisticMath.Rotate(vector, angle + worldAngle, clockwise);

        float xVal = position.x + vector.x;
        float yVal = position.y + vector.y;
        float zVal = position.z + vector.z;
        return new Coords(xVal, yVal, zVal);
    }

    static public Coords Translate(Coords position, Coords vector)
    {
        float[] translateValues = {1, 0, 0, vector.x,
                                   0, 1, 0, vector.y,
                                   0, 0, 1, vector.z,
                                   0, 0, 0, 1};

        Matrix translateMatrix = new Matrix(4, 4, translateValues);
        Matrix pos = new Matrix(4, 1, position.AsFloats());

        Matrix result = translateMatrix * pos;
        return result.AsCoords();
    }

    static public Coords Scale(Coords position, float scaleX, float scaleY, float scaleZ)
    {
        float[] translateValues = {scaleX, 0, 0, 0,
                                   0, scaleY, 0, 0,
                                   0, 0, scaleZ, 0,
                                   0, 0, 0, 1};

        Matrix scaleMatrix = new Matrix(4, 4, translateValues);
        Matrix pos = new Matrix(4, 1, position.AsFloats());

        Matrix result = scaleMatrix * pos;
        return result.AsCoords();
    }

    static public Coords Rotate(Coords position, float x, bool clockwiseX,
                                                 float y, bool clockwiseY,
                                                 float z, bool clockwiseZ)
    {
        x = !clockwiseX ? 2 * Mathf.PI - x : x;
        y = !clockwiseY ? 2 * Mathf.PI - y : y;
        z = !clockwiseZ ? 2 * Mathf.PI - z : z;

        float[] rollX = {1, 0, 0, 0,
                         0, Mathf.Cos(x), -Mathf.Sin(x), 0,
                         0, Mathf.Sin(x),  Mathf.Cos(x), 0,
                         0, 0, 0, 1};

        float[] rollY = {Mathf.Cos(y), 0, Mathf.Sin(y), 0,
                         0, 1, 0, 0,
                        -Mathf.Sin(y), 0, Mathf.Cos(y), 0,
                         0, 0, 0, 1};

        float[] rollZ = {Mathf.Cos(z), -Mathf.Sin(z), 0, 0,
                         Mathf.Sin(z),  Mathf.Cos(z), 0, 0,
                         0, 0, 1, 0,
                         0, 0, 0, 1};

        Matrix rotateX = new Matrix(4, 4, rollX);
        Matrix rotateY = new Matrix(4, 4, rollY);
        Matrix rotateZ = new Matrix(4, 4, rollZ);
        Matrix pos = new Matrix(4, 1, position.AsFloats());

        Matrix result = rotateZ * rotateY * rotateX * pos;

        return result.AsCoords();
    }

    static public Matrix GetRotationMatrix(float x, bool clockwiseX,
                                           float y, bool clockwiseY,
                                           float z, bool clockwiseZ)
    {
        x = !clockwiseX ? 2 * Mathf.PI - x : x;
        y = !clockwiseY ? 2 * Mathf.PI - y : y;
        z = !clockwiseZ ? 2 * Mathf.PI - z : z;

        float[] rollX = {1, 0, 0, 0,
                         0, Mathf.Cos(x), -Mathf.Sin(x), 0,
                         0, Mathf.Sin(x),  Mathf.Cos(x), 0,
                         0, 0, 0, 1};

        float[] rollY = {Mathf.Cos(y), 0, Mathf.Sin(y), 0,
                         0, 1, 0, 0,
                        -Mathf.Sin(y), 0, Mathf.Cos(y), 0,
                         0, 0, 0, 1};

        float[] rollZ = {Mathf.Cos(z), -Mathf.Sin(z), 0, 0,
                         Mathf.Sin(z),  Mathf.Cos(z), 0, 0,
                         0, 0, 1, 0,
                         0, 0, 0, 1};

        Matrix rotateX = new Matrix(4, 4, rollX);
        Matrix rotateY = new Matrix(4, 4, rollY);
        Matrix rotateZ = new Matrix(4, 4, rollZ);

        Matrix result = rotateZ * rotateY * rotateX;

        return result;
    }

    static public float GetRotationAxisAngle(Matrix rotation)
    {
        float angle = 0;

        Mathf.Acos(0.5f * (rotation.GetValue(0,0) + rotation.GetValue(1, 1) + rotation.GetValue(2, 2) + rotation.GetValue(3, 3) - 2));

        return angle;
    }

    static public Coords GetRotationAxis(Matrix rotation, float angle)
    {
        float vx;
        float vy;
        float vz;
        float s = 2 * Mathf.Sin(angle);

        vx = (rotation.GetValue(2, 1) - rotation.GetValue(1, 2)) / s;
        vy = (rotation.GetValue(0, 2) - rotation.GetValue(2, 0)) / s;
        vz = (rotation.GetValue(1, 0) - rotation.GetValue(0, 1)) / s;

        return new Coords(vx, vy, vz, 0);
    }

    static public Coords Shear(Coords position, float shearX, float shearY, float shearZ)
    {
        float[] translateValues = {1, shearY, shearZ, 0,
                                   shearX, 1, shearZ, 0,
                                   shearX, shearY, 1, 0,
                                   0, 0, 0, 1};

        Matrix shearMatrix = new Matrix(4, 4, translateValues);
        Matrix pos = new Matrix(4, 1, position.AsFloats());

        Matrix result = shearMatrix * pos;
        return result.AsCoords();
    }

    static public Coords ReflectX(Coords position)
    {
        float[] translateValues = { -1, 0, 0, 0,
                                    0, 1, 0, 0,
                                    0, 0, 1, 0,
                                    0, 0, 0, 1};

        Matrix reflectMatrix = new Matrix(4, 4, translateValues);
        Matrix pos = new Matrix(4, 1, position.AsFloats());

        Matrix result = reflectMatrix * pos;
        return result.AsCoords();
    }

    static public Coords ReflectY(Coords position)
    {
        float[] translateValues = {1,  0, 0, 0,
                                   0, -1, 0, 0,
                                   0,  0, 1, 0,
                                   0,  0, 0, 1};

        Matrix reflectMatrix = new Matrix(4, 4, translateValues);
        Matrix pos = new Matrix(4, 1, position.AsFloats());

        Matrix result = reflectMatrix * pos;
        return result.AsCoords();
    }

    static public Coords ReflectZ(Coords position)
    {
        float[] translateValues = {1, 0,  0, 0,
                                   0, 1,  0, 0,
                                   0, 0, -1, 0,
                                   0, 0,  0, 1};

        Matrix reflectMatrix = new Matrix(4, 4, translateValues);
        Matrix pos = new Matrix(4, 1, position.AsFloats());

        Matrix result = reflectMatrix * pos;
        return result.AsCoords();
    }

    static public Coords QRotate(Coords position, Coords axis, float angle)
    {
        float w = Mathf.Cos(angle * Mathf.Deg2Rad / 2);
        float s = Mathf.Sin(angle * Mathf.Deg2Rad / 2);
        Coords normalAxis = axis.GetNormal();
        float x = normalAxis.x * s;
        float y = normalAxis.y * s;
        float z = normalAxis.z * s;

        float[] values = {1 - 2*y*y - 2*z*z, 2*x*y - 2*w*z,     2*x*z + 2*w*y,     0,
                          2*x*y + 2*w*z,     1 - 2*x*x - 2*z*z, 2*y*z - 2*w*x,     0,
                          2*x*z - 2*w*y,     2*y*z + 2*w*z,     1 - 2*x*x - 2*y*y, 0,
                                  0,                 0,                 0,         1};

        Matrix quaternionMatrix = new Matrix(4, 4, values);
        Matrix pos = new Matrix(4, 1, position.AsFloats());

        Matrix result = quaternionMatrix * pos;
        return result.AsCoords();
    }

    static public Coords Cross(Coords vector1, Coords vector2)
    {
        float xMult = vector1.y * vector2.z - vector1.z * vector2.y;
        float yMult = vector1.z * vector2.x - vector1.x * vector2.z;
        float zMult = vector1.x * vector2.y - vector1.y * vector2.x;
        Coords crossProd = new Coords(xMult, yMult, zMult);
        return crossProd;
    }
}
