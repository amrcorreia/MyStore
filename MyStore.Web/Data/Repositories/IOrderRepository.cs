using MyStore.Web.Data.Entities;
using MyStore.Web.Models;
using System.Linq;
using System.Threading.Tasks;

namespace MyStore.Web.Data.Repositories
{
    public interface IOrderRepository : IGenericRepository<Order>
    {
        Task<IQueryable<Order>> GetOrdersAsync(string userName);

        Task<IQueryable<OrderDetailsTemp>> GetDetailTempsAsync(string userName);

        Task AddItemToOrdemAsync(AddItemViewModel model, string userName);

        Task ModifyDetailTempQuantityAsync(int id, double quantity);

        Task DeleteDetailTempAsync(int id);

        Task DeleteOrderAsync(int id);

        Task<Order> ConfirmOrderAsync(string userName);

        Task DeliverOrderAsync(DeliverViewModel model);

        Task<Order> GetOrderAsync(int id);


        Task AddProductToOrderAsync(int productId, User user);


        Task AddProductToOrderTempAsync(int productId);
    }
}
