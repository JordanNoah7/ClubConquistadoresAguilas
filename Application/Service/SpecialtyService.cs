﻿using Application.IService;
using Domain;
using Models;

namespace Application.Service;

public class SpecialtyService : ISpecialtyService
{
    private readonly ISpecialtyRepository _specialtyRepository;

    public SpecialtyService(ISpecialtyRepository specialtyRepository)
    {
        _specialtyRepository = specialtyRepository;
    }

    public async Task<IEnumerable<Specialty>> GetSpecialties(int id)
    {
        try
        {
            return await _specialtyRepository.GetSpecialties(id);
        }
        catch (Exception ex)
        {
            return null;
        }
    }

    public async Task<bool> InsertNote(Specialty model)
    {
        try
        {
            return await _specialtyRepository.InsertNote(model);
        }
        catch (Exception e)
        {
            return false;
        }
    }
}