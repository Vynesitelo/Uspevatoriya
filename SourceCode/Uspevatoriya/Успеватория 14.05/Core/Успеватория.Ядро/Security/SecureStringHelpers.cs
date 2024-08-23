using System;
using System.Runtime.InteropServices;
using System.Security;

namespace Успеватория.Ядроe
{
    /// <summary>
    /// Помощник <see cref="SecureString"/> класса
    /// </summary>
    public static class SecureStringHelpers
    {
        /// <summary>
        /// Расшифровывает <see cref="SecureString"/> переводит в текст
        /// </summary>
        /// <param name="secureString">Строка с паролем</param>
        /// <returns></returns>
        public static string Unsecure(this SecureString secureString)
        {
            // MПроверяем наличие строки
            if (secureString == null)
                return string.Empty;

            // Получаем точку незащищённой строки в памяти
            var unmanagedString = IntPtr.Zero;

            try
            {
                // Расшифрованный пароль
                unmanagedString = Marshal.SecureStringToGlobalAllocUnicode(secureString);
                return Marshal.PtrToStringUni(unmanagedString);
            }
            finally
            {
                // Очищаем из памяти
                Marshal.ZeroFreeGlobalAllocUnicode(unmanagedString);
            }
        }
    }
}
