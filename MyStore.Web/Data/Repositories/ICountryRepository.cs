using Microsoft.AspNetCore.Mvc.Rendering;
using MyStore.Web.Data.Entities;
using MyStore.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyStore.Web.Data.Repositories
{
    public interface ICountryRepository : IGenericRepository<Country>
    {
		IQueryable GetCountriesWithCities(); //que me dê os paisses e cidades todos


		Task<Country> GetCountryWithCitiesAsync(int id); //dou-lhe um id e ele vai dar-me o pais a que corresponde


		Task<City> GetCityAsync(int id); //atrave´s dpo is dá-me a cidade


		Task AddCityAsync(CityViewModel model); //adicionar cidades novas


		Task<int> UpdateCityAsync(City city);


		Task<int> DeleteCityAsync(City city);

		IEnumerable<SelectListItem> GetComboCountries();


		IEnumerable<SelectListItem> GetComboCities(int conuntryId);

		Task<Country> GetCountryAsync(City city); //vai preencher combo ...ver
	}
}
