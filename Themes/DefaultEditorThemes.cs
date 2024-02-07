namespace Minerals.Editor.Themes
{
    public class DefaultEditorThemes : IEditorThemes
    {
        public ThemePackage Active { get; private set; } = ThemePackage.Empty;
        public ThemePackage[] Available { get; private set; } = [];
        public ThemePackage[] Installed { get; private set; } = [];

        public event Action<ThemePackage, ThemePackage>? ThemeChanged;

        public async Task<ThemePackage[]> LoadAvailableThemesAsync(string indexUrl)
        {
            using HttpClient client = new();
            string[] packages = await GetPackagesFromUrlAsync(client, indexUrl);
            Available = await GetThemesFromUrlAsync(client, packages);
            return Available;
        }

        public async Task<ThemePackage[]> LoadInstalledThemesAsync(string indexUrl)
        {
            Installed = await LoadAvailableThemesAsync(indexUrl);
            return Installed;
        }

        public void SetActive(ThemePackage theme)
        {
            ThemePackage oldTheme = Active;
            Active = theme;
            ThemeChanged?.Invoke(oldTheme, theme);
        }

        public string GetStyleUrl(ThemePackage theme)
        {
            return theme.Url.Replace("Package.json", $"{theme.Id}.css");
        }

        private static async Task<string[]> GetPackagesFromUrlAsync(HttpClient client, string url)
        {
            return await client.GetFromJsonAsync<string[]>(url) ?? [];
        }

        private static async Task<ThemePackage[]> GetThemesFromUrlAsync(HttpClient client, string[] urls)
        {
            ThemePackage[] themes = new ThemePackage[urls.Length];
            for (int i = 0; i < urls.Length; i++)
            {
                ThemePackage? theme = await client.GetFromJsonAsync<ThemePackage>(urls[i]);
                themes[i] = theme != null ? theme with { Url = urls[i] } : ThemePackage.Empty;
            }
            return themes;
        }
    }
}
