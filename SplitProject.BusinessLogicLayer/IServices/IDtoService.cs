namespace SplitProject.BLL.IServices
	{
	public interface IDtoService<E, D>
		{
		E ToEntity(D expenseDto);
		D ToDto(E expense);
		}
	}
