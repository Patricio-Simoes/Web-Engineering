namespace TP_03.Models
{
    public class DocFiles
    {
        // IHostEnvironment vai buscar o caminho de diretoria do sistema até a raíz do projeto.
        public List<FileViewModel> GetFiles(IHostEnvironment e)
        {
            List<FileViewModel> list = new List<FileViewModel>();
            DirectoryInfo dirInfo = new DirectoryInfo(
                Path.Combine(e.ContentRootPath, "wwwroot/Documents")
                );
            foreach(var item in dirInfo.GetFiles())
            {
                list.Add(
                    new FileViewModel
                    {
                        Name = item.Name,
                        Size = item.Length
                    });
            }
            return list;
        }
    }
}
