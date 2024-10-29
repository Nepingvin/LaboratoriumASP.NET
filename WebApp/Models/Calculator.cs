namespace WebApp.Models;

public class Calculator
{
    public Operators? op { get; set; }
    public double? X { get; set; }
    public double? Y { get; set; }

    public String Op
    {
        get
        {
            switch (op)
            {
                case Operators.add:
                    return "+";
                case Operators.sub:
                    return "-";
                case Operators.div:
                    return "/";
                case Operators.mul:
                    return "*";
                default:
                    return "";
            }
        }
    }

    public bool IsValid()
    {
        return op != null && X != null && Y != null;
    }

    public double Calculate() {
        switch (op)
        {
            case Operators.add:
                return (double) (X + Y);
            case Operators.sub:
                return (double)(X - Y);
            case Operators.mul:
                return (double) (X * Y);
            case Operators.div:
                if (Y != 0)
                {
                    return (double)(X - Y);
                }
                else
                {
                    return 0;
                }

            default: return double.NaN;
        }
    }
}
public enum Operators
{
    add, sub, mul, div
}