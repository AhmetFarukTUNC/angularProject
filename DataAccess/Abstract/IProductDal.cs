using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Abstract
{
    //veri tabanı operasyonları için şablon
    public interface IProductDal:IEntityRepository<Product>
    {
        
    }
}
