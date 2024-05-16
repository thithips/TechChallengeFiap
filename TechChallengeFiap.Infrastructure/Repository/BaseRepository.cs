﻿using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using TechChallengeFiap.Domain.Entities;
using TechChallengeFiap.Domain.Interfaces;
using TechChallengeFiap.Infrastructure.Contexto;

namespace TechChallengeFiap.Infrastructure.Repository
{
    public class BaseRepository<T> : IBaseRepository<T> where T : BaseEntity
    {
        protected readonly ApplicationDbContexto _context;

        public BaseRepository(ApplicationDbContexto context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task Alterar(T entity)
        {
            _context.Set<T>().Update(entity);
            await _context.SaveChangesAsync();
        }

        public async Task<T> Buscar(Expression<Func<T, bool>> predicate)
        {
            return await _context.Set<T>().FirstOrDefaultAsync(predicate);
        }

        public async Task<List<T>> BuscarVarios(Expression<Func<T, bool>> predicate)
        {
            return await _context.Set<T>().Where(predicate).ToListAsync();
        }

        public async Task Incluir(T entity)
        {
            await _context.Set<T>().AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task Remover(T entity)
        {
            _context.Remove(entity);
            await _context.SaveChangesAsync();
        }

        public async Task<T> SelecionarPorId(Guid id)
        {
            return await _context.Set<T>().FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<List<T>> SelecionarTudo()
        {
            return await _context.Set<T>().ToListAsync();
        }
    }
}
