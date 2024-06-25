namespace JewelryShop.BusinessLayer;

public interface IService<ResponseModel, CreateModel, UpdateModel, FilterModel>
{
    public Task<ResponseModel> GetByIdAsync(Guid id);
    public Task<IEnumerable<ResponseModel>> GetAllAsync();
    public Task<Guid> CreateAsync(CreateModel createModel);
    public Task UpdateAsync(Guid id, UpdateModel updateModel);
    public Task DeleteAsync(Guid id);
}
public interface IServiceAlter<ResponseModel, CreateModel, UpdateModel, FilterModel>
{
    public Task<ResponseModel> GetByIdAsync(Guid firstId, Guid secondId);
    public Task<IEnumerable<ResponseModel>> GetAllAsync();
    public Task<Guid> CreateAsync(CreateModel createModel);
    public Task UpdateAsync(Guid firstId, Guid secondId, UpdateModel updateModel);
    public Task DeleteAsync(Guid firstId, Guid secondId);
}