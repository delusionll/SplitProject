using SplitProject.BLL.DTO;
using SplitProject.Domain.Models;

namespace SplitProject.BLL.IServices
{
    public interface IDtoService<E, D>
    {
        public E ToEntity(D expenseDto);
        public D ToDto(E expense);
    }
}
