﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data;

namespace BLL
{
    /// <summary>
    /// This class provide all the methods for CRUD operations
    /// </summary>
    public class Operations
    {
        private SalesOnboardingEntities db;

        public Operations()
        {
            db = new SalesOnboardingEntities();
        }

        #region Product section

        /// <summary>
        /// Get list of products from product table
        /// </summary>
        /// <returns></returns>
        public List<BLL.Model.Product> GetAllProducts()
        {
            var result = MapProducts(db.Products.ToList());
            return result;
        }

        /// <summary>
        /// Get product details by ID
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>
        public BLL.Model.Product GetProduct(int? ID)
        {
            return MapProducts(db.Products.Where(row => row.ID == ID).FirstOrDefault());
        }

        /// <summary>
        /// Save data to product table 
        /// </summary>
        /// <param name="product"></param>
        /// <returns></returns>
        public bool UpdateProduct(Model.Product product)
        {
            var updateproduct = db.Products.Where(row => row.ID == product.Id).FirstOrDefault();

            if (updateproduct != null)
            {
                updateproduct.Name = product.Name;
                updateproduct.Price = (decimal)product.Price;
                db.Products.Attach(updateproduct);
                db.Entry(updateproduct).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return true;
            }
            else  return false;
        }

        /// <summary>
        /// Update existing product
        /// </summary>
        /// <param name="product"></param>
        /// <returns></returns>
        public bool SaveProduct(BLL.Model.Product product)
        {
            db.Products.Add(
                new Product()
                {
                    Name = product.Name,
                    Price = product.Price

                });
            db.SaveChanges();
            return true;
        }
        /// <summary>
        /// This method to map list of product object in DB Model class to BLL Model class
        /// </summary>
        /// <param name="productList"></param>
        /// <returns></returns>
        private List<BLL.Model.Product> MapProducts(List<Product> productList)
        {
            var output = new List<BLL.Model.Product>();
            foreach (var item in productList)
            {
               output.Add( MapProducts(item));
            }
            return output;
        }

        /// <summary>
        /// This method to map one product object in DB Model class to BLL Model class
        /// </summary>
        /// <param name="product"></param>
        /// <returns></returns>
        private Model.Product MapProducts(Product product)
        {
            var newProduct = new Model.Product()
            {
                Id = product.ID,
                Name = product.Name,
                Price = (decimal)product.Price

            };
            return newProduct;
        }

        #endregion Product


        #region Customer Section

        /// <summary>
        /// Get list of products from product table
        /// </summary>
        /// <returns></returns>
        public List<BLL.Model.Customer> GetAllCustomers()
        {
            var result = MapCustomers(db.Customers.ToList());
            return result;
        }

        /// <summary>
        /// Get customer details by ID
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>
        public BLL.Model.Customer GetCustomer(int? ID)
        {
            return MapCustomers(db.Customers.Where(row => row.ID == ID).FirstOrDefault());
        }

        /// <summary>
        /// Save data to customer table 
        /// </summary>
        /// <param name="customer"></param>
        /// <returns></returns>
        public bool SaveCustomer(Model.Customer customer)
        {
            db.Customers.Add(
                new Customer()
                {
                    Name = customer.Name,
                    Address = customer.Address

                });
            db.SaveChanges();
            return true;
        }

        /// <summary>
        ///update existing customer
        /// </summary>
        /// <param name="customer"></param>
        /// <returns></returns>
        public bool UpdateCustomer(Model.Customer customer)
        {
            var existCustomer= db.Customers.FirstOrDefault(r => r.ID == customer.ID);
            if (existCustomer != null)
            {
                existCustomer.Name = customer.Name;
                existCustomer.Address = customer.Address;
                db.Customers.Attach(existCustomer);
                db.Entry(existCustomer).State = System.Data.Entity.EntityState.Modified;
                
                db.SaveChanges();
                return true;
            }
            else return false;
        }
        /// <summary>
        /// This method to map list of customers of DB to Model.Customer on BLL
        /// </summary>
        /// <param name="customerList"></param>
        /// <returns></returns>
        private List<BLL.Model.Customer> MapCustomers(List<Customer> customerList)
        {
            var output = new List<BLL.Model.Customer>();
            foreach (var item in customerList)
            {
                output.Add(MapCustomers(item));
            }
            return output;
        }

