using CarDealerWebProject.Core.Models.Admin;

namespace CarDealerWebProject.Core.Contracts
{
    public interface ISellerService
    {
        Task CreateSellerAsync(CreateSellerFormModel model);

        Task<bool> ExistsByEmailAsync(string userEmail);

        Task<bool> ExistsByIdAsync(Guid userId);

        Task<Guid> GetSellerIdAsync(Guid userId);

        Task<SellerServiceModel?> GetSellerServiceModelByIdAsync(Guid userId);

        Task<IEnumerable<SellerServiceModel>> AllSellersAsync();

        Task EditSellerAsync(Guid userId, SellerServiceModel model);

        Task DeleteSellerAsync(Guid userId);
    }
}
