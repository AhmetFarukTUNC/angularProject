using DataAccess.Abstract;
using Entities.Abstract;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfProductDal : IProductDal
    {
        public void Add(Product entity)

        {
            //IDisposible Pattern implementation
            using (NorthwindContext context = new NorthwindContext())
            {

                var addedEntity = context.Entry(entity); // gelen veriyi veri tabanındaki uygun veriyle eşleştirir.
                addedEntity.State = EntityState.Added; //veri tabanına ekler.
                context.SaveChanges();
            }
        }

        public void Delete(Product entity)
        {
            //IDisposible Pattern implementation
            using (NorthwindContext context = new NorthwindContext())
            {

                var deletedEntity = context.Entry(entity); // gelen veriyi veri tabanındaki uygun veriyle eşleştirir.
                deletedEntity.State = EntityState.Deleted; //veri tabandan ilgili veriyi siler.
                context.SaveChanges();
            }
        }

        public Product Get(Expression<Func<Product, bool>> filter)
        {
            //IDisposible Pattern implementation
            using (NorthwindContext context = new NorthwindContext())
            {

                return context.Set<Product>().SingleOrDefault(filter);
            }
        }

        public List<Product> GetAll(Expression<Func<Product, bool>> filter = null)
        {
            using (NorthwindContext context = new NorthwindContext())
            {
                return filter == null ? context.Set<Product>().ToList() : context.Set<Product>().Where(filter).ToList();
            }
        }

        public void Update(Product entity)
        {
            //IDisposible Pattern implementation
            using (NorthwindContext context = new NorthwindContext())
            {

                var updatedEntity = context.Entry(entity); // gelen veriyi veri tabanındaki uygun veriyle eşleştirir.
                updatedEntity.State = EntityState.Modified; //veri tabanın ilgili verisini günceller.
                context.SaveChanges();
            }
        }
    }
}
