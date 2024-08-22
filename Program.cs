var caminhoArquivos = """ """;
var caminhoDestino  = """ """;

DirectoryInfo dir = new DirectoryInfo(caminhoArquivos);

var listaArquivo = dir.GetFiles("*.xml", SearchOption.AllDirectories);


if (listaArquivo.Length > 0)
{

	foreach (FileInfo arquivo in listaArquivo)
	{
		var novoNome = $"{arquivo.Name.Substring(0, 44)}{Path.GetExtension(arquivo.Name)}";

		Console.WriteLine($"{arquivo.FullName} | {novoNome}");

		try
		{
			File.Copy(arquivo.FullName, $"{caminhoDestino}\\{novoNome}", overwrite: true);
		}
		catch (Exception)
		{
			Console.WriteLine($"Erro ao renomear {arquivo.Name} para: {novoNome}");
		}
	}

	Console.WriteLine($"{listaArquivo.Length} renomeado(s)");
	Console.ReadKey();
}
else
{
	Console.WriteLine("Não foram encontrados arquivos par renomear");
    Console.ReadKey();
}


    

