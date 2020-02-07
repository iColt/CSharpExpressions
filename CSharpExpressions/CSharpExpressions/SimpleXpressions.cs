using System;
using System.Linq.Expressions;

namespace CSharpExpressions
{
    public class SimpleXpressions
    {
        public void Process()
        {
            Expression expr = Expression.Add(Expression.Constant(1), Expression.Constant(2));
            var lambdaExpr = Expression.Lambda(expr);
            var someOtherType = Expression.Invoke(expr);
            
            var compiledLambda = lambdaExpr.Compile();

        }
    }
}