        /// <summary>
        /// This method to map Data.Customer of DB to Model.Customer on BLL
        /// </summary>
        /// <param name="customer"></param>
        /// <returns></returns>
        private Model.Customer MapCustomers(Customer customer)
        {
            var newCustomer = new Model.Customer()
            {
                ID = customer.ID,
                Name = customer.Name,
                Address = customer.Address

            };
            return newCustomer;
        }

        #endregion customer section

        #region Store Section

        /// <summary>
        /// Get list of Stores from Store table
        /// </summary>
        /// <returns></returns>
        public List<BLL.Model.Store> GetAllStores()
        {
            var result = MapStores(db.Stores.ToList());
            return result;
        }

        /// <summary>
        /// Get Store details by ID
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>
        public BLL.Model.Store GetStore(int? ID)
        {
            return MapStores(db.Stores.Where(row => row.ID == ID).FirstOrDefault());
        }

        /// <summary>
        /// Save data to Store table 
        /// </summary>
        /// <param name="store"></param>
        /// <returns></returns>
        public bool SaveStore(BLL.Model.Store store)
        {
            db.Stores.Add(
                new Store()
                {
                    Name = store.Name,
                    Address = store.Address

                });
            db.SaveChanges();
            return true;
        }

        /// <summary>
        /// Update existing Store details
        /// </summary>
        /// <param name="store"></param>
        /// <returns></returns>
        public bool UpdateStore(BLL.Model.Store store)
        {
            var existingStore = db.Stores.FirstOrDefault(r => r.ID == store.Id);
            if (existingStore != null)
            {
                existingStore.Address = store.Address;
                existingStore.Name = store.Name;
                db.Stores.Attach(existingStore);
                db.Entry(existingStore).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();

                return true;
            }
            else return false;
           
        }
       
        /// <summary>
        /// This method to map list of Stores of DB to Model.Store on BLL
        /// </summary>
        /// <param name="storeList"></param>
        /// <returns></returns>
        private List<BLL.Model.Store> MapStores(List<Store> storeList)
        {
            var output = new List<BLL.Model.Store>();
            foreach (var item in storeList)
            {
                output.Add(MapStores(item));
            }
            return output;
        }

        /// <summary>
        /// This method to map Data.Customer of DB to Model.Customer on BLL
        /// </summary>
        /// <param name="customer"></param>
        /// <returns></returns>
        private BLL.Model.Store MapStores(Store store)
        {
            var newStore = new Model.Store()
            {
                Id = store.ID,
                Name = store.Name,
                Address = store.Address

            };
            return newStore;
        }

        #endregion Store section

        #region sales
        /// <summary>
        /// Get Total Sales by customer 
        /// </summary>
        /// <returns></returns>
        public List<BLL.Model.TotalSalesDTO> GetSalesData()
        {
            //var data= db.ProductSolds.GroupBy(r => r.CustomerID).Select(d=>new BLL.Model.TotalSalesDTO()
            //{
            //    customer=new Model.Customer()
            //    {
            //        ID = d.First().Customer.ID,
            //        Address=d.First().Customer.Address,
            //        Name=d.First().Customer.Name

            //    },
            //    Id=d.First().SalesID,
            //    product=new Model.Product()
            //    {
            //        Id=d.First().Product.ID,
            //        Name=d.First().Product.Name,
            //        Price=(decimal)d.First().Product.Price
            //    }


            //})

            var data = db.ProductSolds.GroupBy(r => r.StoreID).Select(d => new BLL.Model.TotalSalesDTO()
            {
                Id=d.FirstOrDefault().SalesID,
                ProductName=d.FirstOrDefault().Product.Name,
                StoreName=d.FirstOrDefault().Store.Name,
                TotalQty=d.Count()
            }).ToList();
            return data;
        }
        /// <summary>
        /// Save a sale
        /// </summary>
        /// <param name="sale"></param>
        /// <returns></returns>
        public bool AddSale(BLL.Model.SalesDTO sale)
        {
            db.ProductSolds.Add(new ProductSold()
            {
                CustomerID = sale.CustomerId,
                ProductID = sale.ProductId,
                StoreID = sale.StoreId,
                DateSold = DateTime.Now
            });
            db.SaveChanges();
            return true;
        }
        #endregion Sales 
    }
}
