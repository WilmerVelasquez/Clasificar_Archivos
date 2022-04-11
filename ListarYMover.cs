using System;
using System.Collections.Generic;
using System.IO;

namespace ClasificarArchivos
{
	public class ListarYMover
	{
		private string @path;
		public ListarYMover(string @path)
		{
			this.path = path;
		}
		public void ListarArchivo(string path)
		{
			DirectoryInfo src = new DirectoryInfo(@path);

			List<string> list = new List<string>(Directory.EnumerateFiles(@path));

			int archivos = list.Count;

			for (int i = 0; i < archivos; i++)
			{
				leerLinea(list[i]);
			}
		}
		public void leerLinea(string path)
		{
			// Leer el archivo y mostrarlo linea por linea   
			foreach (string line in File.ReadLines(@path))
			{
				Console.WriteLine(line);
			}
			Console.WriteLine();
		}
		public void MoverArchivo(string path)
		{

		}
	}
}
