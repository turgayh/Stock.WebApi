using Stock.Operation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Stock.Operation.ProductServices
{
    public interface IProductService
    {
        public List<Product> Get();
        public Product Get(string id);
        public Product Create(Product val);
        public void Update(string id, Product productIn);
        public void Remove(Product productIn);
        public void Remove(string id);

    }
}
