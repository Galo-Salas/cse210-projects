using System;

public class Fraction
{
    // Private attributes for encapsulation
    private int _top;
    private int _bottom;

    // 1. Constructor: No parameters 
    public Fraction()
    {
        _top = 1;
        _bottom = 1;
    }

    // 2. Constructor: One parameter
    public Fraction(int wholeNumber)
    {
        _top = wholeNumber;
        _bottom = 1;
    }

    // 3. Constructor: Two parameters
    public Fraction(int top, int bottom)
    {
        _top = top;
        _bottom = bottom;
    }

    // Getters and Setters
    public int GetTop()
    {
        return _top;
    }

    public void SetTop(int top)
    {
        _top = top;
    }

    public int GetBottom()
    {
        return _bottom;
    }

    public void SetBottom(int bottom)
    {
        _bottom = bottom;
    }

    // Method to return the fraction as a string
    public string GetFractionString()
    {
        return $"{_top}/{_bottom}";
    }

    // Method to return the decimal value
    public double GetDecimalValue()
    {
        // Cast to double to ensure floating-point division, not integer division
        return (double)_top / (double)_bottom;
    }
}