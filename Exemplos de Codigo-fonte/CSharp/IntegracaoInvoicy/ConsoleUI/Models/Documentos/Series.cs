namespace ConsoleUI.Models.Documentos
{
    public class Series
    {
        public string CNPJEmissor { get; set; }
        public string ModeloDocumento { get; set; }
        public string Serie { get; set; }
        public int? UltimoNumero { get; set; }
        public string SerieProduto { get; set; }

        //public Series(string cnpjEmissor)
        //{
        //    this.CNPJEmissor = cnpjEmissor;
        //}


        public string GetLink()
        {
            string url = "https://apibrhomolog.invoicy.com.br/companies/series";

            if (CNPJEmissor != null)
            {
                url = $"{url}?CNPJEmissor={CNPJEmissor}";
            }
            if (ModeloDocumento != null)
            {
                url = $"{url}&ModeloDocumento={ModeloDocumento}";
            }
            if (Serie != null)
            {
                url = $"{url}&Serie={Serie}";
            }
            if (UltimoNumero != null)
            {
                url = $"{url}&UltimoNumero={UltimoNumero}";
            }
            if (SerieProduto != null)
            {
                url = $"{url}&SerieProduto={SerieProduto}";
            }
            return url;
        }
    }

}
