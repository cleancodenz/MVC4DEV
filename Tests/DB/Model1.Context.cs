//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Data.Objects;
using System.Data.EntityClient;

namespace Tests.DB
{
    public partial class NorthwindEntities : ObjectContext
    {
        public const string ConnectionString = "name=NorthwindEntities";
        public const string ContainerName = "NorthwindEntities";
    
        #region Constructors
    
        public NorthwindEntities()
            : base(ConnectionString, ContainerName)
        {
            this.ContextOptions.LazyLoadingEnabled = true;
        }
    
        public NorthwindEntities(string connectionString)
            : base(connectionString, ContainerName)
        {
            this.ContextOptions.LazyLoadingEnabled = true;
        }
    
        public NorthwindEntities(EntityConnection connection)
            : base(connection, ContainerName)
        {
            this.ContextOptions.LazyLoadingEnabled = true;
        }
    
        #endregion
    
        #region ObjectSet Properties
    
        public ObjectSet<Category> Categories
        {
            get { return _categories  ?? (_categories = CreateObjectSet<Category>("Categories")); }
        }
        private ObjectSet<Category> _categories;
    
        public ObjectSet<CustomerDemographic> CustomerDemographics
        {
            get { return _customerDemographics  ?? (_customerDemographics = CreateObjectSet<CustomerDemographic>("CustomerDemographics")); }
        }
        private ObjectSet<CustomerDemographic> _customerDemographics;
    
        public ObjectSet<Customer> Customers
        {
            get { return _customers  ?? (_customers = CreateObjectSet<Customer>("Customers")); }
        }
        private ObjectSet<Customer> _customers;
    
        public ObjectSet<Employee> Employees
        {
            get { return _employees  ?? (_employees = CreateObjectSet<Employee>("Employees")); }
        }
        private ObjectSet<Employee> _employees;
    
        public ObjectSet<Order_Detail> Order_Details
        {
            get { return _order_Details  ?? (_order_Details = CreateObjectSet<Order_Detail>("Order_Details")); }
        }
        private ObjectSet<Order_Detail> _order_Details;
    
        public ObjectSet<Order> Orders
        {
            get { return _orders  ?? (_orders = CreateObjectSet<Order>("Orders")); }
        }
        private ObjectSet<Order> _orders;
    
        public ObjectSet<Product> Products
        {
            get { return _products  ?? (_products = CreateObjectSet<Product>("Products")); }
        }
        private ObjectSet<Product> _products;
    
        public ObjectSet<Region> Regions
        {
            get { return _regions  ?? (_regions = CreateObjectSet<Region>("Regions")); }
        }
        private ObjectSet<Region> _regions;
    
        public ObjectSet<Shipper> Shippers
        {
            get { return _shippers  ?? (_shippers = CreateObjectSet<Shipper>("Shippers")); }
        }
        private ObjectSet<Shipper> _shippers;
    
        public ObjectSet<Supplier> Suppliers
        {
            get { return _suppliers  ?? (_suppliers = CreateObjectSet<Supplier>("Suppliers")); }
        }
        private ObjectSet<Supplier> _suppliers;
    
        public ObjectSet<Territory> Territories
        {
            get { return _territories  ?? (_territories = CreateObjectSet<Territory>("Territories")); }
        }
        private ObjectSet<Territory> _territories;
    
        public ObjectSet<UserProfile> UserProfiles
        {
            get { return _userProfiles  ?? (_userProfiles = CreateObjectSet<UserProfile>("UserProfiles")); }
        }
        private ObjectSet<UserProfile> _userProfiles;
    
        public ObjectSet<webpages_Membership> webpages_Membership
        {
            get { return _webpages_Membership  ?? (_webpages_Membership = CreateObjectSet<webpages_Membership>("webpages_Membership")); }
        }
        private ObjectSet<webpages_Membership> _webpages_Membership;
    
        public ObjectSet<webpages_OAuthMembership> webpages_OAuthMembership
        {
            get { return _webpages_OAuthMembership  ?? (_webpages_OAuthMembership = CreateObjectSet<webpages_OAuthMembership>("webpages_OAuthMembership")); }
        }
        private ObjectSet<webpages_OAuthMembership> _webpages_OAuthMembership;
    
        public ObjectSet<webpages_Roles> webpages_Roles
        {
            get { return _webpages_Roles  ?? (_webpages_Roles = CreateObjectSet<webpages_Roles>("webpages_Roles")); }
        }
        private ObjectSet<webpages_Roles> _webpages_Roles;

        #endregion
    }
}
