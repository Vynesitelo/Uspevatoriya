using System;
using System.Data.Entity;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Успеватория.DAL.Context;
using Успеватория.Ядро;

namespace Успеватория
{
    /// <summary>
    /// Репозиторий для работы с сущностями типа T, наследующими Entity.
    /// </summary>
    /// <typeparam name="T">Тип сущности, наследующей Entity</typeparam>
    public class Repository<T> : IRepository<T>
        where T : Entity, new()
    {
        private readonly sqlUspevatoriyaEntities _uspevatoriyaDbContext;
        private readonly DbSet<T> _dbSet;

        /// <summary>
        /// Флаг автоматического сохранения изменений в базе данных.
        /// </summary>
        public bool AutoSaveChanges { get; set; } = true;

        /// <summary>
        /// Конструктор репозитория.
        /// </summary>
        public Repository()
        {
            var context = new sqlUspevatoriyaEntities();
            _uspevatoriyaDbContext = context;

            _dbSet = _uspevatoriyaDbContext.Set<T>();
        }

        /// <summary>
        /// Получает все элементы типа T из базы данных.
        /// </summary>
        public virtual IQueryable<T> Items => _dbSet;

        /// <summary>
        /// Получает элемент типа T по его идентификатору.
        /// </summary>
        /// <param name="id">Идентификатор элемента</param>
        /// <returns>Элемент типа T с заданным идентификатором, или null, если элемент не найден</returns>
        public T Get(int id) => Items.SingleOrDefault(item => item.ID == id);

        /// <summary>
        /// Асинхронно получает элемент типа T по его идентификатору.
        /// </summary>
        /// <param name="id">Идентификатор элемента</param>
        /// <param name="cancel">Токен отмены операции</param>
        /// <returns>Элемент типа T с заданным идентификатором, или null, если элемент не найден</returns>
        public async Task<T> GetAsync(int id, CancellationToken Cancel = default) => await Items
           .SingleOrDefaultAsync(item => item.ID == id, Cancel)
           .ConfigureAwait(false);

        /// <summary>
        /// Добавляет новый элемент типа T в базу данных.
        /// </summary>
        /// <param name="item">Элемент типа T, который нужно добавить</param>
        /// <returns>Добавленный элемент типа T</returns>
        public T Add(T item)
        {
            if (item is null) throw new ArgumentNullException(nameof(item));
            _uspevatoriyaDbContext.Entry(item).State = EntityState.Added;
            if (AutoSaveChanges)
                _uspevatoriyaDbContext.SaveChanges();
            return item;
        }

        /// <summary>
        /// Асинхронно добавляет новый элемент типа T в базу данных.
        /// </summary>
        /// <param name="item">Элемент типа T, который нужно добавить</param>
        /// <param name="cancel">Токен отмены операции</param>
        /// <returns>Добавленный элемент типа T</returns>
        public async Task<T> AddAsync(T item, CancellationToken Cancel = default)
        {
            if (item is null) throw new ArgumentNullException(nameof(item));
            _uspevatoriyaDbContext.Entry(item).State = EntityState.Added;
            if (AutoSaveChanges)
                await _uspevatoriyaDbContext.SaveChangesAsync(Cancel).ConfigureAwait(false);
            return item;
        }

        /// <summary>
        /// Обновляет элемент типа T в базе данных.
        /// </summary>
        /// <param name="item">Элемент типа T, который нужно обновить</param>
        public void Update(T item)
        {
            if (item is null) throw new ArgumentNullException(nameof(item));
            _uspevatoriyaDbContext.Entry(item).State = EntityState.Modified;
            if (AutoSaveChanges)
                _uspevatoriyaDbContext.SaveChanges();
        }

        /// <summary>
        /// Асинхронно обновляет элемент типа T в базе данных.
        /// </summary>
        /// <param name="item">Элемент типа T</param>
        public async Task UpdateAsync(T item, CancellationToken Cancel = default)
        {
            if (item is null) throw new ArgumentNullException(nameof(item));
            _uspevatoriyaDbContext.Entry(item).State = EntityState.Modified;
            if (AutoSaveChanges)
                await _uspevatoriyaDbContext.SaveChangesAsync(Cancel).ConfigureAwait(false);
        }

        /// <summary>
        /// Удаляет элемент типа T в базе данных.
        /// </summary>
        /// <param name="id">Элемент типа T, который нужно удалить</param>
        public void Remove(int id)
        {
            var item = Items.Where(i => i.ID == id).FirstOrDefault();

            _uspevatoriyaDbContext.Set<T>().Remove(item);

            if (AutoSaveChanges)
                _uspevatoriyaDbContext.SaveChanges();
        }

        /// <summary>
        /// Асинхронно удаялет элемент типа T в базе данных.
        /// </summary>
        /// <param name="id">Элемент типа T</param>
        public async Task RemoveAsync(int id, CancellationToken Cancel = default)
        {
            var item = Items.Where(i => i.ID == id).FirstOrDefault();
            _uspevatoriyaDbContext.Set<T>().Remove(item);
            if (AutoSaveChanges)
                await _uspevatoriyaDbContext.SaveChangesAsync(Cancel).ConfigureAwait(false);
        }
    }
}
