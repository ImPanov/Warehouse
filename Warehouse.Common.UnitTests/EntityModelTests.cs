
using Pckt.Shared;
using Warehouse.Web.Data;
namespace Warehouse.Common.UnitTests
{
    public class EntityModelTests
    {
        [Fact]
        public void WarehouseDatabaseConnectTest()
        {
            using (WarehouseContext db = new())
            {
                Assert.True(db.Database.CanConnect());
            }
        }
        [Fact]
        public void ItemsCountTest()
        {
            using (WarehouseContext db = new())
            {
                int expected = 0;
                int actual = db.Items.Count();
                Assert.Equal(expected, actual);
            }
        }
    }
}