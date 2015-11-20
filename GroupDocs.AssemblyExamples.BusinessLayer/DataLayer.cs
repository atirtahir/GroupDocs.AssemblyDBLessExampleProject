﻿using GroupDocs.AssemblyExamples.ProjectEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GroupDocs.AssemblyExamples.BusinessLayer
{
    public static class DataLayer
    {

        #region DataInitialization

        /// <summary>
        /// This function initialize/populate the data. 
        /// It initialize Customer information, product information and order information
        /// </summary>
        /// <returns></returns>
        public static IEnumerable<Entities.Customer> PopulateData()
        {

            Entities.Customer customer = new Entities.Customer { CustomerName = "Atir Tahir", CustomerContactNumber = "+921874", ShippingAddress = "Flat # 1, Kiyani Plaza ISB" };
            customer.Order = new Entities.Order[]
            {
                  new Entities.Order { Product = new Entities.Product { ProductName ="Lumia 525" }, Customer = customer, Price= 170, ProductQuantity = 5, OrderDate = new DateTime(2015, 1, 1) }

            };
            yield return customer; //yield return statement will return one data at a time


            customer = new Entities.Customer { CustomerName = "Usman Aziz", CustomerContactNumber = "+458789", ShippingAddress = "Quette House, Park Road, ISB" };
            customer.Order = new Entities.Order[]
            {
                  new Entities.Order { Product = new Entities.Product { ProductName = "Lenovo G50" }, Customer = customer, Price = 480, ProductQuantity = 2, OrderDate = new DateTime(2015, 2, 1) },
                  new Entities.Order { Product = new Entities.Product { ProductName = "Pavilion G6"}, Customer = customer, Price = 400, ProductQuantity = 1, OrderDate = new DateTime(2015, 10, 1) },
                  new Entities.Order { Product = new Entities.Product { ProductName = "Nexus 5"}, Customer = customer, Price = 320, ProductQuantity = 3, OrderDate = new DateTime(2015, 6, 1) }
            };
            yield return customer; //yield return statement will return one data at a time 
        }

        #endregion

        #region GetOrders

        /// <summary>
        /// Returns orders information/data
        /// </summary>
        /// <returns></returns>

        public static IEnumerable<Entities.Order> OrdersData()
        {
            foreach (Entities.Customer customer in PopulateData())
            {
                foreach (Entities.Order order in customer.Order)
                    yield return order; //yield return statement returns one data at a time
            }
        }

        #endregion

        #region GetProducts

        /// <summary>
        /// Returns product information/data
        /// </summary>
        /// <returns></returns>
        public static IEnumerable<Entities.Product> ProductsData()
        {
            foreach (Entities.Customer customer in PopulateData())
            {
                foreach (Entities.Order order in customer.Order)
                    yield return order.Product;
            }
        }

        #endregion

        #region GetSingleCustomer

        /// <summary>
        /// Returns single customer's information/data. Usually the first customer.
        /// </summary>
        /// <returns></returns>

        public static Entities.Customer CustomerData()
        {
            IEnumerator<Entities.Customer> customer = PopulateData().GetEnumerator();
            customer.MoveNext();

            return customer.Current;
        }

        #endregion
    }
}
