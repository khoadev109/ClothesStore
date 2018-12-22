using System;
using System.Linq;
using ClothesStore.Domain;
using System.Collections.Generic;

namespace ClothesStore
{
    public static class ServiceOperation
    {
        public static bool Existed<T>(this List<T> entities, Func<T, bool> predicate) where T : BaseObject
        {
            return entities.Any(predicate);
        }

        public static int Add<T>(this List<T> entities, T entity) where T : BaseObject
        {
            if (entity == null)
            {
                throw new Exception("Item not found");
            }

            var isExisted = entities.Any(x => x.Id == entity.Id);
            if (isExisted)
            {
                throw new Exception("Existed item");
            }

            var lastEntityId = entities.OrderBy(x => x.Id).LastOrDefault();

            entity.Id = lastEntityId != null ? lastEntityId.Id + 1 : 1;
            entities.Add(entity);

            return entities.LastOrDefault().Id;
        }

        public static List<T> Edit<T>(this List<T> entities, T entity, int id) where T : BaseObject
        {
            T currentEntity = entities.FirstOrDefault(x => x.Id == id);
            if (currentEntity == null)
            {
                throw new Exception("Item not found");
            }

            entities.Remove(currentEntity);
            entities.Add(entity);

            return entities.OrderBy(x => x.Id).ToList();
        }

        public static void Delete<T>(this List<T> entities, T entity) where T : BaseObject
        {
            T currentEntity = entities.FirstOrDefault(x => x.Id == entity.Id);
            if (currentEntity == null)
            {
                throw new Exception("Item not found");
            }

            entities.Remove(currentEntity);
        }

        public static T Get<T>(this List<T> entities, int id) where T : BaseObject
        {
            T entity = entities.FirstOrDefault(x => x.Id == id);
            return entity;
        }

        public static List<T> GetAll<T>(this List<T> entities) where T : BaseObject
        {
            return entities != null && entities.Count > 0 ? entities.OrderBy(x => x.Id).ToList() : new List<T>();
        }

        public static T GetFirst<T>(this List<T> entities) where T : BaseObject
        {
            return entities.GetAll().FirstOrDefault();
        }

        public static T GetLast<T>(this List<T> entities) where T : BaseObject
        {
            return entities.GetAll().LastOrDefault();
        }

        public static List<T> GetBy<T>(this List<T> entities, Func<T, bool> predicate) where T : BaseObject
        {
            return entities.Where(predicate).ToList();
        }
    }
}
