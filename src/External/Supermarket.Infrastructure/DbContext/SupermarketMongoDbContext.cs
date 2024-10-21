using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using MongoDB.Driver;
using Supermarket.Domain.Entities.Common;
using Supermarket.Domain.Entities.Identity;
using Supermarket.Domain.Entities.SupermarketEntities;
using Supermarket.Domain.Entities.Token;
using Attribute = Supermarket.Domain.Entities.SupermarketEntities.Attribute;

namespace Supermarket.Infrastructure.DbContext
{
    public class SupermarketMongoDbContext : IdentityDbContext<AppUser, IdentityRole<Guid>, Guid>
    {
        private readonly IMongoDatabase _database;

        public SupermarketMongoDbContext(IConfiguration configuration)
        {
            var client = new MongoClient(configuration.GetConnectionString("MongoDbConnection"));
            _database = client.GetDatabase(configuration["MongoDbName"]);
        }

        public IMongoCollection<Attribute> Attributes => _database.GetCollection<Attribute>("Attributes");
        public IMongoCollection<VariantValue> VariantValues => _database.GetCollection<VariantValue>("VariantValues");
        public IMongoCollection<Batch> Batches => _database.GetCollection<Batch>("Batches");
        public IMongoCollection<Category> Categories => _database.GetCollection<Category>("Categories");
        public IMongoCollection<Coupon> Coupons => _database.GetCollection<Coupon>("Coupons");
        public IMongoCollection<Customer> Customers => _database.GetCollection<Customer>("Customers");
        public IMongoCollection<Invoice> Invoices => _database.GetCollection<Invoice>("Invoices");
        public IMongoCollection<InvoiceDetail> InvoiceDetails => _database.GetCollection<InvoiceDetail>("InvoiceDetails");
        public IMongoCollection<MemberShipType> MemberShipTypes => _database.GetCollection<MemberShipType>("MemberShipTypes");
        public IMongoCollection<Product> Products => _database.GetCollection<Product>("Products");
        public IMongoCollection<StockIn> StockIns => _database.GetCollection<StockIn>("StockIns");
        public IMongoCollection<StockInDetail> StockInDetails => _database.GetCollection<StockInDetail>("StockInDetails");
        public IMongoCollection<Supplier> Suppliers => _database.GetCollection<Supplier>("Suppliers");
        public IMongoCollection<UnitConversion> UnitConversions => _database.GetCollection<UnitConversion>("UnitConversions");
        public IMongoCollection<Employee> Employees => _database.GetCollection<Employee>("Employees");
        public IMongoCollection<RefreshToken> RefreshTokens => _database.GetCollection<RefreshToken>("RefreshTokens");
        public IMongoCollection<Modification> Modifications => _database.GetCollection<Modification>("Modifications");
    }
}
