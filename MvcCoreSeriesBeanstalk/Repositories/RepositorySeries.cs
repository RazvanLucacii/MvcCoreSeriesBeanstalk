using Microsoft.EntityFrameworkCore;
using MvcCoreSeriesBeanstalk.Data;
using MvcCoreSeriesBeanstalk.Models;

namespace MvcCoreSeriesBeanstalk.Repositories
{
    public class RepositorySeries
    {
        private SeriesContext context;

        public RepositorySeries(SeriesContext context)
        {
            this.context = context;
        }

        public async Task<List<Serie>> GetSeriesAsync()
        {
            return await this.context.Series.ToListAsync();
        }

        public async Task<int> GetMaxIdSerie()
        {
            return await this.context.Series.MaxAsync(x => x.IdSerie) + 1;
        }

        public async Task InsertSerieAsync(string nombre, string imagen, int anyo)
        {
            Serie serie = new Serie
            {
                IdSerie = await this.GetMaxIdSerie(),
                Nombre = nombre,
                Imagen = imagen,
                Anyo = anyo
            };

            this.context.Series.Add(serie);
            await this.context.SaveChangesAsync();
        }
    }
}
