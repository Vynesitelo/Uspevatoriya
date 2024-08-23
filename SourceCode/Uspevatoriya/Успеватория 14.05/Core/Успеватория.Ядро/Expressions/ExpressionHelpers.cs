using System;
using System.Linq.Expressions;
using System.Reflection;

namespace Успеватория.Ядро
{
    /// <summary>
    /// Вспомогательный инструмент для выражений
    /// </summary>
    public static class ExpressionHelpers
    {
        /// <summary>
        /// Компилирует выражение и получает возвращаемое функцией значение
        /// </summary>
        /// <typeparam name="T">Тип возвращаемого значения</typeparam>
        /// <param name="lamba">Выражение для компиляции</param>
        /// <returns></returns>
        public static T GetPropertyValue<T>(this Expression<Func<T>> lamba)
        {
            return lamba.Compile().Invoke();
        }

        /// <summary>
        /// Устанавливает значение базовых свойств равным заданному значению
        /// из выражения, содержащего свойство
        /// </summary>
        /// <typeparam name="T">Тип получаемый</typeparam>
        /// <param name="lamba">Выражение</param>
        /// <param name="value">Значение, которое требуется присвоить этому свойству</param>
        public static void SetPropertyValue<T>(this Expression<Func<T>> lamba, T value)
        {
            // Конверт lamba () => some.Property, в some.Property
            var expression = (lamba as LambdaExpression).Body as MemberExpression;

            // сохраните информацию о свойстве, чтобы мы могли ее настроить
            var propertyInfo = (PropertyInfo)expression.Member;
            var target = Expression.Lambda(expression.Expression).Compile().DynamicInvoke();

            // Просваивание значение свойству
            propertyInfo.SetValue(target, value);

        }
    }
}
