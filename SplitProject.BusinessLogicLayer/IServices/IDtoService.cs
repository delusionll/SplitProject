namespace SplitProject.BLL.IServices;

public interface IDtoService<TE, TD>
{
    TD ToDto(TE expense);

    TE ToEntity(TD expenseDto);
}