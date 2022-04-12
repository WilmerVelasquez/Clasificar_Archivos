using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace ClasificarArchivos
{
	public class ListarYMover
	{
		private string @path; //Ruta Directorio Principal donde se almacena los archivos para mover
		private string @pathComercial; //Rura directorio o carpeta comercial
		private string @pathProyectos;//Rura directorio o carpeta Proyectos
		private string @pathOtros;//Rura directorio o carpeta Otros
		private string linea; //almacena la primera linea para clasificar a que area de moverse
		private int i; 
		private int j = 0; //funciona como contador para fializar la lectura de archivo en la primera linea 
		string[] areas = new string[] { "Comercial", "Proyectos", "Otros" }; 
		bool comparar = false; //variabale para compara la linea con las areas disponibles 
		string pathArchivo; //alamacena el directorio de archivo
		string nombreArchivo; //almacena el nombre de archivo





		/*Metodo principal donde inicia el proceso para mover los archivos.
		 * se encarga de recibir las rutas de las carpetas donde estan los archivos y a donde se mueven,
		 * adicional recorre el directorio principal y lista los archivos a mover
		 */
		public void ListarMoverArchivo(string @path, string @pathComercial, string @pathProyectos, string pathOtros)
		{
			this.path = path;
			this.pathComercial = pathComercial;
			this.pathProyectos = pathProyectos;
			this.pathOtros = pathOtros;


			DirectoryInfo src = new DirectoryInfo(@path);
			try
			{
				foreach (var archivo in src.GetFiles("*.txt"))
				{
					j = 0;
					pathArchivo = archivo.DirectoryName;
					nombreArchivo = archivo.Name;
					StreamReader arc = new StreamReader(archivo.FullName);

					while ((linea = arc.ReadLine()) != null)
					{
						j++;
						if (j == 1) break;
					}

					Clasificar(linea);
					arc.Close();
					Mover(pathArchivo);
				}
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex.Message);
			}

		}
		//Metodo encargado de comparar la primer linea de texto con las areas disponibles.
		private void Clasificar(string linea)
		{
			this.linea = linea;
			for (int i = 0; i < areas.Length; i++)
			{
				comparar = linea.Contains(areas[i]);
				this.i = i;
				if (comparar == true || i > 2) break;

			}
		}

		//Metodo para mover los archivos a determinadas rutas de acuerdo a la clasificación del metodo anterior.
		private void Mover(string pathArchivo)
		{
			string sourceFile = Path.Combine(pathArchivo, nombreArchivo);
			try
			{

				if (comparar == true && i == 0)
				{
					string destinationFile = Path.Combine(pathComercial, nombreArchivo);
					if (File.Exists(sourceFile))
					{
						File.Move(sourceFile, destinationFile);

					}
				}
				else if (comparar == true && i == 1)
				{
					string destinationFile = Path.Combine(pathProyectos, nombreArchivo);
					if (File.Exists(sourceFile))
					{
						File.Move(sourceFile, destinationFile);

					}
				}
				else
				{
					string destinationFile = Path.Combine(pathOtros, nombreArchivo);
					if (File.Exists(sourceFile))
					{
						File.Move(sourceFile, destinationFile);

					}
				}
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex.ToString());
			}

		}
	}
}
