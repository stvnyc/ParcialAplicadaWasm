using Shared.Interfaces;
using Shared.Models;
using System.Net.Http;
using System.Net.Http.Json;

namespace ParcialAplicadaWasm.Client.Services;

public class ArticulosService(HttpClient httpClient) : IClientService<Articulos>
{
    public async Task<List<Articulos>> GetAllAsync()
    {
        var result = (await httpClient.GetAsync("api/articulos"))!;
        if (result.IsSuccessStatusCode)
        {
            return (await result.Content.ReadFromJsonAsync<List<Articulos>>())!;
        }
        return null!;
    }

    public async Task<Articulos> GetByIdAsync(int id)
    {
        var result = (await httpClient.GetAsync($"api/articulos/{id}"))!;
        if (result.IsSuccessStatusCode)
        {
            return (await result.Content.ReadFromJsonAsync<Articulos>())!;
        }
        return null!;
    }

    public async Task<Articulos> CreateAsync(Articulos articulos)
    {
        var result = await httpClient.PostAsJsonAsync("api/articulos", articulos);
        if (result.IsSuccessStatusCode)
        {
            return (await result.Content.ReadFromJsonAsync<Articulos>())!;
        }
        return null!;
    }

    public async Task<bool> UpdateAsync(int id, Articulos articulo)
    {
        var result = await httpClient.PutAsJsonAsync($"api/articulos/{id}", articulo);
        return result.IsSuccessStatusCode;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var result = await httpClient.DeleteAsync($"api/articulos/{id}");
        return result.IsSuccessStatusCode;
    }
}