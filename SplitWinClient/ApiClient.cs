namespace SplitWinClient;

using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

public class ApiClient
{
    private readonly HttpClient _httpClient;
    private readonly ApiClientLogger _logger;

    public ApiClient()
    {
        _httpClient = new HttpClient();
        _logger = new ApiClientLogger();

        // TODO NO HARDCODE
        _httpClient.BaseAddress = new Uri("http://localhost:5125/");
    }

    public async Task<string> GetAsync(string url)
    {
        try
        {
            var response = await _httpClient.GetAsync(url);
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadAsStringAsync();
        }
        catch (HttpRequestException ex)
        {
            MessageBox.Show($"Ошибка: {ex.Message}", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            return null;
        }
    }

    public async Task<string> PostAsync(string url, string json)
    {
        try
        {
            var response = await _httpClient.PostAsync(url, new StringContent(json, Encoding.UTF8, "text/json"));
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadAsStringAsync();
        }
        catch (HttpRequestException ex)
        {
            MessageBox.Show($"Ошибка: {ex.Message}", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            return null;
        }
    }

    //public async Task<string> PutAsync(string url, string json)
    //{
    //    try
    //    {
    //        var content = new StringContent(json, Encoding.UTF8, "application/json");
    //        var response = await _httpClient.PutAsync(url, content);
    //        response.EnsureSuccessStatusCode();
    //        return await response.Content.ReadAsStringAsync();
    //    }
    //    catch (HttpRequestException ex)
    //    {
    //        MessageBox.Show($"Ошибка: {ex.Message}", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
    //        return null;
    //    }
    //}

    public async Task<string> DeleteAsync(string url)
    {
        try
        {
            var response = await _httpClient.DeleteAsync(url);
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadAsStringAsync();
        }
        catch (HttpRequestException ex)
        {
            MessageBox.Show($"Ошибка: {ex.Message}", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            return null;
        }
    }
}
