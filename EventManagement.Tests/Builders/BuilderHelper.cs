using System;
using System.Diagnostics.CodeAnalysis;
using System.Linq.Expressions;
using System.Reflection;

namespace EventManagement.Tests.Builders
{
    [ExcludeFromCodeCoverage]
    public static class BuilderHelper
    {
        public static TEntity InstantiateClass<TEntity>() where TEntity : class
        {
            var instance = (TEntity)Activator.CreateInstance(typeof(TEntity), true);

            return instance;
        }

        public static TEntity SetPropertyValue<TEntity, TValue>(
            this TEntity target,
            Expression<Func<TEntity, TValue>> memberLambda, TValue value)
            where TEntity : class
        {
            var body = memberLambda.Body;
            var memberLambdaIsMemberExpression = IsMemberExpression(body);

            if (memberLambdaIsMemberExpression)
            {
                var memberSelectorExpression = GetMemberExpression(body);
                var propertyInfo = memberSelectorExpression.Member as PropertyInfo;

                if (propertyInfo != null)
                    propertyInfo.SetValue(target, value, null);
            }

            return target;
        }

        private static bool IsMemberExpression(Expression body) =>
            body is MemberExpression || IsUnaryExpression(body);

        private static bool IsUnaryExpression(Expression body) =>
            body is UnaryExpression;

        private static MemberExpression GetMemberExpression(Expression body) =>
            IsUnaryExpression(body)
                ? GetMemberExpressionFromUnaryMember(body)
                : body as MemberExpression;

        private static MemberExpression GetMemberExpressionFromUnaryMember(Expression body) =>
            (body as UnaryExpression)?.Operand as MemberExpression;
    }
}