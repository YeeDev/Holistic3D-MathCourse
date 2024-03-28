using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Matrix
{
    public float[] values;
    public int rows;
    public int cols;

    public Matrix(int r, int c, float[] v)
    {
        rows = r;
        cols = c;
        values = new float[rows * cols];
        Array.Copy(v, values, rows * cols);
    }

    public override string ToString()
    {
        string matrix = "\n";

        for (int r = 0; r < rows; r++)
        {
            for (int c = 0; c < cols; c++)
            {
                matrix += values[r * cols + c] + " ";
            }

            matrix += "\n";
        }

        return matrix;
    }

    static public Matrix operator +(Matrix a, Matrix b)
    {
        if (a.rows != b.rows || a.cols != b.cols) { return null; }

        Matrix result = new Matrix(a.rows, a.cols, a.values);
        for (int i = 0; i < a.values.Length; i++)
        {
            result.values[i] += b.values[i];
        }

        return result;
    }

    static public Matrix operator *(Matrix a, Matrix b)
    {
        if (a.rows != b.cols) { return null; }

        float[] values = new float[a.rows * b.cols];

        int valueToChange = 0;
        for (int ar = 0; ar < a.rows; ar++)
        {
            for (int bc = 0; bc < b.cols; bc++)
            {
                for (int c = 0; c < a.cols; c++)
                {
                    values[valueToChange] += a.values[c + a.cols * ar] * b.values[bc + b.cols * c];
                }

                valueToChange++;
            }
        }

        return new Matrix(a.rows, b.cols, values);
    }
}