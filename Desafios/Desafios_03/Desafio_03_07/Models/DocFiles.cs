namespace Desafio_03_07.Models
{
    public class DocFiles
    {
        public List<Document> GetFiles(IHostEnvironment e)
        {
            List<Document> list = new List<Document>();
            DirectoryInfo dirInfo = new DirectoryInfo(
                Path.Combine(e.ContentRootPath, "wwwroot/Documents")
                );
            foreach (var item in dirInfo.GetFiles())
            {
                list.Add(
                    new Document
                    {
                        name = item.Name
                    });
            }
            return list;
        }
    }
}
