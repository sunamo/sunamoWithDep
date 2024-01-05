namespace SunamoFubuCore.Reflection.Expressions;

public class GreaterThanPropertyOperation : BinaryComparisonPropertyOperation
{
    public GreaterThanPropertyOperation()
    : base(ExpressionType.GreaterThan)
    {
    }

    public override string OperationName => "GreaterThan";

    public override string Text => "greater than";
}
