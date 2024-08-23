using System.Security;

namespace Успеватория
{
    /// <summary>
    /// Интерфейс для класса, который может предоставить secure password
    /// </summary>
    public interface IHavePassword
    {
        /// <summary>
        /// secure password
        /// </summary>
        SecureString SecurePassword { get; }
    }
}
