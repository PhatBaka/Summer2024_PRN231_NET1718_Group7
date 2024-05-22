namespace PhotoboothBranchService.Domain.Common.Interfaces;

public interface IService<DTOModel>
{
    public Task<DTOModel> GetByIdAsync(Guid id);
    public Task<IEnumerable<DTOModel>> GetAllAsync();
    public Task<Guid> CreateAsync(DTOModel createModel);
    public Task UpdateAsync(Guid id, DTOModel updateModel);
    public Task DeleteAsync(Guid id);
}
public interface IServiceAlter<DTOModel>
{
    public Task<DTOModel> GetByIdAsync(Guid firstId, Guid secondId);
    public Task<IEnumerable<DTOModel>> GetAllAsync();
    public Task<Guid> CreateAsync(DTOModel createModel);
    public Task UpdateAsync(Guid firstId, Guid secondId, DTOModel updateModel);
    public Task DeleteAsync(Guid firstId, Guid secondId);
}