namespace SplitProject.BLL.Services;

using SplitProject.BLL.DTO;
using SplitProject.BLL.IServices;
using SplitProject.Domain.Models;

/// <summary>
/// BenefiterDTO.
/// </summary>
public class BenefiterDtoService : IDtoService<Benefiter, BenefiterDTO>
{
    /// <inheritdoc/>
    public Benefiter ToEntity(BenefiterDTO dto)
    {
        Benefiter benefiter = new()
        {
            Percent = dto.Percent,
            UserId = dto.ExpenseId,
            ExpenseId = dto.ExpenseId,
        };
        return benefiter;
    }

    /// <inheritdoc/>
    public BenefiterDTO ToDto(Benefiter entity)
    {
        return new BenefiterDTO(
            entity.ExpenseId,
            entity.Percent,
            entity.UserId);
    }
}