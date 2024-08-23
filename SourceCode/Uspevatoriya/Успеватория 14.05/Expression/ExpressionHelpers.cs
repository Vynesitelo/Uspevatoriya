using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Успеватория
{
    public static class ExpressionHelpers
    {
        /// <summary>
        /// Компилирует значение и возвращает значени функции
        /// </summary>
        /// <typeparam name="T">Тип выражения</typeparam>
        /// <param name="lambda">Выражение</param>
        /// <returns></returns>
        public static T GetPropertyValue<T>(this Expression<Func<T>> lambda)
        {
            return lambda.Compile().Invoke();
        }
        /// <summary>
        /// Устанавливает значени базовых свойств на заданное значени содержащее свойство
        /// </summary>
        /// <typeparam name="T">Тип значения</typeparam>
        /// <param name="lambda">Выражение</param>
        /// <param name="value">значение</param>
        public static void SetPropertyValue<T> (this Expression<Func<T>> lambda, T value)
        {
            //Преобразует лямбду в свойство суммирование точек
            var expression = (lambda as LambdaExpression).Body as MemberExpression;

            //Получение информации о свойстве
            var propertyInfo = (PropertyInfo)expression.Member;
            var target = Expression.Lambda(expression.Expression).Compile().DynamicInvoke();

            propertyInfo.SetValue(target, value);
        }
    }
}
