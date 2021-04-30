using System.Collections.Generic;
using System.Linq;
using Lab.EF.ILogic;
using Lab.EF.Logic.Base;

namespace Lab.EF.Logic.Category
{
    public class CategoryLogic : BaseLogic, IBaseLogic<Entities.Category>
    {
        public void Add(Entities.Category newEntity)
        {
            Context.Categories.Add(newEntity);
            Context.SaveChanges();
        }

        public void Update(Entities.Category entity)
        {
            var category = Context.Categories.FirstOrDefault(c => c.CategoryID == entity.CategoryID);

            if (category != null)
            {
                category.CategoryName = entity.CategoryName;
                category.Description = entity.Description;
                category.Picture = entity.Picture;

                Context.SaveChanges();
            }
        }

        public void Delete(int id)
        {
            var category = Context.Categories.FirstOrDefault(c => c.CategoryID == id);

            if (category != null)
            {
                Context.Categories.Remove(category);
                Context.SaveChanges();
            }
        }

        public Entities.Category Get(int id)
        {
            var category = Context.Categories.FirstOrDefault(c => c.CategoryID == id);

            return category;
        }

        public IEnumerable<Entities.Category> GetAll()
        {
            var categories = Context.Categories.ToList();

            return categories;
        }
    }
}
