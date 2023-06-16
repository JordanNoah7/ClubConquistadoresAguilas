using Domain;
using Infrastructure.Context;
using Models;

namespace DataAccess.Repositories;

public class SpecialtyRepository: ContextRepository, IGenericRepository<Specialty>
{
    public SpecialtyRepository(ClubConquistadoresAguilasContext context) : base(context) { }

    public async Task<bool> Insert(Specialty model)
    {
        try
        {
            _dbContext.Specialties.Add(model);
            await _dbContext.SaveChangesAsync();
            return true;
        }
        catch (Exception ex)
        {
            return false;
        }
    }

    public async Task<bool> Update(Specialty model)
    {
        try
        {
            _dbContext.Specialties.Update(model);
            await _dbContext.SaveChangesAsync();
            return true;
        }
        catch (Exception ex)
        {
            return false;
        }
    }

    public async Task<bool> Delete(int id1, int id2 = 0)
    {
        try
        {
            Specialty model = _dbContext.Specialties.First(s => s.Id == id1);
            _dbContext.Specialties.Remove(model);
            await _dbContext.SaveChangesAsync();
            return true;
        }
        catch (Exception ex)
        {
            return false;
        }
    }

    public async Task<Specialty> Get(int id1, int id2 = 0)
    {
        try
        {
            return await _dbContext.Specialties.FindAsync(id1);
        }
        catch (Exception ex)
        {
            return null;
        }
    }

    public async Task<IQueryable<Specialty>> GetAll()
    {
        try
        {
            IQueryable<Specialty> querySpecialtiesSQL = _dbContext.Specialties;
            return querySpecialtiesSQL;
        }
        catch (Exception ex)
        {
            return null;
        }
    }
}