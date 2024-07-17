namespace CustomerManager.Web.Interface
{
	public interface IRepositoryAsync<TModel> where TModel : class
	{
		Task<int> CreateAsync(TModel model);
		Task<int> UpdateAsync(TModel model);
		Task<int> DeleteAsync(int id);
		Task<TModel?> GetByIdAsync(object id);
		Task<IEnumerable<TModel>> GetAllAsync();
	}
}
