namespace SunamoFubuCore.Reflection.Expressions;

public abstract class CaseInsensitiveStringMethodPropertyOperation : IPropertyOperation
{
    private readonly MethodInfo _method;
    private readonly bool _negate;

    protected CaseInsensitiveStringMethodPropertyOperation(MethodInfo method) : this(method, false)
    {
    }

    protected CaseInsensitiveStringMethodPropertyOperation(MethodInfo method, bool negate)
    {
        _method = method;
        _negate = negate;
    }

    public virtual string OperationName => _method.Name;

    public abstract string Text { get; }

    public Func<object, Expression<Func<T, bool>>> GetPredicateBuilder<T>(MemberExpression propertyPath)
    {
        return valueToCheck =>
        {
            var valueToCheckConstant = Expression.Constant(valueToCheck);
            var binaryExpression = Expression.Coalesce(propertyPath, Expression.Constant(string.Empty));
            var invariantCulture = Expression.Constant(StringComparison.InvariantCultureIgnoreCase);
            Expression expression =
    Expression.Call(binaryExpression, _method, valueToCheckConstant, invariantCulture);
            if (_negate) expression = Expression.Not(expression);

            var lambdaParameter = propertyPath.GetParameter<T>();
            return Expression.Lambda<Func<T, bool>>(expression, lambdaParameter);
        };
    }
}
